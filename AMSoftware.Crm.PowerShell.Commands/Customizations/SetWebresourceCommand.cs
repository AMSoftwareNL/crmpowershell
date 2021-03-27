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
using System.IO;
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.PowerShell.Commands;
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Commands.Customizations
{
    [Cmdlet(VerbsCommon.Set, "CrmWebresource", HelpUri = HelpUrlConstants.SetWebresourceHelpUrl, DefaultParameterSetName = SetWebresourceParameterSet)]
    [OutputType(typeof(Entity))]
    public sealed class SetWebresourceCommand : CrmOrganizationCmdlet
    {
        internal const string SetWebresourceParameterSet = "SetWebresource";
        internal const string SetWebresourceFromContentParameterSet = "SetWebresourceFromContent";
        internal const string SetWebresourceFromPathParameterSet = "SetWebresourceFromPath";

        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNull]
        public Guid Id { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(ParameterSetName = SetWebresourceFromContentParameterSet)]
        [ValidateNotNull]
        public byte[] Content { get; set; }

        [Parameter(ParameterSetName = SetWebresourceFromPathParameterSet)]
        [Alias("PSPath", "Path")]
        [ValidateNotNullOrEmpty]
        public string LiteralPath { get; set; }

        [Parameter]
        [ValidateNotNull]
        public bool? IsCustomizable { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Entity webresource = _repository.Get("webresource", Id, null);

            if (!string.IsNullOrWhiteSpace(DisplayName))
            {
                if (webresource.Contains("displayname"))
                    webresource.Attributes["displayname"] = DisplayName;
                else
                    webresource.Attributes.Add("displayname", DisplayName);
            }

            if (!string.IsNullOrWhiteSpace(Description))
            {
                if (webresource.Contains("description"))
                    webresource.Attributes["description"] = Description;
                else
                    webresource.Attributes.Add("description", Description);
            }

            if (IsCustomizable.HasValue)
            {
                if (webresource.Contains("iscustomizable"))
                    webresource.Attributes["iscustomizable"] = IsCustomizable.Value;
                else
                    webresource.Attributes.Add("iscustomizable", IsCustomizable.Value);
            }

            switch (this.ParameterSetName)
            {
                case SetWebresourceFromContentParameterSet:
                    string contentAsBase64 = Convert.ToBase64String(Content);
                    webresource.Attributes["content"] = contentAsBase64;
                    break;
                case SetWebresourceFromPathParameterSet:
                    byte[] fileAsBytes = File.ReadAllBytes(LiteralPath);
                    string fileContentAsBase64 = Convert.ToBase64String(fileAsBytes);
                    webresource.Attributes["content"] = fileContentAsBase64;
                    break;
                default:
                    break;
            }

            _repository.Update(webresource);

            if (PassThru)
            {
                WriteObject(_repository.Get("webresource", Id));
            }
        }
    }
}
