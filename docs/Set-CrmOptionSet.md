---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Set-CrmOptionSet.md
schema: 2.0.0
---

# Set-CrmOptionSet

## SYNOPSIS
Update a global optionset.

## SYNTAX

### SetOptionSetByInputObject (Default)
```
Set-CrmOptionSet [-InputObject] <OptionSetMetadata> [-PassThru] [<CommonParameters>]
```

### SetOptionSet
```
Set-CrmOptionSet [-Name] <String> [-DisplayName <String>] [-Description <String>] [-Customizable <Boolean>]
 [-PassThru] [<CommonParameters>]
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

### -InputObject
The updated OptionSetMetadata object for the optionset.

```yaml
Type: OptionSetMetadata
Parameter Sets: SetOptionSetByInputObject
Aliases: OptionSet

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
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

### -PassThru
Returns an object that represents the OptionSetMetadata. By default, this cmdlet does not generate any output.

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
