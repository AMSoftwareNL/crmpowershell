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
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AMSoftware.Crm.PowerShell.Common
{
    internal sealed class MetadataCache
    {
        private Cache<EntityMetadata> _entities = new Cache<EntityMetadata>();
        private string _timestamp = null;

        public MetadataCache(bool initialize = false)
        {
            if (initialize) UpdateCache();
        }

        public IEnumerable<EntityMetadata> GetEntities()
        {
            return _entities;
        }

        private bool IsCacheValid()
        {
            if (_timestamp == null) return false;

            OrganizationRequest request = new OrganizationRequest("RetrieveTimestamp");
            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
            string result = (string)response.Results["Timestamp"];

            return string.Equals(_timestamp, result, StringComparison.InvariantCultureIgnoreCase);
        }

        internal void UpdateCache()
        {
            if (IsCacheValid()) return;

            ParameterCollection result = GetEntityUsingMetadataQuery();
            foreach (var item in (EntityMetadataCollection)result["EntityMetadata"])
            {
                if (item.HasChanged == null || item.HasChanged == true)
                {
                    _entities.Add(item.LogicalName, item);
                }
            }
            var deleted = (DeletedMetadataCollection)result["DeletedMetadata"];
            if (deleted != null && deleted.Keys.Contains(DeletedMetadataFilters.Entity))
            {
                foreach (var item in deleted[DeletedMetadataFilters.Entity])
                {
                    _entities.Remove(_entities.Single(e => e.MetadataId == item).LogicalName);
                }
            }

            _timestamp = (string)result["ServerVersionStamp"];
        }

        private ParameterCollection GetEntityUsingMetadataQuery()
        {
            EntityQueryExpression query = new EntityQueryExpression()
            {
                Properties = new MetadataPropertiesExpression() { AllProperties = true },
                LabelQuery = new LabelQueryExpression()
                {
                    MissingLabelBehavior = 1
                }
            };

            OrganizationRequest request = new OrganizationRequest("RetrieveMetadataChanges")
            {
                Parameters = new ParameterCollection
                {
                    { "Query", query },
                    { "ClientVersionStamp", _timestamp },
                    { "DeletedMetadataFilters", DeletedMetadataFilters.All }
                }
            };

            OrganizationResponse response = CrmContext.Session.OrganizationProxy.Execute(request);
            return response.Results;
        }
    }
}
