---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/New-CrmOptionSetValue.html
schema: 2.0.0
---

# New-CrmOptionSetValue

## SYNOPSIS
Create a new OptionSetValue to use with optionsets.

## SYNTAX

```
New-CrmOptionSetValue [-DisplayName] <String> [[-Value] <Int32>] [[-Description] <String>] [<CommonParameters>]
```

## DESCRIPTION
Create a new OptionSetValue to use with optionsets.

## EXAMPLES

## PARAMETERS

### -Description
The description for the optionset value.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
The displayname for the optionset value.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
The value for the optionset value.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### AMSoftware.Crm.PowerShell.Commands.Models.PSOptionSetValue

## NOTES

## RELATED LINKS

[Add-CrmOptionSetAttribute](Add-CrmOptionSetAttribute.md)

[Get-CrmOptionSet](Get-CrmOptionSet.md)

[New-CrmOptionSet](New-CrmOptionSet.md)

[Remove-CrmOptionSet](Remove-CrmOptionSet.md)

[Remove-CrmOptionSetValue](Remove-CrmOptionSetValue.md)

[Set-CrmOptionSet](Set-CrmOptionSet.md)

[Set-CrmOptionSetAttribute](Set-CrmOptionSetAttribute.md)

[Set-CrmOptionSetValue](Set-CrmOptionSetValue.md)
