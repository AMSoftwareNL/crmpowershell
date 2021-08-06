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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Reflection;

namespace AMSoftware.Crm.PowerShell.Common.PropertyAdapters
{
    public class OrganizationRequestPropertyAdapter : PropertyAdapterBase<OrganizationRequest>
    {
        List<PropertyInfo> _typeProperties = new List<PropertyInfo>();

        public OrganizationRequestPropertyAdapter() : base()
        {
            _typeProperties = new List<PropertyInfo>();

            Type organizationRequestType = typeof(OrganizationRequest);
            PropertyInfo[] organizationRequestProperties = organizationRequestType.GetProperties();

            string[] excludedProperties = { "ExtensionData" };
            foreach (var property in organizationRequestProperties)
            {
                if (!excludedProperties.Contains(property.Name))
                {
                    _typeProperties.Add(property);
                }
            }
        }

        protected override Collection<PSAdaptedProperty> GetAdaptedProperties(OrganizationRequest internalObject)
        {
            var resultCollection = new List<PSAdaptedProperty>();

            List<PSAdaptedProperty> properties = new List<PSAdaptedProperty>();
            foreach (var property in _typeProperties)
            {
                resultCollection.Add(new PSAdaptedProperty(property.Name, new MemberTypePropertyHandler<OrganizationRequest>(property)));

                if (property.Name == nameof(OrganizationRequest.Parameters))
                {
                    foreach (var key in internalObject.Parameters.Keys)
                    {
                        if (internalObject.Parameters[key] != null)
                        {
                            properties.Add(new PSAdaptedProperty(key, new ReadonlyDataCollectionPropertyHandler<OrganizationRequest, string, object>(property, key)));
                        }
                    }
                }
            }
            resultCollection = resultCollection.OrderBy(p => p.Name, StringComparer.OrdinalIgnoreCase).ToList();

            foreach (var prop in properties.OrderBy(p => p.Name, StringComparer.OrdinalIgnoreCase))
            {
                if (!resultCollection.Any(p => p.Name.Equals(prop.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    resultCollection.Add(prop);
                }
            }

            return new Collection<PSAdaptedProperty>(resultCollection);
        }
    }
}
