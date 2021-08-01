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
    public class OrganizationResponsePropertyAdapter : PropertyAdapterBase<OrganizationResponse>
    {
        protected override Collection<PSAdaptedProperty> GetAdaptedProperties(OrganizationResponse internalObject)
        {
            List<PSAdaptedProperty> properties = new List<PSAdaptedProperty>();

            List<PSAdaptedProperty> typeProperties = new List<PSAdaptedProperty>();
            Type responseType = typeof(OrganizationResponse);
            PropertyInfo[] responseProperties = responseType.GetProperties();

            foreach (var property in responseProperties)
            {
                if (property.Name != nameof(OrganizationResponse.ExtensionData))
                {
                    typeProperties.Add(new PSAdaptedProperty(property.Name, new MemberTypePropertyHandler<OrganizationResponse>(property)));

                    if (property.Name == nameof(OrganizationResponse.Results))
                    {
                        foreach (var key in internalObject.Results.Keys)
                        {
                            if (internalObject.Results[key] != null)
                            {
                                properties.Add(new PSAdaptedProperty(key, new ReadonlyDataCollectionPropertyHandler<OrganizationResponse, string, object>(property, key)));
                            }
                        }
                    }
                }
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
    }
}
