---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Test-CrmSolution.html
schema: 2.0.0
---

# Test-CrmSolution

## SYNOPSIS
Validate a customization solution.

## SYNTAX

### TestDependenciesSolution
```
Test-CrmSolution [[-Solution] <Guid>] [-Dependencies]
```

### TestUninstallSolution
```
Test-CrmSolution [[-Solution] <Guid>] [-Uninstall]
```

### TestMissingSolution
```
Test-CrmSolution [-LiteralPath] <String>
```

## DESCRIPTION
Validate a customization solution. 
The following validations can be executed:

 -- Retrieve a list of missing components in the target organization.
 
 -- Retrieve any required solution components that are not included in the solution.
 
 -- Retrieve a list of the solution component dependencies that can prevent you from uninstalling a managed solution.

## EXAMPLES

### Example 1
```
PS C:\> Test-CrmSolution -Solution '' -Dependencies
```

Retrieve any required solution components that are not included in the solution.

### Example 2
```
PS C:\> Test-CrmSolution -Solution '' -Uninstall
```

Retrieve a list of the solution component dependencies that can prevent you from uninstalling a managed solution.

### Example 3
```
PS C:\> Test-CrmSolution -LiteralPath 'c:\temp\product1.zip'
```

Retrieve a list of missing components in the target organization.


## PARAMETERS

### -Dependencies
Retrieve any required solution components that are not included in the solution.

```yaml
Type: SwitchParameter
Parameter Sets: TestDependenciesSolution
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LiteralPath
The path to the solution file to test against the organization.

```yaml
Type: String
Parameter Sets: TestMissingSolution
Aliases: PSPath, Path

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Solution
The id of the solution to test.

```yaml
Type: Guid
Parameter Sets: TestDependenciesSolution, TestUninstallSolution
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Uninstall
Retrieve a list of the solution component dependencies that can prevent you from uninstalling a managed solution.

```yaml
Type: SwitchParameter
Parameter Sets: TestUninstallSolution
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### System.Guid


## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

[Export-CrmSolution](Export-CrmSolution.md)

[Get-CrmSolution](Get-CrmSolution.md)

[Import-CrmSolution](Import-CrmSolution.md)

[New-CrmSolution](New-CrmSolution.md)

[Use-CrmSolution](Use-CrmSolution.md)

[MissingComponent Class](https://msdn.microsoft.com/library/microsoft.crm.sdk.messages.missingcomponent.aspx)
