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
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Helpers;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using System;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands.Administration
{
    [Cmdlet(VerbsCommon.New, "CrmTeam", HelpUri = HelpUrlConstants.NewTeamHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class NewTeamCommand : CrmOrganizationCmdlet
    {
        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateNotNullOrEmpty]
        public CrmTeamType TeamType { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        [ValidateNotNullOrEmpty]
        public Guid Administrator { get; set; }

        [Parameter(ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Guid? BusinessUnit { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(ValueFromRemainingArguments = true)]
        [ValidateNotNull]
        public Guid[] Users { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Guid[] userIds = Users;
            Guid businessUnitId = BusinessUnit ?? SecurityManagementHelper.GetDefaultBusinessUnitId(_repository);

            Entity newTeam = new Entity("team")
            {
                Attributes = new AttributeCollection()
            };
            newTeam.Attributes.Add("name", Name);
            newTeam.Attributes.Add("teamtype", new OptionSetValue((int)TeamType));
            newTeam.Attributes.Add("administratorid", new EntityReference("systemuser", Administrator));
            newTeam.Attributes.Add("businessunitid", new EntityReference("businessunit", businessUnitId));
            if (!string.IsNullOrWhiteSpace(Description))
            {
                newTeam.Attributes.Add("description", Description);
            }

            Guid newTeamId = _repository.Add(newTeam);
            if (Users != null && Users.Length != 0)
            {
                SecurityManagementHelper.AddUsersToTeam(_repository, newTeamId, Users);
            }

            if (PassThru)
            {
                WriteObject(_repository.Get("team", newTeamId));
            }
        }
    }
}
