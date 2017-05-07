---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/New-CrmEntity.html
schema: 2.0.0
---

# New-CrmEntity

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### NewEntityByInputObject (Default)
```
New-CrmEntity [-Entity] <EntityMetadata> [-PrimaryAttribute] <StringAttributeMetadata> [<CommonParameters>]
```

### NewActivity
```
New-CrmEntity [-IsActivity] [-ExcludeFromMenu] [-Name] <String> [-DisplayName] <String>
 -DisplayCollectionName <String> [-Description <String>] [-Customizable <Boolean>] [<CommonParameters>]
```

### NewEntity
```
New-CrmEntity [-Name] <String> [-DisplayName] <String> -DisplayCollectionName <String> [-Description <String>]
 [-Owner <CrmEntityOwner>] -AttributeName <String> -AttributeDisplayName <String>
 [-AttributeRequired <CrmRequiredLevel>] [-AttributeLength <Int32>] [-AttributeDescription <String>]
 [-Customizable <Boolean>] [-CanChangeHierarchicalRelationship <Boolean>]
 [-CanEnableSyncToExternalSearchIndex <Boolean>] [-ChangeTrackingEnabled <Boolean>] [-EntityColor <String>]
 [-EntityHelpUrlEnabled <Boolean>] [-EntityHelpUrl <Uri>] [-IsInteractionCentricEnabled <Boolean>]
 [-IsKnowledgeManagementEnabled <Boolean>] [-IsOfflineInMobileClient <Boolean>]
 [-IsOneNoteIntegrationEnabled <Boolean>] [-IsOptimisticConcurrencyEnabled <Boolean>] [-IsSLAEnabled <Boolean>]
 [-SyncToExternalSearchIndex <Boolean>] [-HasNotes <Boolean>] [-HasActivities <Boolean>]
 [-AutoRouteToOwnerQueue <Boolean>] [-CanCreateAttributes <Boolean>] [-CanCreateCharts <Boolean>]
 [-CanCreateForms <Boolean>] [-CanCreateViews <Boolean>] [-CanModifyAdditionalSettings <Boolean>]
 [-IsActivityParty <Boolean>] [-IsAuditEnabled <Boolean>] [-IsAvailableOffline <Boolean>]
 [-IsConnectionsEnabled <Boolean>] [-IsDocumentManagementEnabled <Boolean>]
 [-IsDuplicateDetectionEnabled <Boolean>] [-IsMailMergeEnabled <Boolean>] [-IsMappable <Boolean>]
 [-IsRenameable <Boolean>] [-IsValidForQueue <Boolean>] [-IsVisibleInMobile <Boolean>]
 [-IconLargeName <String>] [-IconMediumName <String>] [-IconSmallName <String>] [<CommonParameters>]
```

## DESCRIPTION
{{Fill in the Description}}

## EXAMPLES

### Example 1
```
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AttributeDescription
{{Fill AttributeDescription Description}}

```yaml
Type: String
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributeDisplayName
{{Fill AttributeDisplayName Description}}

```yaml
Type: String
Parameter Sets: NewEntity
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributeLength
{{Fill AttributeLength Description}}

```yaml
Type: Int32
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributeName
{{Fill AttributeName Description}}

```yaml
Type: String
Parameter Sets: NewEntity
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributeRequired
{{Fill AttributeRequired Description}}

```yaml
Type: CrmRequiredLevel
Parameter Sets: NewEntity
Aliases: 
Accepted values: Unknown, Required, Recommended, Optional

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoRouteToOwnerQueue
{{Fill AutoRouteToOwnerQueue Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CanChangeHierarchicalRelationship
{{Fill CanChangeHierarchicalRelationship Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CanCreateAttributes
{{Fill CanCreateAttributes Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CanCreateCharts
{{Fill CanCreateCharts Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CanCreateForms
{{Fill CanCreateForms Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CanCreateViews
{{Fill CanCreateViews Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CanEnableSyncToExternalSearchIndex
{{Fill CanEnableSyncToExternalSearchIndex Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CanModifyAdditionalSettings
{{Fill CanModifyAdditionalSettings Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ChangeTrackingEnabled
{{Fill ChangeTrackingEnabled Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Customizable
{{Fill Customizable Description}}

```yaml
Type: Boolean
Parameter Sets: NewActivity, NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
{{Fill Description Description}}

```yaml
Type: String
Parameter Sets: NewActivity, NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayCollectionName
{{Fill DisplayCollectionName Description}}

```yaml
Type: String
Parameter Sets: NewActivity, NewEntity
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
{{Fill DisplayName Description}}

```yaml
Type: String
Parameter Sets: NewActivity, NewEntity
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entity
{{Fill Entity Description}}

```yaml
Type: EntityMetadata
Parameter Sets: NewEntityByInputObject
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EntityColor
{{Fill EntityColor Description}}

```yaml
Type: String
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EntityHelpUrl
{{Fill EntityHelpUrl Description}}

```yaml
Type: Uri
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EntityHelpUrlEnabled
{{Fill EntityHelpUrlEnabled Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExcludeFromMenu
{{Fill ExcludeFromMenu Description}}

```yaml
Type: SwitchParameter
Parameter Sets: NewActivity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HasActivities
{{Fill HasActivities Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HasNotes
{{Fill HasNotes Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IconLargeName
{{Fill IconLargeName Description}}

```yaml
Type: String
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IconMediumName
{{Fill IconMediumName Description}}

```yaml
Type: String
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IconSmallName
{{Fill IconSmallName Description}}

```yaml
Type: String
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsActivity
{{Fill IsActivity Description}}

```yaml
Type: SwitchParameter
Parameter Sets: NewActivity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsActivityParty
{{Fill IsActivityParty Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsAuditEnabled
{{Fill IsAuditEnabled Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsAvailableOffline
{{Fill IsAvailableOffline Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsConnectionsEnabled
{{Fill IsConnectionsEnabled Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsDocumentManagementEnabled
{{Fill IsDocumentManagementEnabled Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsDuplicateDetectionEnabled
{{Fill IsDuplicateDetectionEnabled Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsInteractionCentricEnabled
{{Fill IsInteractionCentricEnabled Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsKnowledgeManagementEnabled
{{Fill IsKnowledgeManagementEnabled Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsMailMergeEnabled
{{Fill IsMailMergeEnabled Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsMappable
{{Fill IsMappable Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsOfflineInMobileClient
{{Fill IsOfflineInMobileClient Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsOneNoteIntegrationEnabled
{{Fill IsOneNoteIntegrationEnabled Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsOptimisticConcurrencyEnabled
{{Fill IsOptimisticConcurrencyEnabled Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsRenameable
{{Fill IsRenameable Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsSLAEnabled
{{Fill IsSLAEnabled Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsValidForQueue
{{Fill IsValidForQueue Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsVisibleInMobile
{{Fill IsVisibleInMobile Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
{{Fill Name Description}}

```yaml
Type: String
Parameter Sets: NewActivity, NewEntity
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Owner
{{Fill Owner Description}}

```yaml
Type: CrmEntityOwner
Parameter Sets: NewEntity
Aliases: 
Accepted values: Unknown, User, Organization

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrimaryAttribute
{{Fill PrimaryAttribute Description}}

```yaml
Type: StringAttributeMetadata
Parameter Sets: NewEntityByInputObject
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SyncToExternalSearchIndex
{{Fill SyncToExternalSearchIndex Description}}

```yaml
Type: Boolean
Parameter Sets: NewEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Xrm.Sdk.Metadata.EntityMetadata

## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/New-CrmEntity.html](http://crmpowershell.amsoftware.nl/New-CrmEntity.html)

