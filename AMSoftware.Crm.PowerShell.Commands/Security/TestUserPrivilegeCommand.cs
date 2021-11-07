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
    [Cmdlet(VerbsDiagnostic.Test, "CrmUserPrivilege", HelpUri = HelpUrlConstants.TestUserPrivilegeHelpUrl)]
    [OutputType(typeof(bool))]
    public sealed class TestUserPrivilegeCommand : CrmOrganizationCmdlet
    {
        private const string TestUserPrivilegeForEntityParameterSet = "TestUserPrivilegeForEntity";
        private const string TestUserPrivilegesByNameParameterSet = "TestUserPrivilegesByName";

        private readonly ContentRepository _repository = new ContentRepository();

        private IEnumerable<Entity> _allPrivileges;

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [Alias("Id")]
        [ValidateNotNullOrEmpty]
        public Guid User { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = TestUserPrivilegesByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string PrivilegeName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = TestUserPrivilegeForEntityParameterSet)]
        [Alias("LogicalName")]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        [ValidateNotNullOrEmpty]
        public string EntityLogicalName { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = TestUserPrivilegeForEntityParameterSet)]
        [ValidateNotNullOrEmpty]
        public CrmAccessRight AccessRight { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            _allPrivileges = _repository.Get(
                new QueryExpression("privilege")
                {
                    ColumnSet = new ColumnSet(true)
                });
        }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case TestUserPrivilegeForEntityParameterSet:
                    TestPrivilegeForEntity();
                    break;
                case TestUserPrivilegesByNameParameterSet:
                    TestPrivilegesByName();
                    break;
                default:
                    break;
            }
        }

        private void TestPrivilegeForEntity()
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
                foreach (var entityPrivilege in entityPrivileges)
                {
                    OrganizationResponse response = _repository.Execute("RetrieveUserPrivilegeByPrivilegeName", new System.Collections.Hashtable() {
                        { "UserId", User },
                        { "PrivilegeName", entityPrivilege.GetAttributeValue<string>("name") }
                    });

                    if (response.Results != null && response.Results.ContainsKey("RolePrivileges") && response["RolePrivileges"] != null)
                    {
                        RolePrivilege[] rolePrivileges = (RolePrivilege[])response["RolePrivileges"];
                        WriteObject(rolePrivileges.Length > 0, false);
                    }
                    else
                    {
                        WriteObject(false, false);
                    }
                }
            }
            else
            {
                WriteObject(false, false);
            }
        }

        private void TestPrivilegesByName()
        {
            OrganizationResponse response = _repository.Execute("RetrieveUserPrivilegeByPrivilegeName", new System.Collections.Hashtable() {
                { "UserId", User },
                { "PrivilegeName", PrivilegeName }
            });

            if (response.Results != null && response.Results.ContainsKey("RolePrivileges") && response["RolePrivileges"] != null)
            {
                RolePrivilege[] rolePrivileges = (RolePrivilege[])response["RolePrivileges"];
                WriteObject(rolePrivileges.Length > 0, false);
            }
            else
            {
                WriteObject(false, false);
            }
        }
    }
}
