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
using System.Linq;
using System.Collections.Generic;

namespace AMSoftware.Crm.PowerShell.Common
{
    interface ICache<TValue>
    {
        TValue Get(string key);
        bool TryGetValue(string key, out TValue value);
    }

    internal sealed class Cache<TValue> : IEnumerable<TValue>, AMSoftware.Crm.PowerShell.Common.ICache<TValue>
    {
        private Dictionary<string, CacheItem> _store = new Dictionary<string, CacheItem>();

        public void Add(string key, TValue value)
        {
            if (_store.ContainsKey(key))
            {
                _store[key].Value = value;
                _store[key].Update();
            }
            else
            {
                _store.Add(key, new CacheItem(key, value));
            }
        }

        public TValue this[string key]
        {
            get
            {
                return Get(key);
            }
            set
            {
                Add(key, value);
            }
        }

        public TValue Get(string key)
        {
            TValue result = default(TValue);
            if (TryGetValue(key, out result))
            {
                return result;
            }

            return default(TValue);
        }

        public bool TryGetValue(string key, out TValue value)
        {
            if (_store.ContainsKey(key))
            {
                CacheItem item = _store[key];
                value = _store[key].Value;
                return true;
            }

            value = default(TValue);
            return false;
        }

        public void Remove(string key)
        {
            if (_store.ContainsKey(key))
            {
                _store.Remove(key);
            }
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            return _store.Values.Select(i => i.Value).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _store.Values.Select(i => i.Value).GetEnumerator();
        }

        private class CacheItem
        {
            private DateTime _lastUpdated;

            public string Key { get; private set; }
            public TValue Value { get; set; }

            public TimeSpan Age
            {
                get
                {
                    return (DateTime.UtcNow - _lastUpdated);
                }
            }

            internal CacheItem(string key, TValue value)
            {
                Key = key;
                Value = value;
                _lastUpdated = DateTime.UtcNow;
            }

            internal void Update()
            {
                _lastUpdated = DateTime.UtcNow;
            }
        }
    }
}
