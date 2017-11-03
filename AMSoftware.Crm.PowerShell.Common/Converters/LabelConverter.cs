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
using Microsoft.Xrm.Sdk;
using System.Linq;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Common.Converters
{
    public sealed class LabelConverter : PSTypeConverter
    {
        public override bool CanConvertFrom(object sourceValue, Type destinationType)
        {
            if (sourceValue == null) return true;
            if (sourceValue.GetType() == typeof(string)) return true;

            StringConverter sc = new StringConverter();
            return sc.CanConvertFrom(sourceValue.GetType());
        }

        public override object ConvertFrom(object sourceValue, Type destinationType, IFormatProvider formatProvider, bool ignoreCase)
        {
            if (sourceValue == null) return null;
            if (sourceValue.GetType() == typeof(string)) return new Label((string)sourceValue, CrmContext.Language);

            StringConverter sc = new StringConverter();
            return new Label((string)sc.ConvertFrom(sourceValue), CrmContext.Language);
        }

        public override bool CanConvertTo(object sourceValue, Type destinationType)
        {
            if (sourceValue == null) return true;
            if (destinationType == typeof(string)) return true;

            StringConverter sc = new StringConverter();
            return sc.CanConvertTo(destinationType);
        }

        public override object ConvertTo(object sourceValue, Type destinationType, IFormatProvider formatProvider, bool ignoreCase)
        {
            if (sourceValue == null) return null;

            if (sourceValue is Label labelValue)
            {
                LocalizedLabel languageLabel = labelValue.LocalizedLabels.SingleOrDefault(l => l.LanguageCode == CrmContext.Language);
                if (languageLabel != null)
                {
                    if (destinationType == typeof(string)) return languageLabel.Label;
                    else
                    {
                        StringConverter sc = new StringConverter();
                        return sc.ConvertTo(languageLabel.Label, destinationType);
                    }
                } else
                {
                    return null;
                }
            }

            return new NotSupportedException();
        }
    }
}
