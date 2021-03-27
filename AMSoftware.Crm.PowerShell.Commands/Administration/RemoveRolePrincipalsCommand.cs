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
using System;
using System.Linq;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands.Administration
{
    [Cmdlet(VerbsCommon.Remove, "CrmRolePrincipals", HelpUri = HelpUrlConstants.RemoveRolePrincipalsHelpUrl, DefaultParameterSetName = RemoveRolePrincipalsSelectedParameterSet)]
    public sealed class RemoveRolePrincipalsCommand : CrmOrganizationCmdlet
    {
        private const string RemoveRolePrincipalsAllParameterSet = "RemoveRolePrincipalsAll";
        private const string RemoveRolePrincipalsSelectedParameterSet = "RemoveRolePrincipalsSelected";

        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [Alias("Id")]
        [ValidateNotNull]
        public Guid[] Role { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = RemoveRolePrincipalsSelectedParameterSet)]
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = RemoveRolePrincipalsAllParameterSet)]
        [ValidateNotNull]
        public CrmPrincipalType? PrincipalType { get; set; }

        [Parameter(Mandatory = true, ValueFromRemainingArguments = true, ParameterSetName = RemoveRolePrincipalsSelectedParameterSet)]
        [ValidateNotNull]
        public Guid[] Principals { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = RemoveRolePrincipalsAllParameterSet)]
        public SwitchParameter All { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case RemoveRolePrincipalsSelectedParameterSet:
                    RemoveRolePrincipalsSelected();
                    break;
                case RemoveRolePrincipalsAllParameterSet:
                    RemoveRolePrincipalsAll();
                    break;
                default:
                    break;
            }
        }

        private void RemoveRolePrincipalsAll()
        {
            foreach (Guid roleId in Role)
            {
                switch (PrincipalType)
                {
                    case CrmPrincipalType.User:
                        RemoveRoleUsersAll(roleId);
                        break;
                    case CrmPrincipalType.Team:
                        RemoveRoleTeamsAll(roleId);
                        break;
                    default:
                        RemoveRoleUsersAll(roleId);
                        RemoveRoleTeamsAll(roleId);
                        break;
                }
            }
        }

        private void RemoveRolePrincipalsSelected()
        {
            string secondaryEntityName = null;
            switch (PrincipalType)
            {
                case CrmPrincipalType.User:
                    secondaryEntityName = "systemuser";
                    break;
                case CrmPrincipalType.Team:
                    secondaryEntityName = "team";
                    break;
                default:
                    break;
            }

            string primaryEntityName = "role";
            foreach (Guid roleId in Role)
            {
                Guid primaryEntityId = roleId;
                Guid[] secondaryEntityIds = Principals;
                Guid[] currentSetIds = SecurityManagementHelper.GetPrincipalsInRole(_repository, PrincipalType.Value, roleId).Select(e => e.Id).ToArray();
                Guid[] removeSet = secondaryEntityIds.Intersect(currentSetIds).ToArray();

                if (removeSet != null && removeSet.Length > 0)
                {
                    SecurityManagementHelper.UnlinkPrincipalRoles(_repository, primaryEntityName, primaryEntityId, secondaryEntityName, removeSet);
                }
            }
        }

        private void RemoveRoleUsersAll(Guid roleId)
        {
            string secondaryEntityName = "systemuser";
            string primaryEntityName = "role";
            Guid primaryEntityId = roleId;
            Guid[] secondaryEntityIds = Principals;
            Guid[] currentSetIds = SecurityManagementHelper.GetPrincipalsInRole(_repository, PrincipalType.Value, roleId).Select(e => e.Id).ToArray();
            Guid[] removeSet = secondaryEntityIds.Intersect(currentSetIds).ToArray();

            if (removeSet != null && removeSet.Length > 0)
            {
                SecurityManagementHelper.UnlinkPrincipalRoles(_repository, primaryEntityName, primaryEntityId, secondaryEntityName, removeSet);
            }
        }

        private void RemoveRoleTeamsAll(Guid roleId)
        {
            string secondaryEntityName = "team";
            string primaryEntityName = "role";
            Guid primaryEntityId = roleId;
            Guid[] secondaryEntityIds = Principals;
            Guid[] currentSetIds = SecurityManagementHelper.GetPrincipalsInRole(_repository, PrincipalType.Value, roleId).Select(e => e.Id).ToArray();
            Guid[] removeSet = secondaryEntityIds.Intersect(currentSetIds).ToArray();

            if (removeSet != null && removeSet.Length > 0)
            {
                SecurityManagementHelper.UnlinkPrincipalRoles(_repository, primaryEntityName, primaryEntityId, secondaryEntityName, removeSet);
            }
        }
    }
}
