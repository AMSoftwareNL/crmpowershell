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
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace AMSoftware.Crm.PowerShell.Commands.Administration
{
    [Cmdlet(VerbsCommon.Get, "Process", HelpUri = HelpUrlConstants.GetProcessHelpUrl, SupportsPaging = true, DefaultParameterSetName = GetAllProcessesParameterSet)]
    [OutputType(typeof(Entity))]
    public sealed class GetProcessCommand : CrmOrganizationCmdlet
    {
        private const string GetAllProcessesParameterSet = "GetAllProcesses";
        private const string GetProcessByNameParameterSet = "GetProcessByName";
        private const string GetProcessByIdParameterSet = "GetProcessById";

        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = GetProcessByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = GetProcessByIdParameterSet)]
        [ValidateNotNull]
        public Guid Id { get; set; }

        [Parameter(Mandatory = false, Position = 10, ParameterSetName = GetAllProcessesParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Entity { get; set; }

        [Parameter(Mandatory = false, Position = 30, ParameterSetName = GetAllProcessesParameterSet)]
        [PSDefaultValue(Value = CrmProcessType.All)]
        public CrmProcessType? ProcessType { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case GetProcessByNameParameterSet:
                    QueryExpression nameQuery = BuildProcessesByNameQuery();
                    GetContentByQuery(nameQuery);
                    break;
                case GetProcessByIdParameterSet:
                    WriteObject(_repository.Get("workflow", Id));
                    break;
                case GetAllProcessesParameterSet:
                    QueryExpression advancedFilterQuery = BuildProcessesByFilterQuery();
                    GetContentByQuery(advancedFilterQuery);
                    break;
                default:
                    break;
            }
        }

        private void GetContentByQuery(QueryBase query)
        {
            if (PagingParameters.IncludeTotalCount)
            {
                double accuracy;
                int count = _repository.GetRowCount(query, out accuracy);
                WriteObject(PagingParameters.NewTotalCount(Convert.ToUInt64(count), accuracy));
            }

            foreach (var item in _repository.Get(query, PagingParameters.First, PagingParameters.Skip))
            {
                WriteObject(item);
            }
        }

        private QueryExpression BuildProcessesByNameQuery()
        {
            QueryExpression query = new QueryExpression("workflow")
            {
                ColumnSet = new ColumnSet(true),
                Criteria =
                {
                    Filters = {
                            new FilterExpression(LogicalOperator.Or)
                            {
                                Conditions =
                                    {
                                        new ConditionExpression("name", ConditionOperator.Equal, Name),
                                        new ConditionExpression("uniquename", ConditionOperator.Equal, Name)
                                    }
                            }
                        }
                }
            };
            return query;
        }

        private QueryExpression BuildProcessesByFilterQuery()
        {
            QueryExpression query = new QueryExpression("workflow")
            {
                ColumnSet = new ColumnSet(true),
            };

            FilterExpression filter = new FilterExpression(LogicalOperator.And);
            if (!string.IsNullOrWhiteSpace(Entity)) filter.AddCondition("primaryentity", ConditionOperator.Equal, Entity);

            if (ProcessType.HasValue && ProcessType.Value != CrmProcessType.All) filter.AddCondition("category", ConditionOperator.Equal, (int)ProcessType.Value);

            if (filter.Conditions.Count > 0)
            {
                query.Criteria.AddFilter(filter);
            }

            return query;
        }
    }
}
