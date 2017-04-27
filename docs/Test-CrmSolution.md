---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Test-CrmSolution.html
schema: 2.0.0
---

# Test-CrmSolution

## SYNOPSIS
{{Fill in the Synopsis}}

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
{{Fill in the Description}}

## EXAMPLES

### Example 1
```
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Dependencies
{{Fill Dependencies Description}}

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
{{Fill LiteralPath Description}}

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
{{Fill Solution Description}}

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
{{Fill Uninstall Description}}

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

[http://crmpowershell.amsoftware.nl/Test-CrmSolution.html](http://crmpowershell.amsoftware.nl/Test-CrmSolution.html)

