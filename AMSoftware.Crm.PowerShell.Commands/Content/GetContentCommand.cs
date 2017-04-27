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
using System.Collections;
using System.Management.Automation;
using System.Xml;
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace AMSoftware.Crm.PowerShell.Commands.Content
{
    [Cmdlet(VerbsCommon.Get, "Content", HelpUri = HelpUrlConstants.GetContentHelpUrl, SupportsPaging = true, DefaultParameterSetName = GetContentForEntityByQueryParameterSet)]
    [OutputType(typeof(Entity))]
    public sealed class GetContentCommand : CrmOrganizationCmdlet
    {
        private const string GetContentForEntityByIdParameterSet = "GetContentForEntityById";
        private const string GetContentForEntityByKeysParameterSet = "GetContentForEntityByKeys";
        private const string GetContentForEntityByQueryParameterSet = "GetContentForEntityByQuery";
        private const string GetContentWithFetchXmlParameterSet = "GetContentWithFetchXml";

        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = GetContentForEntityByIdParameterSet)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = GetContentForEntityByQueryParameterSet)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = GetContentForEntityByKeysParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Entity { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = GetContentForEntityByIdParameterSet)]
        public Guid Id { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = GetContentForEntityByKeysParameterSet)]
        public Hashtable Keys { get; set; }

        [Parameter(Mandatory = false, Position = 2, ParameterSetName = GetContentForEntityByQueryParameterSet)]
        [ValidateCount(1, int.MaxValue)]
        [ValidateNotNull]
        public Hashtable Query { get; set; }

        [Parameter(Mandatory = false, Position = 3, ParameterSetName = GetContentForEntityByQueryParameterSet)]
        [ValidateCount(1, int.MaxValue)]
        [ValidateNotNull]
        public Hashtable Order { get; set; }

        [Parameter(ParameterSetName = GetContentForEntityByIdParameterSet)]
        [Parameter(ParameterSetName = GetContentForEntityByKeysParameterSet)]
        public Hashtable RelatedEntities { get; set; }

        [Parameter(ValueFromRemainingArguments = true, ParameterSetName = GetContentForEntityByIdParameterSet)]
        [Parameter(ValueFromRemainingArguments = true, ParameterSetName = GetContentForEntityByQueryParameterSet)]
        [Parameter(ValueFromRemainingArguments = true, ParameterSetName = GetContentForEntityByKeysParameterSet)]
        public string[] Columns { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = GetContentWithFetchXmlParameterSet)]
        [ValidateNotNullOrEmpty]
        public XmlDocument FetchXml { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case GetContentForEntityByIdParameterSet:
                    WriteObject(_repository.Get(Entity, Id, Columns, RelatedEntities), false);
                    break;
                case GetContentForEntityByKeysParameterSet:
                    WriteObject(_repository.Get(Entity, Keys, Columns, RelatedEntities), false);
                    break;
                case GetContentForEntityByQueryParameterSet:
                    QueryBase queryFromQuery = null;
                    if (Query == null || Query.Count == 0) queryFromQuery = BuildQueryExpression(Entity, Columns, Order);
                    else queryFromQuery = BuildQueryByAttribute(Entity, Columns, Query, Order);
                    GetContentByQuery(queryFromQuery);
                    break;
                case GetContentWithFetchXmlParameterSet:
                    QueryExpression queryFromFetch = BuildQueryExpression(FetchXml.OuterXml);
                    GetContentByQuery(queryFromFetch);
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

        private QueryByAttribute BuildQueryByAttribute(string entity, string[] columns, Hashtable attributeQuery, Hashtable order)
        {
            QueryByAttribute query = new QueryByAttribute(entity)
            {
                ColumnSet = BuildColumnSet(columns)
            };

            if (attributeQuery != null)
            {
                foreach (var item in attributeQuery.ToEnumerable<string, object>())
                {
                    query.AddAttributeValue(item.Key, item.Value);
                }
            }

            if (order != null)
            {
                foreach (var item in order.ToEnumerable<string, OrderType>())
                {
                    query.AddOrder(item.Key, item.Value);
                }
            }

            return query;
        }

        private QueryExpression BuildQueryExpression(string entity, string[] columns, Hashtable order)
        {
            QueryExpression query = new QueryExpression(entity)
            {
                ColumnSet = BuildColumnSet(columns)
            };

            if (order != null)
            {
                foreach (var item in order.ToEnumerable<string, OrderType>())
                {
                    query.AddOrder(item.Key, item.Value);
                }
            }

            return query;
        }

        private QueryExpression BuildQueryExpression(string fetchXml)
        {
            OrganizationRequest request = new OrganizationRequest()
            {
                RequestName = "FetchXmlToQueryExpression"
            };
            request.Parameters["FetchXml"] = fetchXml;

            OrganizationResponse response = _repository.Execute(request);

            return (QueryExpression)response.Results["Query"];
        }

        private ColumnSet BuildColumnSet(string[] columns)
        {
            if (columns == null || columns.Length == 0)
            {
                return new ColumnSet(true);
            }
            else
            {
                return new ColumnSet(columns);
            }
        }
    }
}
