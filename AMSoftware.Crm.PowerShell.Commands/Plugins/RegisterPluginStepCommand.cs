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
using System.Linq;
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.ArgumentCompleters;
using AMSoftware.Crm.PowerShell.Common.Helpers;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace AMSoftware.Crm.PowerShell.Commands.Plugins
{
    [Cmdlet(VerbsLifecycle.Register, "CrmPluginStep", HelpUri = HelpUrlConstants.RegisterPluginStepHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class RegisterPluginStepCommand : CrmOrganizationCmdlet
    {
        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory=true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Guid EventSource { get; set; }

        [Parameter(Position = 2, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Message { get; set; }

        [Parameter(Position = 3)]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string PrimaryEntity { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string SecondaryEntity { get; set; }

        [Parameter]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int ExecutionOrder { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        public CrmPluginStepStage Stage { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        public CrmPluginStepMode Mode { get; set; }

        [Parameter]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmPluginStepDeployment.Both)]
        public CrmPluginStepDeployment Deployment { get; set; }

        [Parameter]
        public SwitchParameter DeleteAsyncOperation { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string UnsecureConfig { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string SecureConfig { get; set; }

        [Parameter]
        public Guid User { get; set; }

        [Parameter(ValueFromRemainingArguments = true)]
        [ArgumentCompleter(typeof(AttributeArgumentCompleter))]
        public string[] Attributes { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        private bool IsServiceEndpoint { get; set; }
        private Entity SdkMessageFilter { get; set; }
        private EntityReference SdkMessage { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (!this.MyInvocation.BoundParameters.ContainsKey(nameof(Deployment)))
            {
                Deployment = CrmPluginStepDeployment.Both;
            }

            if (Mode == CrmPluginStepMode.Asynchronous && Stage != CrmPluginStepStage.PostOperation)
            {
                throw new Exception("Asynchronous Execution Mode requires registration in one of the Post Stages. Please change the Mode or the Stage.");
            }
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(SecureConfig)) && (Deployment == CrmPluginStepDeployment.OfflineOnly || Deployment == CrmPluginStepDeployment.Both))
            {
                throw new Exception("Secure Configuration is not supported for Steps deployed Offline.");
            }

            Entity crmEventSource = RetrieveEventSource(EventSource);
            if (crmEventSource == null)
            {
                throw new Exception(string.Format("No Plugin or ServiceEndpoint found with Id '{0}'.", EventSource));
            }

            SdkMessageFilter = RetrieveMessageFilter(Message, PrimaryEntity, SecondaryEntity);
            if (SdkMessageFilter == null)
            {
                throw new Exception(string.Format("No supported Steps found for '{0}' on entities {1} and {2}.", Message, PrimaryEntity, SecondaryEntity));
            }
            else
            {
                SdkMessage = SdkMessageFilter.GetAttributeValue<EntityReference>("sdkmessageid");
                Message = SdkMessage.Name;
                PrimaryEntity = SdkMessageFilter.GetAttributeValue<string>("primaryobjecttypecode");
                SecondaryEntity = SdkMessageFilter.GetAttributeValue<string>("secondaryobjecttypecode");
            }

            int filterAvailability = SdkMessageFilter.GetAttributeValue<int>("availability");
            if (!IsDeploymentSupported(filterAvailability, Deployment))
            {
                throw new Exception(string.Format("The Step must be deployed '{0}'.", Enum.GetName(typeof(CrmPluginStepDeployment), filterAvailability)));
            }

            if (IsServiceEndpoint && Mode == CrmPluginStepMode.Synchronous)
            {
                throw new Exception("Only asynchronous Steps are supported for Service Endpoint plug-ins.");
            }

            string generatedDescription;
            if (IsServiceEndpoint)
            {
                generatedDescription = PluginManagementHelper.GenerateStepDescription(crmEventSource.GetAttributeValue<string>("name"), Message, PrimaryEntity, SecondaryEntity);
            }
            else
            {
                generatedDescription = PluginManagementHelper.GenerateStepDescription(crmEventSource.GetAttributeValue<string>("typename"), Message, PrimaryEntity, SecondaryEntity);
            }
            if (string.IsNullOrWhiteSpace(Name)) Name = generatedDescription;
            if (string.IsNullOrWhiteSpace(Description)) Description = generatedDescription;

            Guid secureConfigId = Guid.Empty;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(SecureConfig)))
            {
                secureConfigId = _repository.Add("sdkmessageprocessingstepsecureconfig", Guid.Empty, new System.Collections.Hashtable()
                {
                    { "secureconfig", SecureConfig }
                });
            }

            Guid newId = _repository.Add(GenerateCrmEntity(secureConfigId));
            if (PassThru)
            {
                WriteObject(_repository.Get("sdkmessageprocessingstep", newId));
            }
        }

        private Entity RetrieveEventSource(Guid eventSourceId)
        {
            Entity result = null;
            IsServiceEndpoint = false;
            try
            {
                result = _repository.Get("plugintype", eventSourceId);
            }
            catch { }

            if (result == null)
            {
                try
                {
                    result = _repository.Get("serviceendpoint", eventSourceId);
                    IsServiceEndpoint = true;
                }
                catch { }
            }

            return result;
        }

        private Entity RetrieveMessageFilter(string message, string primaryEntity, string secondaryEntity)
        {
            string entity1 = string.IsNullOrWhiteSpace(primaryEntity) ? "none" : primaryEntity;
            string entity2 = string.IsNullOrWhiteSpace(secondaryEntity) ? "none" : secondaryEntity;

            QueryExpression queryExpression = new QueryExpression("sdkmessagefilter")
            {
                ColumnSet = new ColumnSet(true),
                Distinct = true,
                Criteria = new FilterExpression(LogicalOperator.And)
                {
                    Conditions = {
                        new ConditionExpression("primaryobjecttypecode", ConditionOperator.Equal, entity1),
                        new ConditionExpression("secondaryobjecttypecode", ConditionOperator.Equal, entity2),
                        new ConditionExpression("iscustomprocessingstepallowed", ConditionOperator.Equal, true)
                    }
                },
                LinkEntities = {
                    new LinkEntity() {
                        JoinOperator = Microsoft.Xrm.Sdk.Query.JoinOperator.Inner,
                        EntityAlias = "sdkmessage",
                        LinkFromAttributeName = "sdkmessageid",
                        LinkFromEntityName = "sdkmessagefilter",
                        LinkToAttributeName = "sdkmessageid",
                        LinkToEntityName = "sdkmessage",
                        LinkCriteria = new FilterExpression(LogicalOperator.And) {
                            Conditions = {
                                new ConditionExpression("isprivate", ConditionOperator.Equal, false),
                                new ConditionExpression("name", ConditionOperator.Equal, message)    
                            }
                        }
                    }
                }
            };

            return _repository.Get(queryExpression).SingleOrDefault();
        }

        private Entity GenerateCrmEntity(Guid secureConfigId)
        {
            Entity crmPluginStep = new Entity("sdkmessageprocessingstep")
            {
                Attributes = new AttributeCollection()
            };
            crmPluginStep.Attributes.Add("asyncautodelete", DeleteAsyncOperation.ToBool());
            crmPluginStep.Attributes.Add("rank", this.MyInvocation.BoundParameters.ContainsKey(nameof(ExecutionOrder)) ? ExecutionOrder : 1);
            crmPluginStep.Attributes.Add("description", Description);
            crmPluginStep.Attributes.Add("name", Name);
            crmPluginStep.Attributes.Add("configuration", UnsecureConfig);
            crmPluginStep.Attributes.Add("stage", new OptionSetValue((int)Stage));
            crmPluginStep.Attributes.Add("mode", new OptionSetValue((int)Mode));
            crmPluginStep.Attributes.Add("supporteddeployment", new OptionSetValue((int)Deployment));
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(User)) && User != Guid.Empty)
            {
                crmPluginStep.Attributes.Add("impersonatinguserid", new EntityReference("systemuser", User));
            }

            crmPluginStep.Attributes.Add("sdkmessageid", SdkMessage);
            crmPluginStep.Attributes.Add("sdkmessagefilterid", new EntityReference(SdkMessageFilter.LogicalName, SdkMessageFilter.Id));

            if (IsServiceEndpoint)
            {
                crmPluginStep.Attributes.Add("eventhandler", new EntityReference("serviceendpoint", EventSource));
            }
            else
            {
                crmPluginStep.Attributes.Add("eventhandler", new EntityReference("plugintype", EventSource));
            }

            if (SdkMessage.Name.Equals("update", StringComparison.InvariantCultureIgnoreCase))
            {
                if (Attributes != null && Attributes.Length != 0)
                {
                    string filteringAttributes = string.Join(",", Attributes);
                    crmPluginStep.Attributes.Add("filteringattributes", filteringAttributes);
                }
            }

            if (secureConfigId != Guid.Empty)
            {
                crmPluginStep.Attributes.Add("sdkmessageprocessingstepsecureconfigid", new EntityReference("sdkmessageprocessingstepsecureconfig", secureConfigId));
            }

            return crmPluginStep;
        }

        private bool IsDeploymentSupported(int availablity, CrmPluginStepDeployment deployment)
        {
            switch (availablity)
            {
                case 0: //ServerOnly:
                    return deployment == CrmPluginStepDeployment.ServerOnly;
                case 1: //OfflineOnly:
                    return deployment == CrmPluginStepDeployment.OfflineOnly;
                default:
                    return true;
            }
        }
    }
}
