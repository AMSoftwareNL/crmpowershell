---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Remove-CrmOptionSetValue.html
schema: 2.0.0
---

# Remove-CrmOptionSetValue

## SYNOPSIS
Remove a value from a global optionset or picklist attribute.

## SYNTAX

### RemoveOptionSetValueGlobal (Default)
```
Remove-CrmOptionSetValue [-OptionSet] <String> [-Value] <Int32> [-Force] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RemoveOptionSetValueEntity
```
Remove-CrmOptionSetValue [-Entity] <String> [-Attribute] <String> [-Value] <Int32> [-Force] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Remove a value from a global optionset or picklist attribute.

## EXAMPLES

## PARAMETERS

### -Attribute
The LogicalName of the picklist attribute to remove the value from.

```yaml
Type: String
Parameter Sets: RemoveOptionSetValueEntity
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entity
The LogicalName of the entity containing the picklist attribute.

```yaml
Type: String
Parameter Sets: RemoveOptionSetValueEntity
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

### -OptionSet
The name of the global optionset the remove the value from.

```yaml
Type: String
Parameter Sets: RemoveOptionSetValueGlobal
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
The number representing the value to remove.

```yaml
Type: Int32
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### None

## NOTES

## RELATED LINKS

[New-CrmOptionSetValue](New-CrmOptionSetValue.md)

[Set-CrmOptionSetValue](Set-CrmOptionSetValue.md)
