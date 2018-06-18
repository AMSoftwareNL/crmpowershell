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

namespace AMSoftware.Crm.PowerShell.Commands.Customizations
{
    [Cmdlet(VerbsCommon.Get, "CrmPublisher", HelpUri = HelpUrlConstants.GetPublisherHelpUrl, SupportsPaging = true, DefaultParameterSetName = GetAllPublishersParameterSet)]
    [OutputType(typeof(Entity))]
    public sealed class GetPublisherCommand : CrmOrganizationCmdlet
    {
        private const string GetAllPublishersParameterSet = "GetAllPublishers";
        private const string GetPublisherByIdParameterSet = "GetPublisherById";

        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = GetPublisherByIdParameterSet, ValueFromPipeline = true)]
        [ValidateNotNull]
        public Guid Id { get; set; }

        [Parameter(Position = 1, ParameterSetName = GetAllPublishersParameterSet)]
        [Alias("Include")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(ParameterSetName = GetAllPublishersParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Exclude { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case GetAllPublishersParameterSet:
                    GetFilteredContent();
                    break;
                case GetPublisherByIdParameterSet:
                    WriteObject(_repository.Get("publisher", Id));
                    break;
                default:
                    break;
            }
        }

        private void GetFilteredContent()
        {
            QueryExpression advancedFilterQuery = BuildPublisherByFilterQuery();

            if (PagingParameters.IncludeTotalCount)
            {
                int count = _repository.GetRowCount(advancedFilterQuery, out double accuracy);
                WriteObject(PagingParameters.NewTotalCount(Convert.ToUInt64(count), accuracy));
            }

            var result = _repository.Get(advancedFilterQuery, PagingParameters.First, PagingParameters.Skip);
            if (!string.IsNullOrWhiteSpace(Name))
            {
                WildcardPattern includePattern = new WildcardPattern(Name, WildcardOptions.IgnoreCase);
                result = result.Where(a => includePattern.IsMatch(a.GetAttributeValue<string>("uniquename")) || includePattern.IsMatch(a.GetAttributeValue<string>("friendlyname")));
            }
            if (!string.IsNullOrWhiteSpace(Exclude))
            {
                WildcardPattern excludePattern = new WildcardPattern(Exclude, WildcardOptions.IgnoreCase);
                result = result.Where(a => !(excludePattern.IsMatch(a.GetAttributeValue<string>("uniquename")) || excludePattern.IsMatch(a.GetAttributeValue<string>("friendlyname"))));
            }

            WriteObject(result, true);
        }

        private QueryExpression BuildPublisherByFilterQuery()
        {
            QueryExpression query = new QueryExpression("publisher")
            {
                ColumnSet = new ColumnSet(true),
                Orders =
                {
                    new OrderExpression("uniquename", OrderType.Ascending)
                }
            };
            
            return query;
        }
    }
}
