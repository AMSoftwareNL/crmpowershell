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
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Management.Automation;
using Drawing = System.Drawing;

namespace AMSoftware.Crm.PowerShell.Commands.Metadata
{
    [Cmdlet(VerbsCommon.New, "CrmEntity", HelpUri = HelpUrlConstants.NewEntityHelpUrl, DefaultParameterSetName = NewEntityByInputObjectParameterSet)]
    [OutputType(typeof(EntityMetadata))]
    public sealed class NewEntityCommand : CrmOrganizationCmdlet
    {
        internal const string NewEntityParameterSet = "NewEntity";
        internal const string NewEntityByInputObjectParameterSet = "NewEntityByInputObject";
        internal const string NewActivityParameterSet = "NewActivity";
        internal const string NewVirtualEntityParameterSet = "NewVirtualEntity";
        internal const string NewDataSourceEntityParameterSet = "NewDataSourceEntity";

        private readonly MetadataRepository _repository = new MetadataRepository();

        [Parameter(ParameterSetName = NewActivityParameterSet)]
        public SwitchParameter IsActivity { get; set; }

        [Parameter(ParameterSetName = NewActivityParameterSet)]
        public SwitchParameter ExcludeFromMenu { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = NewEntityByInputObjectParameterSet, ValueFromPipeline = true)]
        [Alias("Entity")]
        [ValidateNotNull]
        public EntityMetadata InputObject { get; set; }

