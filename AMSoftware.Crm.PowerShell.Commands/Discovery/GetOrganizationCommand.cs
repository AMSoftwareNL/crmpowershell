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
using System.Management.Automation;
using System.Linq;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk.Discovery;
using System.Collections.Generic;

namespace AMSoftware.Crm.PowerShell.Commands.Discovery
{
    [Cmdlet(VerbsCommon.Get, "Organization", HelpUri = HelpUrlConstants.GetOrganizationHelpUrl)]
    [OutputType(typeof(OrganizationDetail))]
    public sealed class GetOrganizationCommand : CrmDiscoveryCmdlet
    {
        private DeploymentRepository _repository = new DeploymentRepository();

        [Parameter(Position = 0)]
        [Alias("Include")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter()]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Exclude { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            IEnumerable<OrganizationDetail> result = _repository.GetOrganization();
            
            if (!string.IsNullOrWhiteSpace(Name))
            {
                WildcardPattern includePattern = new WildcardPattern(Name, WildcardOptions.IgnoreCase);
                result = result.Where(o => 
                    includePattern.IsMatch(o.UniqueName) ||
                    includePattern.IsMatch(o.FriendlyName) ||
                    includePattern.IsMatch(o.UrlName)
                );
            }
            if (!string.IsNullOrWhiteSpace(Exclude))
            {
                WildcardPattern excludePattern = new WildcardPattern(Exclude, WildcardOptions.IgnoreCase);
                result = result.Where(o =>
                    !(excludePattern.IsMatch(o.UniqueName) ||
                    excludePattern.IsMatch(o.FriendlyName) ||
                    excludePattern.IsMatch(o.UrlName))
                );
            }

            result = result.OrderBy(o => o.UrlName);

            WriteObject(result, true);
        }
    }
}
