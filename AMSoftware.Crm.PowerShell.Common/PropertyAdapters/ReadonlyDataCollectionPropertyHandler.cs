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
using Microsoft.Xrm.Sdk;
using System;
using System.Reflection;

namespace AMSoftware.Crm.PowerShell.Common.PropertyAdapters
{
    internal class ReadonlyDataCollectionPropertyHandler<TObject, TKey, TValue> : IAdaptedPropertyHandler<TObject>
    {
        private readonly TKey _key;
        private readonly PropertyInfo _collectionPropertyInfo;

        public ReadonlyDataCollectionPropertyHandler(PropertyInfo collectionPropertyInfo, TKey key)
        {
            _collectionPropertyInfo = collectionPropertyInfo;
            _key = key;
        }

        public virtual string TypeName
        {
            get { return typeof(TValue).FullName; }
        }

        public virtual bool IsSettable
        {
            get { return false; }
        }

        public virtual bool IsGettable
        {
            get { return true; }
        }

        public virtual object GetValue(TObject baseObject)
        {
            DataCollection<TKey, TValue> collection = _collectionPropertyInfo.GetValue(baseObject) as DataCollection<TKey, TValue>;
            if (collection != null)
            {
                collection.TryGetValue(_key, out TValue result);
                return result;
            }

            return null;
        }

        public virtual void SetValue(TObject baseObject, object value)
        {
            throw new NotSupportedException();
        }
    }
}
