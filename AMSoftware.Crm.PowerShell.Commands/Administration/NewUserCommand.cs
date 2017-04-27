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
using AMSoftware.Crm.PowerShell.Commands;
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Helpers;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Commands.Administration
{
    [Cmdlet(VerbsCommon.New, "User", HelpUri = HelpUrlConstants.NewUserHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class NewUserCommand : CrmOrganizationCmdlet
    {
        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateNotNullOrEmpty]
        public string Firstname { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        [ValidateNotNullOrEmpty]
        public string Lastname { get; set; }

        [Parameter]
        [PSDefaultValue(Value = CrmUserAccessMode.ReadWrite)]
        public CrmUserAccessMode Access { get; set; }

        [Parameter]
        [PSDefaultValue(Value = CrmUserClientLicense.Pro)]
        public CrmUserClientLicense License { get; set; }

        [Parameter(ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Guid? BusinessUnit { get; set; }

        [Parameter(ValueFromRemainingArguments = true)]
        [ValidateNotNull]
        public Guid[] Roles { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Guid[] roleIds = Roles;
            Guid businessUnitId = BusinessUnit ?? SecurityManagementHelper.GetDefaultBusinessUnitId(_repository);

            Entity newUser = new Entity("systemuser");
            newUser.Attributes = new AttributeCollection();
            newUser.Attributes.Add("domainname", UserName);
            newUser.Attributes.Add("firstname", Firstname);
            newUser.Attributes.Add("lastname", Lastname);
            newUser.Attributes.Add("accessmode", new OptionSetValue((int)Access));
            newUser.Attributes.Add("caltype", new OptionSetValue((int)License));
            newUser.Attributes.Add("businessunitid", new EntityReference("businessunit", businessUnitId));

            Guid newUserId = _repository.Add(newUser);
            SecurityManagementHelper.LinkPrincipalRoles(_repository, "systemuser", newUserId, "role", roleIds);

            WriteObject(_repository.Get("systemuser", newUserId));
        }
    }
}
