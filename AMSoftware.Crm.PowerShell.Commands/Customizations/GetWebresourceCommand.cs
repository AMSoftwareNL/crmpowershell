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
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace AMSoftware.Crm.PowerShell.Commands.Customizations
{
    [Cmdlet(VerbsCommon.Get, "CrmWebresource", HelpUri = HelpUrlConstants.GetWebresourceHelpUrl, SupportsPaging = true, DefaultParameterSetName = GetAllWebresourcesParameterSet)]
    [OutputType(typeof(Entity))]
    public sealed class GetWebresourceCommand : CrmOrganizationCmdlet
    {
        private const string GetAllWebresourcesParameterSet = "GetAllWebresources";
        private const string GetWebresourceByIdParameterSet = "GetWebresourceById";

        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = GetWebresourceByIdParameterSet, ValueFromPipeline = true)]
        [ValidateNotNull]
        public Guid[] Id { get; set; }

        [Parameter(ParameterSetName = GetAllWebresourcesParameterSet, Position = 0)]
        [Alias("Include")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(ParameterSetName = GetAllWebresourcesParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Exclude { get; set; }

        [Parameter(ParameterSetName = GetAllWebresourcesParameterSet)]
        [PSDefaultValue(Value = CrmWebresourceType.All)]
        public CrmWebresourceType WebresourceType { get; set; }

        [Parameter(ParameterSetName = GetAllWebresourcesParameterSet)]
        public SwitchParameter ExcludeManaged { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case GetAllWebresourcesParameterSet:
                    GetContentByQuery(BuildWebresourceQuery());
                    break;
                case GetWebresourceByIdParameterSet:
                    foreach (Guid id in Id)
                    {
                        GetContentByQuery(BuildByIdQuery(id));
                    }
                    break;
                default:
                    break;
            }
        }

        private void GetContentByQuery(QueryExpression query)
        {
            if (PagingParameters.IncludeTotalCount)
            {
                int count = _repository.GetRowCount(query, out double accuracy);
                WriteObject(PagingParameters.NewTotalCount(Convert.ToUInt64(count), accuracy));
            }

            var result = _repository.Get(query, PagingParameters.First, PagingParameters.Skip);
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

        private static QueryExpression BuildByIdQuery(Guid id)
        {
            QueryExpression query = new QueryExpression("webresource")
            {
                ColumnSet = new ColumnSet(true),
                Orders =
                {
                    new OrderExpression("name", OrderType.Ascending)
                }
            };

            FilterExpression idFilter = new FilterExpression(LogicalOperator.Or);
            idFilter.AddCondition(new ConditionExpression("webresourceid", ConditionOperator.Equal, id));
            idFilter.AddCondition(new ConditionExpression("webresourceidunique", ConditionOperator.Equal, id));

            query.Criteria.AddFilter(idFilter);

            return query;
        }

        private QueryExpression BuildWebresourceQuery()
        {
            QueryExpression query = new QueryExpression("webresource")
            {
                ColumnSet = new ColumnSet(true),
                Orders =
                {
                    new OrderExpression("name", OrderType.Ascending)
                }
            };

            if (ExcludeManaged.ToBool())
            {
                query.Criteria.AddCondition("ismanaged", ConditionOperator.NotEqual, true);
            }

            CrmWebresourceType webresourceType = WebresourceType;
            switch (webresourceType)
            {
                case CrmWebresourceType.All:
                    break;
                case CrmWebresourceType.HTML:
                    query.Criteria.AddCondition("webresourcetype", ConditionOperator.Equal, 1);
                    break;
                case CrmWebresourceType.CSS:
                    query.Criteria.AddCondition("webresourcetype", ConditionOperator.Equal, 2);
                    break;
                case CrmWebresourceType.JS:
                    query.Criteria.AddCondition("webresourcetype", ConditionOperator.Equal, 3);
                    break;
                case CrmWebresourceType.XML:
                    query.Criteria.AddCondition("webresourcetype", ConditionOperator.Equal, 4);
                    break;
                case CrmWebresourceType.PNG:
                    query.Criteria.AddCondition("webresourcetype", ConditionOperator.Equal, 5);
                    break;
                case CrmWebresourceType.JPG:
                    query.Criteria.AddCondition("webresourcetype", ConditionOperator.Equal, 6);
                    break;
                case CrmWebresourceType.GIF:
                    query.Criteria.AddCondition("webresourcetype", ConditionOperator.Equal, 7);
                    break;
                case CrmWebresourceType.XAP:
                    query.Criteria.AddCondition("webresourcetype", ConditionOperator.Equal, 8);
                    break;
                case CrmWebresourceType.XSL:
                    query.Criteria.AddCondition("webresourcetype", ConditionOperator.Equal, 9);
                    break;
                case CrmWebresourceType.ICO:
                    query.Criteria.AddCondition("webresourcetype", ConditionOperator.Equal, 10);
                    break;
                default:
                    break;
            }

            return query;
        }
    }
}
