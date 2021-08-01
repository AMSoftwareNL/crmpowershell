---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/New-CrmEntity.md
schema: 2.0.0
---

# New-CrmEntity

## SYNOPSIS
Add a new entity.

## SYNTAX

### NewEntityByInputObject (Default)
```
New-CrmEntity [-InputObject] <EntityMetadata> [-PrimaryAttribute] <StringAttributeMetadata> [-PassThru]
 [<CommonParameters>]
```

### NewActivity
```
New-CrmEntity [-IsActivity] [-ExcludeFromMenu] [-Name] <String> [-DisplayName] <String>
 -DisplayCollectionName <String> [-Description <String>] [-Customizable <Boolean>] [-PassThru]
 [<CommonParameters>]
```

### NewVirtualEntity
```
New-CrmEntity [-Virtual] [-Name] <String> [-DisplayName] <String> -DisplayCollectionName <String>
 [-Description <String>] -ExternalName <String> -ExternalCollectionName <String>
 [-DataSourceConfiguration <EntityReference>] -AttributeName <String> -AttributeDisplayName <String>
 -AttributeExternalName <String> [-AttributeRequired <CrmRequiredLevel>] [-AttributeLength <Int32>]
 [-AttributeDescription <String>] [-Customizable <Boolean>] [-HasNotes <Boolean>] [-HasActivities <Boolean>]
 [-CanCreateAttributes <Boolean>] [-CanCreateForms <Boolean>] [-CanCreateViews <Boolean>]
 [-CanModifyAdditionalSettings <Boolean>] [-IsConnectionsEnabled <Boolean>]
 [-IsDocumentManagementEnabled <Boolean>] [-IsMailMergeEnabled <Boolean>] [-IsMappable <Boolean>]
 [-IsRenameable <Boolean>] [-IsValidForQueue <Boolean>] [-IsVisibleInMobile <Boolean>]
 [-IconLargeName <String>] [-IconMediumName <String>] [-IconSmallName <String>]
 [-IsQuickCreateEnabled <Boolean>] [-IsReadOnlyInMobileClient <Boolean>] [-IsVisibleInMobileClient <Boolean>]
 [-EntityColor <String>] [-EntityHelpUrlEnabled <Boolean>] [-EntityHelpUrl <Uri>]
 [-IsInteractionCentricEnabled <Boolean>] [-IsOneNoteIntegrationEnabled <Boolean>] [-PassThru]
 [<CommonParameters>]
```

### NewDataSourceEntity
```
New-CrmEntity [-DataSource] [-Name] <String> [-DisplayName] <String> -DisplayCollectionName <String>
 [-Description <String>] -AttributeName <String> -AttributeDisplayName <String> -AttributeExternalName <String>
 [-AttributeRequired <CrmRequiredLevel>] [-AttributeLength <Int32>] [-AttributeDescription <String>]
 [-PassThru] [<CommonParameters>]
```

### NewEntity
```
New-CrmEntity [-Name] <String> [-DisplayName] <String> -DisplayCollectionName <String> [-Description <String>]
 [-Owner <CrmEntityOwner>] -AttributeName <String> -AttributeDisplayName <String>
 [-AttributeRequired <CrmRequiredLevel>] [-AttributeLength <Int32>] [-AttributeDescription <String>]
 [-Customizable <Boolean>] [-HasNotes <Boolean>] [-HasActivities <Boolean>] [-AutoRouteToOwnerQueue <Boolean>]
 [-CanCreateAttributes <Boolean>] [-CanCreateCharts <Boolean>] [-CanCreateForms <Boolean>]
 [-CanCreateViews <Boolean>] [-CanModifyAdditionalSettings <Boolean>] [-IsActivityParty <Boolean>]
 [-IsAuditEnabled <Boolean>] [-IsAvailableOffline <Boolean>] [-IsConnectionsEnabled <Boolean>]
 [-IsDocumentManagementEnabled <Boolean>] [-IsDuplicateDetectionEnabled <Boolean>]
 [-IsMailMergeEnabled <Boolean>] [-IsMappable <Boolean>] [-IsRenameable <Boolean>] [-IsValidForQueue <Boolean>]
 [-IsVisibleInMobile <Boolean>] [-IconLargeName <String>] [-IconMediumName <String>] [-IconSmallName <String>]
 [-AutoCreateAccessTeams <Boolean>] [-IsBusinessProcessEnabled <Boolean>] [-IsQuickCreateEnabled <Boolean>]
 [-IsReadOnlyInMobileClient <Boolean>] [-IsVisibleInMobileClient <Boolean>]
 [-CanChangeHierarchicalRelationship <Boolean>] [-CanEnableSyncToExternalSearchIndex <Boolean>]
 [-ChangeTrackingEnabled <Boolean>] [-EntityColor <String>] [-EntityHelpUrlEnabled <Boolean>]
 [-EntityHelpUrl <Uri>] [-IsInteractionCentricEnabled <Boolean>] [-IsKnowledgeManagementEnabled <Boolean>]
 [-IsOfflineInMobileClient <Boolean>] [-IsOneNoteIntegrationEnabled <Boolean>]
 [-IsOptimisticConcurrencyEnabled <Boolean>] [-IsSLAEnabled <Boolean>] [-SyncToExternalSearchIndex <Boolean>]
 [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Add a new entity.

## EXAMPLES

## PARAMETERS

### -AttributeDescription
The description for the primary attribute.

```yaml
Type: System.String
Parameter Sets: NewVirtualEntity, NewDataSourceEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributeDisplayName
The displayname for the primary attribute.

