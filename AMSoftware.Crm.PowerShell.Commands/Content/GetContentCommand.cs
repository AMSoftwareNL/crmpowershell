﻿/*
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
using AMSoftware.Crm.PowerShell.Common.ArgumentCompleters;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace AMSoftware.Crm.PowerShell.Commands.Content
{
    [Cmdlet(VerbsCommon.Get, "CrmContent", HelpUri = HelpUrlConstants.GetContentHelpUrl, SupportsPaging = true, DefaultParameterSetName = GetContentForEntityByQueryParameterSet)]
    [OutputType(typeof(Entity))]
    public sealed class GetContentCommand : CrmOrganizationCmdlet
    {
        private const string GetContentForEntityByIdParameterSet = "GetContentForEntityById";
        private const string GetContentForEntityByKeysParameterSet = "GetContentForEntityByKeys";
        private const string GetContentForEntityByQueryParameterSet = "GetContentForEntityByQuery";
        private const string GetContentWithFetchXmlParameterSet = "GetContentWithFetchXml";

        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = GetContentForEntityByIdParameterSet)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = GetContentForEntityByQueryParameterSet)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = GetContentForEntityByKeysParameterSet)]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string Entity { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = GetContentForEntityByIdParameterSet, ValueFromPipeline = true)]
        public Guid[] Id { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = GetContentForEntityByKeysParameterSet)]
        public Hashtable Keys { get; set; }

        [Parameter(Position = 2, ParameterSetName = GetContentForEntityByQueryParameterSet)]
        [ValidateCount(1, int.MaxValue)]
        [ValidateNotNull]
        public Hashtable Query { get; set; }

        [Parameter(Position = 3, ParameterSetName = GetContentForEntityByQueryParameterSet)]
        [ValidateCount(1, int.MaxValue)]
        [ValidateNotNull]
        public Hashtable Order { get; set; }

        [Parameter(ValueFromRemainingArguments = true, ParameterSetName = GetContentForEntityByIdParameterSet)]
        [Parameter(ValueFromRemainingArguments = true, ParameterSetName = GetContentForEntityByQueryParameterSet)]
        [Parameter(ValueFromRemainingArguments = true, ParameterSetName = GetContentForEntityByKeysParameterSet)]
        public string[] Columns { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = GetContentWithFetchXmlParameterSet, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public XmlDocument FetchXml { get; set; }

        [Parameter]
        public SwitchParameter AsBatch { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (AsBatch.ToBool() && !CrmContext.Session.BatchActive)
            {
                throw new InvalidOperationException("No active batch to use.");
            }

            switch (this.ParameterSetName)
            {
                case GetContentForEntityByIdParameterSet:
                    foreach (Guid id in Id)
                    {
                        if (AsBatch.ToBool())
                        {
                            CrmContext.Session.BatchRequestCollection.Add(_repository.GetRequest(Entity, id, Columns));
                        }
                        else
                        {
                            WriteObject(_repository.Get(Entity, id, Columns), false);
                        }
                    }
                    break;
                case GetContentForEntityByKeysParameterSet:
                    if (AsBatch.ToBool())
                    {
                        CrmContext.Session.BatchRequestCollection.Add(_repository.GetRequest(Entity, Keys, Columns));
                    }
                    else
                    {
                        WriteObject(_repository.Get(Entity, Keys, Columns), false);
                    }
                    break;
                case GetContentForEntityByQueryParameterSet:
                    QueryBase queryFromQuery;
                    if (Query == null || Query.Count == 0) queryFromQuery = BuildQueryExpression(Entity, Columns, Order);
                    else queryFromQuery = BuildQueryByAttribute(Entity, Columns, Query, Order);

                    if (AsBatch.ToBool())
                    {
                        CrmContext.Session.BatchRequestCollection.Add(_repository.GetRequest(queryFromQuery));
                    }
                    else
                    {
                        GetContentByQuery(queryFromQuery);
                    }
                    
                    break;
                case GetContentWithFetchXmlParameterSet:
                    FetchExpression queryFromFetch = new FetchExpression(FetchXml.OuterXml);

                    if (AsBatch.ToBool())
                    {
                        CrmContext.Session.BatchRequestCollection.Add(_repository.GetRequest(queryFromFetch));
                    }
                    else
                    {
                        GetContentByQuery(queryFromFetch);
                    }
                    break;
                default:
                    break;
            }
        }

        private void GetContentByQuery(QueryBase query)
        {
            if (PagingParameters.IncludeTotalCount)
            {
                int count = _repository.GetRowCount(query, out double accuracy);
                WriteObject(PagingParameters.NewTotalCount(Convert.ToUInt64(count), accuracy));
            }

            foreach (var item in _repository.Get(query, PagingParameters.First, PagingParameters.Skip))
            {
                WriteObject(new PSObject(item));
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
