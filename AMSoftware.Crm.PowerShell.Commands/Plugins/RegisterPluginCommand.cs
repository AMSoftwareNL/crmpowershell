/*
CRM PowerShell Library
Copyright (C) 2017 Arjan Meskers / AMSoftware

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published
by the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Helpers;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands.Plugins
{
    [Cmdlet(VerbsLifecycle.Register, "CrmPlugin", HelpUri = HelpUrlConstants.RegisterPluginHelpUrl, DefaultParameterSetName = RegisterPluginFromPathParameterSet)]
    [OutputType(typeof(Entity))]
    public sealed class RegisterPluginCommand : CrmOrganizationCmdlet
    {
        private const string RegisterPluginFromLiteralPathParameterSet = "RegisterPluginFromLiteralPath";
        private const string RegisterPluginFromPathParameterSet = "RegisterPluginFromPath";

        private ContentRepository _repository = new ContentRepository();
        private string[] _paths;
        private bool _shouldExpandWildcards;

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = RegisterPluginFromLiteralPathParameterSet, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [Alias("PSPath")]
        [ValidateNotNullOrEmpty]
        public string[] LiteralPath
        {
            get { return _paths; }
            set { _paths = value; }
        }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = RegisterPluginFromPathParameterSet, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string[] Path
        {
            get { return _paths; }
            set
            {
                _shouldExpandWildcards = true;
                _paths = value;
            }
        }

        [Parameter]
        [ValidateNotNull]
        public CrmAssemblyIsolationMode? IsolationMode { get; set; }

        [Parameter]
        [ValidateNotNull]
        public CrmAssemblySourceType? AssemblyLocation { get; set; }

        [Parameter]
        [ValidateNotNull]
        public string Description { get; set; }

        [Parameter]
        public SwitchParameter Force { get; set; }

        [Parameter(ValueFromRemainingArguments = true)]
        [ValidateNotNull, ValidateLength(1, int.MaxValue)]
        public string[] Plugins { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            foreach (string fullPath in ResolvePaths(_paths, _shouldExpandWildcards))
            {
                RegisterPluginAssembly(fullPath);
            }
        }

        private void RegisterPluginAssembly(string path)
        {
            PluginAssemblyInfo assemblyInfo = PluginManagementHelper.RetrievePluginAssemblyInfo(path);
            PluginManagementHelper.RefreshFromExistingAssembly(_repository, assemblyInfo);

            assemblyInfo.SourceType = AssemblyLocation ?? CrmAssemblySourceType.Database;
            assemblyInfo.IsolationMode = IsolationMode ?? CrmAssemblyIsolationMode.Sandbox;
            if (Description != null)
            {
                assemblyInfo.Description = Description;
            }
            if (assemblyInfo.AssemblyId != Guid.Empty && Force.ToBool() != true)
            {
                throw new Exception(string.Format("Assembly '{0}' is already registered. Use Force to overwrite the assembly.", assemblyInfo.Name));
            }

            List<PluginTypeInfo> pluginsToRegister = GetPluginsToRegister(assemblyInfo);
            if (pluginsToRegister.Count == 0)
            {
                throw new Exception("No Plugins for registration.");
            }
            if (assemblyInfo.IsolationMode == CrmAssemblyIsolationMode.Sandbox && pluginsToRegister.Any(p => p.Isolatable != true))
            {
                throw new Exception("Since some of the plug-ins cannot be isolated, the assembly cannot be marked as Isolated.");
            }
            if (string.IsNullOrWhiteSpace(assemblyInfo.PublicKeyToken) && pluginsToRegister.Any(p => p.PluginType == CrmPluginType.Plugin))
            {
                throw new Exception("Assemblies containing Plugins must be strongly signed. Sign the Assembly using a KeyFile.");
            }

            Entity pluginAssemblyEntity = GenerateCrmEntity(assemblyInfo);
            Guid assemblyId = pluginAssemblyEntity.Id;
            if (assemblyId == Guid.Empty)
            {
                assemblyId = _repository.Add(pluginAssemblyEntity);
            }
            else
            {
                _repository.Update(pluginAssemblyEntity);
            }

            foreach (PluginTypeInfo plugin in pluginsToRegister)
            {
                Entity pluginTypeEntity = GenerateCrmEntity(assemblyId, plugin);
                Guid pluginTypeId = pluginTypeEntity.Id;
                if (pluginTypeEntity.Id == Guid.Empty)
                {
                    pluginTypeId = _repository.Add(pluginTypeEntity);
                }
                else
                {
                    _repository.Update(pluginTypeEntity);
                }

                if (PassThru)
                {
                    WriteObject(_repository.Get("plugintype", pluginTypeId));
                }
            }
        }

        private List<PluginTypeInfo> GetPluginsToRegister(PluginAssemblyInfo assemblyInfo)
        {
            List<PluginTypeInfo> pluginsToRegister = new List<PluginTypeInfo>();
            if (Plugins == null || Plugins.Length == 0)
            {
                pluginsToRegister.AddRange(assemblyInfo.Plugins);
            }
            else
            {
                foreach (string pluginName in Plugins)
                {
                    PluginTypeInfo tempPluginType = assemblyInfo.Plugins.SingleOrDefault(p => p.TypeName.Equals(pluginName, StringComparison.InvariantCultureIgnoreCase) || p.PluginId != Guid.Empty);
                    if (tempPluginType == null)
                    {
                        throw new Exception(string.Format("No Plugin named '{0}' found in assembly '{1}'.", pluginName, assemblyInfo.Name));
                    }
                    else
                    {
                        pluginsToRegister.Add(tempPluginType);
                    }
                }
            }

            return pluginsToRegister;
        }

        private Entity GenerateCrmEntity(PluginAssemblyInfo assemblyInfo)
        {
            Entity crmPluginAssembly = new Entity("pluginassembly")
            {
                Id = assemblyInfo.AssemblyId,
                Attributes = new AttributeCollection()
            };
            crmPluginAssembly.Attributes.Add("sourcetype", new OptionSetValue((int)assemblyInfo.SourceType));
            crmPluginAssembly.Attributes.Add("isolationmode", new OptionSetValue((int)assemblyInfo.IsolationMode));
            crmPluginAssembly.Attributes.Add("culture", assemblyInfo.Culture);
            crmPluginAssembly.Attributes.Add("publickeytoken", assemblyInfo.PublicKeyToken);
            crmPluginAssembly.Attributes.Add("version", assemblyInfo.Version);
            crmPluginAssembly.Attributes.Add("name", assemblyInfo.Name);
            if (assemblyInfo.Description != null)
            {
                crmPluginAssembly.Attributes.Add("description", assemblyInfo.Description);
            }

            switch (assemblyInfo.SourceType)
            {
                case CrmAssemblySourceType.Database:
                    crmPluginAssembly.Attributes.Add("content", Convert.ToBase64String(File.ReadAllBytes(assemblyInfo.LiteralPath)));
                    break;
                case CrmAssemblySourceType.GAC:
                    break;
                case CrmAssemblySourceType.Disk:
                    crmPluginAssembly.Attributes.Add("path", assemblyInfo.ServerFileName);
                    break;
                default:
                    throw new NotImplementedException("SourceType = " + assemblyInfo.SourceType.ToString());
            }
            
            return crmPluginAssembly;
        }

        private Entity GenerateCrmEntity(Guid assemblyId, PluginTypeInfo pluginTypeInfo)
        {
            Entity crmPluginType = new Entity("plugintype")
            {
                Id = pluginTypeInfo.PluginId,
                Attributes = new AttributeCollection()
            };
            crmPluginType.Attributes.Add("pluginassemblyid", new EntityReference("pluginassembly", assemblyId));
            crmPluginType.Attributes.Add("typename", pluginTypeInfo.TypeName);
            crmPluginType.Attributes.Add("friendlyname", pluginTypeInfo.TypeName);
            crmPluginType.Attributes.Add("name", pluginTypeInfo.Name);
            if (pluginTypeInfo.PluginType == CrmPluginType.WorkflowActivity)
            {
                crmPluginType.Attributes.Add("workflowactivitygroupname", pluginTypeInfo.WorkflowActivityGroupName);
            }

            return crmPluginType;
        }
    }
}
