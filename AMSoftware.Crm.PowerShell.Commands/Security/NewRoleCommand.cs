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
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Helpers;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Commands.Security
{
    [Cmdlet(VerbsCommon.New, "CrmRole", HelpUri = HelpUrlConstants.NewRoleHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class NewRoleCommand : CrmOrganizationCmdlet
    {
        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Guid BusinessUnit { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        [PSDefaultValue(Value = CrmRoleInheritance.DirectUser)]
        public CrmRoleInheritance Inheritance { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Guid businessUnitId = this.MyInvocation.BoundParameters.ContainsKey(nameof(BusinessUnit)) ? BusinessUnit : SecurityManagementHelper.GetDefaultBusinessUnitId(_repository);

            Entity newRole = new Entity("role")
            {
                Attributes = new AttributeCollection()
            };
            newRole.Attributes.Add("name", Name);
            newRole.Attributes.Add("businessunitid", new EntityReference("businessunit", businessUnitId));
            newRole.Attributes.Add("isinherited", this.MyInvocation.BoundParameters.ContainsKey(nameof(Inheritance)) ? new OptionSetValue((int)Inheritance) : new OptionSetValue((int)CrmRoleInheritance.DirectUser)); 

            Guid newRoleId = _repository.Add(newRole);

            if (PassThru)
            {
                WriteObject(_repository.Get("role", newRoleId));
            }
        }
    }
}
