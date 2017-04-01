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
using System.Linq;
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common.Helpers;
using AMSoftware.Crm.PowerShell.Common.Repositories;

namespace AMSoftware.Crm.PowerShell.Commands.Administration
{
    [Cmdlet(VerbsCommon.Set, "UserTeams", HelpUri = HelpUrlConstants.SetUserTeamsHelpUrl)]
    public class SetUserTeamsCommand : CrmOrganizationCmdlet
    {
        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNull]
        public Guid User { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromRemainingArguments = true)]
        [ValidateNotNull]
        public Guid[] Teams { get; set; }

        [Parameter]
        public SwitchParameter Overwrite { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Guid[] currentSetIds = SecurityManagementHelper.GetTeamsForUser(_repository, User).ToArray();

            Guid[] addSet = Teams.Except(currentSetIds).ToArray();
            if (addSet != null && addSet.Length > 0)
            {
                foreach (var item in addSet)
                {
                    SecurityManagementHelper.AddUsersToTeam(_repository, item, new Guid[] { User });
                }
            }
            //Remove associations which are in current and not in new
            if (Overwrite)
            {
                Guid[] removeSet = currentSetIds.Except(Teams).ToArray();
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
}
