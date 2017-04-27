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
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace AMSoftware.Crm.PowerShell.Commands.Administration
{
    [Cmdlet(VerbsLifecycle.Stop, "Process", HelpUri = HelpUrlConstants.StopProcessHelpUrl, ConfirmImpact = ConfirmImpact.High, SupportsShouldProcess = true, DefaultParameterSetName = StopProcessByAsyncOperationParameterSet)]
    public sealed class StopProcessCommand : CrmOrganizationConfirmActionCmdlet
    {
        private const string StopProcessByAsyncOperationParameterSet = "StopProcessByAsyncOperation";
        private const string StopProcessByWorkflowParameterSet = "StopProcessByWorkflow";

        private ContentRepository _repository = new ContentRepository();

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = StopProcessByAsyncOperationParameterSet)]
        [ValidateNotNull]
        public Guid ASyncOperation { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = StopProcessByWorkflowParameterSet)]
        [ValidateNotNull]
        public Guid Process { get; set; }

        [Parameter(Position = 5, Mandatory = false, ValueFromPipeline = true, ParameterSetName = StopProcessByWorkflowParameterSet)]
        [ValidateNotNull]
        public Guid Record { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case StopProcessByAsyncOperationParameterSet:
                    StopASyncOperation();
                    break;
                case StopProcessByWorkflowParameterSet:
                    StopProcess();
                    break;
                default:
                    break;
            }
        }

        private void StopASyncOperation()
        {
            Entity asyncOperation = _repository.Get("asyncoperation", ASyncOperation);
            OptionSetValue asyncOperationStatus = asyncOperation.GetAttributeValue<OptionSetValue>("statuscode");

            if (asyncOperationStatus.Value == 0 /* Wating for Resources */ || asyncOperationStatus.Value == 10 /* Waiting */ || asyncOperationStatus.Value == 20 /* In Process */)
            {
                ExecuteAction(string.Format("{0}: {1}", asyncOperation.LogicalName, asyncOperation.Id), delegate
                {
                    asyncOperation["statecode"] = new OptionSetValue(3);
                    asyncOperation["statuscode"] = new OptionSetValue(32);

                    _repository.Update(asyncOperation);
                });
            }
        }

        private void StopProcess()
        {
            QueryExpression query = GetRunningProcessesQuery();
            foreach (var asyncOperation in _repository.Get(query))
            {
                OptionSetValue asyncOperationStatus = asyncOperation.GetAttributeValue<OptionSetValue>("statuscode");
                if (asyncOperationStatus.Value == 0 /* Wating for Resources */ || asyncOperationStatus.Value == 10 /* Waiting */ || asyncOperationStatus.Value == 20 /* In Process */)
                {
                    ExecuteAction(string.Format("{0}: {1}", asyncOperation.LogicalName, asyncOperation.Id), delegate
                    {
                        asyncOperation["statecode"] = new OptionSetValue(3);
                        asyncOperation["statuscode"] = new OptionSetValue(32);

                        _repository.Update(asyncOperation);
                    });
                }
            }
        }

        private QueryExpression GetRunningProcessesQuery()
        {
            QueryExpression query = new QueryExpression("asyncoperation")
            {
                ColumnSet = new ColumnSet("statecode", "statuscode")
            };
            query.Criteria.AddCondition("statuscode", ConditionOperator.In, 0, 10, 20);

            LinkEntity processEntity = query.AddLink("workflow", "workflowactivationid", "workflowid");
            processEntity.LinkCriteria.AddCondition("parentworkflowid", ConditionOperator.Equal, Process);

            if (Record != Guid.Empty)
            {
                query.Criteria.AddCondition("regardingobjectid", ConditionOperator.Equal, Record);
            }

            return query;
        }
    }
}
