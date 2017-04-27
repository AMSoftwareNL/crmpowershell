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
    [Cmdlet(VerbsCommon.Get, "PluginAssembly", HelpUri = HelpUrlConstants.GetPluginAssemblyHelpUrl, SupportsPaging = true, DefaultParameterSetName = GetAssemblyByFilterParameterSet)]
    [OutputType(typeof(Entity))]
    public sealed class GetPluginAssemblyCommand : CrmOrganizationCmdlet
    {
        private const string GetAssemblyByNameParameterSet = "GetAssemblyByName";
        private const string GetAssemblyByIdParameterSet = "GetAssemblyById";
        private const string GetAssemblyByFilterParameterSet = "GetAssemblyByFilter";

        private ContentRepository _repository = new ContentRepository();

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = GetAssemblyByIdParameterSet)]
        [ValidateNotNull]
        public Guid Id { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = GetAssemblyByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = GetAssemblyByFilterParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Include { get; set; }

        [Parameter(ParameterSetName = GetAssemblyByFilterParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Exclude { get; set; }

        [Parameter(ParameterSetName = GetAssemblyByFilterParameterSet)]
        public SwitchParameter ExcludeManaged { get; set; }

        [Parameter(ParameterSetName = GetAssemblyByFilterParameterSet)]
        public SwitchParameter IncludeHidden { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case GetAssemblyByNameParameterSet:
                    QueryExpression nameQuery = BuildAssemblyByNameQuery();
                    GetContentByQuery(nameQuery);
                    break;
                case GetAssemblyByIdParameterSet:
                    WriteObject(_repository.Get("pluginassembly", Id));
                    break;
                case GetAssemblyByFilterParameterSet:
                    GetFilteredContent();
                    break;
                default:
                    break;
            }
        }

        private void GetFilteredContent()
        {
            QueryExpression advancedFilterQuery = BuildAssemblyByFilterQuery();

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

        private QueryExpression BuildAssemblyByNameQuery()
        {
            QueryExpression query = new QueryExpression("pluginassembly")
            {
                ColumnSet = new ColumnSet(true),
                Criteria =
                {
                    Conditions =
                    {
                        new ConditionExpression("name", ConditionOperator.Equal, Name),
                    }
                }
            };
            return query;
        }

        private QueryExpression BuildAssemblyByFilterQuery()
        {
            QueryExpression query = new QueryExpression("pluginassembly")
            {
                ColumnSet = new ColumnSet(true),
            };

            FilterExpression filter = new FilterExpression(LogicalOperator.And);
            if (!IncludeHidden.IsPresent) filter.AddCondition("ishidden", ConditionOperator.Equal, false);
            if (ExcludeManaged.IsPresent) filter.AddCondition("ismanaged", ConditionOperator.Equal, false);

            if (filter.Conditions.Count > 0)
            {
                query.Criteria.AddFilter(filter);
            }

            return query;
        }
    }
}
