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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands.Security
{
    [Cmdlet(VerbsCommon.Get, "CrmRolePrivileges", HelpUri = HelpUrlConstants.GetRolePrivilegesHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class GetRolePrivilegesCommand : CrmOrganizationCmdlet
    {
        private readonly ContentRepository _repository = new ContentRepository();

        private IEnumerable<Entity> _allPrivileges;
        private IEnumerable<Guid> _entityPriviligeIds;

        [Parameter(Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [Alias("Id")]
        [ValidateNotNullOrEmpty]
        public Guid Role { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Include { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Exclude { get; set; }

        [Parameter]
        public SwitchParameter EntityPrivilegesOnly { get; set; }

        [Parameter]
        public SwitchParameter OtherPrivilegesOnly { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            _allPrivileges = _repository.Get(
                new QueryExpression("privilege")
                {
                    ColumnSet = new ColumnSet(true)
                }).ToList();

            _entityPriviligeIds = _repository.Get(
                new QueryExpression("privilegeobjecttypecodes")
                {
                    ColumnSet = new ColumnSet("privilegeid"),
                    Criteria = {
                        Conditions = {
                            //new ConditionExpression("objecttypecode", ConditionOperator.ContainValues),
                            new ConditionExpression("objecttypecode", ConditionOperator.NotEqual, "none")
                        }
                    }
                }).Select(etn => etn.GetAttributeValue<EntityReference>("privilegeid").Id).ToList();
        }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            OrganizationResponse response = _repository.Execute("RetrieveRolePrivilegesRole", new System.Collections.Hashtable() {
                    { "RoleId", Role }
                });

            if (response.Results != null && response.Results.ContainsKey("RolePrivileges") && response["RolePrivileges"] != null)
            {
                RolePrivilege[] rolePrivileges = (RolePrivilege[])response["RolePrivileges"];

                var output = from rolePrivilege in rolePrivileges
                             join privilege in _allPrivileges
                             on rolePrivilege.PrivilegeId equals privilege.Id
                             select privilege;

                if (!string.IsNullOrWhiteSpace(Include))
                {
                    WildcardPattern includePattern = new WildcardPattern(Include, WildcardOptions.IgnoreCase);
                    output = output.Where(a => includePattern.IsMatch(a.GetAttributeValue<string>("name")));
                }
                if (!string.IsNullOrWhiteSpace(Exclude))
                {
                    WildcardPattern excludePattern = new WildcardPattern(Exclude, WildcardOptions.IgnoreCase);
                    output = output.Where(a => !(excludePattern.IsMatch(a.GetAttributeValue<string>("name"))));
                }

                if (EntityPrivilegesOnly.ToBool())
                {
                    output = output.Where(o => _entityPriviligeIds.Contains(o.Id));
                }
                if (OtherPrivilegesOnly.ToBool())
                {
                    output = output.Where(o => !_entityPriviligeIds.Contains(o.Id));
                }

                WriteObject(output, true);
            }
        }
    }
}
