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
using Microsoft.PowerShell.Commands;
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Commands.Customizations
{
    [Cmdlet(VerbsCommon.New, "Webresource", HelpUri = HelpUrlConstants.NewWebresourceHelpUrl, DefaultParameterSetName = NewWebresourceFromContentParameterSet)]
    [OutputType(typeof(Entity))]
    public sealed class NewWebresourceCommand : CrmOrganizationCmdlet, IDynamicParameters
    {
        internal const string NewWebresourceFromContentParameterSet = "NewWebresourceFromContent";
        internal const string NewWebresourceFromPathParameterSet = "NewWebresourceFromPath";

        private ContentRepository _repository = new ContentRepository();
        private NewWebresourceDynamicParameters _contentParameters = new NewWebresourceDynamicParameters();

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(Mandatory = true)]
        [PSDefaultValue(Value = CrmWebresourceType.All)]
        public CrmWebresourceType WebresourceType { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = NewWebresourceFromContentParameterSet)]
        [ValidateNotNull]
        public byte[] Content { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NewWebresourceFromPathParameterSet)]
        [Alias("PSPath", "Path")]
        [ValidateNotNullOrEmpty]
        public string LiteralPath { get; set; }

        [Parameter]
        [ValidateNotNull]
        public bool? IsCustomizable { get; set; }

        public object GetDynamicParameters()
        {
            return _contentParameters;
        }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Entity newWebResource = new Entity("webresource");
            newWebResource.Attributes = new AttributeCollection();
            newWebResource.Attributes.Add("name", Name);
            newWebResource.Attributes.Add("webresourcetype", new OptionSetValue(GetWebresourceTypeFromEnum(WebresourceType)));

            if (!string.IsNullOrWhiteSpace(DisplayName)) newWebResource.Attributes.Add("displayname", DisplayName);
            if (!string.IsNullOrWhiteSpace(Description)) newWebResource.Attributes.Add("description", Description);
            if (IsCustomizable.HasValue) newWebResource.Attributes.Add("iscustomizable", IsCustomizable.Value);

            switch (this.ParameterSetName)
            {
                case NewWebresourceFromContentParameterSet:
                    string contentAsBase64 = Convert.ToBase64String(Content);
                    newWebResource.Attributes.Add("content", contentAsBase64);
                    break;
                case NewWebresourceFromPathParameterSet:
                    FileContentReaderWriter fcrw = new FileContentReaderWriter(LiteralPath, _contentParameters.EncodingType, _contentParameters.UsingByteEncoding);
                    byte[] fileAsBytes = fcrw.ReadAsBytes();
                    string fileContentAsBase64 = Convert.ToBase64String(fileAsBytes);
                    newWebResource.Attributes.Add("content", fileContentAsBase64);
                    break;
                default:
                    break;
            }

            Guid newId = _repository.Add(newWebResource);
            WriteObject(_repository.Get("webresource", newId, null));
        }

        private static int GetWebresourceTypeFromEnum(CrmWebresourceType webresourceType)
        {
            switch (webresourceType)
            {
                case CrmWebresourceType.HTML:
                    return 1;
                case CrmWebresourceType.CSS:
                    return 2;
                case CrmWebresourceType.JS:
                    return 3;
                case CrmWebresourceType.XML:
                    return 4;
                case CrmWebresourceType.PNG:
                    return 5;
                case CrmWebresourceType.JPG:
                    return 6;
                case CrmWebresourceType.GIF:
                    return 7;
                case CrmWebresourceType.XAP:
                    return 8;
                case CrmWebresourceType.XSL:
                    return 9;
                case CrmWebresourceType.ICO:
                    return 10;
                default:
                    throw new ArgumentOutOfRangeException("WebresourceType", webresourceType, "Invalid WebresourceType. Parameter must be a specific type for the webresource.");
            }
        }
    }

    public sealed class NewWebresourceDynamicParameters : FileContentDynamicsParameters
    {
        [Parameter(ParameterSetName = NewWebresourceCommand.NewWebresourceFromPathParameterSet)]
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
