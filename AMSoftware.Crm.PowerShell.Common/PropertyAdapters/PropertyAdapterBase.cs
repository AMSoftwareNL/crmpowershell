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
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Common.PropertyAdapters
{
    public abstract class PropertyAdapterBase<T> : PSPropertyAdapter
    {
        public override Collection<PSAdaptedProperty> GetProperties(object baseObject)
        {
            if (baseObject is T internalObject)
            {
                return GetAdaptedProperties(internalObject);
            }

            return null;
        }

        public override PSAdaptedProperty GetProperty(object baseObject, string propertyName)
        {
            if (baseObject is T internalObject)
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
                if (adaptedProperty.Tag is IAdaptedPropertyHandler<T> propHandler) return propHandler.TypeName;
            }

            return typeof(object).FullName;
        }

        public override object GetPropertyValue(PSAdaptedProperty adaptedProperty)
        {
            if (adaptedProperty.BaseObject is T internalObject && adaptedProperty.Tag != null && IsGettable(adaptedProperty))
            {
                if (adaptedProperty.Tag is IAdaptedPropertyHandler<T> propHandler)
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
                if (adaptedProperty.Tag is IAdaptedPropertyHandler<T> propHandler)
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
                if (adaptedProperty.Tag is IAdaptedPropertyHandler<T> propHandler)
                {
                    return propHandler.IsSettable;
                }
            }
            return false;
        }

        public override void SetPropertyValue(PSAdaptedProperty adaptedProperty, object value)
        {
            if (adaptedProperty.BaseObject is T internalObject && adaptedProperty.Tag != null && IsSettable(adaptedProperty))
            {
                if (adaptedProperty.Tag is IAdaptedPropertyHandler<T> propHandler)
                {
                    object internalValue = value;
                    if (value is PSObject objectValue)
                    {
                        internalValue = objectValue.BaseObject;
                    }

                    propHandler.SetValue(internalObject, internalValue);
                }
            }
        }

        protected abstract Collection<PSAdaptedProperty> GetAdaptedProperties(T internalObject);
    }
}
