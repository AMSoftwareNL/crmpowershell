﻿/*
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

namespace AMSoftware.Crm.PowerShell.Commands.Security
{
    [Cmdlet(VerbsCommon.Set, "CrmRolePrincipals", HelpUri = HelpUrlConstants.SetRolePrincipalsHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class SetRolePrincipalsCommand : CrmOrganizationCmdlet
    {
        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [Alias("Id")]
        [ValidateNotNull]
        public Guid[] Role { get; set; }

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateNotNull]
        public CrmPrincipalType PrincipalType { get; set; }

        [Parameter(Mandatory = true, ValueFromRemainingArguments = true)]
        [ValidateNotNull]
        public Guid[] Principals { get; set; }

        [Parameter]
        public SwitchParameter Overwrite { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

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
                Guid[] currentSetIds = SecurityManagementHelper.GetPrincipalsInRole(_repository, PrincipalType, roleId).Select(e => e.Id).ToArray();

                Guid[] addSet = secondaryEntityIds.Except(currentSetIds).ToArray();
                if (addSet != null && addSet.Length > 0)
                {
                    SecurityManagementHelper.LinkPrincipalRoles(_repository, primaryEntityName, primaryEntityId, secondaryEntityName, addSet);
                }
                //Remove associations which are in current and not in new
                if (Overwrite)
                {
                    Guid[] removeSet = currentSetIds.Except(secondaryEntityIds).ToArray();
                    if (removeSet != null && removeSet.Length > 0)
                    {
                        SecurityManagementHelper.UnlinkPrincipalRoles(_repository, primaryEntityName, primaryEntityId, secondaryEntityName, removeSet);
                    }
                }

                if (PassThru)
                {
                    WriteObject(_repository.Get(primaryEntityName, primaryEntityId));
                }
            }
        }
    }
}
