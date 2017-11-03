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
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Commands.Plugins
{
    [Cmdlet(VerbsCommon.Set, "PluginStep", HelpUri = HelpUrlConstants.SetPluginStepHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class SetPluginStepCommand : CrmOrganizationCmdlet
    {
        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Guid Id { get; set; }

        [Parameter]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int? ExecutionOrder { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter]
        [ValidateNotNull]
        public string Description { get; set; }

        [Parameter]
        [ValidateNotNull]
        public CrmPluginStepStage? Stage { get; set; }

        [Parameter]
        [ValidateNotNull]
        public CrmPluginStepMode? Mode { get; set; }

        [Parameter]
        [ValidateNotNull]
        public CrmPluginStepDeployment? Deployment { get; set; }

        [Parameter]
        public SwitchParameter DeleteAsyncOperation { get; set; }

        [Parameter]
        [ValidateNotNull]
        public string UnsecureConfig { get; set; }

        [Parameter]
        [ValidateNotNull]
        public string SecureConfig { get; set; }

        [Parameter]
        [ValidateNotNull]
        public Guid? User { get; set; }

        [Parameter(ValueFromRemainingArguments = true)]
        public string[] Attributes { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Entity crmPluginStep = _repository.Get("sdkmessageprocessingstep", Id);

            Mode = Mode ?? (CrmPluginStepMode)crmPluginStep.GetAttributeValue<OptionSetValue>("mode").Value;
            Stage = Stage ?? (CrmPluginStepStage)crmPluginStep.GetAttributeValue<OptionSetValue>("stage").Value;
            Deployment = Deployment ?? (CrmPluginStepDeployment)crmPluginStep.GetAttributeValue<OptionSetValue>("supporteddeployment").Value;

            if (Mode == CrmPluginStepMode.Asynchronous && Stage != CrmPluginStepStage.PostOperation)
            {
                throw new Exception("Asynchronous Execution Mode requires registration in one of the Post Stages. Please change the Mode or the Stage.");
            }
            if (!string.IsNullOrWhiteSpace(SecureConfig) && (Deployment == CrmPluginStepDeployment.OfflineOnly || Deployment == CrmPluginStepDeployment.Both))
            {
                throw new Exception("Secure Configuration is not supported for Steps deployed Offline.");
            }

            EntityReference crmMessageFilterReference = crmPluginStep.GetAttributeValue<EntityReference>("sdkmessagefilterid");
            Entity crmMessageFilter = _repository.Get(crmMessageFilterReference.LogicalName, crmMessageFilterReference.Id);

            int filterAvailability = crmMessageFilter.GetAttributeValue<int>("availability");
            if (!IsDeploymentSupported(filterAvailability, Deployment.Value))
            {
                throw new Exception(string.Format("The Step must be deployed '{0}'.", Enum.GetName(typeof(CrmPluginStepDeployment), filterAvailability)));
            }

            EntityReference crmEventHandlerReference = crmPluginStep.GetAttributeValue<EntityReference>("eventhandler");
            if (crmEventHandlerReference.LogicalName.Equals("serviceendpoint", StringComparison.InvariantCultureIgnoreCase) && Mode == CrmPluginStepMode.Synchronous)
            {
                throw new Exception("Only asynchronous Steps are supported for Service Endpoint plug-ins.");
            }

            if (!string.IsNullOrWhiteSpace(Name))
            {
                if (crmPluginStep.Contains("name")) crmPluginStep.Attributes["name"] = Name;
                else crmPluginStep.Attributes.Add("name", Name);
            }
            if (Description != null)
            {
                string description = string.IsNullOrWhiteSpace(Description) ? null : Description;
                if (crmPluginStep.Contains("description")) crmPluginStep.Attributes["description"] = description;
                else crmPluginStep.Attributes.Add("description", description);
            }
            if (UnsecureConfig != null)
            {
                string unsecureConfig = string.IsNullOrWhiteSpace(UnsecureConfig) ? null : UnsecureConfig;
                if (crmPluginStep.Contains("configuration")) crmPluginStep.Attributes["configuration"] = unsecureConfig;
                else crmPluginStep.Attributes.Add("configuration", unsecureConfig);
            }
            if (ExecutionOrder.HasValue)
            {
                if (crmPluginStep.Contains("rank")) crmPluginStep.Attributes["rank"] = ExecutionOrder.Value;
                else crmPluginStep.Attributes.Add("rank", ExecutionOrder.Value);
            }
            if (DeleteAsyncOperation.IsPresent)
            {
                if (crmPluginStep.Contains("asyncautodelete")) crmPluginStep.Attributes["asyncautodelete"] = DeleteAsyncOperation.ToBool();
                else crmPluginStep.Attributes.Add("asyncautodelete", DeleteAsyncOperation.ToBool());
            }
            if (User != null)
            {
                if (User.Value != Guid.Empty)
                {
                    if (crmPluginStep.Contains("impersonatinguserid")) crmPluginStep.Attributes["impersonatinguserid"] = new EntityReference("systemuser", User.Value);
                    else crmPluginStep.Attributes.Add("impersonatinguserid", new EntityReference("systemuser", User.Value));
                }
                else
                {
                    if (crmPluginStep.Contains("impersonatinguserid")) crmPluginStep.Attributes["impersonatinguserid"] = null;
                    else crmPluginStep.Attributes.Add("impersonatinguserid", null);
                }
            }
            if (Attributes != null)
            {
                EntityReference crmMessageReference = crmPluginStep.GetAttributeValue<EntityReference>("sdkmessageid");
                if (crmMessageReference.Name.Equals("update", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (Attributes.Length != 0)
                    {
                        string filteringAttributes = string.Join(",", Attributes);
                        if (crmPluginStep.Contains("filteringattributes")) crmPluginStep.Attributes["filteringattributes"] = filteringAttributes;
                        else crmPluginStep.Attributes.Add("filteringattributes", filteringAttributes);
                    }
                    else
                    {
                        if (crmPluginStep.Contains("filteringattributes")) crmPluginStep.Attributes["filteringattributes"] = null;
                        else crmPluginStep.Attributes.Add("filteringattributes", null);
                    }
                }
            }
            crmPluginStep.Attributes["mode"] = new OptionSetValue((int)Mode);
            crmPluginStep.Attributes["stage"] = new OptionSetValue((int)Stage);
            crmPluginStep.Attributes["supporteddeployment"] = new OptionSetValue((int)Deployment);

            EntityReference crmSecureConfigReference = crmPluginStep.GetAttributeValue<EntityReference>("sdkmessageprocessingstepsecureconfigid");
            if (SecureConfig != null)
            {
                if (!string.IsNullOrWhiteSpace(SecureConfig))
                {
                    if (crmSecureConfigReference != null)
                    {
                        _repository.Update(crmSecureConfigReference.LogicalName, crmSecureConfigReference.Id, new System.Collections.Hashtable()
                        {
                            { "secureconfig", SecureConfig }
                        });
                    }
                    else
                    {
                        Guid secureConfigId = _repository.Add("sdkmessageprocessingstepsecureconfig", Guid.Empty, new System.Collections.Hashtable()
                        {
                            { "secureconfig", SecureConfig }
                        });
                        crmPluginStep.Attributes.Add("sdkmessageprocessingstepsecureconfigid", new EntityReference("sdkmessageprocessingstepsecureconfig", secureConfigId));
                    }
                }
                else
                {
                    if (crmSecureConfigReference != null)
                    {
                        crmPluginStep.Attributes["sdkmessageprocessingstepsecureconfigid"] = null;
                    }
                }
            }

            _repository.Update(crmPluginStep);
            if (SecureConfig != null && string.IsNullOrWhiteSpace(SecureConfig) && crmSecureConfigReference != null)
            {
                _repository.Delete(crmSecureConfigReference.LogicalName, crmSecureConfigReference.Id);
            }

            if (PassThru)
            {
                WriteObject(_repository.Get("sdkmessageprocessingstep", Id));
            }
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
