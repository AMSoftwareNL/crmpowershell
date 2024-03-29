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
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace AMSoftware.Crm.PowerShell.Common.Repositories
{
    internal sealed class MetadataRepository
    {
        #region Entity
        public EntityMetadata GetEntity(string name)
        {
            if (CrmContext.Session.UseMetadataCache)
            {
                return CrmContext.Session.OrganizationCache.GetEntities()
                    .FirstOrDefault(e => e.LogicalName.Equals(name, StringComparison.InvariantCulture));
            }
            else
            {
                OrganizationRequest request = new OrganizationRequest("RetrieveEntity")
                {
                    Parameters = new ParameterCollection
                    {
                        { "LogicalName", name },
                        { "EntityFilters", EntityFilters.Entity },
                        { "RetrieveAsIfPublished", true },
                        { "MetadataId", default(Guid) }
                    }
                };

                OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);

                return (EntityMetadata)response.Results["EntityMetadata"];
            }
        }

        public EntityMetadata GetEntity(Guid metadataId)
        {
            if (CrmContext.Session.UseMetadataCache)
            {
                return CrmContext.Session.OrganizationCache.GetEntities()
                .FirstOrDefault(e => e.MetadataId == metadataId);
            }
            else
            {
                OrganizationRequest request = new OrganizationRequest("RetrieveEntity")
                {
                    Parameters = new ParameterCollection
                    {
                        { "EntityFilters", EntityFilters.Entity },
                        { "RetrieveAsIfPublished", true },
                        { "MetadataId", metadataId }
                    }
                };

                OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);

                return (EntityMetadata)response.Results["EntityMetadata"];
            }
        }

        public EntityMetadata GetEntity(int objectTypeCode)
        {
            IEnumerable<EntityMetadata> entitiesData = GetEntity();

            return entitiesData.FirstOrDefault(e => e.ObjectTypeCode == objectTypeCode);
        }

        public IEnumerable<EntityMetadata> GetEntity()
        {
            if (CrmContext.Session.UseMetadataCache)
            {
                return CrmContext.Session.OrganizationCache.GetEntities();
            }
            else
            {
                OrganizationRequest request = new OrganizationRequest("RetrieveAllEntities")
                {
                    Parameters = new ParameterCollection
                    {
                        { "EntityFilters", EntityFilters.Entity },
                        { "RetrieveAsIfPublished", true }
                    }
                };

                OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);

                return (EntityMetadata[])response.Results["EntityMetadata"];
            }
        }

        public Guid AddEntity(EntityMetadata entity, AttributeMetadata attribute, bool? hasNotes = null, bool? hasActivites = null)
        {
            OrganizationRequest request = new OrganizationRequest("CreateEntity")
            {
                Parameters = new ParameterCollection
                {
                    { "Entity", entity },
                    { "PrimaryAttribute", attribute },
                    { "HasNotes", hasNotes.GetValueOrDefault() },
                    { "HasActivities", hasActivites.GetValueOrDefault() }
                }
            };

            if (CrmContext.Session.ActiveSolutionName != null)
            {
                request.Parameters.Add("SolutionUniqueName", CrmContext.Session.ActiveSolutionName);
            }

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);

            return (Guid)response.Results["EntityId"];
        }

        public void UpdateEntity(EntityMetadata entity, bool? hasNotes = null, bool? hasActivites = null)
        {
            OrganizationRequest request = new OrganizationRequest("UpdateEntity")
            {
                Parameters = new ParameterCollection
                {
                    { "Entity", entity },
                    { "HasNotes", hasNotes.GetValueOrDefault() },
                    { "HasActivities", hasActivites.GetValueOrDefault() },
                    { "MergeLabels", true }
                }
            };

            if (CrmContext.Session.ActiveSolutionName != null)
            {
                request.Parameters.Add("SolutionUniqueName", CrmContext.Session.ActiveSolutionName);
            }

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
        }

        public void DeleteEntity(string name)
        {
            OrganizationRequest request = new OrganizationRequest("DeleteEntity")
            {
                Parameters = new ParameterCollection
                {
                    { "LogicalName", name }
                }
            };

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
        }

        private EntityMetadata GetEntity(string name, EntityFilters filter)
        {
            OrganizationRequest request = new OrganizationRequest("RetrieveEntity")
            {
                Parameters = new ParameterCollection
                {
                    { "LogicalName", name },
                    { "EntityFilters", filter },
                    { "RetrieveAsIfPublished", true },
                    { "MetadataId", default(Guid) }
                }
            };

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);

            return (EntityMetadata)response.Results["EntityMetadata"];
        }
        #endregion

        #region OptionSet
        public OptionSetMetadataBase GetOptionSet(string name)
        {
            OrganizationRequest request = new OrganizationRequest("RetrieveOptionSet")
            {
                Parameters = new ParameterCollection
                {
                    { "Name", name },
                    { "RetrieveAsIfPublished", true },
                    { "MetadataId", default(Guid) }
                }
            };

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);

            return (OptionSetMetadataBase)response.Results["OptionSetMetadata"];
        }

        public OptionSetMetadataBase GetOptionSet(Guid metadataId)
        {
            OrganizationRequest request = new OrganizationRequest("RetrieveOptionSet")
            {
                Parameters = new ParameterCollection
                {
                    { "RetrieveAsIfPublished", true },
                    { "MetadataId", metadataId }
                }
            };

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);

            return (OptionSetMetadataBase)response.Results["OptionSetMetadata"];
        }

        public IEnumerable<OptionSetMetadataBase> GetOptionSet(bool customOnly, bool excludeManaged)
        {
            OrganizationRequest request = new OrganizationRequest("RetrieveAllOptionSets")
            {
                Parameters = new ParameterCollection
                {
                    { "RetrieveAsIfPublished", true }
                }
            };

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
            IEnumerable<OptionSetMetadataBase> result = ((OptionSetMetadataBase[])response.Results["OptionSetMetadata"]).Cast<OptionSetMetadataBase>();
            result = result
                .Where(e => e.IsCustomOptionSet == customOnly || customOnly == false)              // include if custom, or customOnly not active
                .Where(e => e.IsManaged != excludeManaged || excludeManaged == false);           // exclude if is managed, or excludeManaged not active

            return result;
        }

        public Guid AddOptionSet(OptionSetMetadataBase optionSet)
        {
            OrganizationRequest request = new OrganizationRequest("CreateOptionSet")
            {
                Parameters = new ParameterCollection
                {
                    { "OptionSet", optionSet }
                }
            };

            if (CrmContext.Session.ActiveSolutionName != null)
            {
                request.Parameters.Add("SolutionUniqueName", CrmContext.Session.ActiveSolutionName);
            }

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);

            return (Guid)response.Results["OptionSetId"];
        }

        public void UpdateOptionSet(OptionSetMetadataBase optionSet)
        {
            OrganizationRequest request = new OrganizationRequest("UpdateOptionSet")
            {
                Parameters = new ParameterCollection
                {
                    { "OptionSet", optionSet },
                    { "MergeLabels", true }
                }
            };

            if (CrmContext.Session.ActiveSolutionName != null)
            {
                request.Parameters.Add("SolutionUniqueName", CrmContext.Session.ActiveSolutionName);
            }

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
        }

        public void DeleteOptionSet(string name)
        {
            OrganizationRequest request = new OrganizationRequest("DeleteOptionSet")
            {
                Parameters = new ParameterCollection
                {
                    { "Name", name }
                }
            };

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
        }

        public int AddOptionSetValue(string name, string displayName, int? value = null, string description = null)
        {
            OrganizationRequest request = new OrganizationRequest("InsertOptionValue")
            {
                Parameters = new ParameterCollection
                {
                    { "OptionSetName", name },
                    { "Label", new Label(displayName, CrmContext.Session.Language) }
                }
            };
            if (value.HasValue)
            {
                request.Parameters.Add("Value", value.Value);
            }
            if (description != null)
            {
                request.Parameters.Add("Description", new Label(description, CrmContext.Session.Language));
            }

            if (CrmContext.Session.ActiveSolutionName != null)
            {
                request.Parameters.Add("SolutionUniqueName", CrmContext.Session.ActiveSolutionName);
            }

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
            return (int)response.Results["NewOptionValue"];
        }

        public int AddOptionSetValue(string entity, string attribute, string displayName, int? value = null, string description = null)
        {
            OrganizationRequest request = new OrganizationRequest("InsertOptionValue")
            {
                Parameters = new ParameterCollection
                {
                    { "EntityLogicalName", entity },
                    { "AttributeLogicalName", attribute },
                    { "Label", new Label(displayName, CrmContext.Session.Language) }
                }
            };
            if (value.HasValue)
            {
                request.Parameters.Add("Value", value.Value);
            }
            if (description != null)
            {
                request.Parameters.Add("Description", new Label(description, CrmContext.Session.Language));
            }

            if (CrmContext.Session.ActiveSolutionName != null)
            {
                request.Parameters.Add("SolutionUniqueName", CrmContext.Session.ActiveSolutionName);
            }

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
            return (int)response.Results["NewOptionValue"];
        }

        public void DeleteOptionSetValue(string name, int value)
        {
            OrganizationRequest request = new OrganizationRequest("DeleteOptionValue")
            {
                Parameters = new ParameterCollection
                {
                    { "OptionSetName", name },
                    { "Value", value }
                }
            };

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
        }

        public void DeleteOptionSetValue(string entity, string attribute, int value)
        {
            OrganizationRequest request = new OrganizationRequest("DeleteOptionValue")
            {
                Parameters = new ParameterCollection
                {
                    { "EntityLogicalName", entity },
                    { "AttributeLogicalName", attribute },
                    { "Value", value }
                }
            };

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
        }

        public void UpdateOptionSetValue(string name, int value, string displayName = null, string description = null)
        {
            OrganizationRequest request = new OrganizationRequest("UpdateOptionValue")
            {
                Parameters = new ParameterCollection
                {
                    { "OptionSetName", name },
                    { "Value", value },
                    { "MergeLabels", true }
                }
            };

            if (!string.IsNullOrEmpty(displayName))
            {
                request.Parameters.Add("Label", new Label(displayName, CrmContext.Session.Language));
            }
            if (description != null)
            {
                request.Parameters.Add("Description", new Label(description, CrmContext.Session.Language));
            }

            if (CrmContext.Session.ActiveSolutionName != null)
            {
                request.Parameters.Add("SolutionUniqueName", CrmContext.Session.ActiveSolutionName);
            }

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
        }

        public void UpdateOptionSetValue(string entity, string attribute, int value, string displayName = null, string description = null)
        {
            OrganizationRequest request = new OrganizationRequest("UpdateOptionValue")
            {
                Parameters = new ParameterCollection
                {
                    { "EntityLogicalName", entity },
                    { "AttributeLogicalName", attribute },
                    { "Value", value },
                    { "MergeLabels", true }
                }
            };

            if (!string.IsNullOrEmpty(displayName))
            {
                request.Parameters.Add("Label", new Label(displayName, CrmContext.Session.Language));
            }
            if (description != null)
            {
                request.Parameters.Add("Description", new Label(description, CrmContext.Session.Language));
            }

            if (CrmContext.Session.ActiveSolutionName != null)
            {
                request.Parameters.Add("SolutionUniqueName", CrmContext.Session.ActiveSolutionName);
            }

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
        }
        #endregion

        #region Attribute
        public AttributeMetadata GetAttribute(Guid id)
        {
            if (CrmContext.Session.UseMetadataCache)
            {
                return CrmContext.Session.OrganizationCache.GetEntities()
                    .SelectMany(e => e.Attributes)
                    .FirstOrDefault(a => a.MetadataId == id);
            }
            else
            {
                OrganizationRequest request = new OrganizationRequest("RetrieveAttribute")
                {
                    Parameters = new ParameterCollection
                    {
                        { "RetrieveAsIfPublished", true },
                        { "MetadataId", id }
                    }
                };

                OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);

                return (AttributeMetadata)response.Results["AttributeMetadata"];
            }
        }

        public AttributeMetadata GetAttribute(string entity, string attribute)
        {
            if (CrmContext.Session.UseMetadataCache)
            {
                EntityMetadata entityData = GetEntity(entity);
                if (entityData == null) return null;

                return entityData.Attributes.FirstOrDefault(a => a.LogicalName.Equals(attribute, StringComparison.InvariantCulture));
            }
            else
            {
                OrganizationRequest request = new OrganizationRequest("RetrieveAttribute")
                {
                    Parameters = new ParameterCollection
                    {
                        { "EntityLogicalName", entity },
                        { "LogicalName", attribute },
                        { "RetrieveAsIfPublished", true },
                        { "MetadataId", default(Guid) }
                    }
                };

                OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);

                return (AttributeMetadata)response.Results["AttributeMetadata"];
            }
        }

        public IEnumerable<AttributeMetadata> GetAttribute(string entity, bool customOnly, bool excludeManaged, bool includeLinked)
        {
            EntityMetadata entityData = null;
            if (CrmContext.Session.UseMetadataCache)
            {
                entityData = GetEntity(entity);
                if (entityData == null) return null;
            }
            else
            {
                entityData = GetEntity(entity, EntityFilters.Attributes);
                if (entityData == null) return null;
            }

            IEnumerable<AttributeMetadata> result = entityData.Attributes.AsEnumerable<AttributeMetadata>();
            if (customOnly)
            {
                result = result.Where(a => a.IsCustomAttribute == true);
            }
            if (excludeManaged)
            {
                result = result.Where(a => a.IsManaged != true);
            }
            if (!includeLinked)
            {
                result = result.Where(a => string.IsNullOrWhiteSpace(a.AttributeOf));
            }

            return result;
        }

        public Guid AddAttribute(string entity, AttributeMetadata attribute)
        {
            OrganizationRequest request = new OrganizationRequest("CreateAttribute")
            {
                Parameters = new ParameterCollection
                {
                    { "EntityName", entity },
                    { "Attribute", attribute }
                }
            };

            if (CrmContext.Session.ActiveSolutionName != null)
            {
                request.Parameters.Add("SolutionUniqueName", CrmContext.Session.ActiveSolutionName);
            }

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
            return (Guid)response.Results["AttributeId"];
        }

        public void UpdateAttribute(string entity, AttributeMetadata attribute)
        {
            OrganizationRequest request = new OrganizationRequest("UpdateAttribute")
            {
                Parameters = new ParameterCollection
                {
                    { "EntityName", entity },
                    { "Attribute", attribute },
                    { "MergeLabels", true }
                }
            };

            if (CrmContext.Session.ActiveSolutionName != null)
            {
                request.Parameters.Add("SolutionUniqueName", CrmContext.Session.ActiveSolutionName);
            }

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
        }

        public void DeleteAttribute(string entity, string attribute)
        {
            OrganizationRequest request = new OrganizationRequest("DeleteAttribute")
            {
                Parameters = new ParameterCollection
                {
                    { "EntityLogicalName", entity },
                    { "LogicalName", attribute }
                }
            };

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
        }
        #endregion

        #region EntityKey
        public EntityKeyMetadata GetEntityKey(Guid id)
        {
            if (CrmContext.Session.UseMetadataCache)
            {
                return CrmContext.Session.OrganizationCache.GetEntities()
                .SelectMany(e => e.Keys)
                .FirstOrDefault(k => k.MetadataId == id);
            }
            else
            {
                OrganizationRequest request = new OrganizationRequest("RetrieveEntityKey")
                {
                    Parameters = new ParameterCollection
                    {
                        { "RetrieveAsIfPublished", false },
                        { "MetadataId", id }
                    }
                };

                OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);

                return (EntityKeyMetadata)response.Results["EntityKeyMetadata"];
            }
        }

        public EntityKeyMetadata GetEntityKey(string entity, string key)
        {
            if (CrmContext.Session.UseMetadataCache)
            {
                EntityMetadata entityData = GetEntity(entity);
                if (entityData == null) return null;

                return entityData.Keys.FirstOrDefault(k => k.LogicalName.Equals(key, StringComparison.InvariantCulture));
            }
            else
            {
                OrganizationRequest request = new OrganizationRequest("RetrieveEntityKey")
                {
                    Parameters = new ParameterCollection
                    {
                        { "EntityLogicalName", entity },
                        { "LogicalName", key },
                        { "RetrieveAsIfPublished", false },
                        { "MetadataId", default(Guid) }
                    }
                };

                OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);

                return (EntityKeyMetadata)response.Results["EntityKeyMetadata"];
            }
        }

        public IEnumerable<EntityKeyMetadata> GetEntityKey(string entity, bool excludeManaged)
        {
            EntityMetadata entityData = null;
            if (CrmContext.Session.UseMetadataCache)
            {
                entityData = GetEntity(entity);
                if (entityData == null) return null;
            }
            else
            {
                entityData = GetEntity(entity, EntityFilters.All);
                if (entityData == null) return null;
            }

            IEnumerable<EntityKeyMetadata> result = entityData.Keys.AsEnumerable<EntityKeyMetadata>();
            if (excludeManaged)
            {
                result = result.Where(a => a.IsManaged != true);
            }

            return result;
        }

        public Guid AddEntityKey(string entity, EntityKeyMetadata key)
        {
            OrganizationRequest request = new OrganizationRequest("CreateEntityKey")
            {
                Parameters = new ParameterCollection
                {
                    { "EntityName", entity },
                    { "EntityKey", key }
                }
            };

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
            return (Guid)response.Results["EntityKeyId"];
        }

        public void DeleteEntityKey(string entity, string key)
        {
            OrganizationRequest request = new OrganizationRequest("DeleteEntityKey")
            {
                Parameters = new ParameterCollection
                {
                    { "EntityLogicalName", entity },
                    { "Name", key }
                }
            };

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
        }
        #endregion

        #region Relationship
        public IEnumerable<RelationshipMetadataBase> GetRelationship(string entity, string relatedEntity, CrmRelationshipType relationshipType, bool customOnly, bool excludeManaged)
        {
            EntityMetadata entityData = null;
            if (CrmContext.Session.UseMetadataCache)
            {
                entityData = GetEntity(entity);
            }
            else
            {
                entityData = GetEntity(entity, EntityFilters.Relationships);
            }
            if (entityData == null) return null;

            List<RelationshipMetadataBase> resultAsList = new List<RelationshipMetadataBase>();

            if (string.IsNullOrWhiteSpace(relatedEntity))
            {
                if ((relationshipType == CrmRelationshipType.All || relationshipType == CrmRelationshipType.ManyToMany) && entityData.ManyToManyRelationships != null)
                {
                    resultAsList.AddRange(entityData.ManyToManyRelationships);
                }
                if (relationshipType == CrmRelationshipType.All || relationshipType == CrmRelationshipType.OneToMany)
                {
                    if (entityData.OneToManyRelationships != null)
                        resultAsList.AddRange(entityData.OneToManyRelationships);
                    if (entityData.ManyToOneRelationships != null)
                        resultAsList.AddRange(entityData.ManyToOneRelationships);
                }
            }
            else
            {
                if ((relationshipType == CrmRelationshipType.All || relationshipType == CrmRelationshipType.ManyToMany) && entityData.ManyToManyRelationships != null)
                {
                    resultAsList.AddRange(
                        entityData.ManyToManyRelationships.Where(r =>
                            r.Entity2LogicalName.Equals(relatedEntity, StringComparison.InvariantCultureIgnoreCase) ||
                            r.Entity1LogicalName.Equals(relatedEntity, StringComparison.InvariantCultureIgnoreCase)));
                }
                if (relationshipType == CrmRelationshipType.All || relationshipType == CrmRelationshipType.OneToMany)
                {
                    if (entityData.OneToManyRelationships != null)
                        resultAsList.AddRange(
                                entityData.OneToManyRelationships.Where(r =>
                                    r.ReferencedEntity.Equals(relatedEntity, StringComparison.InvariantCultureIgnoreCase) ||
                                    r.ReferencingEntity.Equals(relatedEntity, StringComparison.InvariantCultureIgnoreCase)));
                    if (entityData.ManyToOneRelationships != null)
                        resultAsList.AddRange(
                            entityData.ManyToOneRelationships.Where(r =>
                                r.ReferencedEntity.Equals(relatedEntity, StringComparison.InvariantCultureIgnoreCase) ||
                                r.ReferencingEntity.Equals(relatedEntity, StringComparison.InvariantCultureIgnoreCase)));
                }
            }

            IEnumerable<RelationshipMetadataBase> result = resultAsList.AsEnumerable<RelationshipMetadataBase>();
            if (customOnly)
            {
                result = result.Where(r => r.IsCustomRelationship == true);
            }
            if (excludeManaged)
            {
                result = result.Where(r => r.IsManaged != true);
            }

            return result;
        }

        public RelationshipMetadataBase GetRelationship(Guid id)
        {
            if (CrmContext.Session.UseMetadataCache)
            {
                var entities = CrmContext.Session.OrganizationCache.GetEntities();

                var relationship = entities
                    .SelectMany(e => e.OneToManyRelationships)
                    .FirstOrDefault<RelationshipMetadataBase>(r => r.MetadataId == id);

                if (relationship == null)
                {
                    relationship = entities
                    .SelectMany(e => e.ManyToOneRelationships)
                    .FirstOrDefault<RelationshipMetadataBase>(r => r.MetadataId == id);
                }

                if (relationship == null)
                {
                    relationship = entities
                    .SelectMany(e => e.ManyToManyRelationships)
                    .FirstOrDefault<RelationshipMetadataBase>(r => r.MetadataId == id);
                }

                return relationship;
            }
            else
            {
                OrganizationRequest request = new OrganizationRequest("RetrieveRelationship")
                {
                    Parameters = new ParameterCollection
                    {
                        { "MetadataId", id },
                        { "RetrieveAsIfPublished", true }
                    }
                };

                OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
                return (RelationshipMetadataBase)response.Results["RelationshipMetadata"];
            }
        }

        public RelationshipMetadataBase GetRelationship(string name)
        {
            if (CrmContext.Session.UseMetadataCache)
            {
                var entities = CrmContext.Session.OrganizationCache.GetEntities();

                var relationship = entities
                    .SelectMany(e => e.OneToManyRelationships)
                    .FirstOrDefault<RelationshipMetadataBase>(r => r.SchemaName.Equals(name, StringComparison.InvariantCulture));

                if (relationship == null)
                {
                    relationship = entities
                    .SelectMany(e => e.ManyToOneRelationships)
                    .FirstOrDefault<RelationshipMetadataBase>(r => r.SchemaName.Equals(name, StringComparison.InvariantCulture));
                }

                if (relationship == null)
                {
                    relationship = entities
                    .SelectMany(e => e.ManyToManyRelationships)
                    .FirstOrDefault<RelationshipMetadataBase>(r => r.SchemaName.Equals(name, StringComparison.InvariantCulture));
                }

                return relationship;
            }
            else
            {
                OrganizationRequest request = new OrganizationRequest("RetrieveRelationship")
                {
                    Parameters = new ParameterCollection
                    {
                        { "Name", name },
                        { "RetrieveAsIfPublished", true },
                        { "MetadataId", Guid.Empty }
                    }
                };

                OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
                return (RelationshipMetadataBase)response.Results["RelationshipMetadata"];
            }
        }

        public Guid AddRelationship(OneToManyRelationshipMetadata relationship, LookupAttributeMetadata lookup)
        {
            if (!IsOneToManyRelationshipEligible(relationship))
            {
                throw new Exception(string.Format("One-to-Many relationship between '{0}' and '{1}' is not allowed.",
                    relationship.ReferencingEntity, relationship.ReferencedEntity));
            }

            OrganizationRequest request = new OrganizationRequest("CreateOneToMany")
            {
                Parameters = new ParameterCollection
                {
                    { "OneToManyRelationship", relationship },
                    { "Lookup", lookup }
                }
            };

            if (CrmContext.Session.ActiveSolutionName != null)
            {
                request.Parameters.Add("SolutionUniqueName", CrmContext.Session.ActiveSolutionName);
            }

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
            return (Guid)response.Results["RelationshipId"];
        }

        public Guid AddPolymorphicRelationship(OneToManyRelationshipMetadata relationship, LookupAttributeMetadata lookup)
        {
            if (!IsOneToManyRelationshipEligible(relationship))
            {
                throw new Exception(string.Format("One-to-Many relationship between '{0}' and '{1}' is not allowed.",
                    relationship.ReferencingEntity, relationship.ReferencedEntity));
            }

            AttributeMetadata existingLookupAttribute = null;
            try
            {
                existingLookupAttribute = GetAttribute(relationship.ReferencingEntity, lookup.LogicalName);
            }
            catch { }

            if (existingLookupAttribute == null)
            {
                // Lookup Attribute doesn't exist yet. Create new Polymorphic Lookup Attribute
                OrganizationRequest request = new OrganizationRequest("CreatePolymorphicLookupAttribute")
                {
                    Parameters = new ParameterCollection
                {
                    { "OneToManyRelationships", new OneToManyRelationshipMetadata[] { relationship } },
                    { "Lookup", lookup }
                }
                };

                if (CrmContext.Session.ActiveSolutionName != null)
                {
                    request.Parameters.Add("SolutionUniqueName", CrmContext.Session.ActiveSolutionName);
                }

                OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
                return ((Guid[])response.Results["RelationshipIds"]).First();
            }
            else
            {
                // Add relationship to existing Lookup
                return AddRelationship(relationship, (LookupAttributeMetadata)existingLookupAttribute);
            }
        }

        public Guid AddRelationship(ManyToManyRelationshipMetadata relationship, string intersect)
        {
            bool isEligible1 = EligibleForRelationship(relationship.Entity1LogicalName, "CanManyToMany");
            bool isEligible2 = EligibleForRelationship(relationship.Entity2LogicalName, "CanManyToMany");

            if (!(isEligible1 && isEligible2))
            {
                throw new Exception(string.Format("Many-to-Many relationship between '{0}' and '{1}' is not allowed.",
                    relationship.Entity1LogicalName, relationship.Entity2LogicalName));
            }

            OrganizationRequest request = new OrganizationRequest("CreateManyToMany")
            {
                Parameters = new ParameterCollection
                {
                    { "IntersectEntitySchemaName", intersect },
                    { "ManyToManyRelationship", relationship }
                }
            };

            if (CrmContext.Session.ActiveSolutionName != null)
            {
                request.Parameters.Add("SolutionUniqueName", CrmContext.Session.ActiveSolutionName);
            }

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
            return (Guid)response.Results["ManyToManyRelationshipId"];
        }

        public void UpdateRelationship(RelationshipMetadataBase relationship)
        {
            OrganizationRequest request = new OrganizationRequest("UpdateRelationship")
            {
                Parameters = new ParameterCollection
                {
                    { "Relationship", relationship },
                    { "MergeLabels", true }
                }
            };

            if (CrmContext.Session.ActiveSolutionName != null)
            {
                request.Parameters.Add("SolutionUniqueName", CrmContext.Session.ActiveSolutionName);
            }

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
        }

        public void DeleteRelationship(string relationship)
        {
            OrganizationRequest request = new OrganizationRequest("DeleteRelationship")
            {
                Parameters = new ParameterCollection
                {
                    { "Name", relationship }
                }
            };

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
        }

        public void DeleteRelationship(string entity, string fromEntity, string attributeHint = null)
        {
            RelationshipMetadataBase relationship = FindAssociationRelationship(fromEntity, entity, attributeHint);
            if (relationship == null)
            {
                // No relationship between entities. Throw exception
                throw new KeyNotFoundException(string.Format("No (unique) relationship from {0} to {1}", entity, fromEntity));
            }

            DeleteRelationship(relationship.SchemaName);
        }

        internal RelationshipMetadataBase FindAssociationRelationship(string referencedEntity, string referencingEntity, string referencingAttribute = null)
        {
            var relationships = this
                .GetRelationship(referencedEntity, referencingEntity, CrmRelationshipType.All, false, false)
                .Where(r =>
                    r.RelationshipType == RelationshipType.ManyToManyRelationship ||
                    (r.RelationshipType == RelationshipType.OneToManyRelationship &&
                        ((OneToManyRelationshipMetadata)r).ReferencedEntity.Equals(referencedEntity, StringComparison.InvariantCultureIgnoreCase) &&
                        ((OneToManyRelationshipMetadata)r).ReferencingEntity.Equals(referencingEntity, StringComparison.InvariantCultureIgnoreCase)))
                .ToList();

            RelationshipMetadataBase relationship = null;
            if (relationships.Count == 1)
            {
                // Exactly one relationship found. Ignore relatedAttribute hint, and use this relationship
                relationship = relationships[0];
            }
            else if (relationships.Count > 1)
            {
                if (!string.IsNullOrWhiteSpace(referencingAttribute))
                {
                    // Assume one-to-many relationship and use relatedAttribute hint to located the correct one.
                    relationship = relationships
                        .Where(r =>
                            r.RelationshipType == RelationshipType.OneToManyRelationship &&
                            ((OneToManyRelationshipMetadata)r).ReferencingAttribute.Equals(referencingAttribute, StringComparison.InvariantCultureIgnoreCase))
                        .SingleOrDefault();
                }

                if (relationship == null)
                {
                    //No relationship found using hint. Assume Many-to-Many relationship. Try to find single one.
                    relationship = relationships
                        .Where(r => r.RelationshipType == RelationshipType.ManyToManyRelationship)
                        .SingleOrDefault();
                }
            }

            return relationship;
        }

        private bool EligibleForRelationship(string entity, string relationCheck)
        {
            OrganizationRequest request = new OrganizationRequest(relationCheck)
            {
                Parameters = new ParameterCollection
                {
                    { "EntityName", entity }
                }
            };

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);

            return (bool)response.Results[relationCheck];
        }

        private bool IsOneToManyRelationshipEligible(OneToManyRelationshipMetadata relationship)
        {
            bool isReferencingEligible = EligibleForRelationship(relationship.ReferencingEntity, "CanBeReferencing");
            bool isReferencedEligible = EligibleForRelationship(relationship.ReferencedEntity, "CanBeReferenced");

            return isReferencedEligible && isReferencingEligible;
        }
        #endregion

        #region Managed Property
        public ManagedPropertyMetadata GetManagedProperty(Guid metadataId)
        {
            OrganizationRequest request = new OrganizationRequest("RetrieveManagedProperty")
            {
                Parameters = new ParameterCollection
                {
                    { "MetadataId", metadataId }
                }
            };

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);

            return (ManagedPropertyMetadata)response.Results["ManagedPropertyMetadata"];
        }

        #endregion
    }
}
