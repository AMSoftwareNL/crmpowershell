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
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Linq;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands.Security
{
    [Cmdlet(VerbsCommon.Get, "CrmPrincipalPrivileges", HelpUri = HelpUrlConstants.GetPrincipalPrivilegesHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class GetPrincipalPrivilegesCommand : CrmOrganizationCmdlet
    {
        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [Alias("User", "Team")]
        [ValidateNotNullOrEmpty]
        public Entity InputObject { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var allPrivileges = _repository.Get(
                new QueryExpression("privilege")
                {
                    ColumnSet = new ColumnSet(true)
                });


            RolePrivilege[] principalPrivileges = null;

            if (InputObject.LogicalName.Equals("systemuser", StringComparison.InvariantCultureIgnoreCase))
            {
                // For Users
                principalPrivileges = GetUserOrTeamsPrivileges("RetrieveUserPrivileges", "UserId", InputObject.Id);
            } else if (InputObject.LogicalName.Equals("team", StringComparison.InvariantCultureIgnoreCase))
            {
                // For Teams
                principalPrivileges = GetUserOrTeamsPrivileges("RetrieveTeamPrivileges", "TeamId", InputObject.Id);
            } else
            {
                return;
            }

            var principalOutput = from principalPrivilege in principalPrivileges
                                  join privilege in allPrivileges
                                  on principalPrivilege.PrivilegeId equals privilege.Id
                                  select privilege;
            WriteObject(principalOutput, true);
        }

        private RolePrivilege[] GetUserOrTeamsPrivileges(string requestName, string keyName, Guid principalId)
        {
            OrganizationResponse responseForPrincipal =
                _repository.Execute(requestName, new System.Collections.Hashtable()
                {
                    { keyName, principalId }
                });

            if (responseForPrincipal.Results != null && responseForPrincipal.Results.ContainsKey("RolePrivileges") && responseForPrincipal["RolePrivileges"] != null)
            {
                return (RolePrivilege[])responseForPrincipal["RolePrivileges"];
            }

            return new RolePrivilege[] { };
        }
    }
}
