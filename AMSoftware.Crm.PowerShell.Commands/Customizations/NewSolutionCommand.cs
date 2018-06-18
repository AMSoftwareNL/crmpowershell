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
using Microsoft.Xrm.Sdk.Query;

namespace AMSoftware.Crm.PowerShell.Commands.Customizations
{
    [Cmdlet(VerbsCommon.New, "CrmSolution", HelpUri = HelpUrlConstants.NewSolutionHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class NewSolutionCommand : CrmOrganizationCmdlet
    {
        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true)]
        [ValidatePattern(@"^\d+(\.\d+){1,3}$")]
        [ValidateNotNullOrEmpty]
        public string Version { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Guid Publisher { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Entity newSolution = new Entity("solution")
            {
                Attributes = new AttributeCollection()
            };
            newSolution.Attributes.Add("uniquename", Name);
            newSolution.Attributes.Add("friendlyname", DisplayName);
            newSolution.Attributes.Add("version", Version);
            newSolution.Attributes.Add("publisherid", new EntityReference("publisher", Publisher));

            if (!string.IsNullOrWhiteSpace(Description))
            {
                newSolution.Attributes.Add("description", Description);
            }

            Guid newSolutionId = _repository.Add(newSolution);

            if (PassThru)
            {
                WriteObject(_repository.Get("solution", newSolutionId));
            }
        }
    }
}
