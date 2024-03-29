---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Test-CrmSolution.md
schema: 2.0.0
---

# Test-CrmSolution

## SYNOPSIS
Validate a customization solution.

## SYNTAX

### TestUninstallSolution
```
Test-CrmSolution [[-Solution] <Guid[]>] [-Uninstall] [<CommonParameters>]
```

### TestDependenciesSolution
```
Test-CrmSolution [[-Solution] <Guid[]>] [-Dependencies] [<CommonParameters>]
```

### TestMissingSolution
```
Test-CrmSolution [-LiteralPath] <String> [<CommonParameters>]
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
Type: System.Management.Automation.SwitchParameter
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
Type: System.String
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
Type: System.Guid[]
Parameter Sets: TestUninstallSolution, TestDependenciesSolution
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: TestUninstallSolution
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid[]

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[Export-CrmSolution](Export-CrmSolution.md)

[Get-CrmSolution](Get-CrmSolution.md)

[Import-CrmSolution](Import-CrmSolution.md)

[New-CrmSolution](New-CrmSolution.md)

[Use-CrmSolution](Use-CrmSolution.md)

[MissingComponent Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.missingcomponent)
