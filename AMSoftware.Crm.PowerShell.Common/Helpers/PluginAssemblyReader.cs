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
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Common.Helpers
{
    internal sealed class PluginAssemblyReader : MarshalByRefObject
    {
        public PluginAssemblyInfo RetrievePluginAssemblyInfo(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }
            if (!File.Exists(path))
            {
                throw new ArgumentException("Path does not point to an existing file");
            }

            Assembly assembly = this.LoadAssembly(path);
            AssemblyName name = assembly.GetName();

            PluginAssemblyInfo pluginAssembly = this.RetrieveAssemblyProperties(assembly, path);

            Type[] exportedTypes = assembly.GetExportedTypes();
            foreach (Type exportedType in exportedTypes)
            {
                if (!exportedType.IsAbstract && exportedType.IsClass)
                {
                    Type xrmPluginInterface = exportedType.GetInterface(typeof(IPlugin).FullName);
                    Type crmPluginInterface = exportedType.GetInterface("Microsoft.Crm.Sdk.IPlugin");

                    Version version = null;
                    CrmPluginType crmPluginType;
                    bool? isolatable;

                    if (xrmPluginInterface != null)
                    {
                        crmPluginType = CrmPluginType.Plugin;
                        isolatable = true;
                        version = xrmPluginInterface.Assembly.GetName().Version;
                    }
                    else if (crmPluginInterface != null)
                    {
                        crmPluginType = CrmPluginType.Plugin;
                        isolatable = false;
                        version = new Version(4, 0);
                    }
                    else if (exportedType.IsSubclassOf(typeof(System.Activities.Activity)))
                    {
                        crmPluginType = CrmPluginType.WorkflowActivity;
                        isolatable = true;
                    }
                    else
                    {
                        continue;
                    }

                    if (version != null)
                    {
                        pluginAssembly.SdkVersion = new Version(version.Major, version.Minor);
                    }

                    PluginTypeInfo pluginType = new PluginTypeInfo
                    {
                        PluginId = Guid.Empty,
                        Name = exportedType.FullName,
                        TypeName = exportedType.FullName,
                        PluginType = crmPluginType,
                        AssemblyId = pluginAssembly.AssemblyId,
                        Isolatable = isolatable
                    };
                    if (crmPluginType == CrmPluginType.WorkflowActivity)
                    {
                        pluginType.WorkflowActivityGroupName = PluginManagementHelper.GenerateDefaultGroupName(name.Name, name.Version);
                    }
                    pluginAssembly.Plugins.Add(pluginType);
                }
            }
            return pluginAssembly;
        }

        private Assembly LoadAssembly(string path)
        {
            return Assembly.LoadFrom(path);
        }

        private PluginAssemblyInfo RetrieveAssemblyProperties(Assembly assembly, string path)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException("assembly");
            }

            FileInfo fileInfo = new FileInfo(path);
            AssemblyName name = assembly.GetName();

            PluginAssemblyInfo pluginAssembly = new PluginAssemblyInfo(path)
            {
                AssemblyId = Guid.Empty,
                SourceType = CrmAssemblySourceType.Database,
                IsolationMode = CrmAssemblyIsolationMode.Sandbox,
                ServerFileName = fileInfo.Name,
                Name = name.Name,
                Version = name.Version.ToString()
            };

            if (name.CultureInfo.LCID == CultureInfo.InvariantCulture.LCID)
            {
                pluginAssembly.Culture = "neutral";
            }
            else
            {
                pluginAssembly.Culture = name.CultureInfo.Name;
            }

            byte[] publicKeyToken = name.GetPublicKeyToken();
            if (publicKeyToken == null || publicKeyToken.Length == 0)
            {
                pluginAssembly.PublicKeyToken = null;
            }
            else
            {
                pluginAssembly.PublicKeyToken = string.Join(string.Empty, publicKeyToken.Select(b => b.ToString("X2")));
            }
            return pluginAssembly;
        }
    }
}
