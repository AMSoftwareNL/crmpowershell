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
using System.Management.Automation.Provider;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.PowerShell.Commands;
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Commands.Customizations
{
    [Cmdlet(VerbsData.Import, "CrmWebresource", HelpUri = HelpUrlConstants.ImportWebresourceHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class ImportWebresourceCommand : CrmOrganizationCmdlet
    {
        internal const string ImportWebresourceFromValueParameterSet = "ImportWebresourceFromValue";
        internal const string ImportWebresourceFromPathParameterSet = "ImportWebresourceFromPath";

        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNull]
        public Guid Id { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ImportWebresourceFromValueParameterSet)]
        [ValidateNotNull]
        public byte[] Value { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ImportWebresourceFromPathParameterSet)]
        [Alias("PSPath", "Path")]
        [ValidateNotNullOrEmpty]
        public string LiteralPath { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Entity webresource = _repository.Get("webresource", Id, new string[] { "content" });

            switch (this.ParameterSetName)
            {
                case ImportWebresourceFromValueParameterSet:
                    string contentAsBase64 = Convert.ToBase64String(Value);
                    webresource.Attributes["content"] = contentAsBase64;
                    break;
                case ImportWebresourceFromPathParameterSet:
                    byte[] fileAsBytes = File.ReadAllBytes(LiteralPath);
                    string fileContentAsBase64 = Convert.ToBase64String(fileAsBytes);
                    webresource.Attributes["content"] = fileContentAsBase64;
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
