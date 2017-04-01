---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Test-CrmSolutionComponent.html
schema: 2.0.0
---

# Test-CrmSolutionComponent

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### TestDependenciesSolutionComponentEntity
```
Test-CrmSolutionComponent [[-SolutionComponent] <Entity>] [-Dependencies]
```

### TestDeleteSolutionComponentEntity
```
Test-CrmSolutionComponent [[-SolutionComponent] <Entity>] [-Delete]
```

### TestRequiredSolutionComponentEntity
```
Test-CrmSolutionComponent [[-SolutionComponent] <Entity>] [-Required]
```

### TestDeleteSolutionComponent
```
Test-CrmSolutionComponent [[-ObjectId] <Guid>] [[-ComponentType] <Int32>] [-Delete]
```

### TestDependenciesSolutionComponent
```
Test-CrmSolutionComponent [[-ObjectId] <Guid>] [[-ComponentType] <Int32>] [-Dependencies]
```

### TestRequiredSolutionComponent
```
Test-CrmSolutionComponent [[-ObjectId] <Guid>] [[-ComponentType] <Int32>] [-Required]
```

## DESCRIPTION
{{Fill in the Description}}

## EXAMPLES

### Example 1
```
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -ComponentType
{{Fill ComponentType Description}}

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
{{Fill Delete Description}}

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
{{Fill Dependencies Description}}

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
{{Fill ObjectId Description}}

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
{{Fill Required Description}}

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
{{Fill SolutionComponent Description}}

```yaml
Type: Entity
Parameter Sets: TestDependenciesSolutionComponentEntity, TestDeleteSolutionComponentEntity, TestRequiredSolutionComponentEntity
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

## INPUTS

### Microsoft.Xrm.Sdk.Entity
System.Guid


## OUTPUTS

### Microsoft.Xrm.Sdk.Entity


## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/Test-CrmSolutionComponent.html](http://crmpowershell.amsoftware.nl/Test-CrmSolutionComponent.html)

