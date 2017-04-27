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
using System.Linq;
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace AMSoftware.Crm.PowerShell.Commands.Administration
{
    [Cmdlet(VerbsCommon.Get, "BusinessUnit", HelpUri = HelpUrlConstants.GetBusinessUnitHelpUrl, SupportsPaging = true, DefaultParameterSetName = GetAllBusinessUnitsParameterSet)]
    [OutputType(typeof(Entity))]
    public sealed class GetBusinessUnitCommand : CrmOrganizationCmdlet
    {
        private const string GetAllBusinessUnitsParameterSet = "GetAllBusinessUnits";
        private const string GetBusinessUnitByIdParameterSet = "GetBusinessUnitById";

        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = GetBusinessUnitByIdParameterSet)]
        [ValidateNotNull]
        public Guid Id { get; set; }

        [Parameter(ParameterSetName = GetAllBusinessUnitsParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Include { get; set; }

        [Parameter(ParameterSetName = GetAllBusinessUnitsParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Exclude { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = GetAllBusinessUnitsParameterSet)]
        [ValidateNotNullOrEmpty]
        public Guid? Parent { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case GetAllBusinessUnitsParameterSet:
                    GetFilteredContent();
                    break;
                case GetBusinessUnitByIdParameterSet:
                    WriteObject(_repository.Get("businessunit", Id));
                    break;
                default:
                    break;
            }
        }

        private void GetFilteredContent()
        {
            QueryExpression advancedFilterQuery = BuildBusinessUnitByFilterQuery();

            if (PagingParameters.IncludeTotalCount)
            {
                double accuracy;
                int count = _repository.GetRowCount(advancedFilterQuery, out accuracy);
                WriteObject(PagingParameters.NewTotalCount(Convert.ToUInt64(count), accuracy));
            }

            var result = _repository.Get(advancedFilterQuery, PagingParameters.First, PagingParameters.Skip);
            if (!string.IsNullOrWhiteSpace(Include))
            {
                WildcardPattern includePattern = new WildcardPattern(Include, WildcardOptions.IgnoreCase);
                result = result.Where(a => includePattern.IsMatch(a.GetAttributeValue<string>("name")));
            }
            if (!string.IsNullOrWhiteSpace(Exclude))
            {
                WildcardPattern excludePattern = new WildcardPattern(Exclude, WildcardOptions.IgnoreCase);
                result = result.Where(a => !(excludePattern.IsMatch(a.GetAttributeValue<string>("name"))));
            }

            WriteObject(result, true);
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

        private QueryExpression BuildBusinessUnitByFilterQuery()
        {
            QueryExpression query = new QueryExpression("businessunit")
            {
                ColumnSet = new ColumnSet(true)
            };

            if (Parent.HasValue && Parent.Value != Guid.Empty)
            {
                query.Criteria.AddCondition("parentbusinessunitid", ConditionOperator.Equal, Parent.Value);
            }

            return query;
        }
    }
}
