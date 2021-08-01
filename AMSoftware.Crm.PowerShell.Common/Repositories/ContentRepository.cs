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
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Crm.Sdk.Messages;
using System.Xml.Linq;

namespace AMSoftware.Crm.PowerShell.Common.Repositories
{
    internal sealed class ContentRepository
    {
        #region Get
        public OrganizationRequest GetRequest(string entity, Guid id, string[] columns = null, Hashtable related = null)
        {
            ColumnSet columnSet = BuildColumnSet(columns);
            EntityReference reference = new EntityReference(entity, id);

            OrganizationRequest request = new OrganizationRequest("Retrieve")
            {
                Parameters = new ParameterCollection()
            };
            request.Parameters.Add("Target", reference);
            request.Parameters.Add("ColumnSet", columnSet);

            IncludeRelatedEntitiesInRetrieveRequest(request, related);

            return request;
        }
        public Entity Get(string entity, Guid id, string[] columns = null, Hashtable related = null)
        {
            OrganizationRequest request = GetRequest(entity, id, columns, related);
            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);

            return (Entity)response.Results["Entity"];
        }

        public OrganizationRequest GetRequest(string entity, Hashtable keys, string[] columns = null)
        {
            ColumnSet columnSet = BuildColumnSet(columns);

            KeyAttributeCollection keysCollection = new KeyAttributeCollection();
            keysCollection.AddRange(keys.ToEnumerable<string, object>());
            EntityReference reference = new EntityReference(entity, keysCollection);

            OrganizationRequest request = new OrganizationRequest("Retrieve")
            {
                Parameters = new ParameterCollection()
            };
            request.Parameters.Add("Target", reference);
            request.Parameters.Add("ColumnSet", columnSet);

            return request; ;
        }
        public Entity Get(string entity, Hashtable keys, string[] columns = null)
        {
            OrganizationRequest request = GetRequest(entity, keys, columns);
            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);

