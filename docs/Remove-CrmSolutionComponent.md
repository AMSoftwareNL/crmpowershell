---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Remove-CrmSolutionComponent.md
schema: 2.0.0
---

# Remove-CrmSolutionComponent

## SYNOPSIS
Remove a component from a customization solution.

## SYNTAX

```
Remove-CrmSolutionComponent [-Solution] <Guid> [-Type] <String> [-ComponentId] <Guid> [<CommonParameters>]
```

## DESCRIPTION
Remove a component from a customization solution.

## EXAMPLES

## PARAMETERS

### -ComponentId
The id of the component to remove.

This can be the MetadataId or the id of the record.

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases: ObjectId

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Solution
The id of the solution to remove the component from.

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Type
The type of component to remove.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ComponentType

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[Add-CrmSolutionComponent](Add-CrmSolutionComponent.md)

[Get-CrmSolutionComponent](Get-CrmSolutionComponent.md)

[Test-CrmSolutionComponent](Test-CrmSolutionComponent.md)
