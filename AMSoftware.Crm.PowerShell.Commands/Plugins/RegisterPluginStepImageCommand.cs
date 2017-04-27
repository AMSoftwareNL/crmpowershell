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
using AMSoftware.Crm.PowerShell.Common.Helpers;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Commands.Plugins
{
    [Cmdlet(VerbsLifecycle.Register, "PluginStepImage", HelpUri = HelpUrlConstants.RegisterPluginStepImageHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class RegisterPluginStepImageCommand : CrmOrganizationCmdlet
    {
        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Guid PluginStep { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Alias { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        public CrmPluginStepImageType ImageType { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string MessagePropertyName { get; set; }

        [Parameter(ValueFromRemainingArguments = true)]
        public string[] Attributes { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Entity crmPluginStep = _repository.Get("sdkmessageprocessingstep", PluginStep);
            EntityReference crmPluginStepMessageReference = crmPluginStep.GetAttributeValue<EntityReference>("sdkmessageid");
            string[] messageProperties = PluginManagementHelper.GetSdkMessagePropertyNames(crmPluginStepMessageReference.Name);

            if (messageProperties == null || messageProperties.Length == 0)
            {
                throw new Exception(string.Format("Steps registered on message '{0}'do not support images.", crmPluginStepMessageReference.Name));
            }
            else if (messageProperties.Length > 1)
            {
                string messageProperty = messageProperties.SingleOrDefault(s => s.Equals(MessagePropertyName, StringComparison.InvariantCultureIgnoreCase));
                if (string.IsNullOrWhiteSpace(messageProperty))
                {
                    throw new Exception(
                        string.Format("Message '{0}' supports multiple message properties ({1}). Include the parameter 'MessagePropertyName'.", 
                            crmPluginStepMessageReference.Name, string.Join(", ", messageProperties)));
                }
                MessagePropertyName = messageProperty;
            }
            else
            {
                MessagePropertyName = messageProperties[0];
            }

            WriteObject(_repository.Add(GenerateCrmEntity()));
        }

        private Entity GenerateCrmEntity()
        {
            Entity crmPluginStepImage = new Entity("sdkmessageprocessingstepimage");
            crmPluginStepImage.Attributes = new AttributeCollection();
            crmPluginStepImage.Attributes.Add("sdkmessageprocessingstepid", new EntityReference("sdkmessageprocessingstep", PluginStep));
            crmPluginStepImage.Attributes.Add("name", Name);
            crmPluginStepImage.Attributes.Add("entityalias", Alias);
            crmPluginStepImage.Attributes.Add("imagetype", new OptionSetValue((int)ImageType));

            if (Attributes != null && Attributes.Length != 0)
            {
                string filteringAttributes = string.Join(",", Attributes);
                crmPluginStepImage.Attributes.Add("attributes", filteringAttributes);
            }

            crmPluginStepImage.Attributes.Add("messagepropertyname", MessagePropertyName);

            return crmPluginStepImage;
        }
    }
}
