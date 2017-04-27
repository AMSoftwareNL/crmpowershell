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
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Commands.Customizations
{
    [Cmdlet(VerbsCommon.New, "Publisher", HelpUri = HelpUrlConstants.NewPublisherHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class NewPublisherCommand : CrmOrganizationCmdlet
    {
        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Prefix { get; set; }

        [Parameter]
        [ValidateRange(10000, 99999)]
        public int? OptionSetValuePrefix { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            int valuePrefix = new Random().Next(10000, 99999);
            if (OptionSetValuePrefix.HasValue) {
                valuePrefix = OptionSetValuePrefix.Value;
            }

            Entity newPublisher = new Entity("publisher");
            newPublisher.Attributes = new AttributeCollection();
            newPublisher.Attributes.Add("uniquename", Name);
            newPublisher.Attributes.Add("friendlyname", DisplayName);
            newPublisher.Attributes.Add("customizationprefix", Prefix);
            newPublisher.Attributes.Add("customizationoptionvalueprefix", valuePrefix);

            if (!string.IsNullOrWhiteSpace(Description)) {
                newPublisher.Attributes.Add("description", Description);
            }

            Guid newPublisherId = _repository.Add(newPublisher);
            WriteObject(_repository.Get("publisher", newPublisherId));
        }
    }
}
