---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/New-CrmOptionSet.md
schema: 2.0.0
---

# New-CrmOptionSet

## SYNOPSIS
Add a new global optionset.

## SYNTAX

### NewOptionSetByInputObject (Default)
```
New-CrmOptionSet [-InputObject] <OptionSetMetadata> [-PassThru] [<CommonParameters>]
```

### NewOptionSet
```
New-CrmOptionSet [-Name] <String> [-DisplayName] <String> -Values <PSOptionSetValue[]> [-Description <String>]
 [-Customizable <Boolean>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Add a new global optionset.

## EXAMPLES

## PARAMETERS

### -Customizable
Whether the optionset is customizable.

```yaml
Type: System.Boolean
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
Type: System.String
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
Type: System.String
Parameter Sets: NewOptionSet
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The OptionSetMetadata object for the new optionset.

```yaml
Type: Microsoft.Xrm.Sdk.Metadata.OptionSetMetadata
Parameter Sets: NewOptionSetByInputObject
Aliases: OptionSet

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name for the optionset.

```yaml
Type: System.String
Parameter Sets: NewOptionSet
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Values
The OptionSetValues for the new optionset.

```yaml
Type: AMSoftware.Crm.PowerShell.Commands.Models.PSOptionSetValue[]
Parameter Sets: NewOptionSet
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

### Microsoft.Xrm.Sdk.Metadata.OptionSetMetadata

### AMSoftware.Crm.PowerShell.Commands.Models.PSOptionSetValue[]

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

[OptionSetMetadata Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.metadata.optionsetmetadata)
