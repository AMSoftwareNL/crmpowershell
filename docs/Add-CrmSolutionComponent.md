---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Add-CrmSolutionComponent.md
schema: 2.0.0
---

# Add-CrmSolutionComponent

## SYNOPSIS
Add a component to a customization solution.

## SYNTAX

```
Add-CrmSolutionComponent [-Solution] <Guid> [-Type] <String> [-ComponentId] <Guid> [-IncludeRequired]
 [<CommonParameters>]
```

## DESCRIPTION
Add a component to a customization solution.

## EXAMPLES

## PARAMETERS

### -ComponentId
The id of the component to add.

```yaml
Type: Guid
Parameter Sets: (All)
Aliases: ObjectId

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeRequired
Whether other solution components that are required by the solution component that you are adding should also be added to the unmanaged solution.

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

### -Solution
The id of the solution to add the component to.

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

### -Type
The type of component to add.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid
## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[Get-CrmSolution](Get-CrmSolution.md)

[Get-CrmSolutionComponent](Get-CrmSolutionComponent.md)

[Remove-CrmSolutionComponent](Remove-CrmSolutionComponent.md)

[Test-CrmSolutionComponent](Test-CrmSolutionComponent.md)
