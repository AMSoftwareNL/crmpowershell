---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Test-CrmSolutionComponent.md
schema: 2.0.0
---

# Test-CrmSolutionComponent

## SYNOPSIS
Validate a component in a solution.

## SYNTAX

### TestDeleteSolutionComponentEntity
```
Test-CrmSolutionComponent [[-SolutionComponent] <Entity>] [-Delete] [<CommonParameters>]
```

### TestDependenciesSolutionComponentEntity
```
Test-CrmSolutionComponent [[-SolutionComponent] <Entity>] [-Dependencies] [<CommonParameters>]
```

### TestRequiredSolutionComponentEntity
```
Test-CrmSolutionComponent [[-SolutionComponent] <Entity>] [-Required] [<CommonParameters>]
```

### TestDeleteSolutionComponent
```
Test-CrmSolutionComponent [[-ObjectId] <Guid>] [[-ComponentType] <Int32>] [-Delete] [<CommonParameters>]
```

### TestDependenciesSolutionComponent
```
Test-CrmSolutionComponent [[-ObjectId] <Guid>] [[-ComponentType] <Int32>] [-Dependencies] [<CommonParameters>]
```

### TestRequiredSolutionComponent
```
Test-CrmSolutionComponent [[-ObjectId] <Guid>] [[-ComponentType] <Int32>] [-Required] [<CommonParameters>]
```

## DESCRIPTION
Validate a component in a solution.

The following validations can be applied:

 -- Retrieve a collection of dependency records that describe any solution components that would prevent a solution component from being deleted.
 
 -- Retrieves a list dependencies for solution components that directly depend on a solution component.
 
 -- Retrieve a collection of solution components that are required for a solution component.

## EXAMPLES

## PARAMETERS

### -ComponentType
The type of component to test. Matches a value from the global optionset 'Component Type'(componenttype).

```yaml
Type: Int32
Parameter Sets: TestDeleteSolutionComponent, TestDependenciesSolutionComponent, TestRequiredSolutionComponent
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Delete
Retrieve a collection of dependency records that describe any solution components that would prevent a solution component from being deleted.

```yaml
Type: SwitchParameter
Parameter Sets: TestDeleteSolutionComponentEntity, TestDeleteSolutionComponent
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Dependencies
Retrieves a list dependencies for solution components that directly depend on a solution component. 

```yaml
Type: SwitchParameter
Parameter Sets: TestDependenciesSolutionComponentEntity, TestDependenciesSolutionComponent
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ObjectId
The id of the object in the solution to test. 

This depends on the type of object represented by the solution copmponent. From metadata items the id is the Metadata Id, for other items it is the id of the record.

```yaml
Type: Guid
Parameter Sets: TestDeleteSolutionComponent, TestDependenciesSolutionComponent, TestRequiredSolutionComponent
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Required
Retrieve a collection of solution components that are required for a solution component.

```yaml
Type: SwitchParameter
Parameter Sets: TestRequiredSolutionComponentEntity, TestRequiredSolutionComponent
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SolutionComponent
A record from the solutioncomponent entity describing the solution component to validate.

```yaml
Type: Entity
Parameter Sets: TestDeleteSolutionComponentEntity, TestDependenciesSolutionComponentEntity, TestRequiredSolutionComponentEntity
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Xrm.Sdk.Entity
### System.Guid
## OUTPUTS

### Microsoft.Xrm.Sdk.Entity
## NOTES

## RELATED LINKS

[Add-CrmSolutionComponent](Add-CrmSolutionComponent.md)

[Get-CrmSolutionComponent](Get-CrmSolutionComponent.md)

[Remove-CrmSolutionComponent](Remove-CrmSolutionComponent.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
