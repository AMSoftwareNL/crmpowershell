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
using AMSoftware.Crm.PowerShell.Common.ArgumentCompleters;
using AMSoftware.Crm.PowerShell.Common.Helpers;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands.Security
{
    [Cmdlet(VerbsCommon.Remove, "CrmRolePrivilege", HelpUri = HelpUrlConstants.RemoveRolePrivilegeHelpUrl, DefaultParameterSetName = RemoveRolePrivilegeForEntityParameterSet)]
    public sealed class RemoveRolePrivilegeCommand : CrmOrganizationConfirmActionCmdlet
    {
        private const string RemoveRolePrivilegeForEntityParameterSet = "RemoveRolePrivilegeForEntity";
        private const string RemoveRolePrivilegesByNameParameterSet = "RemoveRolePrivilegesByName";

        private readonly ContentRepository _repository = new ContentRepository();

        private Dictionary<string, Guid> _privilegeNames;

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [Alias("Id")]
        [ValidateNotNullOrEmpty]
        public Guid[] Role { get; set; }

        [Parameter(Mandatory = true, ValueFromRemainingArguments = true, ParameterSetName = RemoveRolePrivilegesByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string[] PrivilegeName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = RemoveRolePrivilegeForEntityParameterSet)]
        [Alias("LogicalName")]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        [ValidateNotNullOrEmpty]
        public string EntityLogicalName { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = RemoveRolePrivilegeForEntityParameterSet)]
        [ValidateNotNullOrEmpty]
        public CrmAccessRight AccessRight { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            _privilegeNames = _repository.Get(
                                new QueryExpression("privilege")
                                {
                                    ColumnSet = new ColumnSet("privilegeid", "name")
                                })
                              .Select(p => new { Id = p.Id, Name = p.GetAttributeValue<string>("name") })
                              .ToDictionary(k => k.Name, v => v.Id);
        }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case RemoveRolePrivilegeForEntityParameterSet:
                    RemovePrivilegesForEntity();
                    break;
                case RemoveRolePrivilegesByNameParameterSet:
                    RemovePrivilegesByName();
                    break;
                default:
                    break;
            }
        }

        private void RemovePrivilegesByName()
        {
            foreach (Guid roleId in Role)
            {
                foreach (string privilegeName in PrivilegeName)
                {
                    if (_privilegeNames.ContainsKey(privilegeName))
                    {
                        ExecuteAction($"{privilegeName}", "Remove", () =>
                        {
                            _repository.Execute("RemovePrivilegeRole", new System.Collections.Hashtable()
                            {
                                { "RoleId", roleId },
                                { "PrivilegeId", _privilegeNames[privilegeName] }
                            });
                        });
                    }
                }
            }
        }

        private void RemovePrivilegesForEntity()
        {
            foreach (Guid roleId in Role)
            {
                IEnumerable<Entity> entityPrivileges = 
                    SecurityManagementHelper.GetEntityPrivileges(_repository, EntityLogicalName)
                    .Where(e => {
                        CrmAccessRight privilegeAccessRight = (CrmAccessRight)e.GetAttributeValue<int>("accessright");
                        return (AccessRight & privilegeAccessRight) == privilegeAccessRight;
                    });

                if (entityPrivileges != null && entityPrivileges.Count() > 0)
                {
                    foreach (var privilege in entityPrivileges)
                    {
                        ExecuteAction($"{privilege.GetAttributeValue<string>("name")}", "Remove", () =>
                        {
                            _repository.Execute("RemovePrivilegeRole", new System.Collections.Hashtable()
                            {
                                { "RoleId", roleId },
                                { "PrivilegeId", privilege.Id }
                            });
                        });
                    }
                }
            }
        }
    }
}
