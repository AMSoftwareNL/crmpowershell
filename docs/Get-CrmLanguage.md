---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmLanguage.md
schema: 2.0.0
---

# Get-CrmLanguage

## SYNOPSIS
Get the language of the connected organization.

## SYNTAX

```
Get-CrmLanguage [-All] [-ListAvailable] [<CommonParameters>]
```

## DESCRIPTION
Get the language of the connected organization. This is based on the installation language, and available language packs.

If no parameters are provided the enabled languages are returned.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmLanguage -All
```

Get all enabled and disabled languages.

## PARAMETERS

### -All
Get all enabled and disabled languages.

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

### -ListAvailable
Get all languages that are available but not enabled.

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

### System.Globalization.CultureInfo

## NOTES

## RELATED LINKS

[Use-CrmLanguage](Use-CrmLanguage.md)

[Add-CrmLanguage](Add-CrmLanguage.md)

[Remove-CrmLanguage](Remove-CrmLanguage.md)

