---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Remove-CrmRelationship.md
schema: 2.0.0
---

# Remove-CrmRelationship

## SYNOPSIS
Remove a relationship.

## SYNTAX

### RemoveRelationshipByName
```
Remove-CrmRelationship [-Name] <String> [-Force] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RemoveRelationshipByEntity
```
Remove-CrmRelationship [-Entity] <String> [-FromEntity] <String> [-Attribute <String>] [-Force] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Remove a relationship.

## EXAMPLES

## PARAMETERS

### -Attribute
The LogicalName of the attribute on the entity to remove the lookup from.

This is only required if the relationship cannot be uniquely determined for both entities.

```yaml
Type: String
Parameter Sets: RemoveRelationshipByEntity
Aliases:

Required: False
Position: Named
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

### -Entity
The LogicalName of the entity to remove to relationship for.

```yaml
Type: String
Parameter Sets: RemoveRelationshipByEntity
Aliases: EntityLogicalName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -FromEntity
The LogicalName of the entity to remove the relationship from.

```yaml
Type: String
Parameter Sets: RemoveRelationshipByEntity
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The SchemaName of the relationship to remove.

```yaml
Type: String
Parameter Sets: RemoveRelationshipByName
Aliases: SchemaName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### System.String
## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[Add-CrmRelationship](Add-CrmRelationship.md)

[Get-CrmRelationship](Get-CrmRelationship.md)

[Set-CrmRelationship](Set-CrmRelationship.md)
