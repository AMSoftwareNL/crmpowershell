---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Remove-CrmLanguage.html
schema: 2.0.0
---

# Remove-CrmLanguage

## SYNOPSIS
Deprovision a language.

## SYNTAX

```
Remove-CrmLanguage [-LocaleId] <Int32> [-Force] [-WhatIf] [-Confirm]
```

## DESCRIPTION
Deprovision a language.

## EXAMPLES


## PARAMETERS

### -Force
Executes the action without prompting for confirmation.

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

### -LocaleId
The LCID of the language to deprovision.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### None


## OUTPUTS

### None

## NOTES

## RELATED LINKS

[Add-CrmLanguage](Add-CrmLanguage.md)

[Get-CrmLanguage](Get-CrmLanguage.md)

[Use-CrmLanguage](Use-CrmLanguage.md)
