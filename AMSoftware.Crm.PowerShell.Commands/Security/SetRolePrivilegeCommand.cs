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
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands.Security
{
    [Cmdlet(VerbsCommon.Set, "CrmRolePrivilege", HelpUri = HelpUrlConstants.SetRolePrivilegesHelpUrl, DefaultParameterSetName = SetRolePrivilegeForEntityParameterSet)]
    [OutputType(typeof(Entity))]
    public sealed class SetRolePrivilegeCommand : CrmOrganizationCmdlet
    {
        private const string SetRolePrivilegeForEntityParameterSet = "SetRolePrivilegeForEntity";
        private const string SetRolePrivilegesByNameParameterSet = "SetRolePrivilegesByName";

        private readonly ContentRepository _repository = new ContentRepository();

        private Dictionary<string, Guid> _privilegeNames;

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [Alias("Id")]
        [ValidateNotNullOrEmpty]
        public Guid[] Role { get; set; }

        [Parameter(Mandatory = true, ValueFromRemainingArguments = true, ParameterSetName = SetRolePrivilegesByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string[] PrivilegeName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = SetRolePrivilegeForEntityParameterSet)]
        [Alias("LogicalName")]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        [ValidateNotNullOrEmpty]
        public string EntityLogicalName { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = SetRolePrivilegeForEntityParameterSet)]
        [ValidateNotNullOrEmpty]
        public CrmAccessRight AccessRight { get; set; }

        [Parameter(Mandatory = true, Position = 3)]
        [ValidateNotNullOrEmpty]
        public CrmAccessScope Scope { get; set; }

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
                case SetRolePrivilegeForEntityParameterSet:
                    SetPrivilegeForEntity();
                    break;
                case SetRolePrivilegesByNameParameterSet:
                    SetPrivilegesByName();
                    break;
                default:
                    break;
            }
        }

        private void SetPrivilegesByName()
        {
            foreach (Guid roleId in Role)
            {
                // List of Priviliges to set on Role
                var privileges = from selectedPrivilegeName in PrivilegeName
                                 join privilege in _privilegeNames
                                 on selectedPrivilegeName equals privilege.Key
                                 select new RolePrivilege((int)Scope, privilege.Value);

                if (privileges.Count() == 0)
                {
                    WriteWarningWithTimestamp("No matching Privileges found");
                }
                else
                {
                    _repository.Execute("AddPrivilegesRole", new System.Collections.Hashtable()
                    {
                        { "RoleId", roleId },
                        { "Privileges", privileges.ToArray() }
                    });
                }
            }
        }

        private void SetPrivilegeForEntity()
        {
            foreach (Guid roleId in Role)
            {
                IEnumerable<Entity> entityPrivileges =
                    SecurityManagementHelper.GetEntityPrivileges(_repository, EntityLogicalName)
                    .Where(e =>
                    {
                        CrmAccessRight privilegeAccessRight = (CrmAccessRight)e.GetAttributeValue<int>("accessright");
                        return (AccessRight & privilegeAccessRight) == privilegeAccessRight;
                    });

                if (entityPrivileges != null && entityPrivileges.Count() > 0)
                {
                    var privileges = entityPrivileges.Select(p => new RolePrivilege((int)Scope, p.Id));

                    _repository.Execute("AddPrivilegesRole", new System.Collections.Hashtable()
                    {
                        { "RoleId", roleId },
                        { "Privileges", privileges.ToArray() }
                    });
                }
                else
                {
                    WriteWarningWithTimestamp($"No Privileges found for '{EntityLogicalName}' with '{AccessRight}'");
                }
            }
        }
    }
}
