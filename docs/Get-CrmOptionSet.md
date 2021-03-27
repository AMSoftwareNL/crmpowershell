---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmOptionSet.md
schema: 2.0.0
---

# Get-CrmOptionSet

## SYNOPSIS
Get the metadata of a global optionset.

## SYNTAX

### GetOptionSetByFilter (Default)
```
Get-CrmOptionSet [[-Name] <String>] [-Exclude <String>] [-CustomOnly] [-ExcludeManaged] [<CommonParameters>]
```

### GetOptionSetById
```
Get-CrmOptionSet [-Id] <Guid[]> [<CommonParameters>]
```

## DESCRIPTION
Get the metadata of a global optionset. For attribute specific optionsets use Get-CrmAttribute.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmOptionSet | Select Name -ExpandProperty Options | Select Name, Label, Value
```

Get all global optionsets with the labels and values of the options.

## PARAMETERS

### -CustomOnly
Retrieve only the metadata for optionsets that are marked as custom.

```yaml
Type: SwitchParameter
Parameter Sets: GetOptionSetByFilter
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Exclude
Exclude the metadata for optionsets whose Name matches the provided pattern.

```yaml
Type: String
Parameter Sets: GetOptionSetByFilter
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExcludeManaged
Do not retrieve metadata for optionsets that are marked as managed.

```yaml
Type: SwitchParameter
Parameter Sets: GetOptionSetByFilter
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The MetadataId of the optionset to retrieve.

```yaml
Type: Guid[]
Parameter Sets: GetOptionSetById
Aliases: MetadataId

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The Name of the optionset to retrieve the metadata for.

NOTE: This parameter is case sensitive. i.e. it must match the case of the Name exactly.

```yaml
Type: String
Parameter Sets: GetOptionSetByFilter
Aliases: Include

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid[]
## OUTPUTS

### Microsoft.Xrm.Sdk.Metadata.OptionSetMetadataBase
## NOTES
The Name parameter is case sensitive. i.e. it must match the case of the LogicalName exactly.

## RELATED LINKS

[Get-CrmEntity](Get-CrmEntity.md)

[Get-CrmAttribute](Get-CrmAttribute.md)

[Get-CrmEntityKey](Get-CrmEntityKey.md)

[Get-CrmRelationship](Get-CrmRelationship.md)

[New-CrmOptionSet](New-CrmOptionSet.md)

[New-CrmOptionSetValue](New-CrmOptionSetValue.md)

[Set-CrmOptionSet](Set-CrmOptionSet.md)

[Set-CrmOptionSetValue](Set-CrmOptionSetValue.md)

[Remove-CrmOptionSet](Remove-CrmOptionSet.md)

[Remove-CrmOptionSetValue](Remove-CrmOptionSetValue.md)

[OptionSetMetadata Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.metadata.optionsetmetadata.aspx)

[BooleanOptionSetMetadata Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.metadata.booleanoptionsetmetadata.aspx)
