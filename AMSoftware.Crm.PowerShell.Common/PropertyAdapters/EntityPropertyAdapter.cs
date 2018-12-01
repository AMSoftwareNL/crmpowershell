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
using AMSoftware.Crm.PowerShell.Common.Helpers;
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
        private Dictionary<string, IAdaptedPropertyHandler<Entity>> _entityPropertyHandlerCache = null;
        private Cache<string> _entityPrimaryNameCache = new Cache<string>();

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

        protected override Collection<PSAdaptedProperty> GetAdaptedProperties(Entity internalObject)
        {
            List<PSAdaptedProperty> properties = new List<PSAdaptedProperty>();
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
                else
                {
                    properties.Add(new PSAdaptedProperty(key, new EntityAttributePropertyHandler(key)));
                    if (internalObject.Attributes[key] != null && internalObject.Attributes[key] is EntityReference)
                    {
                        properties.Add(new PSAdaptedProperty(string.Format("{0}_Entity", key), new EntityRefAttributePropertyHandler(key)));
                    }
                }
            }

            foreach (var key in internalObject.FormattedValues.Keys)
            {
                properties.Add(new PSAdaptedProperty(string.Format("{0}_FormattedValue", key.Replace('.', '_')), new FormattedValuePropertyHandler(key)));
            }

            if (_entityPropertyHandlerCache == null)
            {
                InitEntityPropertyHandlerCache();
            }

            List<PSAdaptedProperty> typeProperties = new List<PSAdaptedProperty>();
            PSAdaptedProperty nameProperty = GetPrimaryNameProperty(internalObject);
            if (nameProperty != null)
            {
                typeProperties.Add(nameProperty);
            }

            foreach (var item in _entityPropertyHandlerCache)
            {
                typeProperties.Add(new PSAdaptedProperty(item.Key, item.Value));
            }
            typeProperties = typeProperties.OrderBy(p => p.Name, StringComparer.OrdinalIgnoreCase).ToList();

            var resultCollection = new Collection<PSAdaptedProperty>(typeProperties);
            foreach (var prop in properties.OrderBy(p => p.Name, StringComparer.OrdinalIgnoreCase))
            {
                if (!resultCollection.Any(p => p.Name.Equals(prop.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    resultCollection.Add(prop);
                }
            }

            return resultCollection;
        }

        public override PSAdaptedProperty GetProperty(object baseObject, string propertyName)
        {
            PSAdaptedProperty prop = base.GetProperty(baseObject, propertyName);

            if (prop == null && baseObject is Entity internalObject)
            {
                MetadataRepository repository = new MetadataRepository();
                AttributeMetadata attributeMetadata = null;
                try
                {
                    attributeMetadata = repository.GetAttribute(internalObject.LogicalName, propertyName);
                }
                catch { }

                if (attributeMetadata != null)
                {
                    return new PSAdaptedProperty(attributeMetadata.LogicalName, new EntityAttributePropertyHandler(attributeMetadata.LogicalName));
                }
            }
            return prop;
        }

        private void InitEntityPropertyHandlerCache()
        {
            _entityPropertyHandlerCache = new Dictionary<string, IAdaptedPropertyHandler<Entity>>();

            Type entityType = typeof(Entity);
            PropertyInfo[] entityProperties = entityType.GetProperties();

            string[] excludedProperties = { "Attributes", "EntityState", "ExtensionData", "FormattedValues", "Item", "KeyAttributes", "RelatedEntities" };
            foreach (var property in entityProperties)
            {
                if (!excludedProperties.Contains(property.Name))
                {
                    _entityPropertyHandlerCache.Add(property.Name, new MemberTypePropertyHandler<Entity>(property));
                }
            }

            _entityPropertyHandlerCache.Add("State", new FormattedValuePropertyHandler("statecode"));
            _entityPropertyHandlerCache.Add("Status", new FormattedValuePropertyHandler("statuscode"));
        }

        private PSAdaptedProperty GetPrimaryNameProperty(Entity internalObject)
        {
            if (internalObject.LogicalName.Equals("solutioncomponent", StringComparison.InvariantCultureIgnoreCase))
            {
                return new PSAdaptedProperty("Name", new FunctionPropertyHandler<Entity, string>(GetSolutionComponentName));
            }

            string primaryNameAttribute = GetPrimaryNameAttribute(internalObject);
            if (!string.IsNullOrWhiteSpace(primaryNameAttribute))
            {
                return new PSAdaptedProperty("Name", new EntityAttributePropertyHandler(primaryNameAttribute));
            }
            else
            {
                return null;
            }
        }

        private string GetPrimaryNameAttribute(Entity internalObject)
        {
            if (!_entityPrimaryNameCache.TryGetValue(internalObject.LogicalName, out string primaryNameAttribute))
            {
                MetadataRepository repository = new MetadataRepository();
                EntityMetadata entityMetadata = repository.GetEntity(internalObject.LogicalName);
                if (entityMetadata != null && !string.IsNullOrWhiteSpace(entityMetadata.PrimaryNameAttribute))
                {
                    primaryNameAttribute = entityMetadata.PrimaryNameAttribute;
                }
                else
                {
                    primaryNameAttribute = null;
                }
                _entityPrimaryNameCache.Add(internalObject.LogicalName, primaryNameAttribute);
            }

            return primaryNameAttribute;
        }

        private string GetSolutionComponentName(Entity baseObject)
        {
            OptionSetValue componentType = baseObject.GetAttributeValue<OptionSetValue>("componenttype");
            Guid objectId = baseObject.GetAttributeValue<Guid>("objectid");

            return SolutionManagementHelper.GetComponentName(componentType.Value, objectId);
        }
    }
}
