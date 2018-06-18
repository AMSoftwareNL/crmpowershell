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
using System.Linq;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands.Administration
{
    [Cmdlet(VerbsCommon.Remove, "CrmPrincipalRoles", HelpUri = HelpUrlConstants.RemovePrincipalRolesHelpUrl, DefaultParameterSetName = RemovePrincipalRolesSelectedParameterSet)]
    public sealed class RemovePrincipalRolesCommand : CrmOrganizationCmdlet
    {
        private const string RemovePrincipalRolesAllParameterSet = "RemovePrincipalRolesAll";
        private const string RemovePrincipalRolesSelectedParameterSet = "RemovePrincipalRolesSelected";

        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [Alias("Id")]
        [ValidateNotNull]
        public Guid Principal { get; set; }

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateNotNull]
        public CrmPrincipalType PrincipalType { get; set; }

        [Parameter(Mandatory = true, ValueFromRemainingArguments = true, ParameterSetName = RemovePrincipalRolesSelectedParameterSet)]
        [ValidateNotNull]
        public Guid[] Roles { get; set; }

        [Parameter(Mandatory=true, ParameterSetName = RemovePrincipalRolesAllParameterSet)]
        public SwitchParameter All { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            string primaryEntityName = null;
            switch (PrincipalType)
            {
                case CrmPrincipalType.User:
                    primaryEntityName = "systemuser";
                    break;
                case CrmPrincipalType.Team:
                    primaryEntityName = "team";
                    break;
                default:
                    break;
            }

            string secondaryEntityName = "role";
            Guid primaryEntityId = Principal;
            Guid[] currentSetIds = SecurityManagementHelper.GetRolesForPrincipal(_repository, PrincipalType, Principal).Select(e => e.Id).ToArray();
            Guid[] removeSet = Roles;

            if (this.ParameterSetName == RemovePrincipalRolesAllParameterSet)
            {
                removeSet = currentSetIds;
            }

            if (removeSet != null && removeSet.Length > 0)
            {
                SecurityManagementHelper.UnlinkPrincipalRoles(_repository, primaryEntityName, primaryEntityId, secondaryEntityName, removeSet);
            }
        }
    }
}
