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

namespace AMSoftware.Crm.PowerShell.Commands.Plugins
{
    [Cmdlet(VerbsCommon.Get, "Plugin", HelpUri = HelpUrlConstants.GetPluginHelpUrl, SupportsPaging = true, DefaultParameterSetName = GetPluginByFilterParameterSet)]
    [OutputType(typeof(Entity))]
    public sealed class GetPluginCommand : CrmOrganizationCmdlet
    {
        private const string GetPluginByNameParameterSet = "GetPluginByName";
        private const string GetPluginByIdParameterSet = "GetPluginById";
        private const string GetPluginByFilterParameterSet = "GetPluginByFilter";

        private ContentRepository _repository = new ContentRepository();

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = GetPluginByIdParameterSet)]
        [ValidateNotNull]
        public Guid Id { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = GetPluginByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1, ValueFromPipeline = true, ParameterSetName = GetPluginByFilterParameterSet)]
        [ValidateNotNullOrEmpty]
        public Guid PluginAssembly { get; set; }

        [Parameter(ParameterSetName = GetPluginByFilterParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Include { get; set; }

        [Parameter(ParameterSetName = GetPluginByFilterParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Exclude { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case GetPluginByNameParameterSet:
                    QueryExpression nameQuery = BuildPluginByNameQuery();
                    GetContentByQuery(nameQuery);
                    break;
                case GetPluginByIdParameterSet:
                    WriteObject(_repository.Get("plugintype", Id));
                    break;
                case GetPluginByFilterParameterSet:
                    GetFilteredContent();
                    break;
                default:
                    break;
            }
        }

        private void GetFilteredContent()
        {
            QueryExpression advancedFilterQuery = BuildPluginByFilterQuery();

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
                result = result.Where(a => includePattern.IsMatch(a.GetAttributeValue<string>("name")) || includePattern.IsMatch(a.GetAttributeValue<string>("friendlyname")) || includePattern.IsMatch(a.GetAttributeValue<string>("typename")));
            }
            if (!string.IsNullOrWhiteSpace(Exclude))
            {
                WildcardPattern excludePattern = new WildcardPattern(Exclude, WildcardOptions.IgnoreCase);
                result = result.Where(a => !(excludePattern.IsMatch(a.GetAttributeValue<string>("name")) || excludePattern.IsMatch(a.GetAttributeValue<string>("friendlyname")) || excludePattern.IsMatch(a.GetAttributeValue<string>("typename"))));
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

        private QueryExpression BuildPluginByNameQuery()
        {
            QueryExpression query = new QueryExpression("plugintype")
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
                                new ConditionExpression("friendlyname", ConditionOperator.Equal, Name),
                                new ConditionExpression("typename", ConditionOperator.Equal, Name)
                            }
                        }
                    }
                }
            };
            return query;
        }

        private QueryExpression BuildPluginByFilterQuery()
        {
            QueryExpression query = new QueryExpression("plugintype")
            {
                ColumnSet = new ColumnSet(true),
            };

            FilterExpression filter = new FilterExpression(LogicalOperator.And);
            if (PluginAssembly != Guid.Empty) filter.AddCondition("pluginassemblyid", ConditionOperator.Equal, PluginAssembly);

            if (filter.Conditions.Count > 0)
            {
                query.Criteria.AddFilter(filter);
            }

            return query;
        }
    }
}
