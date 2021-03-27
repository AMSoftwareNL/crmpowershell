---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Set-CrmEntity.md
schema: 2.0.0
---

# Set-CrmEntity

## SYNOPSIS
Update an entity.

## SYNTAX

### SetEntityByInputObject (Default)
```
Set-CrmEntity [-InputObject] <EntityMetadata> [-PassThru] [<CommonParameters>]
```

### SetEntity
```
Set-CrmEntity [-Name] <String> [-DisplayName <String>] [-DisplayCollectionName <String>]
 [-Description <String>] [-Customizable <Boolean>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Update an entity.

## EXAMPLES

## PARAMETERS

### -Customizable
Whether the entity is customizable.

```yaml
Type: Boolean
Parameter Sets: SetEntity
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
Parameter Sets: SetEntity
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
Parameter Sets: SetEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
The label containing the display name for the entity.

```yaml
Type: String
Parameter Sets: SetEntity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The updated EntityMetadata object for the entity.

```yaml
Type: EntityMetadata
Parameter Sets: SetEntityByInputObject
Aliases: Entity

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The LogicalName of the entity to update.

```yaml
Type: String
Parameter Sets: SetEntity
Aliases: LogicalName

Required: True
Position: 1
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Xrm.Sdk.Metadata.EntityMetadata
## OUTPUTS

### Microsoft.Xrm.Sdk.Metadata.EntityMetadata
## NOTES

## RELATED LINKS

[Get-CrmEntity](Get-CrmEntity.md)

[New-CrmEntity](New-CrmEntity.md)

[Remove-CrmEntity](Remove-CrmEntity.md)

[EntityMetadata Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.metadata.entitymetadata.aspx)
