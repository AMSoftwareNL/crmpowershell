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

namespace AMSoftware.Crm.PowerShell.Common.Repositories
{
    internal sealed class ContentRepository
    {
        public Entity Get(string entity, Guid id, string[] columns = null, Hashtable related = null)
        {
            ColumnSet columnSet = BuildColumnSet(columns);
            EntityReference reference = new EntityReference(entity, id);

            OrganizationRequest request = new OrganizationRequest("Retrieve");
            request.Parameters = new ParameterCollection();
            request.Parameters.Add("Target", reference);
            request.Parameters.Add("ColumnSet", columnSet);

            IncludeRelatedEntitiesInRetrieveRequest(request, related);

            OrganizationResponse response = CrmContext.OrganizationProxy.Execute(request);

            return (Entity)response.Results["Entity"];
        }

        public Entity Get(string entity, Hashtable keys, string[] columns = null, Hashtable related = null)
        {
            if (!CrmVersionManager.IsSupported(CrmVersion.CRM2015_1_RTM))
            {
                throw new NotSupportedException();
            }

            ColumnSet columnSet = BuildColumnSet(columns);

            KeyAttributeCollection keysCollection = new KeyAttributeCollection();
            keysCollection.AddRange(keys.ToEnumerable<string, object>());
            EntityReference reference = new EntityReference(entity, keysCollection);

            OrganizationRequest request = new OrganizationRequest("Retrieve");
            request.Parameters = new ParameterCollection();
            request.Parameters.Add("Target", reference);
            request.Parameters.Add("ColumnSet", columnSet);

            IncludeRelatedEntitiesInRetrieveRequest(request, related);

            OrganizationResponse response = CrmContext.OrganizationProxy.Execute(request);

            return (Entity)response.Results["Entity"];
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

            EntityCollection tempCollection = CrmContext.OrganizationProxy.RetrieveMultiple(query);
            accuracy = tempCollection.TotalRecordCountLimitExceeded ? 0.5 : 1.0;
            return tempCollection.TotalRecordCount;
        }

        public Guid Add(Entity entity)
        {
            OrganizationRequest request = new OrganizationRequest("Create");
            request.Parameters = new ParameterCollection();
            request.Parameters.Add("Target", entity);

            if (CrmContext.ActiveSolution != null)
            {
                request.Parameters.Add("SolutionUniqueName", CrmContext.ActiveSolution);
            }

            OrganizationResponse response = CrmContext.OrganizationProxy.Execute(request);
            return (Guid)response.Results["id"];
        }

        public Guid Add(string entity, Guid id, Hashtable attributes)
        {
            Entity newEntity = new Entity(entity);
            newEntity.Attributes = new AttributeCollection();

            if (id != Guid.Empty)
            {
                newEntity.Id = id;
            }

            if (attributes != null)
            {
                newEntity.Attributes.AddRange(attributes.ToEnumerable<string, object>());
            }

            return Add(newEntity);
        }

        public void Update(Entity entity)
        {
            OrganizationRequest request = new OrganizationRequest("Update");
            request.Parameters = new ParameterCollection();
            request.Parameters.Add("Target", entity);

            if (CrmContext.ActiveSolution != null)
            {
                request.Parameters.Add("SolutionUniqueName", CrmContext.ActiveSolution);
            }

            OrganizationResponse response = CrmContext.OrganizationProxy.Execute(request);
        }

        public void Update(string entity, Guid id, Hashtable attributes)
        {
            Entity newEntity = new Entity(entity);
            newEntity.Attributes = new AttributeCollection();
            newEntity.Id = id;

            if (attributes != null)
            {
                newEntity.Attributes.AddRange(attributes.ToEnumerable<string, object>());
            }

            Update(newEntity);
        }

        public void Delete(string entity, Guid id)
        {
            OrganizationRequest request = new OrganizationRequest("Delete");
            request.Parameters = new ParameterCollection();
            request.Parameters.Add("Target", new EntityReference(entity, id));

            if (CrmContext.ActiveSolution != null)
            {
                request.Parameters.Add("SolutionUniqueName", CrmContext.ActiveSolution);
            }

            OrganizationResponse response = CrmContext.OrganizationProxy.Execute(request);
        }

        public OrganizationResponse Execute(string requestName, Hashtable requestParameters = null)
        {
            OrganizationRequest request = new OrganizationRequest(requestName);
            request.Parameters = new ParameterCollection();

            if (requestParameters != null)
            {
                request.Parameters.AddRange(requestParameters.ToEnumerable<string, object>());
            }

            return Execute(request);
        }

        public OrganizationResponse Execute(OrganizationRequest request)
        {
            OrganizationResponse response = CrmContext.OrganizationProxy.Execute(request);
            return response;
        }

        public void Associate(string addEntity, Guid addEntityId, string toEntity, Guid toEntityId, string addAttributeHint = null)
        {
            MetadataRepository repository = new MetadataRepository();
            RelationshipMetadataBase relationship = repository.FindAssociationRelationship(toEntity, addEntity, addAttributeHint);
            if (relationship == null)
            {
                // No relationship between entities. Throw exception
                throw new KeyNotFoundException(string.Format("No (unique) relationship from {0} to {1}", addEntity, toEntity));
            }

            CrmContext.OrganizationProxy.Associate(toEntity, toEntityId, new Relationship(relationship.SchemaName), new EntityReferenceCollection() {
                new EntityReference(addEntity, addEntityId)
            });
        }

        public void Associate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
        {
            CrmContext.OrganizationProxy.Associate(entityName, entityId, relationship, relatedEntities);
        }

        public void Disassociate(string addEntity, Guid addEntityId, string toEntity, Guid toEntityId, string addAttributeHint = null)
        {
            MetadataRepository repository = new MetadataRepository();
            RelationshipMetadataBase relationship = repository.FindAssociationRelationship(toEntity, addEntity, addAttributeHint);
            if (relationship == null)
            {
                // No relationship between entities. Throw exception
                throw new KeyNotFoundException(string.Format("No (unique) relationship from {0} to {1}", addEntity, toEntity));
            }

            CrmContext.OrganizationProxy.Disassociate(toEntity, toEntityId, new Relationship(relationship.SchemaName), new EntityReferenceCollection() {
                new EntityReference(addEntity, addEntityId)
            });
        }

        public void Disassociate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
        {
            CrmContext.OrganizationProxy.Disassociate(entityName, entityId, relationship, relatedEntities);
        }

        private IEnumerable<Entity> GetByQuery(QueryBase query, int? first = null, int? skip = null)
        {
            int skipRemaining = 0;
            int firstRemaining = first.HasValue ? first.Value : 0;

            PagingInfo pageInfo = BuildPagingInfo(500);
            if (skip.HasValue && skip.Value != 0)
            {
                pageInfo.PageNumber = Math.DivRem(skip.Value, pageInfo.Count, out skipRemaining) + 1;
            }
            SetQueryPagingInfo(query, pageInfo);

            bool isCompleted = false;
            do
            {
                EntityCollection tempCollection = CrmContext.OrganizationProxy.RetrieveMultiple(query);
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

        private static void SetQueryPagingInfo(QueryBase query, PagingInfo pageInfo)
        {
            if (query is QueryExpression)
            {
                (query as QueryExpression).PageInfo = pageInfo;
            }

            if (query is QueryByAttribute)
            {
                (query as QueryByAttribute).PageInfo = pageInfo;
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
            PagingInfo p = new PagingInfo();
            p.ReturnTotalRecordCount = true;
            p.PageNumber = 1;
            p.Count = pageSize;

            return p;
        }
    }
}
