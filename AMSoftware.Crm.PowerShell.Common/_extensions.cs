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
using System.ComponentModel;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Common
{
    public static class _extensions
    {
        public static IEnumerable<KeyValuePair<TKey, TValue>> ToEnumerable<TKey, TValue>(this Hashtable table)
        {
            foreach (var key in table.Keys)
            {
                if (key == null) throw new NullReferenceException("Key cannot be null");
                TKey keyTyped = ConvertValue<TKey>(key);

                var value = table[key];
                TValue valueTyped = ConvertValue<TValue>(value);

                yield return new KeyValuePair<TKey, TValue>(keyTyped, valueTyped);
            }
        }

        private static T ConvertValue<T>(object value)
        {
            if (value == null) return default;

            object internalValue = value;

            if (value is PSObject objectValue)
            {
                internalValue = objectValue.BaseObject;
            }

            if (typeof(T).IsEnum)
            {
                EnumConverter ec = new EnumConverter(typeof(T));
                internalValue = ec.ConvertFrom(value);
            }

            return (T)internalValue;
        }
    }
}
