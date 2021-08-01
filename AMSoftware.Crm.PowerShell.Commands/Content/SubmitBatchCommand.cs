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
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands.Content
{
    [Cmdlet(VerbsLifecycle.Submit, "CrmBatch", HelpUri = HelpUrlConstants.SubmitBatchHelpUrl, DefaultParameterSetName = AsMultipleParameterSet)]
    [OutputType(typeof(OrganizationResponse), ParameterSetName = new string[] { AsTransactionParameterSet })]
    [OutputType(typeof(ExecuteMultipleResponseItem), ParameterSetName = new string[] { AsMultipleParameterSet })]
    public sealed class SubmitBatchCommand : CrmOrganizationCmdlet
    {
        private const string AsTransactionParameterSet = "AsTransaction";
        private const string AsMultipleParameterSet = "AsMultiple";

        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(ParameterSetName = AsTransactionParameterSet)]
        public SwitchParameter AsTransaction { get; set; }

        [Parameter(ParameterSetName = AsMultipleParameterSet)]
        public SwitchParameter ContinueOnError { get; set; }

        [Parameter]
        public SwitchParameter ReturnResponses { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (CrmContext.Session.BatchActive)
            {
                try
                {
                    switch (ParameterSetName)
                    {
                        case AsTransactionParameterSet:
                            var transactionResponses = _repository.ExecuteTransaction(CrmContext.Session.BatchRequestCollection, ReturnResponses.ToBool());

                            if (ReturnResponses)
                            {
                                WriteObject(transactionResponses, true);
                            }
                            break;
                        case AsMultipleParameterSet:
                            bool success = _repository.TryExecuteMultiple(
                                CrmContext.Session.BatchRequestCollection,
                                ReturnResponses.ToBool(),
                                ContinueOnError.ToBool(),
                                out IEnumerable<ExecuteMultipleResponseItem> responses);

                            if (!success)
                            {
                                WriteWarning("Batch completed with faults.");
                            }

                            if (ReturnResponses)
                                WriteObject(responses, true);
                            else
                                WriteObject(success);
                            break;
                        default:
                            break;
                    }
                } finally
                {
                    CrmContext.Session.BatchActive = false;
                }
            }
            else
            {
                WriteWarning("No active Batch to submit.");
            }
        }
    }
}
