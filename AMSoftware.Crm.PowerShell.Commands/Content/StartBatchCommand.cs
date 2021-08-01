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
using AMSoftware.Crm.PowerShell.Common;
using System;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands.Content
{
    [Cmdlet(VerbsLifecycle.Start, "CrmBatch", HelpUri = HelpUrlConstants.StartBatchHelpUrl)]
    public sealed class StartBatchCommand : CrmOrganizationCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (CrmContext.Session.BatchActive)
            {
                throw new InvalidOperationException("A Batch is already active. Submit or Stop the current batch before starting a new one.");
            } else
            {
                CrmContext.Session.BatchActive = true; 
            }
        }
    }
}
