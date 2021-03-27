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

### NewEntity
```
New-CrmEntity [-Name] <String> [-DisplayName] <String> -DisplayCollectionName <String> [-Description <String>]
 [-Owner <CrmEntityOwner>] -AttributeName <String> -AttributeDisplayName <String>
 [-AttributeRequired <CrmRequiredLevel>] [-AttributeLength <Int32>] [-AttributeDescription <String>]
 [-Customizable <Boolean>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Add a new entity.

## EXAMPLES

## PARAMETERS

### -AttributeDescription
The description for the primary attribute.

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
The displayname for the primary attribute.

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
The maximum length for the primary attribute.

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
The LogicalName for the primary attribute.

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
The data entry requirement level enforced for the primary attribute.

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

### -Customizable
Whether the entity is customizable.

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
The label containing the description for the entity.

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
The label containing the plural display name for the entity.

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
The label containing the display name for the entity.

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

### -ExcludeFromMenu
Whether a custom activity should appear in the activity menus in the Web application.

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

### -InputObject
The EntityMetadata object for the new entity.

```yaml
Type: EntityMetadata
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
Type: SwitchParameter
Parameter Sets: NewActivity
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
The ownership type for the entity.

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

### -PassThru
Returns an object that represents the EntityMetadata. By default, this cmdlet does not generate any output.

```yaml
Type: SwitchParameter
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
Type: StringAttributeMetadata
Parameter Sets: NewEntityByInputObject
Aliases:

Required: True
Position: 2
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

[EntityMetadata Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.metadata.entitymetadata.aspx)