```yaml
Type: System.String
Parameter Sets: NewVirtualEntity, NewDataSourceEntity, NewEntity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributeExternalName
The ExternalName of the primary attribute when used in a Virtual Entity

```yaml
Type: System.String
Parameter Sets: NewVirtualEntity, NewDataSourceEntity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributeLength
The maximum length for the primary attribute.

```yaml
Type: System.Int32
Parameter Sets: NewVirtualEntity, NewDataSourceEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributeName
The LogicalName for the primary attribute.

```yaml
Type: System.String
Parameter Sets: NewVirtualEntity, NewDataSourceEntity, NewEntity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributeRequired
The data entry requirement level enforced for the primary attribute.

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmRequiredLevel
Parameter Sets: NewVirtualEntity, NewDataSourceEntity, NewEntity
Aliases:
Accepted values: Unknown, Required, Recommended, Optional

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoCreateAccessTeams
Whether the entity is enabled for auto created access teams

```yaml
Type: System.Boolean
Parameter Sets: NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoRouteToOwnerQueue
Whether to automatically move records to the owner's default queue when a record of this type is created or assigned

```yaml
Type: System.Boolean
Parameter Sets: NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CanChangeHierarchicalRelationship
Whether the hierarchical state of entity relationships included in your managed solutions can be changed

```yaml
Type: System.Boolean
Parameter Sets: NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CanCreateAttributes
Determines whether additional attributes can be added to the entity

```yaml
Type: System.Boolean
Parameter Sets: NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CanCreateCharts
Determines whether new charts can be created for the entity

```yaml
Type: System.Boolean
Parameter Sets: NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CanCreateForms
Determines whether new forms can be created for the entity

```yaml
Type: System.Boolean
Parameter Sets: NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CanCreateViews
Determines whether new views can be created for the entity

```yaml
Type: System.Boolean
Parameter Sets: NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CanEnableSyncToExternalSearchIndex
Whether this entity can be enabled for relevance search when customizing a managed solution

```yaml
Type: System.Boolean
Parameter Sets: NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CanModifyAdditionalSettings
Determines whether any other entity properties not represented by a managed property can be changed

```yaml
Type: System.Boolean
Parameter Sets: NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ChangeTrackingEnabled
Boolean value that specifies whether change tracking is enabled for an entity or not

```yaml
Type: System.Boolean
Parameter Sets: NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Customizable
Whether the entity is customizable.

```yaml
Type: System.Boolean
Parameter Sets: NewActivity, NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSource
Create a DataSource Entity

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: NewDataSourceEntity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSourceConfiguration
Entity containing the DataSource configuration

```yaml
Type: Microsoft.Xrm.Sdk.EntityReference
Parameter Sets: NewVirtualEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
The label containing the description for the entity.

```yaml
Type: System.String
Parameter Sets: NewActivity, NewVirtualEntity, NewDataSourceEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayCollectionName
The label containing the plural display name for the entity.

```yaml
Type: System.String
Parameter Sets: NewActivity, NewVirtualEntity, NewDataSourceEntity, NewEntity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
The label containing the display name for the entity.

```yaml
Type: System.String
Parameter Sets: NewActivity, NewVirtualEntity, NewDataSourceEntity, NewEntity
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EntityColor
The code to represent the color to be used for this entity in the application.
Provide a well known colorname or the hexadecimal code of the color. 

```yaml
Type: System.String
Parameter Sets: NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EntityHelpUrl
The URL of the resource to display help content for this entity

```yaml
Type: System.Uri
Parameter Sets: NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EntityHelpUrlEnabled
Whether the entity supports custom help content

```yaml
Type: System.Boolean
Parameter Sets: NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExcludeFromMenu
Whether a custom activity should appear in the activity menus in the Web application.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: NewActivity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExternalCollectionName
The ExternalName when used as a Virtual Entity

```yaml
Type: System.String
Parameter Sets: NewVirtualEntity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExternalName
The ExternalName when used as a Virtual Entity

```yaml
Type: System.String
Parameter Sets: NewVirtualEntity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HasActivities
Allow this table to represent a task that is performed by an activity table.

```yaml
Type: System.Boolean
Parameter Sets: NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HasNotes
Enable Attachments (including Notes and Files)

```yaml
Type: System.Boolean
Parameter Sets: NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IconLargeName
The name of the image web resource for the large icon for the entity

