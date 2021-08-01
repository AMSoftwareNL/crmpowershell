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
using AMSoftware.Crm.PowerShell.Commands.Helpers;
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Helpers;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using System;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Set, "CrmSession", HelpUri = HelpUrlConstants.SetSessionHelpUrl)]
    public sealed class SetSessionCommand : CrmOrganizationCmdlet
    {
        [Parameter]
        [ValidateNotNullOrEmpty]
        public int Language { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public Guid Solution { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public bool UseMetadataCache { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Language)))
            {
                CrmContext.Session.Language = Language;
            }

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(UseMetadataCache)))
            {
                CrmContext.Session.UseMetadataCache = UseMetadataCache;
            }

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Solution)))
            {
                if (Solution == Guid.Empty)
                {
                    CrmContext.Session.ActiveSolutionName = null;
                    CrmContext.Session.ActiveSolutionId = Guid.Empty;
                }
                else
                {
                    ContentRepository repository = new ContentRepository();
                    string solutionName = SolutionManagementHelper.GetSolutionUniqueName(repository, Solution, false);
                    if (!string.IsNullOrWhiteSpace(solutionName))
                    {
                        CrmContext.Session.ActiveSolutionName = solutionName;
                        CrmContext.Session.ActiveSolutionId = Solution;
                    }
                }
            }
        }
    }
}
