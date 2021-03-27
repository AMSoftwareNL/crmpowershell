---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Remove-CrmContent.md
schema: 2.0.0
---

# Remove-CrmContent

## SYNOPSIS
Remove a data record from an entity.

## SYNTAX

### RemoveContentByInputObject (Default)
```
Remove-CrmContent [-InputObject] <Entity[]> [-Force] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RemoveContent
```
Remove-CrmContent [-Entity] <String> [-Id] <Guid[]> [-Force] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Remove a data record from an entity.

## EXAMPLES

## PARAMETERS

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

### -Entity
The LogicalName of the entity to remove the record from.

```yaml
Type: String
Parameter Sets: RemoveContent
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

### -Id
The id of the data record to remove.

```yaml
Type: Guid[]
Parameter Sets: RemoveContent
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
The entity object representing the record to remove.

```yaml
Type: Entity[]
Parameter Sets: RemoveContentByInputObject
Aliases: Record

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Xrm.Sdk.Entity[]

### System.Guid[]

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[Add-CrmContent](Add-CrmContent.md)

[Get-CrmContent](Get-CrmContent.md)

[Join-CrmContent](Join-CrmContent.md)

[Set-CrmContent](Set-CrmContent.md)

[Split-CrmContent](Split-CrmContent.md)
