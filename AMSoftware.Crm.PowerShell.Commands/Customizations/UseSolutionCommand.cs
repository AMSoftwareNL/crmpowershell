﻿/*
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

namespace AMSoftware.Crm.PowerShell.Commands.Customizations
{
    [Cmdlet(VerbsOther.Use, "CrmSolution", HelpUri = HelpUrlConstants.UseSolutionHelpUrl)]
    public sealed class UseSolutionCommand : CrmOrganizationCmdlet
    {
        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Position = 1, ValueFromPipeline = true)]
        [Alias("Id")]
        [ValidateNotNull]
        public Guid Solution { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Solution)) && Solution != Guid.Empty)
            {
                string solutionName = SolutionManagementHelper.GetSolutionUniqueName(_repository, Solution, false);
                if (!string.IsNullOrWhiteSpace(solutionName))
                {
                    CrmContext.Session.ActiveSolutionName = solutionName;
                    CrmContext.Session.ActiveSolutionId = Solution;
                }
            }
            else
            {
                CrmContext.Session.ActiveSolutionName = null;
                CrmContext.Session.ActiveSolutionId = Guid.Empty;
            }
        }
    }
}
