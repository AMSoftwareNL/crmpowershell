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
using System.Linq;
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace AMSoftware.Crm.PowerShell.Commands.Plugins
{
    public abstract class UnregisterPluginCommandBase : CrmOrganizationConfirmActionCmdlet
    {
        protected enum PluginComponentType
        {
            PluginAssembly = 0,
            ServiceEndpoint,
            PluginType,
            PluginStepSecureConfig,
            PluginStep,
            PluginImage
        }

        private ContentRepository _repository = new ContentRepository();
        private Dictionary<PluginComponentType, List<Guid>> _components = new Dictionary<PluginComponentType, List<Guid>>();

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Guid Id { get; set; }

        protected abstract PluginComponentType ComponentType { get; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            foreach (PluginComponentType componentType in Enum.GetValues(typeof(PluginComponentType)))
            {
                _components.Add(componentType, new List<Guid>());
            }
        }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            _components[ComponentType].Add(Id);

            //Add child components to list
            _components[PluginComponentType.PluginType].AddRange(RetrieveReferencedIds(_repository, "plugintype", "plugintypeid", "pluginassemblyid", _components[PluginComponentType.PluginAssembly]));
            _components[PluginComponentType.PluginStep].AddRange(RetrieveReferencedIds(_repository, "sdkmessageprocessingstep", "sdkmessageprocessingstepid", "plugintypeid", _components[PluginComponentType.PluginType]));
            _components[PluginComponentType.PluginStep].AddRange(RetrieveReferencedIds(_repository, "sdkmessageprocessingstep", "sdkmessageprocessingstepid", "eventhandler", _components[PluginComponentType.ServiceEndpoint]));
            _components[PluginComponentType.PluginStepSecureConfig].AddRange(RetrieveReferencedIds(_repository, "sdkmessageprocessingstep", "sdkmessageprocessingstepsecureconfigid", "sdkmessageprocessingstepid", _components[PluginComponentType.PluginStep]));
            _components[PluginComponentType.PluginImage].AddRange(RetrieveReferencedIds(_repository, "sdkmessageprocessingstepimage", "sdkmessageprocessingstepimageid", "sdkmessageprocessingstepid", _components[PluginComponentType.PluginStep]));

            //Remove components in list
            UnregisterComponents("sdkmessageprocessingstepimage", _components[PluginComponentType.PluginImage]);
            UnregisterComponents("sdkmessageprocessingstep", _components[PluginComponentType.PluginStep]);
            UnregisterComponents("sdkmessageprocessingstepsecureconfig", _components[PluginComponentType.PluginStepSecureConfig]);
            UnregisterComponents("plugintype", _components[PluginComponentType.PluginType]);
            UnregisterComponents("pluginassembly", _components[PluginComponentType.PluginAssembly]);
            UnregisterComponents("serviceendpoint", _components[PluginComponentType.ServiceEndpoint]);
        }

        private void UnregisterComponents(string logicalName, IEnumerable<Guid> ids)
        {
            foreach (var id in ids)
            {
                ExecuteAction(string.Format("{0}: {1}", logicalName, id), "Unregister", delegate
                {
                    _repository.Delete(logicalName, id);
                });
            }
        }

        private static IEnumerable<Guid> RetrieveReferencedIds(ContentRepository repository, string entityName, string retrieveAttribute, string filterAttribute, IList<Guid> filterIdList)
        {
            if (filterIdList.Count == 0)
            {
                return new List<Guid>();
            }

            QueryExpression query = new QueryExpression(entityName)
            {
                ColumnSet = new ColumnSet(new string[] { retrieveAttribute })
            };

            ConditionExpression condition = new ConditionExpression(filterAttribute, ConditionOperator.In);
            condition.Values.Clear();
            condition.Values.AddRange(filterIdList.Cast<object>().AsEnumerable());
            query.Criteria.AddCondition(condition);

            List<Guid> list = new List<Guid>();
            foreach (Entity component in repository.Get(query))
            {
                if (component.Attributes.TryGetValue(retrieveAttribute, out object referencedAttributeValue))
                {
                    Type type = referencedAttributeValue.GetType();
                    if (type == typeof(Guid))
                    {
                        list.Add((Guid)referencedAttributeValue);
                    }
                    else
                    {
                        if (type == typeof(EntityReference))
                        {
                            list.Add(((EntityReference)referencedAttributeValue).Id);
                        }
                    }
                }
            }
            return list;
        }
    }

    [Cmdlet(VerbsLifecycle.Unregister, "CrmPluginAssembly", HelpUri = HelpUrlConstants.UnregisterPluginAssemblyHelpUrl)]
    public sealed class UnregisterPluginAssemblyCommand : UnregisterPluginCommandBase
    {
        protected override PluginComponentType ComponentType
        {
            get { return PluginComponentType.PluginAssembly; }
        }
    }

    [Cmdlet(VerbsLifecycle.Unregister, "CrmServiceEndpoint", HelpUri = HelpUrlConstants.UnregisterServiceEndpointHelpUrl)]
    public sealed class UnregisterServiceEndpointCommand : UnregisterPluginCommandBase
    {
        protected override PluginComponentType ComponentType
        {
            get { return PluginComponentType.ServiceEndpoint; }
        }
    }

    [Cmdlet(VerbsLifecycle.Unregister, "CrmPlugin", HelpUri = HelpUrlConstants.UnregisterPluginHelpUrl)]
    public sealed class UnregisterPluginCommand : UnregisterPluginCommandBase
    {
        protected override PluginComponentType ComponentType
        {
            get { return PluginComponentType.PluginType; }
        }
    }

    [Cmdlet(VerbsLifecycle.Unregister, "CrmPluginStep", HelpUri = HelpUrlConstants.UnregisterPluginStepHelpUrl)]
    public sealed class UnregisterPluginStepCommand : UnregisterPluginCommandBase
    {
        protected override PluginComponentType ComponentType
        {
            get { return PluginComponentType.PluginStep; }
        }
    }

    [Cmdlet(VerbsLifecycle.Unregister, "CrmPluginStepImage", HelpUri = HelpUrlConstants.UnregisterPluginStepImageHelpUrl)]
    public sealed class UnregisterPluginStepImageCommand : UnregisterPluginCommandBase
    {
        protected override PluginComponentType ComponentType
        {
            get { return PluginComponentType.PluginImage; }
        }
    }
}
