---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmSolution.md
schema: 2.0.0
---

# Get-CrmSolution

## SYNOPSIS
Get a customizations solution.

## SYNTAX

### GetAllSolutions (Default)
```
Get-CrmSolution [[-Name] <String>] [-Exclude <String>] [-ExcludeManaged] [-IncludeTotalCount] [-Skip <UInt64>]
 [-First <UInt64>] [<CommonParameters>]
```

### GetSolutionById
```
Get-CrmSolution [-Id] <Guid[]> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

## DESCRIPTION
Get a customizations solution.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmSolution -ExcludeManaged
```

Get all unmanaged customization solutions.

## PARAMETERS

### -Exclude
Exclude solutions whose name matches the provided pattern.

```yaml
Type: System.String
Parameter Sets: GetAllSolutions
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -ExcludeManaged
Exclude solutions marked as managed.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GetAllSolutions
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The id of the solution to retrieve.

```yaml
Type: System.Guid[]
Parameter Sets: GetSolutionById
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The unique name or friendly name of the solution to retrieve.

```yaml
Type: System.String
Parameter Sets: GetAllSolutions
Aliases: Include

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -IncludeTotalCount
Return the total count (and accuracy) of the number of records before returning the result.

Because of the limitations of Dynamics CRM, the total count is only returned accurate when the result is limited to 5000 items.

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
Skips (does not return) the specified number of records.

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
Specifies the number of records to retrieve from the beginning.

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

[Use-CrmSolution](Use-CrmSolution.md)

[New-CrmSolution](New-CrmSolution.md)

[Test-CrmSolution](Test-CrmSolution.md)

[Export-CrmSolution](Export-CrmSolution.md)

[Import-CrmSolution](Import-CrmSolution.md)

[Get-CrmSolutionComponent](Get-CrmSolutionComponent.md)

[Entity Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.entity)