```yaml
Type: System.String
Parameter Sets: NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IconMediumName
The name of the image web resource for the medium icon for the entity

```yaml
Type: System.String
Parameter Sets: NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IconSmallName
The name of the image web resource for the small icon for the entity

```yaml
Type: System.String
Parameter Sets: NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The EntityMetadata object for the new entity.

```yaml
Type: Microsoft.Xrm.Sdk.Metadata.EntityMetadata
Parameter Sets: NewEntityByInputObject
Aliases: Entity

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsActivity
Whether the entity is an activity.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: NewActivity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsActivityParty
Whether the email messages can be sent to an email address stored in a record of this type

```yaml
Type: System.Boolean
Parameter Sets: NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsAuditEnabled
Determines whether auditing has been enabled for the entity

```yaml
Type: System.Boolean
Parameter Sets: NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsAvailableOffline
Whether the entity is available offline

```yaml
Type: System.Boolean
Parameter Sets: NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsBusinessProcessEnabled
Whether the entity is enabled for business process flows

```yaml
Type: System.Boolean
Parameter Sets: NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsConnectionsEnabled
Determines whether connections are enabled for this entity

```yaml
Type: System.Boolean
Parameter Sets: NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsDocumentManagementEnabled
Determines whether document management is enabled

```yaml
Type: System.Boolean
Parameter Sets: NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsDuplicateDetectionEnabled
Determines whether duplicate detection is enabled

```yaml
Type: System.Boolean
Parameter Sets: NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsInteractionCentricEnabled
Whether the entity is enabled for interactive experience

```yaml
Type: System.Boolean
Parameter Sets: NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsKnowledgeManagementEnabled
Whether Parature knowledge management integration is enabled for the entity

```yaml
Type: System.Boolean
Parameter Sets: NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsMailMergeEnabled
Determines whether mail merge is enabled for this entity

```yaml
Type: System.Boolean
Parameter Sets: NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsMappable
Determines whether entity mapping is available for the entity

```yaml
Type: System.Boolean
Parameter Sets: NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsOfflineInMobileClient

```yaml
Type: System.Boolean
Parameter Sets: NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsOneNoteIntegrationEnabled
Whether OneNote integration is enabled for the Entity

```yaml
Type: System.Boolean
Parameter Sets: NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsOptimisticConcurrencyEnabled
Whether optimistic concurrency is enabled for the entity

```yaml
Type: System.Boolean
Parameter Sets: NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsQuickCreateEnabled
Indicating if the entity is enabled for quick create forms

```yaml
Type: System.Boolean
Parameter Sets: NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsReadOnlyInMobileClient
Determines whether Microsoft Dynamics 365 for tablets users can update data for this entity

```yaml
Type: System.Boolean
Parameter Sets: NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsRenameable
Determines whether the entity DisplayName and DisplayCollectionName can be changed by editing the entity in the application

```yaml
Type: System.Boolean
Parameter Sets: NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsSLAEnabled
Indicating if the entity is enabled for service level agreements (SLAs)

```yaml
Type: System.Boolean
Parameter Sets: NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsValidForQueue
Determines whether the entity is enabled for queues

```yaml
Type: System.Boolean
Parameter Sets: NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsVisibleInMobile
Determines whether Microsoft Dynamics 365 for phones users can see data for this entity

```yaml
Type: System.Boolean
Parameter Sets: NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsVisibleInMobileClient
Determines whether Microsoft Dynamics 365 for tablets users can see data for this entity

```yaml
Type: System.Boolean
Parameter Sets: NewVirtualEntity, NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The LogicalName for the new entity. This must include the prefix for custom entities.

```yaml
Type: System.String
Parameter Sets: NewActivity, NewVirtualEntity, NewDataSourceEntity, NewEntity
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Owner
The ownership type for the entity.

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmEntityOwner
Parameter Sets: NewEntity
Aliases:
Accepted values: Unknown, User, Organization

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns an object that represents the EntityMetadata. By default, this cmdlet does not generate any output.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrimaryAttribute
The AttributeMetadata for the primary attribute.

```yaml
Type: Microsoft.Xrm.Sdk.Metadata.StringAttributeMetadata
Parameter Sets: NewEntityByInputObject
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SyncToExternalSearchIndex
Whether this entity is searchable in relevance search.

```yaml
Type: System.Boolean
Parameter Sets: NewEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Virtual
Create the Entity as a Virtual Entity

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: NewVirtualEntity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Xrm.Sdk.Metadata.EntityMetadata

## OUTPUTS

### Microsoft.Xrm.Sdk.Metadata.EntityMetadata

## NOTES

## RELATED LINKS

[Get-CrmEntity](Get-CrmEntity.md)

[Remove-CrmEntity](Remove-CrmEntity.md)

[Set-CrmEntity](Set-CrmEntity.md)

[EntityMetadata Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.metadata.entitymetadata)
