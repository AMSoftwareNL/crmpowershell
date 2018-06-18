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
using System.Drawing;
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace AMSoftware.Crm.PowerShell.Commands.Metadata
{
    [Cmdlet(VerbsCommon.Set, "CrmEntity", HelpUri = HelpUrlConstants.SetEntityHelpUrl, DefaultParameterSetName = SetEntityByInputObjectParameterSet)]
    [OutputType(typeof(EntityMetadata))]
    public sealed class SetEntityCommand : CrmOrganizationCmdlet, IDynamicParameters
    {
        internal const string SetEntityParameterSet = "SetEntity";
        internal const string SetEntityByInputObjectParameterSet = "SetEntityByInputObject";

        private MetadataRepository _repository = new MetadataRepository();
        private SetEntityDynamicParameters _context;

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = SetEntityByInputObjectParameterSet, ValueFromPipeline = true)]
        [Alias("Entity")]
        [ValidateNotNull]
        public EntityMetadata InputObject { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = SetEntityParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = SetEntityParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(ParameterSetName = SetEntityParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DisplayCollectionName { get; set; }

        [Parameter(ParameterSetName = SetEntityParameterSet)]
        [ValidateNotNull]
        public string Description { get; set; }

        [Parameter(ParameterSetName = SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? Customizable { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            switch (this.ParameterSetName)
            {
                case SetEntityParameterSet:
                    EntityMetadata internalEntity = BuildEntity();
                    if (_context == null)
                    {
                        _repository.UpdateEntity(internalEntity, _context.HasNotes, _context.HasActivities);
                    }
                    else
                    {
                        _repository.UpdateEntity(internalEntity, _context.HasNotes, _context.HasActivities);
                    }

                    if(PassThru)
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
            EntityMetadata entity = new EntityMetadata()
            {
                LogicalName = Name
            };

            if (!string.IsNullOrWhiteSpace(DisplayName)) entity.DisplayName = new Label(DisplayName, CrmContext.Language);
            if (!string.IsNullOrWhiteSpace(DisplayCollectionName)) entity.DisplayCollectionName = new Label(DisplayCollectionName, CrmContext.Language);
            if (Description != null) entity.Description = new Label(Description ?? string.Empty, CrmContext.Language);
            if (Customizable.HasValue) entity.IsCustomizable = new BooleanManagedProperty(Customizable.Value);

            if (_context != null)
            {
                _context.SetParametersOnEntity(entity);
            }

            return entity;
        }

        public object GetDynamicParameters()
        {
            if (CrmVersionManager.IsSupported(CrmVersion.CRM2016_RTM))
            {
                _context = new SetEntityDynamicParameters2016();
            }
            else if (CrmVersionManager.IsSupported(CrmVersion.CRM2013_RTM))
            {
                _context = new SetEntityDynamicParameters2013();
            }
            else
            {
                _context = new SetEntityDynamicParameters();
            }
            return _context;
        }
    }

    public class SetEntityDynamicParameters
    {
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? HasNotes { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? HasActivities { get; set; }

        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? AutoRouteToOwnerQueue { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? CanCreateAttributes { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? CanCreateCharts { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? CanCreateForms { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? CanCreateViews { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? CanModifyAdditionalSettings { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? IsActivityParty { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? IsAuditEnabled { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? IsAvailableOffline { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? IsConnectionsEnabled { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? IsDocumentManagementEnabled { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? IsDuplicateDetectionEnabled { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? IsMailMergeEnabled { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? IsMappable { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? IsRenameable { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? IsValidForQueue { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? IsVisibleInMobile { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public string IconLargeName { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public string IconMediumName { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public string IconSmallName { get; set; }

        internal protected virtual void SetParametersOnEntity(EntityMetadata entity)
        {
            if (AutoRouteToOwnerQueue.HasValue) entity.AutoRouteToOwnerQueue = AutoRouteToOwnerQueue.Value;
            if (CanCreateAttributes.HasValue) entity.CanCreateAttributes = new BooleanManagedProperty(CanCreateAttributes.Value);
            if (CanCreateCharts.HasValue) entity.CanCreateCharts = new BooleanManagedProperty(CanCreateCharts.Value);
            if (CanCreateForms.HasValue) entity.CanCreateForms = new BooleanManagedProperty(CanCreateForms.Value);
            if (CanCreateViews.HasValue) entity.CanCreateViews = new BooleanManagedProperty(CanCreateViews.Value);
            if (CanModifyAdditionalSettings.HasValue) entity.CanModifyAdditionalSettings = new BooleanManagedProperty(CanModifyAdditionalSettings.Value);
            if (IsActivityParty.HasValue) entity.IsActivityParty = IsActivityParty.Value;
            if (IsAuditEnabled.HasValue) entity.IsAuditEnabled = new BooleanManagedProperty(IsAuditEnabled.Value);
            if (IsAvailableOffline.HasValue) entity.IsAvailableOffline = IsAvailableOffline.Value;
            if (IsConnectionsEnabled.HasValue) entity.IsConnectionsEnabled = new BooleanManagedProperty(IsConnectionsEnabled.Value);
            if (IsDocumentManagementEnabled.HasValue) entity.IsDocumentManagementEnabled = IsDocumentManagementEnabled.Value;
            if (IsDuplicateDetectionEnabled.HasValue) entity.IsDuplicateDetectionEnabled = new BooleanManagedProperty(IsDuplicateDetectionEnabled.Value);
            if (IsMailMergeEnabled.HasValue) entity.IsMailMergeEnabled = new BooleanManagedProperty(IsMailMergeEnabled.Value);
            if (IsMappable.HasValue) entity.IsMappable = new BooleanManagedProperty(IsMappable.Value);
            if (IsRenameable.HasValue) entity.IsRenameable = new BooleanManagedProperty(IsRenameable.Value);
            if (IsValidForQueue.HasValue) entity.IsValidForQueue = new BooleanManagedProperty(IsValidForQueue.Value);
            if (IsVisibleInMobile.HasValue) entity.IsVisibleInMobile = new BooleanManagedProperty(IsVisibleInMobile.Value);
            if (IconLargeName != null) entity.IconLargeName = IconLargeName;
            if (IconMediumName != null) entity.IconMediumName = IconMediumName;
            if (IconSmallName != null) entity.IconSmallName = IconSmallName;
        }
    }

    public sealed class SetEntityDynamicParameters2013 : SetEntityDynamicParameters
    {
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? AutoCreateAccessTeams { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? IsBusinessProcessEnabled { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? IsQuickCreateEnabled { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? IsReadOnlyInMobileClient { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? IsVisibleInMobileClient { get; set; }

        protected internal override void SetParametersOnEntity(EntityMetadata entity)
        {
            base.SetParametersOnEntity(entity);

            if (AutoCreateAccessTeams.HasValue) entity.AutoCreateAccessTeams = AutoCreateAccessTeams;
            if (IsBusinessProcessEnabled.HasValue) entity.IsBusinessProcessEnabled = IsBusinessProcessEnabled;
            if (IsQuickCreateEnabled.HasValue) entity.IsQuickCreateEnabled = IsQuickCreateEnabled;
            if (IsReadOnlyInMobileClient.HasValue) entity.IsReadOnlyInMobileClient = new BooleanManagedProperty(IsReadOnlyInMobileClient.Value);
            if (IsVisibleInMobileClient.HasValue) entity.IsVisibleInMobileClient = new BooleanManagedProperty(IsVisibleInMobileClient.Value);
        }
    }

    public sealed class SetEntityDynamicParameters2016 : SetEntityDynamicParameters
    {
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? CanChangeHierarchicalRelationship { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? CanEnableSyncToExternalSearchIndex { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? ChangeTrackingEnabled { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public string EntityColor { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? EntityHelpUrlEnabled { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public Uri EntityHelpUrl { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? IsInteractionCentricEnabled { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? IsKnowledgeManagementEnabled { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? IsOfflineInMobileClient { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? IsOneNoteIntegrationEnabled { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? IsOptimisticConcurrencyEnabled { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? IsSLAEnabled { get; set; }
        [Parameter(ParameterSetName = SetEntityCommand.SetEntityParameterSet)]
        [ValidateNotNull]
        public bool? SyncToExternalSearchIndex { get; set; }

        protected internal override void SetParametersOnEntity(EntityMetadata entity)
        {
            base.SetParametersOnEntity(entity);

            if (CanChangeHierarchicalRelationship.HasValue) entity.CanChangeHierarchicalRelationship = new BooleanManagedProperty(CanChangeHierarchicalRelationship.Value);
            if (CanEnableSyncToExternalSearchIndex.HasValue) entity.CanEnableSyncToExternalSearchIndex = new BooleanManagedProperty(CanEnableSyncToExternalSearchIndex.Value);
            if (ChangeTrackingEnabled.HasValue) entity.ChangeTrackingEnabled = ChangeTrackingEnabled;
            if (EntityHelpUrlEnabled.HasValue) entity.EntityHelpUrlEnabled = EntityHelpUrlEnabled;
            if (IsInteractionCentricEnabled.HasValue) entity.IsInteractionCentricEnabled = IsInteractionCentricEnabled;
            if (IsKnowledgeManagementEnabled.HasValue) entity.IsKnowledgeManagementEnabled = IsKnowledgeManagementEnabled;
            if (IsOfflineInMobileClient.HasValue) entity.IsOfflineInMobileClient = new BooleanManagedProperty(IsOfflineInMobileClient.Value);
            if (IsOneNoteIntegrationEnabled.HasValue) entity.IsOneNoteIntegrationEnabled = IsOneNoteIntegrationEnabled;
            if (IsSLAEnabled.HasValue) entity.IsSLAEnabled = IsSLAEnabled;
            if (SyncToExternalSearchIndex.HasValue) entity.SyncToExternalSearchIndex = SyncToExternalSearchIndex;
            if (EntityColor != null)
            {
                if (string.IsNullOrWhiteSpace(EntityColor))
                {
                    entity.EntityColor = null;
                }
                else
                {
                    Color c = Color.FromName(EntityColor);
                    if (!c.IsEmpty) entity.EntityColor = string.Format("#{0:X2}{1:X2}{2:X2}", c.R, c.G, c.B);
                }
            }
            if (EntityHelpUrl != null) entity.EntityHelpUrl = EntityHelpUrl.ToString();
        }
    }
}
