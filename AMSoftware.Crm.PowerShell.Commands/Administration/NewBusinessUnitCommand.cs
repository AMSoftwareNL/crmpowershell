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
using AMSoftware.Crm.PowerShell.Common.Helpers;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Commands.Administration
{
    [Cmdlet(VerbsCommon.New, "BusinessUnit", HelpUri = HelpUrlConstants.NewBusinessUnitHelpUrl)]
    [OutputType(typeof(Entity))]
    public class NewBusinessUnitCommand : CrmOrganizationCmdlet
    {
        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Guid? Parent { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Guid businessUnitId = Parent ?? SecurityManagementHelper.GetDefaultBusinessUnitId(_repository);

            Entity newBusinessUnit = new Entity("businessunit");
            newBusinessUnit.Attributes = new AttributeCollection();
            newBusinessUnit.Attributes.Add("name", Name);
            newBusinessUnit.Attributes.Add("parentbusinessunitid", new EntityReference("businessunit", businessUnitId));

            Guid newBusinessUnitId = _repository.Add(newBusinessUnit);
            WriteObject(_repository.Get("businessunit", newBusinessUnitId));
        }
    }
}
