---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Set-CrmOptionSet.html
schema: 2.0.0
---

# Set-CrmOptionSet

## SYNOPSIS
Update a global optionset.

## SYNTAX

### SetOptionSetByInputObject
```
Set-CrmOptionSet [-OptionSet] <OptionSetMetadata> [<CommonParameters>]
```

### SetOptionSet
```
Set-CrmOptionSet [-Name] <String> [-DisplayName <String>] [-Description <String>] [-Customizable <Boolean>]
 [<CommonParameters>]
```

## DESCRIPTION
Update a global optionset.

## EXAMPLES

## PARAMETERS

### -Customizable
Whether the optionset is customizable. 

```yaml
Type: Boolean
Parameter Sets: SetOptionSet
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
Parameter Sets: SetOptionSet
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
Parameter Sets: SetOptionSet
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the optionset to update.

```yaml
Type: String
Parameter Sets: SetOptionSet
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionSet
The updated OptionSetMetadata object for the optionset.

```yaml
Type: OptionSetMetadata
Parameter Sets: SetOptionSetByInputObject
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### None

## NOTES

## RELATED LINKS

[Get-CrmOptionSet](Get-CrmOptionSet.md)

[New-CrmOptionSet](New-CrmOptionSet.md)

[New-CrmOptionSetValue](New-CrmOptionSetValue.md)

[Remove-CrmOptionSet](Remove-CrmOptionSet.md)

[Remove-CrmOptionSetValue](Remove-CrmOptionSetValue.md)

[Set-CrmOptionSetValue](Set-CrmOptionSetValue.md)

[OptionSetMetadata Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.metadata.optionsetmetadata.aspx)
