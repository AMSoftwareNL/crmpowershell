---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/New-CrmOptionSet.html
schema: 2.0.0
---

# New-CrmOptionSet

## SYNOPSIS
Add a new global optionset.

## SYNTAX

### NewOptionSetByInputObject
```
New-CrmOptionSet [-OptionSet] <OptionSetMetadata> [<CommonParameters>]
```

### NewOptionSet
```
New-CrmOptionSet [-Name] <String> [-DisplayName] <String> [-Values] <PSOptionSetValue[]>
 [-Description <String>] [-Customizable <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
Add a new global optionset.

## EXAMPLES

## PARAMETERS

### -Customizable
Whether the optionset is customizable.

```yaml
Type: Boolean
Parameter Sets: NewOptionSet
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
The description for the optionset.

```yaml
Type: String
Parameter Sets: NewOptionSet
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
The displayname for the optionset.

```yaml
Type: String
Parameter Sets: NewOptionSet
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name for the optionset.

```yaml
Type: String
Parameter Sets: NewOptionSet
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionSet
The OptionSetMetadata object for the new optionset.

```yaml
Type: OptionSetMetadata
Parameter Sets: NewOptionSetByInputObject
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Values
The OptionSetValues for the new optionset.

```yaml
Type: PSOptionSetValue[]
Parameter Sets: NewOptionSet
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Xrm.Sdk.Metadata.OptionSetMetadata

## NOTES

## RELATED LINKS

[Get-CrmOptionSet](Get-CrmOptionSet.md)

[New-CrmOptionSetValue](New-CrmOptionSetValue.md)

[Remove-CrmOptionSet](Remove-CrmOptionSet.md)

[Remove-CrmOptionSetValue](Remove-CrmOptionSetValue.md)

[Set-CrmOptionSet](Set-CrmOptionSet.md)

[Set-CrmOptionSetValue](Set-CrmOptionSetValue.md)

[OptionSetMetadata Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.metadata.optionsetmetadata.aspx)
