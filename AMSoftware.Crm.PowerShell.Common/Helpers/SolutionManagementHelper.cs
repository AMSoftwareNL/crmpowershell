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
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AMSoftware.Crm.PowerShell.Common.Converters;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace AMSoftware.Crm.PowerShell.Common.Helpers
{
    internal sealed class SolutionManagementHelper
    {
        public static string GetSolutionUniqueName(ContentRepository repository, Guid id, bool managed)
        {
            Entity solution = repository.Get("solution", id, new string[] { "uniquename", "ismanaged" });
            if (solution != null)
            {
                bool isManaged = solution.GetAttributeValue<bool>("ismanaged");
                if (isManaged == managed)
                {
                    return solution.GetAttributeValue<string>("uniquename");
                }
            }

            throw new Exception(string.Format("No solution found with Id '{0}'.", id));
        }

        public static string GetSolutionUniqueName(ContentRepository repository, Guid id)
        {
            Entity solution = repository.Get("solution", id, new string[] { "uniquename" });
            if (solution != null)
            {
                return solution.GetAttributeValue<string>("uniquename");
            }

            throw new Exception(string.Format("No solution found with Id '{0}'.", id));
        }

        public static IDictionary<int, string> GetComponentTypes()
        {
            MetadataRepository repository = new MetadataRepository();
            OptionSetMetadata componentTypeSet = repository.GetOptionSet("componenttype") as OptionSetMetadata;

            LabelConverter lc = new LabelConverter();
            return componentTypeSet.Options.ToDictionary(k => k.Value.GetValueOrDefault(), e => ((string)lc.ConvertTo(e.Label, typeof(string), null, true)).Replace(" ", ""));
        }

        public static string GetComponentName(int componentType, Guid objectId, bool ismetadata)
        {
            ContentRepository ctr = new ContentRepository();
            MetadataRepository mdr = new MetadataRepository();

            if (!ismetadata)
            {
                EntityMetadata entity = mdr.GetEntity(componentType);
                Entity componentEntity = ctr.Get(entity.LogicalName, objectId);

                if (!string.IsNullOrWhiteSpace(entity.PrimaryNameAttribute)) {
                    return componentEntity.GetAttributeValue<string>(entity.PrimaryNameAttribute);
                } else
                {
                    return entity.LogicalName;
                }
            } else {
                switch (componentType)
                {
                    case 1:  //Entity
                        return mdr.GetEntity(objectId).LogicalName;
                    case 2:  //Attribute
                        return mdr.GetAttribute(objectId).LogicalName;
                    case 3:  //Relationship
                        return mdr.GetRelationship(objectId).SchemaName;
                    case 9:  //Option Set
                        return mdr.GetOptionSet(objectId).Name;
                    case 10: //Entity Relationship
                        return mdr.GetRelationship(objectId).SchemaName;
                    case 13: //Managed Property
                        return mdr.GetManagedProperty(objectId).LogicalName;
                    default:
                        break;
                }
            }

            return null;
        }
    }
}
