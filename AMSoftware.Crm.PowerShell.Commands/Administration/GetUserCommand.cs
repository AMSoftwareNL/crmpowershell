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
    [Cmdlet(VerbsCommon.Get, "User", HelpUri = HelpUrlConstants.GetUserHelpUrl, SupportsPaging = true, DefaultParameterSetName = GetAllUsersParameterSet)]
    [OutputType(typeof(Entity))]
    public sealed class GetUserCommand : CrmOrganizationCmdlet
    {
        private const string GetAllUsersParameterSet = "GetAllUsers";
        private const string GetUserByIdParameterSet = "GetUserById";

        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = GetUserByIdParameterSet, ValueFromPipeline = true)]
        [ValidateNotNull]
        public Guid Id { get; set; }

        [Parameter(Position = 0, ParameterSetName = GetAllUsersParameterSet)]
        [Alias("Include")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(ParameterSetName = GetAllUsersParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Exclude { get; set; }

        [Parameter(ParameterSetName = GetAllUsersParameterSet)]
        [ValidateNotNullOrEmpty]
        public Guid? BusinessUnit { get; set; }

        [Parameter(ParameterSetName = GetAllUsersParameterSet)]
        public SwitchParameter IncludeDisabled { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case GetAllUsersParameterSet:
                    GetFilteredContent();
                    break;
                case GetUserByIdParameterSet:
                    WriteObject(_repository.Get("systemuser", Id));
                    break;
                default:
                    break;
            }
        }

        private void GetFilteredContent()
        {
            QueryExpression advancedFilterQuery = BuildUserByFilterQuery();
            
            if (PagingParameters.IncludeTotalCount)
            {
                int count = _repository.GetRowCount(advancedFilterQuery, out double accuracy);
                WriteObject(PagingParameters.NewTotalCount(Convert.ToUInt64(count), accuracy));
            }

            var result = _repository.Get(advancedFilterQuery, PagingParameters.First, PagingParameters.Skip);
            if (!string.IsNullOrWhiteSpace(Name))
            {
                WildcardPattern includePattern = new WildcardPattern(Name, WildcardOptions.IgnoreCase);
                result = result.Where(a => includePattern.IsMatch(a.GetAttributeValue<string>("fullname")) || includePattern.IsMatch(a.GetAttributeValue<string>("domainname")));
            }
            if (!string.IsNullOrWhiteSpace(Exclude))
            {
                WildcardPattern excludePattern = new WildcardPattern(Exclude, WildcardOptions.IgnoreCase);
                result = result.Where(a => !(excludePattern.IsMatch(a.GetAttributeValue<string>("fullname")) || excludePattern.IsMatch(a.GetAttributeValue<string>("domainname"))));
            }

            WriteObject(result, true);
        }

        private QueryExpression BuildUserByFilterQuery()
        {
            QueryExpression query = new QueryExpression("systemuser")
            {
                ColumnSet = new ColumnSet(true),
                Orders =
                {
                    new OrderExpression("fullname", OrderType.Ascending)
                }
            };

            if (!IncludeDisabled.ToBool())
            {
                query.Criteria.AddCondition("isdisabled", ConditionOperator.Equal, false);
            }

            if (BusinessUnit.HasValue && BusinessUnit.Value != Guid.Empty)
            {
                query.Criteria.AddCondition("businessunitid", ConditionOperator.Equal, BusinessUnit.Value);
            }

            return query;
        }
    }
}
