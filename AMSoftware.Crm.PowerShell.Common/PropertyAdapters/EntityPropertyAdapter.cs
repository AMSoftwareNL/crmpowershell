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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using AMSoftware.Crm.PowerShell.Common.Helpers;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace AMSoftware.Crm.PowerShell.Common.PropertyAdapters
{
    public sealed class EntityPropertyAdapter : PSPropertyAdapter
    {
        private Dictionary<string, IAdaptedPropertyHandler<Entity>> _entityPropertyHandlerCache = null;
        private Cache<string> _entityPrimaryNameCache = new Cache<string>();

        public override Collection<string> GetTypeNameHierarchy(object baseObject)
        {
            Entity internalObject = baseObject as Entity;
            if (internalObject != null)
            {
                Collection<string> typeHierarchy = base.GetTypeNameHierarchy(baseObject);
                typeHierarchy.Insert(0, string.Format("{0}+{1}", internalObject.GetType().FullName, internalObject.LogicalName));

                return typeHierarchy;
            }
            return base.GetTypeNameHierarchy(baseObject);
        }

        public override Collection<PSAdaptedProperty> GetProperties(object baseObject)
        {
            Entity internalObject = baseObject as Entity;
            if (internalObject != null)
            {
                return GetAdaptedProperties(internalObject);
            }

            return null;
        }

        public override PSAdaptedProperty GetProperty(object baseObject, string propertyName)
        {
            Entity internalObject = baseObject as Entity;
            if (internalObject != null)
            {
                var properties = GetAdaptedProperties(internalObject);
                PSAdaptedProperty property = properties.SingleOrDefault(p => p.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase));
                if (property != null)
                {
                    return property;
                }
            }

            return null;
        }

        public override string GetPropertyTypeName(PSAdaptedProperty adaptedProperty)
        {
            if (adaptedProperty.Tag != null)
            {
                IAdaptedPropertyHandler<Entity> propHandler = adaptedProperty.Tag as IAdaptedPropertyHandler<Entity>;
                if (propHandler != null) return propHandler.TypeName;
            }

            return typeof(object).FullName;
        }

        public override object GetPropertyValue(PSAdaptedProperty adaptedProperty)
        {
            Entity internalObject = adaptedProperty.BaseObject as Entity;

            if (internalObject != null && adaptedProperty.Tag != null && IsGettable(adaptedProperty))
            {
                IAdaptedPropertyHandler<Entity> propHandler = adaptedProperty.Tag as IAdaptedPropertyHandler<Entity>;
                if (propHandler != null)
                {
                    return propHandler.GetValue(internalObject);
                }
            }

            return null;
        }

        public override bool IsGettable(PSAdaptedProperty adaptedProperty)
        {
            if (adaptedProperty.Tag != null)
            {
                IAdaptedPropertyHandler<Entity> propHandler = adaptedProperty.Tag as IAdaptedPropertyHandler<Entity>;
                if (propHandler != null)
                {
                    return propHandler.IsGettable;
                }
            }
            return false;
        }

        public override bool IsSettable(PSAdaptedProperty adaptedProperty)
        {
            if (adaptedProperty.Tag != null)
            {
                IAdaptedPropertyHandler<Entity> propHandler = adaptedProperty.Tag as IAdaptedPropertyHandler<Entity>;
                if (propHandler != null)
                {
                    return propHandler.IsSettable;
                }
            }
            return false;
        }

        public override void SetPropertyValue(PSAdaptedProperty adaptedProperty, object value)
        {
            Entity internalObject = adaptedProperty.BaseObject as Entity;

            if (internalObject != null && adaptedProperty.Tag != null && IsSettable(adaptedProperty))
            {
                IAdaptedPropertyHandler<Entity> propHandler = adaptedProperty.Tag as IAdaptedPropertyHandler<Entity>;
                if (propHandler != null)
                {
                    object internalValue = value;
                    if (value is PSObject)
                    {
                        internalValue = ((PSObject)value).BaseObject;
                    }

                    propHandler.SetValue(internalObject, internalValue);
                }
            }
        }

        private Collection<PSAdaptedProperty> GetAdaptedProperties(Entity internalObject)
        {
            List<PSAdaptedProperty> properties = new List<PSAdaptedProperty>();
            foreach (var key in internalObject.Attributes.Keys)
            {
                if (internalObject.Attributes[key] != null && internalObject.Attributes[key] is AliasedValue)
                {
                    AliasedValue aliasedValueAttribute = internalObject.GetAttributeValue<AliasedValue>(key);
                    string aliassedKey = string.Format("{0}_{1}", aliasedValueAttribute.EntityLogicalName, aliasedValueAttribute.AttributeLogicalName);
                    properties.Add(new PSAdaptedProperty(aliassedKey, new AliassedAttributePropertyHandler(key)));

                    if (aliasedValueAttribute.Value != null && aliasedValueAttribute.Value is EntityReference)
                    {
                        properties.Add(new PSAdaptedProperty(string.Format("{0}entity", aliassedKey), new EntityRefAttributePropertyHandler(key, "Entity")));
                        properties.Add(new PSAdaptedProperty(string.Format("{0}name", aliassedKey), new EntityRefAttributePropertyHandler(key, "Name")));
                    }
                }
                else
                {
                    properties.Add(new PSAdaptedProperty(key, new AttributePropertyHandler(key)));
                    if (internalObject.Attributes[key] != null && internalObject.Attributes[key] is EntityReference)
                    {
                        properties.Add(new PSAdaptedProperty(string.Format("{0}entity", key), new EntityRefAttributePropertyHandler(key, "Entity")));
                        properties.Add(new PSAdaptedProperty(string.Format("{0}name", key), new EntityRefAttributePropertyHandler(key, "Name")));
                    }
                }
            }

            foreach (var key in internalObject.FormattedValues.Keys)
            {
                properties.Add(new PSAdaptedProperty(string.Format("{0}name", key.Replace('.', '_')), new FormattedValuePropertyHandler(key)));
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

        private void InitEntityPropertyHandlerCache()
        {
            _entityPropertyHandlerCache = new Dictionary<string, IAdaptedPropertyHandler<Entity>>();

            Type entityType = typeof(Entity);
            PropertyInfo[] entityProperties = entityType.GetProperties();

            foreach (var property in entityProperties)
            {
                _entityPropertyHandlerCache.Add(property.Name, new TypePropertyHandler(property));
            }

            _entityPropertyHandlerCache.Add("State", new FormattedValuePropertyHandler("statecode"));
            _entityPropertyHandlerCache.Add("Status", new FormattedValuePropertyHandler("statuscode"));
        }

        private PSAdaptedProperty GetPrimaryNameProperty(Entity internalObject)
        {
            if (internalObject.LogicalName.Equals("solutioncomponent", StringComparison.InvariantCultureIgnoreCase))
            {
                return new PSAdaptedProperty("Name", new FunctionPropertyHandler<string>(GetSolutionComponentName));
            }

            string primaryNameAttribute = GetPrimaryNameAttribute(internalObject);
            if (!string.IsNullOrWhiteSpace(primaryNameAttribute))
            {
                return new PSAdaptedProperty("Name", new AttributePropertyHandler(primaryNameAttribute));
            }
            else
            {
                return null;
            }
        }

        private string GetPrimaryNameAttribute(Entity internalObject)
        {
            string primaryNameAttribute = null;
            if (!_entityPrimaryNameCache.TryGetValue(internalObject.LogicalName, out primaryNameAttribute))
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

        private class AttributePropertyHandler : IAdaptedPropertyHandler<Entity>
        {
            private string _attributeName;

            public AttributePropertyHandler(string attributeName)
            {
                _attributeName = attributeName;
            }

            public virtual string TypeName
            {
                get { return typeof(object).FullName; }
            }

            public virtual bool IsSettable
            {
                get { return true; }
            }

            public virtual bool IsGettable
            {
                get { return true; }
            }

            public virtual object GetValue(Entity baseObject)
            {
                object result = null;
                baseObject.Attributes.TryGetValue(_attributeName, out result);

                if (result is AliasedValue)
                {
                    return ((AliasedValue)result).Value;
                }
                else
                {
                    return result;
                }
            }

            public virtual void SetValue(Entity baseObject, object value)
            {
                if (baseObject.Attributes.Contains(_attributeName))
                {
                    baseObject.Attributes[_attributeName] = value;
                }
                else
                {
                    baseObject.Attributes.Add(_attributeName, value);
                }
            }
        }

        private class EntityRefAttributePropertyHandler : IAdaptedPropertyHandler<Entity>
        {
            private string _attributeName;
            private string _subvalue;

            public EntityRefAttributePropertyHandler(string attributeName, string subvalue)
            {
                _attributeName = attributeName;
                _subvalue = subvalue;
            }

            public virtual string TypeName
            {
                get { return typeof(string).FullName; }
            }

            public virtual bool IsSettable
            {
                get { return false; }
            }

            public virtual bool IsGettable
            {
                get { return true; }
            }

            public virtual object GetValue(Entity baseObject)
            {
                object result = null;
                if (baseObject.Attributes.TryGetValue(_attributeName, out result))
                {
                    if (result != null && result is EntityReference)
                    {
                        if (_subvalue == "Entity") return ((EntityReference)result).LogicalName;
                        if (_subvalue == "Name") return ((EntityReference)result).Name;
                    }
                    else if (result != null && result is AliasedValue && ((AliasedValue)result).Value is EntityReference)
                    {
                        EntityReference aliassedResult = ((AliasedValue)result).Value as EntityReference;
                        if (aliassedResult != null)
                        {
                            if (_subvalue == "Entity") return aliassedResult.LogicalName;
                            if (_subvalue == "Name") return aliassedResult.Name;
                        }
                    }
                }

                return null;
            }

            public virtual void SetValue(Entity baseObject, object value)
            {
                throw new NotSupportedException();
            }
        }

        private class AliassedAttributePropertyHandler : AttributePropertyHandler
        {
            public AliassedAttributePropertyHandler(string attributeName)
                : base(attributeName) { }

            public override bool IsSettable
            {
                get { return false; }
            }

            public override void SetValue(Entity baseObject, object value)
            {
                throw new NotSupportedException();
            }
        }

        private class FormattedValuePropertyHandler : IAdaptedPropertyHandler<Entity>
        {
            private string _formattedValueName;

            public FormattedValuePropertyHandler(string formattedValueName)
            {
                _formattedValueName = formattedValueName;
            }

            public virtual string TypeName
            {
                get { return typeof(string).FullName; }
            }

            public virtual bool IsSettable
            {
                get { return false; }
            }

            public virtual bool IsGettable
            {
                get { return true; }
            }

            public virtual object GetValue(Entity baseObject)
            {
                string result = null;
                baseObject.FormattedValues.TryGetValue(_formattedValueName, out result);

                return result;
            }

            public virtual void SetValue(Entity baseObject, object value)
            {
                throw new NotSupportedException();
            }
        }

        private class TypePropertyHandler : IAdaptedPropertyHandler<Entity>
        {
            private PropertyInfo _propertyInfo;

            public TypePropertyHandler(PropertyInfo propertyInfo)
            {
                _propertyInfo = propertyInfo;
            }

            public virtual string TypeName
            {
                get { return _propertyInfo.PropertyType.FullName; }
            }

            public virtual bool IsSettable
            {
                get { return _propertyInfo.CanWrite; }
            }

            public virtual bool IsGettable
            {
                get { return _propertyInfo.CanRead; }
            }

            public virtual object GetValue(Entity baseObject)
            {
                return _propertyInfo.GetMethod.Invoke(baseObject, null);
            }

            public virtual void SetValue(Entity baseObject, object value)
            {
                _propertyInfo.SetMethod.Invoke(baseObject, new object[] { value });
            }
        }

        private class FunctionPropertyHandler<TResult> : IAdaptedPropertyHandler<Entity>
        {
            private Func<Entity, TResult> _getFunction;

            public FunctionPropertyHandler(Func<Entity, TResult> getFunction)
            {
                _getFunction = getFunction;
            }

            public virtual string TypeName
            {
                get { return typeof(TResult).FullName; }
            }

            public virtual bool IsSettable
            {
                get { return false; }
            }

            public virtual bool IsGettable
            {
                get { return true; }
            }

            public virtual object GetValue(Entity baseObject)
            {
                return _getFunction(baseObject);
            }

            public virtual void SetValue(Entity baseObject, object value)
            {
                throw new NotSupportedException();
            }
        }
    }
}
