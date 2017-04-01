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
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Common.PropertyAdapters
{
    public abstract class DataCollectionPropertyAdapter<TValue> : PSPropertyAdapter
    {
        protected virtual bool IsReadOnly { 
            get { 
                return false; 
            }
        }

        public override Collection<PSAdaptedProperty> GetProperties(object baseObject)
        {
            DataCollection<string, TValue> internalObject = baseObject as DataCollection<string, TValue>;
            if (internalObject != null)
            {
                return GetAdaptedProperties(internalObject);
            }

            return null;
        }

        public override PSAdaptedProperty GetProperty(object baseObject, string propertyName)
        {
            DataCollection<string, TValue> internalObject = baseObject as DataCollection<string, TValue>;
            if (internalObject != null)
            {
                PSAdaptedProperty property = GetAdaptedProperties(internalObject).SingleOrDefault(p => p.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase));
                if (property != null)
                {
                    return property;
                }
                else if (!IsReadOnly)
                {
                    return new PSAdaptedProperty(propertyName, null);
                }
            }

            return null;
        }

        public override string GetPropertyTypeName(PSAdaptedProperty adaptedProperty)
        {
            return typeof(TValue).FullName;
        }

        public override object GetPropertyValue(PSAdaptedProperty adaptedProperty)
        {
            DataCollection<string, TValue> internalObject = adaptedProperty.BaseObject as DataCollection<string, TValue>;

            if (internalObject != null)
            {
                TValue resultValue;
                if (internalObject.TryGetValue(adaptedProperty.Name, out resultValue))
                {
                    return resultValue;
                }
            }

            return null;
        }

        public override bool IsGettable(PSAdaptedProperty adaptedProperty)
        {
            return true;
        }

        public override bool IsSettable(PSAdaptedProperty adaptedProperty)
        {
            return !IsReadOnly;
        }

        public override void SetPropertyValue(PSAdaptedProperty adaptedProperty, object value)
        {
            if (IsReadOnly) throw new NotSupportedException();

            DataCollection<string, TValue> internalObject = adaptedProperty.BaseObject as DataCollection<string, TValue>;
            if (internalObject != null && IsSettable(adaptedProperty))
            {
                if (internalObject.Contains(adaptedProperty.Name))
                {
                    internalObject[adaptedProperty.Name] = (TValue)value;
                }
                else
                {
                    internalObject.Add(adaptedProperty.Name, (TValue)value);
                }
            }
        }

        private Collection<PSAdaptedProperty> GetAdaptedProperties(DataCollection<string, TValue> internalObject)
        {
            Collection<PSAdaptedProperty> properties = new Collection<PSAdaptedProperty>();

            foreach (var key in internalObject.Keys)
            {
                properties.Add(new PSAdaptedProperty(key, key));
            }

            return properties;
        }
    }

    public class AttributeCollectionPropertyAdapter : DataCollectionPropertyAdapter<object>
    {

    }

    public class FormattedValueCollectionPropertyAdapter : DataCollectionPropertyAdapter<string>
    {
        protected override bool IsReadOnly
        {
            get
            {
                return true;
            }
        }
    }

    public class KeyAttributeCollectionPropertyAdapter : DataCollectionPropertyAdapter<object>
    {

    }
}
