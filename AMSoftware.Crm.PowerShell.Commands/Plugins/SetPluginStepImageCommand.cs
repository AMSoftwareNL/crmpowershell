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
    [Cmdlet(VerbsCommon.Set, "CrmPluginStepImage", HelpUri = HelpUrlConstants.SetPluginStepImageHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class SetPluginStepImageCommand : CrmOrganizationCmdlet
    {
        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Guid Id { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Alias { get; set; }

        [Parameter]
        [ValidateNotNull]
        public CrmPluginStepImageType ImageType { get; set; }

        [Parameter(ValueFromRemainingArguments = true)]
        public string[] Attributes { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Entity crmPluginStepImage = _repository.Get("sdkmessageprocessingstepimage", Id);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
            {
                if (crmPluginStepImage.Contains("name")) crmPluginStepImage.Attributes["name"] = Name;
                else crmPluginStepImage.Attributes.Add("name", Name);
            }
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Alias)))
            {
                if (crmPluginStepImage.Contains("entityalias")) crmPluginStepImage.Attributes["entityalias"] = Alias;
                else crmPluginStepImage.Attributes.Add("entityalias", Alias);
            }
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(ImageType)))
            {
                if (crmPluginStepImage.Contains("imagetype")) crmPluginStepImage.Attributes["imagetype"] = new OptionSetValue((int)ImageType);
                else crmPluginStepImage.Attributes.Add("imagetype", new OptionSetValue((int)ImageType));
            }
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Attributes)))
            {
                if (Attributes != null && Attributes.Length != 0)
                {
                    string filteringAttributes = string.Join(",", Attributes);
                    if (crmPluginStepImage.Contains("attributes")) crmPluginStepImage.Attributes["attributes"] = filteringAttributes;
                    else crmPluginStepImage.Attributes.Add("attributes", filteringAttributes);
                }
                else
                {
                    if (crmPluginStepImage.Contains("attributes")) crmPluginStepImage.Attributes["attributes"] = null;
                    else crmPluginStepImage.Attributes.Add("attributes", null);
                }
            }

            _repository.Update(crmPluginStepImage);
            if (PassThru)
            {
                WriteObject(_repository.Get("sdkmessageprocessingstepimage", Id));
            }
        }
    }
}
