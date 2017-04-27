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

namespace AMSoftware.Crm.PowerShell.Commands.Customizations
{
    [Cmdlet(VerbsCommon.Get, "Webresource", HelpUri = HelpUrlConstants.GetWebresourceHelpUrl, SupportsPaging = true, DefaultParameterSetName = GetWebresourceParameterSet)]
    [OutputType(typeof(Entity))]
    public sealed class GetWebresourceCommand : CrmOrganizationCmdlet
    {
        private const string GetWebresourceParameterSet = "GetWebresource";
        private const string GetWebresourceByIdParameterSet = "GetWebresourceById";
        private const string GetWebresourceByNameParameterSet = "GetWebresourceByName";

        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = GetWebresourceByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = GetWebresourceByIdParameterSet)]
        [ValidateNotNull]
        public Guid Id { get; set; }

        [Parameter(ParameterSetName = GetWebresourceParameterSet)]
        [PSDefaultValue(Value = CrmWebresourceType.All)]
        public CrmWebresourceType WebresourceType { get; set; }

        [Parameter(ParameterSetName = GetWebresourceParameterSet)]
        public SwitchParameter ExcludeManaged { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case GetWebresourceParameterSet:
                    GetContentByQuery(BuildWebresourceQuery());
                    break;
                case GetWebresourceByIdParameterSet:
                    GetContentByQuery(BuildByIdQuery(Id));
                    break;
                case GetWebresourceByNameParameterSet:
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
            
            foreach (var item in _repository.Get(query, PagingParameters.First, PagingParameters.Skip))
            {
                WriteObject(item);
            }
        }

        private static QueryExpression BuildByIdQuery(Guid id)
        {
            QueryExpression query = new QueryExpression("webresource")
            {
                ColumnSet = new ColumnSet(true)
            };

            FilterExpression idFilter = new FilterExpression(LogicalOperator.Or);
            idFilter.AddCondition(new ConditionExpression("webresourceid", ConditionOperator.Equal, id));
            idFilter.AddCondition(new ConditionExpression("webresourceidunique", ConditionOperator.Equal, id));

            query.Criteria.AddFilter(idFilter);

            return query;
        }

        private static QueryExpression BuildByNameQuery(string name)
        {
            QueryExpression query = new QueryExpression("webresource")
            {
                ColumnSet = new ColumnSet(true)
            };

            FilterExpression nameFilter = new FilterExpression(LogicalOperator.Or);
            nameFilter.AddCondition(new ConditionExpression("name", ConditionOperator.Equal, name));
            nameFilter.AddCondition(new ConditionExpression("displayname", ConditionOperator.Equal, name));

            query.Criteria.AddFilter(nameFilter);

            return query;
        }

        private QueryExpression BuildWebresourceQuery()
        {
            QueryExpression query = new QueryExpression("webresource")
            {
                ColumnSet = new ColumnSet(true)
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
