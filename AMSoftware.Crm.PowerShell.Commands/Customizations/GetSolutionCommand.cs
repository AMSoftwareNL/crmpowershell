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

namespace AMSoftware.Crm.PowerShell.Commands.Customizations
{
    [Cmdlet(VerbsCommon.Get, "Solution", HelpUri = HelpUrlConstants.GetSolutionHelpUrl, SupportsPaging = true, DefaultParameterSetName = GetSolutionParameterSet)]
    [OutputType(typeof(Entity))]
    public class GetSolutionCommand : CrmOrganizationCmdlet
    {
        private const string GetSolutionParameterSet = "GetSolution";
        private const string GetSolutionByIdParameterSet = "GetSolutionById";
        private const string GetSolutionByNameParameterSet = "GetSolutionByName";

        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = GetSolutionByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = GetSolutionByIdParameterSet)]
        [ValidateNotNull]
        public Guid Id { get; set; }

        [Parameter(ParameterSetName = GetSolutionParameterSet)]
        public SwitchParameter ExcludeManaged { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case GetSolutionParameterSet:
                    GetContentByQuery(BuildSolutionQuery(ExcludeManaged.ToBool()));
                    break;
                case GetSolutionByIdParameterSet:
                    WriteObject(_repository.Get("solution", Id, null));
                    break;
                case GetSolutionByNameParameterSet:
                    GetContentByQuery(BuildByNameQuery(Name));
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
            
            foreach (var item in _repository.Get(query))
            {
                WriteObject(item);
            }
        }

        private static QueryExpression BuildByNameQuery(string name)
        {
            QueryExpression query = new QueryExpression("solution")
            {
                ColumnSet = new ColumnSet(true)
            };

            FilterExpression nameFilter = new FilterExpression(LogicalOperator.Or);
            nameFilter.AddCondition(new ConditionExpression("friendlyname", ConditionOperator.Equal, name));
            nameFilter.AddCondition(new ConditionExpression("uniquename", ConditionOperator.Equal, name));

            query.Criteria.AddFilter(nameFilter);

            return query;
        }

        private static QueryExpression BuildSolutionQuery(bool excludeManaged)
        {
            QueryExpression query = new QueryExpression("solution")
            {
                ColumnSet = new ColumnSet(true)
            };

            if (excludeManaged)
            {
                query.Criteria.AddCondition("ismanaged", ConditionOperator.NotEqual, true);
            }

            return query;
        }
    }
}
