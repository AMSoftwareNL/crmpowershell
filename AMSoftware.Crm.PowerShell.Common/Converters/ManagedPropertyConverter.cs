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
using System.ComponentModel;
using System.Management.Automation;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace AMSoftware.Crm.PowerShell.Common.Converters
{
    public sealed class ManagedPropertyConverter : PSTypeConverter
    {
        public override bool CanConvertFrom(object sourceValue, Type destinationType)
        {
            if (sourceValue == null) return true;

            if (destinationType == typeof(BooleanManagedProperty))
            {
                BooleanConverter bc = new BooleanConverter();
                return bc.CanConvertFrom(sourceValue.GetType());
            }

            if (destinationType == typeof(AttributeRequiredLevel))
            {
                EnumConverter ec = new EnumConverter(typeof(AttributeRequiredLevel));
                return ec.CanConvertFrom(sourceValue.GetType());
            }

            return false;
        }

        public override bool CanConvertTo(object sourceValue, Type destinationType)
        {
            return false;
        }

        public override object ConvertFrom(object sourceValue, Type destinationType, IFormatProvider formatProvider, bool ignoreCase)
        {
            if (sourceValue == null) return null;

            if (destinationType == typeof(BooleanManagedProperty))
            {
                BooleanConverter bc = new BooleanConverter();
                bool value = (bool)bc.ConvertFrom(sourceValue);

                return new BooleanManagedProperty(value);
            }

            if (destinationType == typeof(AttributeRequiredLevel))
            {
                EnumConverter ec = new EnumConverter(typeof(AttributeRequiredLevel));
                AttributeRequiredLevel value = (AttributeRequiredLevel)ec.ConvertFrom(sourceValue);

                return new AttributeRequiredLevelManagedProperty(value);
            }

            return null;
        }

        public override object ConvertTo(object sourceValue, Type destinationType, IFormatProvider formatProvider, bool ignoreCase)
        {
            throw new NotImplementedException();
        }
    }
}
