---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Remove-CrmEntityKey.html
schema: 2.0.0
---

# Remove-CrmEntityKey

## SYNOPSIS
Remove a key from an entity.

## SYNTAX

```
Remove-CrmEntityKey [-Entity] <String> [-Name] <String> [-Force] [-WhatIf] [-Confirm]
```

## DESCRIPTION
Remove a key from an entity.

## EXAMPLES


## PARAMETERS

### -Entity
The LogicalName of the entity to remove the key from.

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

### -Name
The LogicalName of the key to remove.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 2
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

[Add-CrmEntityKey](Add-CrmEntityKey.md)

[Get-CrmEntityKey](Get-CrmEntityKey.md)
