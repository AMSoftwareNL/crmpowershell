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
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using System;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands.Plugins
{
    [Cmdlet(VerbsCommon.Set, "CrmPlugin", HelpUri = HelpUrlConstants.SetPluginHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class SetPluginCommand : CrmOrganizationCmdlet
    {
        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Guid Id { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        [Parameter]
        [ValidateNotNull]
        public string Description { get; set; }

        [Parameter]
        [ValidateNotNull]
        public string WorkflowActivityGroupName { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Entity crmPluginType = _repository.Get("plugintype", Id);
            if (!string.IsNullOrWhiteSpace(Name))
            {
                if (crmPluginType.Contains("name")) crmPluginType.Attributes["name"] = Name;
                else crmPluginType.Attributes.Add("name", Name);
            }
            if (!string.IsNullOrWhiteSpace(FriendlyName))
            {
                if (crmPluginType.Contains("friendlyname")) crmPluginType.Attributes["friendlyname"] = FriendlyName;
                else crmPluginType.Attributes.Add("friendlyname", FriendlyName);
            }
            if (Description != null)
            {
                string description = string.IsNullOrWhiteSpace(Description) ? null : Description;
                if (crmPluginType.Contains("description")) crmPluginType.Attributes["description"] = description;
                else crmPluginType.Attributes.Add("description", description);
            }
            if (WorkflowActivityGroupName != null && crmPluginType.Contains("isworkflowactivity") && crmPluginType.GetAttributeValue<bool>("isworkflowactivity") == true)
            {
                string groupName = string.IsNullOrWhiteSpace(WorkflowActivityGroupName) ? null : WorkflowActivityGroupName;
                if (crmPluginType.Contains("workflowactivitygroupname")) crmPluginType.Attributes["workflowactivitygroupname"] = groupName;
                else crmPluginType.Attributes.Add("workflowactivitygroupname", groupName);
            }

            _repository.Update(crmPluginType);
            if (PassThru)
            {
                WriteObject(_repository.Get("plugintype", Id));
            }
        }
    }
}
