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
using System.Linq;
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
        private const string GetProcessByIdParameterSet = "GetProcessById";

        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = GetProcessByIdParameterSet, ValueFromPipeline = true)]
        [ValidateNotNull]
        public Guid Id { get; set; }

        [Parameter(Mandatory = false, Position = 0, ParameterSetName = GetAllProcessesParameterSet)]
        [Alias("Include")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(ParameterSetName = GetAllProcessesParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Exclude { get; set; }

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
                case GetProcessByIdParameterSet:
                    WriteObject(_repository.Get("workflow", Id));
                    break;
                case GetAllProcessesParameterSet:
                    GetFilteredContent();
                    break;
                default:
                    break;
            }
        }

        private void GetFilteredContent()
        {
            QueryExpression advancedFilterQuery = BuildProcessesByFilterQuery();

            if (PagingParameters.IncludeTotalCount)
            {
                int count = _repository.GetRowCount(advancedFilterQuery, out double accuracy);
                WriteObject(PagingParameters.NewTotalCount(Convert.ToUInt64(count), accuracy));
            }

            var result = _repository.Get(advancedFilterQuery, PagingParameters.First, PagingParameters.Skip);
            if (!string.IsNullOrWhiteSpace(Name))
            {
                WildcardPattern includePattern = new WildcardPattern(Name, WildcardOptions.IgnoreCase);
                result = result.Where(a => includePattern.IsMatch(a.GetAttributeValue<string>("name")));
            }
            if (!string.IsNullOrWhiteSpace(Exclude))
            {
                WildcardPattern excludePattern = new WildcardPattern(Exclude, WildcardOptions.IgnoreCase);
                result = result.Where(a => !(excludePattern.IsMatch(a.GetAttributeValue<string>("name"))));
            }

            WriteObject(result, true);
        }

        private QueryExpression BuildProcessesByFilterQuery()
        {
            QueryExpression query = new QueryExpression("workflow")
            {
                ColumnSet = new ColumnSet(true),
                Orders = {
                    new OrderExpression("primaryentity", OrderType.Ascending),
                    new OrderExpression("name", OrderType.Ascending),
                }
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
