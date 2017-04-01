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
using System.Linq;
using System.Text;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;

namespace AMSoftware.Crm.PowerShell.Common
{
    internal class MetadataCache
    {
        private Cache<EntityMetadata> _entities = new Cache<EntityMetadata>();
        private string _timestamp = null;
        private DateTime? _lastUpdated = null;

        public IEnumerable<EntityMetadata> GetEntities()
        {
            if (!IsCacheValid())
            {
                UpdateCache();
            }

            return _entities;
        }

        private bool IsCacheValid()
        {
            if (CrmVersionManager.IsSupported(CrmVersion.CRM2011_UR12))
            {
                if (_timestamp == null) return false;

                OrganizationRequest request = new OrganizationRequest("RetrieveTimestamp");
                OrganizationResponse response = CrmContext.OrganizationProxy.Execute(request);
                string result = (string)response.Results["Timestamp"];

                return string.Equals(_timestamp, result, StringComparison.InvariantCultureIgnoreCase);
            }
            else
            {
                if (_lastUpdated == null) return false;

                return (DateTime.UtcNow - _lastUpdated).Value.TotalMinutes < 10.0;
            }
        }

        private void UpdateCache()
        {
            if (CrmVersionManager.IsSupported(CrmVersion.CRM2011_UR12))
            {
                ParameterCollection result = GetEntityUsingMetadataQuery();
                foreach (var item in (EntityMetadataCollection)result["EntityMetadata"])
                {
                    _entities.Add(item.LogicalName, item);
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
            else
            {
                IEnumerable<EntityMetadata> result = (EntityMetadata[])GetEntitiesUsingRequestAll()["EntityMetadata"];
                _entities = new Cache<EntityMetadata>();
                foreach (var item in result)
                {
                    _entities.Add(item.LogicalName, item);
                }

                _lastUpdated = DateTime.UtcNow;
            }
        }

        private ParameterCollection GetEntityUsingMetadataQuery()
        {
            LabelQueryExpression labelFilter = new LabelQueryExpression();
            labelFilter.FilterLanguages.Add(CrmContext.Language);

            EntityQueryExpression query = new EntityQueryExpression()
            {
                Properties = new MetadataPropertiesExpression() { AllProperties = true },
                LabelQuery = labelFilter
            };

            OrganizationRequest request = new OrganizationRequest("RetrieveMetadataChanges");
            request.Parameters = new ParameterCollection();
            request.Parameters.Add("Query", query);
            request.Parameters.Add("ClientVersionStamp", _timestamp);

            OrganizationResponse response = CrmContext.OrganizationProxy.Execute(request);
            return response.Results;
        }

        private ParameterCollection GetEntitiesUsingRequestAll()
        {
            OrganizationRequest request = new OrganizationRequest("RetrieveAllEntities");
            request.Parameters = new ParameterCollection();
            request.Parameters.Add("EntityFilters", EntityFilters.Entity | EntityFilters.Privileges);
            request.Parameters.Add("RetrieveAsIfPublished", true);

            OrganizationResponse response = CrmContext.OrganizationProxy.Execute(request);
            return response.Results;
        }
    }
}
