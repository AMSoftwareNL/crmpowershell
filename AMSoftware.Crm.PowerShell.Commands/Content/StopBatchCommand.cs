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
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands.Content
{
    [Cmdlet(VerbsLifecycle.Stop, "CrmBatch", HelpUri = HelpUrlConstants.StopBatchHelpUrl)]
    public sealed class StopBatchCommand : CrmOrganizationConfirmActionCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (CrmContext.Session.BatchActive)
            {
                ExecuteAction("Batch", "Stop", delegate
                {
                    CrmContext.Session.BatchActive = false;
                });
            } else
            {
                WriteWarning("No active Batch to stop.");
            }
        }
    }
}
