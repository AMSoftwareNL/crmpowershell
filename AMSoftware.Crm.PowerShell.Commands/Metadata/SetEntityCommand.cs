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
using AMSoftware.Crm.PowerShell.Commands.Helpers;
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.ArgumentCompleters;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Management.Automation;
using Drawing = System.Drawing;

namespace AMSoftware.Crm.PowerShell.Commands.Metadata
{
    [Cmdlet(VerbsCommon.Set, "CrmEntity", HelpUri = HelpUrlConstants.SetEntityHelpUrl, DefaultParameterSetName = SetEntityByInputObjectParameterSet)]
    [OutputType(typeof(EntityMetadata))]
    public sealed class SetEntityCommand : CrmOrganizationCmdlet
    {
        internal const string SetEntityParameterSet = "SetEntity";
        internal const string SetVirtualEntityParameterSet = "SetVirtualEntity";
        internal const string SetDataSourceEntityParameterSet = "SetDataSourceEntity";
        internal const string SetEntityByInputObjectParameterSet = "SetEntityByInputObject";

        private readonly MetadataRepository _repository = new MetadataRepository();

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = SetEntityByInputObjectParameterSet, ValueFromPipeline = true)]
        [Alias("Entity")]
        [ValidateNotNull]
        public EntityMetadata InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SetVirtualEntityParameterSet)]
        public SwitchParameter Virtual { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SetDataSourceEntityParameterSet)]
        public SwitchParameter DataSource { get; set; }


        [Parameter(Position = 1, Mandatory = true, ParameterSetName = SetEntityParameterSet)]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = SetVirtualEntityParameterSet)]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = SetDataSourceEntityParameterSet)]
        [Alias("LogicalName")]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string Name { get; set; }

        [Parameter(ParameterSetName = SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetVirtualEntityParameterSet)]
        [Parameter(ParameterSetName = SetDataSourceEntityParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(ParameterSetName = SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetVirtualEntityParameterSet)]
        [Parameter(ParameterSetName = SetDataSourceEntityParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DisplayCollectionName { get; set; }

        [Parameter(ParameterSetName = SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetVirtualEntityParameterSet)]
        [Parameter(ParameterSetName = SetDataSourceEntityParameterSet)]
        [ValidateNotNull]
        public string Description { get; set; }

        [Parameter(ParameterSetName = SetVirtualEntityParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ExternalName { get; set; }

        [Parameter(ParameterSetName = SetVirtualEntityParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ExternalCollectionName { get; set; }

        [Parameter(ParameterSetName = SetVirtualEntityParameterSet)]
        public EntityReference DataSourceConfiguration { get; set; }

        [Parameter(ParameterSetName = SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool Customizable { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetEntityCommand.SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool HasNotes { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetEntityCommand.SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool HasActivities { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool AutoRouteToOwnerQueue { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetEntityCommand.SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool CanCreateAttributes { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool CanCreateCharts { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetEntityCommand.SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool CanCreateForms { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetEntityCommand.SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool CanCreateViews { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetEntityCommand.SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool CanModifyAdditionalSettings { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool IsActivityParty { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool IsAuditEnabled { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool IsAvailableOffline { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetEntityCommand.SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool IsConnectionsEnabled { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetEntityCommand.SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool IsDocumentManagementEnabled { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool IsDuplicateDetectionEnabled { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetEntityCommand.SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool IsMailMergeEnabled { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetEntityCommand.SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool IsMappable { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetEntityCommand.SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool IsRenameable { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetEntityCommand.SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool IsValidForQueue { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetEntityCommand.SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool IsVisibleInMobile { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetEntityCommand.SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public string IconLargeName { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetEntityCommand.SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public string IconMediumName { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetEntityCommand.SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public string IconSmallName { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool AutoCreateAccessTeams { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool IsBusinessProcessEnabled { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetEntityCommand.SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool IsQuickCreateEnabled { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetEntityCommand.SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool IsReadOnlyInMobileClient { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetEntityCommand.SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool IsVisibleInMobileClient { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool CanChangeHierarchicalRelationship { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool CanEnableSyncToExternalSearchIndex { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool ChangeTrackingEnabled { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetEntityCommand.SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public string EntityColor { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetEntityCommand.SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool EntityHelpUrlEnabled { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetEntityCommand.SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public Uri EntityHelpUrl { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetEntityCommand.SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool IsInteractionCentricEnabled { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool IsKnowledgeManagementEnabled { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool IsOfflineInMobileClient { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [Parameter(ParameterSetName = SetEntityCommand.SetVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool IsOneNoteIntegrationEnabled { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool IsOptimisticConcurrencyEnabled { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool IsSLAEnabled { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool SyncToExternalSearchIndex { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            switch (this.ParameterSetName)
            {
                case SetEntityParameterSet:
                case SetVirtualEntityParameterSet:
                case SetDataSourceEntityParameterSet:
                    EntityMetadata internalEntity = BuildEntity();

                    bool? hasNotes = null;
                    if (this.MyInvocation.BoundParameters.ContainsKey(nameof(HasNotes))) hasNotes = HasNotes;
                    
                    bool? hasActivities = null;
                    if (this.MyInvocation.BoundParameters.ContainsKey(nameof(HasActivities))) hasActivities = HasActivities;

                    _repository.UpdateEntity(internalEntity, hasNotes, hasActivities);
                    if (PassThru)
                    {
                        WriteObject(_repository.GetEntity(Name));
                    }
                    break;
                case SetEntityByInputObjectParameterSet:
                    _repository.UpdateEntity(InputObject, null, null);

                    if (PassThru)
                    {
                        WriteObject(_repository.GetEntity(InputObject.MetadataId.Value));
                    }
                    break;
                default:
                    break;
            }
        }

        private EntityMetadata BuildEntity()
        {
            EntityMetadata entity = _repository.GetEntity(Name);

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(DisplayName))) 
                entity.DisplayName = new Label(DisplayName, CrmContext.Session.Language);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(DisplayCollectionName))) 
                entity.DisplayCollectionName = new Label(DisplayCollectionName, CrmContext.Session.Language);

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Description))) 
                entity.Description = new Label(Description ?? string.Empty, CrmContext.Session.Language);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Customizable))) 
                entity.IsCustomizable = new BooleanManagedProperty(Customizable);

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(AutoRouteToOwnerQueue)))
                entity.AutoRouteToOwnerQueue = AutoRouteToOwnerQueue;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(CanCreateAttributes)))
                entity.CanCreateAttributes = new BooleanManagedProperty(CanCreateAttributes);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(CanCreateCharts)))
                entity.CanCreateCharts = new BooleanManagedProperty(CanCreateCharts);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(CanCreateForms)))
                entity.CanCreateForms = new BooleanManagedProperty(CanCreateForms);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(CanCreateViews)))
                entity.CanCreateViews = new BooleanManagedProperty(CanCreateViews);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(CanModifyAdditionalSettings)))
                entity.CanModifyAdditionalSettings = new BooleanManagedProperty(CanModifyAdditionalSettings);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsActivityParty)))
                entity.IsActivityParty = IsActivityParty;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsAuditEnabled)))
                entity.IsAuditEnabled = new BooleanManagedProperty(IsAuditEnabled);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsAvailableOffline)))
                entity.IsAvailableOffline = IsAvailableOffline;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsConnectionsEnabled)))
                entity.IsConnectionsEnabled = new BooleanManagedProperty(IsConnectionsEnabled);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsDocumentManagementEnabled)))
                entity.IsDocumentManagementEnabled = IsDocumentManagementEnabled;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsDuplicateDetectionEnabled)))
                entity.IsDuplicateDetectionEnabled = new BooleanManagedProperty(IsDuplicateDetectionEnabled);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsMailMergeEnabled)))
                entity.IsMailMergeEnabled = new BooleanManagedProperty(IsMailMergeEnabled);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsMappable)))
                entity.IsMappable = new BooleanManagedProperty(IsMappable);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsRenameable)))
                entity.IsRenameable = new BooleanManagedProperty(IsRenameable);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsValidForQueue)))
                entity.IsValidForQueue = new BooleanManagedProperty(IsValidForQueue);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsVisibleInMobile)))
                entity.IsVisibleInMobile = new BooleanManagedProperty(IsVisibleInMobile);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IconLargeName)))
                entity.IconLargeName = IconLargeName;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IconMediumName)))
                entity.IconMediumName = IconMediumName;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IconSmallName)))
                entity.IconSmallName = IconSmallName;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(AutoCreateAccessTeams)))
                entity.AutoCreateAccessTeams = AutoCreateAccessTeams;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsBusinessProcessEnabled)))
                entity.IsBusinessProcessEnabled = IsBusinessProcessEnabled;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsQuickCreateEnabled)))
                entity.IsQuickCreateEnabled = IsQuickCreateEnabled;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsReadOnlyInMobileClient)))
                entity.IsReadOnlyInMobileClient = new BooleanManagedProperty(IsReadOnlyInMobileClient);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsVisibleInMobileClient)))
                entity.IsVisibleInMobileClient = new BooleanManagedProperty(IsVisibleInMobileClient);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(CanChangeHierarchicalRelationship)))
                entity.CanChangeHierarchicalRelationship = new BooleanManagedProperty(CanChangeHierarchicalRelationship);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(CanEnableSyncToExternalSearchIndex)))
                entity.CanEnableSyncToExternalSearchIndex = new BooleanManagedProperty(CanEnableSyncToExternalSearchIndex);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(ChangeTrackingEnabled)))
                entity.ChangeTrackingEnabled = ChangeTrackingEnabled;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(EntityHelpUrlEnabled)))
                entity.EntityHelpUrlEnabled = EntityHelpUrlEnabled;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsInteractionCentricEnabled)))
                entity.IsInteractionCentricEnabled = IsInteractionCentricEnabled;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsKnowledgeManagementEnabled)))
                entity.IsKnowledgeManagementEnabled = IsKnowledgeManagementEnabled;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsOfflineInMobileClient)))
                entity.IsOfflineInMobileClient = new BooleanManagedProperty(IsOfflineInMobileClient);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsOneNoteIntegrationEnabled)))
                entity.IsOneNoteIntegrationEnabled = IsOneNoteIntegrationEnabled;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsSLAEnabled)))
                entity.IsSLAEnabled = IsSLAEnabled;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(SyncToExternalSearchIndex)))
                entity.SyncToExternalSearchIndex = SyncToExternalSearchIndex;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(EntityHelpUrl)))
                entity.EntityHelpUrl = EntityHelpUrl.ToString();

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(EntityColor)) && !string.IsNullOrWhiteSpace(EntityColor))
            {
                Drawing.Color c = Drawing.Color.FromName(EntityColor);
                if (!c.IsEmpty) entity.EntityColor = string.Format("#{0:X2}{1:X2}{2:X2}", c.R, c.G, c.B);
            }

            if (Virtual)
            {
                EntitiesHelper.SetVirtualEntityDefaults(entity);

                if (this.MyInvocation.BoundParameters.ContainsKey(nameof(ExternalName))) 
                    entity.ExternalName = ExternalName;
                if (this.MyInvocation.BoundParameters.ContainsKey(nameof(ExternalCollectionName)))
                    entity.ExternalCollectionName = ExternalCollectionName;

                if (this.MyInvocation.BoundParameters.ContainsKey(nameof(DataSourceConfiguration)))
                {
                    if (DataSourceConfiguration == null)
                    {
                        entity.DataProviderId = new Guid("7015A531-CC0D-4537-B5F2-C882A1EB65AD"); // Data Provider = NONE
                        entity.DataSourceId = null;
                    }
                    else
                    {
                        var contentRepository = new ContentRepository();

                        EntitiesHelper.ValidateVirtualDataSource(contentRepository, DataSourceConfiguration.LogicalName, DataSourceConfiguration.Id);

                        Guid? dataProviderId = EntitiesHelper.GetVirtualDataProvider(contentRepository, DataSourceConfiguration.LogicalName);
                        if (dataProviderId == null)
                        {
                            throw new Exception($"DataProvider for DataSource '{DataSourceConfiguration.LogicalName}' can not be found.");
                        }
                        else
                        {
                            entity.DataProviderId = dataProviderId.Value;
                            entity.DataSourceId = DataSourceConfiguration.Id;
                        }
                    }
                }
            }

            if (DataSource)
            {
                EntitiesHelper.SetDataSourceEntityDefaults(entity);
            }

            return entity;
        }
    }
}
