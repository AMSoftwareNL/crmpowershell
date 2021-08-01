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
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Linq;

namespace AMSoftware.Crm.PowerShell.Commands.Helpers
{
    internal sealed class EntitiesHelper
    {
        public static void SetVirtualEntityDefaults(EntityMetadata entity)
        {
            entity.ActivityTypeMask = 0;
            entity.AutoCreateAccessTeams = false;
            entity.AutoRouteToOwnerQueue = false;
            entity.CanChangeHierarchicalRelationship = new BooleanManagedProperty(false);
            entity.CanChangeTrackingBeEnabled = new BooleanManagedProperty(false);
            entity.CanCreateCharts = new BooleanManagedProperty(false);
            entity.CanEnableSyncToExternalSearchIndex = new BooleanManagedProperty(false);
            entity.ChangeTrackingEnabled = false;
            entity.DaysSinceRecordLastModified = null;
            entity.IsActivity = false;
            entity.IsActivityParty = false;
            entity.IsAuditEnabled = new BooleanManagedProperty(false);
            entity.IsAvailableOffline = false;
            entity.IsBusinessProcessEnabled = false;
            entity.IsDocumentRecommendationsEnabled = false;
            entity.IsDuplicateDetectionEnabled = new BooleanManagedProperty(false);
            entity.IsKnowledgeManagementEnabled = false;
            entity.IsOfflineInMobileClient = new BooleanManagedProperty(false);
            entity.IsSLAEnabled = false;
            entity.MobileOfflineFilters = null;
            entity.OwnershipType = OwnershipTypes.OrganizationOwned;
            entity.SyncToExternalSearchIndex = null;
        }

        public static void SetDataSourceEntityDefaults(EntityMetadata entity)
        {
            BooleanManagedProperty booleanManagedProperty = new BooleanManagedProperty(value: false);
            BooleanManagedProperty booleanManagedProperty2 = new BooleanManagedProperty(value: true);

            entity.DataProviderId = new Guid("B2112A7E-B26C-42F7-9B63-9A809A9D716F");
            entity.IsActivity = false;
            entity.OwnershipType = OwnershipTypes.OrganizationOwned;
            entity.IsAvailableOffline = false;
            entity.IsBusinessProcessEnabled = false;
            entity.IsVisibleInMobile = booleanManagedProperty;
            entity.IsVisibleInMobileClient = booleanManagedProperty;
            entity.IsReadOnlyInMobileClient = booleanManagedProperty;
            entity.IsOfflineInMobileClient = booleanManagedProperty;
            entity.IsAuditEnabled = booleanManagedProperty;
            entity.IsSLAEnabled = false;
            entity.IsBPFEntity = false;
            entity.IsDuplicateDetectionEnabled = booleanManagedProperty;
            entity.IsConnectionsEnabled = booleanManagedProperty;
            entity.IsActivityParty = false;
            entity.IsReadingPaneEnabled = false;
            entity.IsQuickCreateEnabled = false;
            entity.AutoCreateAccessTeams = false;
            entity.CanCreateCharts = booleanManagedProperty;
            entity.IsMailMergeEnabled = booleanManagedProperty;
            entity.ChangeTrackingEnabled = false;
            entity.CanChangeTrackingBeEnabled = booleanManagedProperty;
            entity.IsEnabledForExternalChannels = false;
            entity.EntityHelpUrlEnabled = false;
            entity.IsCustomizable = booleanManagedProperty2;
            entity.IsRenameable = booleanManagedProperty2;
            entity.IsMappable = booleanManagedProperty;
            entity.SyncToExternalSearchIndex = false;
            entity.CanEnableSyncToExternalSearchIndex = booleanManagedProperty;
            entity.CanModifyAdditionalSettings = booleanManagedProperty;
            entity.CanChangeHierarchicalRelationship = booleanManagedProperty;
        }

        public static Guid? GetVirtualDataProvider(ContentRepository contentRepository, string dataSourceLogicalName)
        {
            QueryExpression query = new QueryExpression("entitydataprovider")
            {
                ColumnSet = new ColumnSet("entitydataproviderid"),
                Criteria = new FilterExpression()
                {
                    Conditions =
                            {
                                new ConditionExpression("datasourcelogicalname", ConditionOperator.Equal, dataSourceLogicalName)
                            }
                }
            };

            var dataProviders = contentRepository.Get(query);
            var dataProvider = dataProviders.SingleOrDefault();

            if (dataProvider == null)
            {
                return null;
            }

            return dataProvider.Id;
        }

        public static void ValidateVirtualDataSource(ContentRepository contentRepository, string dataSourceLogicalName, Guid dataSourceId)
        {
            var datasource = contentRepository.Get(dataSourceLogicalName, dataSourceId);
            if (datasource == null)
            {
                throw new Exception($"Specified DataSource in Tabel '{dataSourceLogicalName}' with Id '{dataSourceId}' can not be found.");
            }
        }
    }
}