            return (Entity)response.Results["Entity"];
        }

        public OrganizationRequest GetRequest(QueryBase query)
        {
            OrganizationRequest request = new OrganizationRequest("RetrieveMultiple")
            {
                Parameters = new ParameterCollection() {
                    { "Query", query }
                }
            };
            return request;
        }
        public IEnumerable<Entity> Get(QueryBase query, ulong? first = null, ulong? skip = null)
        {
            int? firstAsInt = null;
            int? skipAsInt = null;

            if (first.HasValue && first != ulong.MaxValue) firstAsInt = Convert.ToInt32(first.Value);
            if (skip.HasValue && skip != 0) skipAsInt = Convert.ToInt32(skip.Value);

            return GetByQuery(query, firstAsInt, skipAsInt);
        }

        public int GetRowCount(QueryBase query, out double accuracy)
        {
            PagingInfo pageInfo = BuildPagingInfo(1);
            SetQueryPagingInfo(query, pageInfo);

            EntityCollection tempCollection = CrmContext.Session.OrganizationProxy.RetrieveMultiple(query);
            accuracy = tempCollection.TotalRecordCountLimitExceeded ? 0.5 : 1.0;
            return tempCollection.TotalRecordCount;
        }

        private IEnumerable<Entity> GetByQuery(QueryBase query, int? first = null, int? skip = null)
        {
            int skipRemaining = 0;
            int firstRemaining = first ?? 0;

            PagingInfo pageInfo = BuildPagingInfo(500);
            if (skip.HasValue && skip.Value != 0)
            {
                pageInfo.PageNumber = Math.DivRem(skip.Value, pageInfo.Count, out skipRemaining) + 1;
            }
            SetQueryPagingInfo(query, pageInfo);

            bool isCompleted = false;
            do
            {
                EntityCollection tempCollection = CrmContext.Session.OrganizationProxy.RetrieveMultiple(query);
                if (tempCollection != null && tempCollection.Entities != null && tempCollection.Entities.Count != 0)
                {
                    int resultCount = tempCollection.Entities.Count;
                    IEnumerable<Entity> result = tempCollection.Entities;
                    if (skipRemaining > 0)
                    {
                        result = result.Skip(skipRemaining);
                        resultCount -= skipRemaining;
                        skipRemaining = 0;
                    }
                    if (first.HasValue)
                    {
                        if (firstRemaining <= resultCount)
                        {
                            result = result.Take(firstRemaining);
                            isCompleted = true;
                        }
                        else
                        {
                            firstRemaining -= resultCount;
                        }
                    }

                    foreach (var item in result)
                    {
                        yield return item;
                    }

                    if (tempCollection.MoreRecords && !isCompleted)
                    {
                        pageInfo.PageNumber++;
                        pageInfo.PagingCookie = tempCollection.PagingCookie;
                        SetQueryPagingInfo(query, pageInfo);
                    }
                    else
                    {
                        isCompleted = true;
                    }
                }
                else
                {
                    isCompleted = true;
                }
            } while (!isCompleted);
        }
        #endregion

        #region Add
        public OrganizationRequest AddRequest(Entity entity)
        {
            OrganizationRequest request = new OrganizationRequest("Create")
            {
                Parameters = new ParameterCollection()
            };
            request.Parameters.Add("Target", entity);

            if (CrmContext.Session.ActiveSolutionName != null)
            {
                request.Parameters.Add("SolutionUniqueName", CrmContext.Session.ActiveSolutionName);
            }

            return request;
        }
        public Guid Add(Entity entity)
        {
            OrganizationRequest request = AddRequest(entity);
            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
            return (Guid)response.Results["id"];
        }

        public OrganizationRequest AddRequest(string entity, Guid id, Hashtable attributes)
        {
            Entity newEntity = BuildEntity(entity, id, attributes);
            return AddRequest(newEntity);
        }
        public Guid Add(string entity, Guid id, Hashtable attributes)
        {
            Entity newEntity = BuildEntity(entity, id, attributes);

            return Add(newEntity);
        }
        #endregion

        #region Update
        public OrganizationRequest UpdateRequest(Entity entity)
        {
            OrganizationRequest request = new OrganizationRequest("Update")
            {
                Parameters = new ParameterCollection()
            };
            request.Parameters.Add("Target", entity);

            if (CrmContext.Session.ActiveSolutionName != null)
            {
                request.Parameters.Add("SolutionUniqueName", CrmContext.Session.ActiveSolutionName);
            }

            return request;
        }
        public void Update(Entity entity)
        {
            OrganizationRequest request = UpdateRequest(entity);
            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
        }

        public OrganizationRequest UpdateRequest(string entity, Guid id, Hashtable attributes)
        {
            Entity newEntity = BuildEntity(entity, id, attributes);
            return UpdateRequest(newEntity);
        }
        public void Update(string entity, Guid id, Hashtable attributes)
        {
            Entity newEntity = BuildEntity(entity, id, attributes);
            Update(newEntity);
        }
        #endregion

        #region Upsert
        public OrganizationRequest UpsertRequest(Entity entity)
        {
            OrganizationRequest request = new OrganizationRequest("Upsert")
            {
                Parameters = new ParameterCollection()
            };
            request.Parameters.Add("Target", entity);

            if (CrmContext.Session.ActiveSolutionName != null)
            {
                request.Parameters.Add("SolutionUniqueName", CrmContext.Session.ActiveSolutionName);
            }

            return request;
        }
        public Guid Upsert(Entity entity)
        {
            OrganizationRequest request = UpsertRequest(entity);
            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
            return (Guid)response.Results["id"];
        }

        public OrganizationRequest UpsertRequest(string entity, Guid id, Hashtable attributes)
        {
            Entity newEntity = BuildEntity(entity, id, attributes);
            return UpsertRequest(newEntity);
        }
        public Guid Upsert(string entity, Guid id, Hashtable attributes)
        {
            Entity newEntity = BuildEntity(entity, id, attributes);
            return Upsert(newEntity);
        }
        #endregion

        #region Delete
        public OrganizationRequest DeleteRequest(string entity, Guid id)
        {
            OrganizationRequest request = new OrganizationRequest("Delete")
            {
                Parameters = new ParameterCollection()
            };
            request.Parameters.Add("Target", new EntityReference(entity, id));

            if (CrmContext.Session.ActiveSolutionName != null)
            {
                request.Parameters.Add("SolutionUniqueName", CrmContext.Session.ActiveSolutionName);
            }

            return request;
        }
        public void Delete(string entity, Guid id)
        {
            OrganizationRequest request = DeleteRequest(entity, id);
            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
        }
        #endregion

        #region Execute
        public OrganizationRequest ExecuteRequest(string requestName, Hashtable requestParameters = null)
        {
            OrganizationRequest request = new OrganizationRequest(requestName)
            {
                Parameters = new ParameterCollection()
            };

            if (requestParameters != null)
            {
                request.Parameters.AddRange(requestParameters.ToEnumerable<string, object>());
            }

            return request;
        }
        public OrganizationResponse Execute(string requestName, Hashtable requestParameters = null)
        {
            OrganizationRequest request = new OrganizationRequest(requestName)
            {
                Parameters = new ParameterCollection()
            };

            if (requestParameters != null)
            {
                request.Parameters.AddRange(requestParameters.ToEnumerable<string, object>());
            }

            return Execute(request);
        }

        public OrganizationResponse Execute(OrganizationRequest request)
        {
            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
            return response;
        }

        public OrganizationResponse ExecuteAsync(string requestName, Hashtable requestParameters = null)
        {
            OrganizationRequest request = new OrganizationRequest(requestName)
            {
                Parameters = new ParameterCollection()
            };

            if (requestParameters != null)
            {
                request.Parameters.AddRange(requestParameters.ToEnumerable<string, object>());
            }

            return ExecuteAsync(request);
        }

        public OrganizationResponse ExecuteAsync(OrganizationRequest request)
        {
            OrganizationRequest asyncRequest = new OrganizationRequest("ExecuteAsync")
            {
                Parameters = new ParameterCollection()
            };
            asyncRequest.Parameters.Add("Request", request);

            OrganizationResponse asyncResponse = CrmContext.Session.OrganizationProxy.Execute(asyncRequest);
            return asyncResponse;
        }

        public bool TryExecuteMultiple(OrganizationRequestCollection batchRequestCollection, bool returnResponses, bool continueOnError, out IEnumerable<ExecuteMultipleResponseItem> results)
        {
            OrganizationRequest request = new OrganizationRequest("ExecuteMultiple")
            {
                Parameters = new ParameterCollection()
            };
            request.Parameters.Add("Requests", batchRequestCollection);
            request.Parameters.Add("Settings", new ExecuteMultipleSettings() {
                ContinueOnError = continueOnError,
                ReturnResponses = returnResponses
            });

            OrganizationResponse batchResponse = CrmContext.Session.OrganizationProxy.Execute(request);

            ExecuteMultipleResponseItemCollection batchResults = (ExecuteMultipleResponseItemCollection)batchResponse["Responses"];
            if (returnResponses)
            {
                results = batchResults?.AsEnumerable();
            } else
            {
                results = null;
            }

            return !(bool)batchResponse["IsFaulted"];
        }

        public IEnumerable<OrganizationResponse> ExecuteTransaction(OrganizationRequestCollection batchRequestCollection, bool returnResponses)
        {
            OrganizationRequest request = new OrganizationRequest("ExecuteTransaction")
            {
                Parameters = new ParameterCollection()
            };
            request.Parameters.Add("Requests", batchRequestCollection);
            request.Parameters.Add("ReturnResponses", returnResponses);

            OrganizationResponse batchResponse = CrmContext.Session.OrganizationProxy.Execute(request);
            
            OrganizationResponseCollection responseCollection = (OrganizationResponseCollection)batchResponse["Responses"];

            if (returnResponses)
            {
                return responseCollection.AsEnumerable();
            } else
            {
                return null;
            }
        }
        #endregion

        #region Associate
        public OrganizationRequest AssociateRequest(string addEntity, Guid addEntityId, string toEntity, Guid toEntityId, string addAttributeHint = null)
        {
            MetadataRepository repository = new MetadataRepository();
            RelationshipMetadataBase relationship = repository.FindAssociationRelationship(toEntity, addEntity, addAttributeHint);
            if (relationship == null)
            {
                // No relationship between entities. Throw exception
                throw new KeyNotFoundException(string.Format("No (unique) relationship from {0} to {1}", addEntity, toEntity));
            }

            OrganizationRequest request = new OrganizationRequest("Associate")
            {
                Parameters = new ParameterCollection()
            };
            request.Parameters.Add("Target", new EntityReference(toEntity, toEntityId));
            request.Parameters.Add("RelatedEntities", new EntityReferenceCollection() {
                new EntityReference(addEntity, addEntityId)
            });
            request.Parameters.Add("Relationship", new Relationship(relationship.SchemaName));

            return request;
        }
        public void Associate(string addEntity, Guid addEntityId, string toEntity, Guid toEntityId, string addAttributeHint = null)
        {
            OrganizationRequest request = AssociateRequest(addEntity, addEntityId, toEntity, toEntityId, addAttributeHint);
            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
        }

        public OrganizationRequest AssociateRequest(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
        {
            OrganizationRequest request = new OrganizationRequest("Associate")
            {
                Parameters = new ParameterCollection()
            };
            request.Parameters.Add("Target", new EntityReference(entityName, entityId));
            request.Parameters.Add("RelatedEntities", relatedEntities);
            request.Parameters.Add("Relationship", relationship);

            return request;
        }
        public void Associate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
        {
            OrganizationRequest request = AssociateRequest(entityName, entityId, relationship, relatedEntities);
            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
        }

        public OrganizationRequest DisassociateRequest(string addEntity, Guid addEntityId, string toEntity, Guid toEntityId, string addAttributeHint = null)
        {
            MetadataRepository repository = new MetadataRepository();
            RelationshipMetadataBase relationship = repository.FindAssociationRelationship(toEntity, addEntity, addAttributeHint);
            if (relationship == null)
            {
                // No relationship between entities. Throw exception
                throw new KeyNotFoundException(string.Format("No (unique) relationship from {0} to {1}", addEntity, toEntity));
            }

            OrganizationRequest request = new OrganizationRequest("Disassociate")
            {
                Parameters = new ParameterCollection()
            };
            request.Parameters.Add("Target", new EntityReference(toEntity, toEntityId));
            request.Parameters.Add("RelatedEntities", new EntityReferenceCollection() {
                new EntityReference(addEntity, addEntityId)
            });
            request.Parameters.Add("Relationship", new Relationship(relationship.SchemaName));

            return request;
        }
        public void Disassociate(string addEntity, Guid addEntityId, string toEntity, Guid toEntityId, string addAttributeHint = null)
        {
            OrganizationRequest request = DisassociateRequest(addEntity, addEntityId, toEntity, toEntityId, addAttributeHint);
            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
        }

        public OrganizationRequest DisassociateRequest(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
        {
            OrganizationRequest request = new OrganizationRequest("Disassociate")
            {
                Parameters = new ParameterCollection()
            };
            request.Parameters.Add("Target", new EntityReference(entityName, entityId));
            request.Parameters.Add("RelatedEntities", relatedEntities);
            request.Parameters.Add("Relationship", relationship);

            return request;
        }
        public void Disassociate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
        {
            OrganizationRequest request = DisassociateRequest(entityName, entityId, relationship, relatedEntities);
            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
        }
        #endregion

        private static Entity BuildEntity(string entity, Guid id, Hashtable attributes)
        {
            Entity newEntity = new Entity(entity)
            {
                Attributes = new AttributeCollection()
            };

            if (id != Guid.Empty)
            {
                newEntity.Id = id;
            }

            if (attributes != null)
            {
                newEntity.Attributes.AddRange(attributes.ToEnumerable<string, object>());
            }

            return newEntity;
        }

        private static void SetQueryPagingInfo(QueryBase query, PagingInfo pageInfo)
        {
            if (query is QueryExpression qe)
            {
                qe.PageInfo = pageInfo;
            }
            else if (query is QueryByAttribute qa)
            {
                qa.PageInfo = pageInfo;
            }
            else if (query is FetchExpression fe)
            {
                XDocument fetchXml = XDocument.Parse(fe.Query);
                fetchXml.Root.SetAttributeValue("returntotalrecordcount", pageInfo.ReturnTotalRecordCount);
                fetchXml.Root.SetAttributeValue("count", pageInfo.Count);
                fetchXml.Root.SetAttributeValue("page", pageInfo.PageNumber);

                if (!string.IsNullOrWhiteSpace(pageInfo.PagingCookie)) fetchXml.Root.SetAttributeValue("paging-cookie", pageInfo.PagingCookie);
                else fetchXml.Root.SetAttributeValue("paging-cookie", pageInfo.PagingCookie);

                fe.Query = fetchXml.ToString();
            }
        }

        private static ColumnSet BuildColumnSet(string[] columns)
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

        private static PagingInfo BuildPagingInfo(int pageSize)
        {
            PagingInfo p = new PagingInfo
            {
                ReturnTotalRecordCount = true,
                PageNumber = 1,
                Count = pageSize
            };

            return p;
        }

        private static void IncludeRelatedEntitiesInRetrieveRequest(OrganizationRequest request, Hashtable related)
        {
            if (related != null && related.Count > 0)
            {
                RelationshipQueryCollection relatedEntities = new RelationshipQueryCollection();
                foreach (string relatedEntityName in related.Keys)
                {
                    QueryExpression relatedQuery = new QueryExpression(relatedEntityName)
                    {
                        ColumnSet = new ColumnSet(true)
                    };
                    Relationship relationship = new Relationship((string)related[relatedEntityName]);
                    relatedEntities.Add(relationship, relatedQuery);
                }
                request.Parameters.Add("RelatedEntitiesQuery", relatedEntities);
            }
        }
    }
}