        [Parameter(Position = 2, Mandatory = true, ParameterSetName = NewEntityByInputObjectParameterSet)]
        [ValidateNotNull]
        public StringAttributeMetadata PrimaryAttribute { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NewVirtualEntityParameterSet)]
        public SwitchParameter Virtual { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NewDataSourceEntityParameterSet)]
        public SwitchParameter DataSource { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = NewEntityParameterSet)]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = NewVirtualEntityParameterSet)]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = NewActivityParameterSet)]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = NewDataSourceEntityParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 2, Mandatory = true, ParameterSetName = NewEntityParameterSet)]
        [Parameter(Position = 2, Mandatory = true, ParameterSetName = NewVirtualEntityParameterSet)]
        [Parameter(Position = 2, Mandatory = true, ParameterSetName = NewDataSourceEntityParameterSet)]
        [Parameter(Position = 2, Mandatory = true, ParameterSetName = NewActivityParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NewEntityParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = NewVirtualEntityParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = NewDataSourceEntityParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = NewActivityParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DisplayCollectionName { get; set; }

        [Parameter(ParameterSetName = NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewVirtualEntityParameterSet)]
        [Parameter(ParameterSetName = NewDataSourceEntityParameterSet)]
        [Parameter(ParameterSetName = NewActivityParameterSet)]
        [ValidateNotNull]
        public string Description { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NewVirtualEntityParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ExternalName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NewVirtualEntityParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ExternalCollectionName { get; set; }

        [Parameter(ParameterSetName = NewVirtualEntityParameterSet)]
        [ValidateNotNullOrEmpty]
        public EntityReference DataSourceConfiguration { get; set; }

        [Parameter(ParameterSetName = NewEntityParameterSet)]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmEntityOwner.User)]
        public CrmEntityOwner Owner { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NewEntityParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = NewDataSourceEntityParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = NewVirtualEntityParameterSet)]
        [ValidateNotNullOrEmpty]
        public string AttributeName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NewEntityParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = NewVirtualEntityParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = NewDataSourceEntityParameterSet)]
        [ValidateNotNullOrEmpty]
        public string AttributeDisplayName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NewVirtualEntityParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = NewDataSourceEntityParameterSet)]
        [ValidateNotNullOrEmpty]
        public string AttributeExternalName { get; set; }

        [Parameter(ParameterSetName = NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewVirtualEntityParameterSet)]
        [Parameter(ParameterSetName = NewDataSourceEntityParameterSet)]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmRequiredLevel.Required)]
        public CrmRequiredLevel AttributeRequired { get; set; }

        [Parameter(ParameterSetName = NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewVirtualEntityParameterSet)]
        [Parameter(ParameterSetName = NewDataSourceEntityParameterSet)]
        [ValidateRange(1, 4096)]
        [ValidateNotNull]
        [PSDefaultValue(Value = 100)]
        public int AttributeLength { get; set; }

        [Parameter(ParameterSetName = NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewVirtualEntityParameterSet)]
        [Parameter(ParameterSetName = NewDataSourceEntityParameterSet)]
        [ValidateNotNull]
        public string AttributeDescription { get; set; }

        [Parameter(ParameterSetName = NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewVirtualEntityParameterSet)]
        [Parameter(ParameterSetName = NewActivityParameterSet)]
        [ValidateNotNull]
        public bool Customizable { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewEntityCommand.NewVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool HasNotes { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewEntityCommand.NewVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool HasActivities { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [ValidateNotNull]
        public bool AutoRouteToOwnerQueue { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewEntityCommand.NewVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool CanCreateAttributes { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [ValidateNotNull]
        public bool CanCreateCharts { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewEntityCommand.NewVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool CanCreateForms { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewEntityCommand.NewVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool CanCreateViews { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewEntityCommand.NewVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool CanModifyAdditionalSettings { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [ValidateNotNull]
        public bool IsActivityParty { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [ValidateNotNull]
        public bool IsAuditEnabled { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [ValidateNotNull]
        public bool IsAvailableOffline { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewEntityCommand.NewVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool IsConnectionsEnabled { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewEntityCommand.NewVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool IsDocumentManagementEnabled { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [ValidateNotNull]
        public bool IsDuplicateDetectionEnabled { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewEntityCommand.NewVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool IsMailMergeEnabled { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewEntityCommand.NewVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool IsMappable { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewEntityCommand.NewVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool IsRenameable { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewEntityCommand.NewVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool IsValidForQueue { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewEntityCommand.NewVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool IsVisibleInMobile { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewEntityCommand.NewVirtualEntityParameterSet)]
        [ValidateNotNull]
        public string IconLargeName { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewEntityCommand.NewVirtualEntityParameterSet)]
        [ValidateNotNull]
        public string IconMediumName { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewEntityCommand.NewVirtualEntityParameterSet)]
        [ValidateNotNull]
        public string IconSmallName { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [ValidateNotNull]
        public bool AutoCreateAccessTeams { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [ValidateNotNull]
        public bool IsBusinessProcessEnabled { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewEntityCommand.NewVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool IsQuickCreateEnabled { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewEntityCommand.NewVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool IsReadOnlyInMobileClient { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewEntityCommand.NewVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool IsVisibleInMobileClient { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [ValidateNotNull]
        public bool CanChangeHierarchicalRelationship { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [ValidateNotNull]
        public bool CanEnableSyncToExternalSearchIndex { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [ValidateNotNull]
        public bool ChangeTrackingEnabled { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewEntityCommand.NewVirtualEntityParameterSet)]
        [ValidateNotNull]
        public string EntityColor { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewEntityCommand.NewVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool EntityHelpUrlEnabled { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewEntityCommand.NewVirtualEntityParameterSet)]
        [ValidateNotNull]
        public Uri EntityHelpUrl { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewEntityCommand.NewVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool IsInteractionCentricEnabled { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [ValidateNotNull]
        public bool IsKnowledgeManagementEnabled { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [ValidateNotNull]
        public bool IsOfflineInMobileClient { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [Parameter(ParameterSetName = NewEntityCommand.NewVirtualEntityParameterSet)]
        [ValidateNotNull]
        public bool IsOneNoteIntegrationEnabled { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [ValidateNotNull]
        public bool IsOptimisticConcurrencyEnabled { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [ValidateNotNull]
        public bool IsSLAEnabled { get; set; }

        [Parameter(ParameterSetName = NewEntityCommand.NewEntityParameterSet)]
        [ValidateNotNull]
        public bool SyncToExternalSearchIndex { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            bool hasNotes = this.MyInvocation.BoundParameters.ContainsKey(nameof(HasNotes)) ? HasNotes : false;
            bool hasActivities = this.MyInvocation.BoundParameters.ContainsKey(nameof(HasActivities)) ? HasActivities : false;

            switch (this.ParameterSetName)
            {
                case NewEntityParameterSet:
                case NewVirtualEntityParameterSet:
                case NewDataSourceEntityParameterSet:
                case NewActivityParameterSet:
                    if (IsActivity) hasNotes = true;
                    if (IsActivity) hasActivities = false;

                    EntityMetadata internalEntity = BuildEntity();
                    StringAttributeMetadata internalAttribute = BuildAttribute();

                    Guid objectId1 = _repository.AddEntity(internalEntity, internalAttribute, hasNotes, hasActivities);
                    // ID Attribute must have External Name
                    if (DataSource || Virtual)
                    {
                        var idAttribute = _repository.GetAttribute(internalEntity.LogicalName, $"{internalEntity.LogicalName}id");
                        idAttribute.ExternalName = ExternalName;
                        _repository.UpdateAttribute(internalEntity.LogicalName, idAttribute);
                    }

                    if (PassThru)
                    {
                        WriteObject(_repository.GetEntity(objectId1));
                    }

                    break;
                case NewEntityByInputObjectParameterSet:
                    if (InputObject.IsActivity.GetValueOrDefault()) hasNotes = true;
                    if (InputObject.IsActivity.GetValueOrDefault()) hasActivities = false;

                    Guid objectId2 = _repository.AddEntity(InputObject, PrimaryAttribute, hasNotes, hasActivities);
                    if (PassThru)
                    {
                        WriteObject(_repository.GetEntity(objectId2));
                    }

                    break;
                default:
                    break;
            }
        }

        private StringAttributeMetadata BuildAttribute()
        {
            AttributeRequiredLevel requiredLevel = AttributeRequiredLevel.ApplicationRequired;
            if (AttributeRequired == CrmRequiredLevel.Required) requiredLevel = AttributeRequiredLevel.ApplicationRequired;
            if (AttributeRequired == CrmRequiredLevel.Recommended) requiredLevel = AttributeRequiredLevel.Recommended;
            if (AttributeRequired == CrmRequiredLevel.Optional) requiredLevel = AttributeRequiredLevel.None;

            StringAttributeMetadata attribute = new StringAttributeMetadata();
            if (!IsActivity)
            {
                attribute.LogicalName = AttributeName;
                attribute.SchemaName = AttributeName;
                attribute.RequiredLevel = new AttributeRequiredLevelManagedProperty(requiredLevel);
                attribute.MaxLength = this.MyInvocation.BoundParameters.ContainsKey(nameof(AttributeLength)) ? AttributeLength : 100;
                attribute.DisplayName = new Label(AttributeDisplayName, CrmContext.Session.Language);
                attribute.Description = new Label(AttributeDescription ?? string.Empty, CrmContext.Session.Language);
                attribute.Format = StringFormat.Text;
            }
            else
            {
                attribute.SchemaName = "subject";
                attribute.MaxLength = 100;
            }

            if (Virtual || DataSource)
                attribute.ExternalName = AttributeExternalName;

            return attribute;
        }

        private EntityMetadata BuildEntity()
        {
            OwnershipTypes ownerType = OwnershipTypes.UserOwned;
            if (Owner == CrmEntityOwner.Organization) ownerType = OwnershipTypes.OrganizationOwned;
            if (Owner == CrmEntityOwner.User) ownerType = OwnershipTypes.UserOwned;

            EntityMetadata entity = new EntityMetadata()
            {
                LogicalName = Name,
                SchemaName = Name.ToLower(),
                DisplayName = new Label(DisplayName, CrmContext.Session.Language),
                DisplayCollectionName = new Label(DisplayCollectionName, CrmContext.Session.Language),
                Description = new Label(Description ?? string.Empty, CrmContext.Session.Language),
                OwnershipType = ownerType,
                IsActivity = IsActivity.ToBool()
            };
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Customizable)))
                entity.IsCustomizable = new BooleanManagedProperty(Customizable);

            if (IsActivity)
            {
                if (ExcludeFromMenu) entity.ActivityTypeMask = 0;
                entity.IsConnectionsEnabled = new BooleanManagedProperty(true);
                entity.IsValidForQueue = new BooleanManagedProperty(true);
                entity.IsAvailableOffline = true;
                entity.OwnershipType = OwnershipTypes.UserOwned;
            }
            else
            {
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
            }

            if (Virtual)
            {
                EntitiesHelper.SetVirtualEntityDefaults(entity);

                entity.ExternalName = ExternalName;
                entity.ExternalCollectionName = ExternalCollectionName;
                entity.DataProviderId = new Guid("7015A531-CC0D-4537-B5F2-C882A1EB65AD"); // Data Provider = NONE
                entity.DataSourceId = null;

                if (this.MyInvocation.BoundParameters.ContainsKey(nameof(DataSourceConfiguration)))
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

            if (DataSource)
            {
                EntitiesHelper.SetDataSourceEntityDefaults(entity);

                entity.ExternalName = DisplayName.Replace(" ", string.Empty);
                entity.ExternalCollectionName = DisplayCollectionName.Replace(" ", string.Empty);
            }

            return entity;
        }
    }
}
