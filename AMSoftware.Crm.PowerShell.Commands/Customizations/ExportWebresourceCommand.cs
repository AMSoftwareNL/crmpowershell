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
using System.Text;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.PowerShell.Commands;
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Commands.Customizations
{
    [Cmdlet(VerbsData.Export, "CrmWebresource", HelpUri = HelpUrlConstants.ExportWebresourceHelpUrl)]
    public sealed class ExportWebresourceCommand : CrmOrganizationCmdlet, IDynamicParameters
    {
        private ContentRepository _repository = new ContentRepository();
        private ExportWebresourceDynamicParameters _contentParameters = new ExportWebresourceDynamicParameters();

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNull]
        public Guid Id { get; set; }

        public object GetDynamicParameters()
        {
            return _contentParameters;
        }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Entity webresource = _repository.Get("webresource", Id, new string[] { "content" });
            string contentAsBase64 = webresource.GetAttributeValue<string>("content");
            byte[] contentAsBytes = Convert.FromBase64String(contentAsBase64);

            if (_contentParameters.UsingByteEncoding)
            {
                WriteObject(contentAsBytes);
            }
            else
            {
                Encoding e = _contentParameters.EncodingType;
                WriteObject(e.GetString(contentAsBytes));
            }
        }
    }

    public sealed class ExportWebresourceDynamicParameters : FileContentDynamicsParameters
    {
        [Parameter]
        public FileSystemCmdletProviderEncoding Encoding
        {
            get
            {
                return base.streamType;
            }
            set
            {
                base.streamType = value;
            }
        }
    }
}
