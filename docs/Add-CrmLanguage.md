---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Add-CrmLanguage.html
schema: 2.0.0
---

# Add-CrmLanguage

## SYNOPSIS
Provision a language.

## SYNTAX

```
Add-CrmLanguage [-LocaleId] <Int32> [-Force] [-WhatIf] [-Confirm]
```

## DESCRIPTION
Provision a language.

## EXAMPLES

### Example 1
```
PS C:\> Add-CrmLanguage -LocaleId 1043
```

Provision the Dutch language.

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
The LCID of the language to provision.

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

[Get-CrmLanguage](Get-CrmLanguage.md)

[Remove-CrmLanguage](Remove-CrmLanguage.md)

[Use-CrmLanguage](Use-CrmLanguage.md)
