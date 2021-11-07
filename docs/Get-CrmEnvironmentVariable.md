---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmEnvironmentVariable.md
schema: 2.0.0
---

# Get-CrmEnvironmentVariable

## SYNOPSIS
Get an environment variable

## SYNTAX

### GetAllEnvironmentVariables (Default)
```
Get-CrmEnvironmentVariable [[-Name] <String>] [-Exclude <String>] [-VariableType <CrmEnvironmentVariableType>]
 [-SolutionId <Guid>] [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

### GetEnvironmentVariableById
```
Get-CrmEnvironmentVariable [-Id] <Guid[]> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
 [<CommonParameters>]
```

## DESCRIPTION
Get an environment variable

## EXAMPLES

## PARAMETERS

### -Exclude
Exclude environments variables whose name matches the provided pattern.

```yaml
Type: System.String
Parameter Sets: GetAllEnvironmentVariables
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -Id
The id of the environment variable to retrieve.

```yaml
Type: System.Guid[]
Parameter Sets: GetEnvironmentVariableById
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the environment variable to retrieve.

```yaml
Type: System.String
Parameter Sets: GetAllEnvironmentVariables
Aliases: Include

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -SolutionId
Return environment variables included in the solution

```yaml
Type: System.Guid
Parameter Sets: GetAllEnvironmentVariables
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VariableType
The value type of the environment variable to retrieve

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmEnvironmentVariableType
Parameter Sets: GetAllEnvironmentVariables
Aliases:
Accepted values: All, String, Number, Boolean, JSON, DataSource

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeTotalCount
Reports the total number of objects in the data set (an integer) followed by the selected objects.
If the cmdlet cannot determine the total count, it displays "Unknown total count." The integer has an Accuracy property that indicates the reliability of the total count value.
The value of Accuracy ranges from 0.0 to 1.0 where 0.0 means that the cmdlet could not count the objects, 1.0 means that the count is exact, and a value between 0.0 and 1.0 indicates an increasingly reliable estimate.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Ignores the specified number of objects and then gets the remaining objects.
Enter the number of objects to skip.

```yaml
Type: System.UInt64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -First
Gets only the specified number of objects.
Enter the number of objects to get.

```yaml
Type: System.UInt64
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[Get-CrmEnvironmentVariable](Get-CrmEnvironmentVariable.md)

