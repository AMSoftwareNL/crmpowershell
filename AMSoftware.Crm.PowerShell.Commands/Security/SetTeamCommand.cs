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

namespace AMSoftware.Crm.PowerShell.Commands.Security
{
    [Cmdlet(VerbsCommon.Set, "CrmTeam", HelpUri = HelpUrlConstants.SetTeamHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class SetTeamCommand : CrmOrganizationCmdlet
    {
        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public Guid Id { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public Guid Administrator { get; set; }

        [Parameter]
        public string Description { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Entity updateTeam = _repository.Get("team", Id);

            updateTeam.Attributes["name"] = this.MyInvocation.BoundParameters.ContainsKey(nameof(Name)) ? Name : updateTeam.Attributes["name"];
            updateTeam.Attributes["administratorid"] = this.MyInvocation.BoundParameters.ContainsKey(nameof(Administrator)) ? Administrator : updateTeam.Attributes["administratorid"];

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Description)))
            {
                if (updateTeam.Attributes.ContainsKey("description")) updateTeam.Attributes["description"] = Description;
                else updateTeam.Attributes.Add("description", Description);
            }

            _repository.Update(updateTeam);

            if (PassThru)
            {
                WriteObject(_repository.Get("team", Id));
            }
        }
    }
}
