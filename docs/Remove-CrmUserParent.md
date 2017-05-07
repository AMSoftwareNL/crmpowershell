---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Remove-CrmUserParent.html
schema: 2.0.0
---

# Remove-CrmUserParent

## SYNOPSIS
Remove the parent for a system user (user) record.

## SYNTAX

```
Remove-CrmUserParent [-User] <Guid> [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Remove the parent for a system user (user) record.

## EXAMPLES

## PARAMETERS

### -User
The id of the user to remove the parent for.

```yaml
Type: Guid
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
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

### System.Guid

## OUTPUTS

### None

## NOTES

## RELATED LINKS

[Get-CrmUser](Get-CrmUser.md)

[New-CrmUser](New-CrmUser.md)
