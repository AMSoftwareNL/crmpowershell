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
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xrm.Sdk.Discovery;

namespace AMSoftware.Crm.PowerShell.Common.Repositories
{
    public sealed class DeploymentRepository
    {
        public IEnumerable<OrganizationDetail> GetOrganization()
        {
            RetrieveOrganizationsRequest request = new RetrieveOrganizationsRequest();
            RetrieveOrganizationsResponse response = (RetrieveOrganizationsResponse)CrmContext.DiscoveryProxy.Execute(request);

            if (response.Details == null || response.Details.Count == 0) return null;

            return response.Details.AsEnumerable();
        }

        public OrganizationDetail GetOrganization(string name)
        {
            RetrieveOrganizationsRequest request = new RetrieveOrganizationsRequest();
            RetrieveOrganizationsResponse response = (RetrieveOrganizationsResponse)CrmContext.DiscoveryProxy.Execute(request);

            if (response.Details == null || response.Details.Count == 0) return null;

            OrganizationDetail result = response.Details.SingleOrDefault(o => o.UniqueName.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            if (result == null)
            {
                result = response.Details.SingleOrDefault(o => o.UrlName.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            }
            if (result == null)
            {
                result = response.Details.SingleOrDefault(o => o.FriendlyName.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            }

            return result;
        }
    }
}
