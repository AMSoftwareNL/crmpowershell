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
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands.Security
{
    [Cmdlet(VerbsCommon.New, "CrmApplication", HelpUri = HelpUrlConstants.NewApplicationHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class NewApplicationCommand : CrmOrganizationCmdlet
    {
        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0)]
        [ValidateNotNullOrEmpty]
        public Guid AppId { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public Guid BusinessUnit { get; set; }

        [Parameter(ValueFromRemainingArguments = true)]
        [ValidateNotNull]
        public Guid[] Roles { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Guid[] roleIds = Roles;
            Guid businessUnitId = this.MyInvocation.BoundParameters.ContainsKey(nameof(BusinessUnit)) ? BusinessUnit : SecurityManagementHelper.GetDefaultBusinessUnitId(_repository);

            Entity newUser = new Entity("systemuser")
            {
                Attributes = new AttributeCollection()
            };
            newUser.Attributes.Add("applicationid", AppId);
            newUser.Attributes.Add("businessunitid", new EntityReference("businessunit", businessUnitId));

            Guid newUserId = _repository.Add(newUser);

            if (roleIds != null && roleIds.Length != 0)
            {
                SecurityManagementHelper.LinkPrincipalRoles(_repository, "systemuser", newUserId, "role", roleIds);
            }

            if (PassThru)
            {
                WriteObject(_repository.Get("systemuser", newUserId));
            }
        }
    }

}
