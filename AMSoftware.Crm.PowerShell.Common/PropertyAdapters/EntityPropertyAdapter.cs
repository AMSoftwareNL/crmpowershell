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
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Reflection;

namespace AMSoftware.Crm.PowerShell.Common.PropertyAdapters
{
    public sealed class EntityPropertyAdapter : PropertyAdapterBase<Entity>
    {
        List<PropertyInfo> _typeProperties = new List<PropertyInfo>();

        public EntityPropertyAdapter()
        {
            _typeProperties = new List<PropertyInfo>();

            Type entityType = typeof(Entity);
            PropertyInfo[] entityProperties = entityType.GetProperties();

            string[] excludedProperties = { "EntityState", "ExtensionData", "FormattedValues", "Item",
                "LazyFileAttributeKey","LazyFileAttributeValue","LazyFileSizeAttributeKey","LazyFileSizeAttributeValue", "HasLazyFileAttribute"
            };
            foreach (var property in entityProperties)
            {
                if (!excludedProperties.Contains(property.Name))
                {
                    _typeProperties.Add(property);
                }
            }
        }

        protected override Collection<PSAdaptedProperty> GetAdaptedProperties(Entity internalObject)
        {
            MetadataRepository repository = new MetadataRepository();
            EntityMetadata entityMetadata = repository.GetEntity(internalObject.LogicalName);

            var resultCollection = new List<PSAdaptedProperty>();
            foreach (var propertyInfo in _typeProperties)
            {
                resultCollection.Add(new PSAdaptedProperty(propertyInfo.Name, new MemberTypePropertyHandler<Entity>(propertyInfo)));
            }

            PropertyInfo formattedValuesPropertyInfo = typeof(Entity).GetProperty(nameof(Entity.FormattedValues));
            resultCollection.Add(new PSAdaptedProperty("State", new ReadonlyDataCollectionPropertyHandler<Entity, string, string>(formattedValuesPropertyInfo, "statecode")));
            resultCollection.Add(new PSAdaptedProperty("Status", new ReadonlyDataCollectionPropertyHandler<Entity, string, string>(formattedValuesPropertyInfo, "statuscode")));

            string primaryNameLogicalName = entityMetadata.PrimaryNameAttribute;
            if (!string.IsNullOrWhiteSpace(primaryNameLogicalName))
            {
                resultCollection.Add(new PSAdaptedProperty("Name", new EntityAttributePropertyHandler(primaryNameLogicalName)));
            }
            resultCollection = resultCollection.OrderBy(p => p.Name, StringComparer.OrdinalIgnoreCase).ToList();

            List<PSAdaptedProperty> properties = new List<PSAdaptedProperty>();
            #region Metadata Attributes
            foreach (var attribute in entityMetadata.Attributes)
            {
                if (attribute.AttributeTypeName == AttributeTypeDisplayName.VirtualType) continue;
                if (!string.IsNullOrWhiteSpace(attribute.AttributeOf)) continue;
                if (attribute.IsValidForRead == false) continue;

                string key = attribute.LogicalName;
                properties.Add(new PSAdaptedProperty(key, new EntityAttributePropertyHandler(key)));
                if (attribute.AttributeTypeName == AttributeTypeDisplayName.CustomerType ||
                    attribute.AttributeTypeName == AttributeTypeDisplayName.LookupType ||
                    attribute.AttributeTypeName == AttributeTypeDisplayName.OwnerType)
                {
                    properties.Add(new PSAdaptedProperty(string.Format("{0}_Entity", key), new EntityRefAttributePropertyHandler(key)));
                }
            }
            #endregion

            #region Aliased Attributes
            foreach (var key in internalObject.Attributes.Keys)
            {
                if (internalObject.Attributes[key] != null && internalObject.Attributes[key] is AliasedValue)
                {
                    AliasedValue aliasedValueAttribute = internalObject.GetAttributeValue<AliasedValue>(key);
                    string aliassedKey = key.Replace('.', '_');
                    properties.Add(new PSAdaptedProperty(aliassedKey, new EntityAliassedAttributePropertyHandler(key)));

                    if (aliasedValueAttribute.Value != null && aliasedValueAttribute.Value is EntityReference)
                    {
                        properties.Add(new PSAdaptedProperty(string.Format("{0}_Entity", aliassedKey), new EntityRefAttributePropertyHandler(key)));
                    }
                }
            }
            #endregion

            #region FormattedValues
            foreach (var key in internalObject.FormattedValues.Keys)
            {
                if (internalObject.FormattedValues[key] != null)
                {
                    properties.Add(
                        new PSAdaptedProperty(string.Format("{0}_FormattedValue", key.Replace('.', '_')), 
                            new ReadonlyDataCollectionPropertyHandler<Entity, string, string>(
                                formattedValuesPropertyInfo, key)));
                }
            }
            #endregion
       
            foreach (var prop in properties.OrderBy(p => p.Name, StringComparer.OrdinalIgnoreCase))
            {
                if (!resultCollection.Any(p => p.Name.Equals(prop.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    resultCollection.Add(prop);
                }
            }

            return new Collection<PSAdaptedProperty>(resultCollection);
        }

        public override Collection<string> GetTypeNameHierarchy(object baseObject)
        {
            if (baseObject is Entity internalObject)
            {
                Collection<string> typeHierarchy = base.GetTypeNameHierarchy(baseObject);
                typeHierarchy.Insert(0, string.Format("{0}+{1}", internalObject.GetType().FullName, internalObject.LogicalName));

                return typeHierarchy;
            }
            return base.GetTypeNameHierarchy(baseObject);
        }
    }
}
