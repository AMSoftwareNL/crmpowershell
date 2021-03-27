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
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Reflection;

namespace AMSoftware.Crm.PowerShell.Common.PropertyAdapters
{
    public sealed class MetadataPropertyAdapter : PropertyAdapterBase<MetadataBase>
    {
        private readonly Dictionary<Type, Dictionary<string, IAdaptedPropertyHandler<MetadataBase>>> _propertyHandlerCaches = new Dictionary<Type, Dictionary<string, IAdaptedPropertyHandler<MetadataBase>>>();

        protected override Collection<PSAdaptedProperty> GetAdaptedProperties(MetadataBase internalObject)
        {
            var propertyHandlerCache = InitEntityPropertyHandlerCache(internalObject);

            List<PSAdaptedProperty> typeProperties = new List<PSAdaptedProperty>();
            foreach (var item in propertyHandlerCache)
            {
                typeProperties.Add(new PSAdaptedProperty(item.Key, item.Value));
            }
            typeProperties = typeProperties.OrderBy(p => p.Name, StringComparer.OrdinalIgnoreCase).ToList();

            var resultCollection = new Collection<PSAdaptedProperty>(typeProperties);
            return resultCollection;
        }

        private Dictionary<string, IAdaptedPropertyHandler<MetadataBase>> InitEntityPropertyHandlerCache(MetadataBase internalObject)
        {
            Type metadataType = internalObject.GetType();

            if (_propertyHandlerCaches.TryGetValue(metadataType, out Dictionary<string, IAdaptedPropertyHandler<MetadataBase>> typeCache)) {
                return typeCache;
            }

            var propertyHandlerCache = new Dictionary<string, IAdaptedPropertyHandler<MetadataBase>>();
            string[] excludedProperties = { "Attributes", "ExtensionData", "HasChanged", "Keys", "ManyToManyRelationships", "ManyToOneRelationships", "OneToManyRelationships", "Privileges" };

            PropertyInfo[] metadataProperties = metadataType.GetProperties();
            foreach (var property in metadataProperties)
            {
                if (!excludedProperties.Contains(property.Name))
                {
                    propertyHandlerCache.Add(property.Name, new MetadataTypePropertyHandler(property));
                }
            }

            _propertyHandlerCaches.Add(metadataType, propertyHandlerCache);

            return propertyHandlerCache;
        }
    }
}
