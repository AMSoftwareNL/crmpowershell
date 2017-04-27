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
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk.Discovery;

namespace AMSoftware.Crm.PowerShell.Commands.Discovery
{
    [Cmdlet(VerbsCommunications.Connect, "Organization", HelpUri = HelpUrlConstants.ConnectOrganizationHelpUrl)]
    [OutputType(typeof(OrganizationDetail))]
    public sealed class ConnectOrganizationCommand : CrmDiscoveryCmdlet
    {
        private DeploymentRepository _repository = new DeploymentRepository();

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ConnectByName();
        }

        private void ConnectByName()
        {
            var org = _repository.GetOrganization(Name);
            if (org == null)
            {
                base.ThrowTerminatingError(new ErrorRecord(new InvalidOperationException(), "", ErrorCategory.InvalidData, this));
            }
            CrmContext.ConnectOrganization(org);

            WriteObject(org, false);
        }
    }
}
