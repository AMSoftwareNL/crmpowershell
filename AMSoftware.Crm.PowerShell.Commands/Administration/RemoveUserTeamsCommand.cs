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
using AMSoftware.Crm.PowerShell.Common.Helpers;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using System;
using System.Linq;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands.Administration
{
    [Cmdlet(VerbsCommon.Remove, "CrmUserTeams", HelpUri = HelpUrlConstants.RemoveUserTeamsHelpUrl, DefaultParameterSetName = RemoveUserTeamsSelectedParameterSet)]
    public sealed class RemoveUserTeamsCommand : CrmOrganizationCmdlet
    {
        private const string RemoveUserTeamsAllParameterSet = "RemoveUserTeamsAll";
        private const string RemoveUserTeamsSelectedParameterSet = "RemoveUserTeamsSelected";

        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [Alias("Id")]
        [ValidateNotNull]
        public Guid User { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromRemainingArguments = true, ParameterSetName = RemoveUserTeamsSelectedParameterSet)]
        [ValidateNotNull]
        public Guid[] Teams { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = RemoveUserTeamsAllParameterSet)]
        public SwitchParameter All { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Guid[] currentSetIds = SecurityManagementHelper.GetTeamsForUser(_repository, User).Select(e => e.Id).ToArray();
            Guid[] removeSet = Teams;
            if (this.ParameterSetName == RemoveUserTeamsAllParameterSet)
            {
                removeSet = currentSetIds;
            }

            if (removeSet != null && removeSet.Length > 0)
            {
                foreach (var item in removeSet)
                {
                    SecurityManagementHelper.RemoveUsersFromTeam(_repository, item, new Guid[] { User });
                }
            }
        }
    }
}
