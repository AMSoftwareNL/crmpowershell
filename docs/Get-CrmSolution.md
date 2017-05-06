---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmSolution.html
schema: 2.0.0
---

# Get-CrmSolution

## SYNOPSIS
Get a customizations solution.

## SYNTAX

### GetSolution (Default)
```
Get-CrmSolution [-ExcludeManaged] [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
```

### GetSolutionByName
```
Get-CrmSolution [-Name] <String> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
```

### GetSolutionById
```
Get-CrmSolution [-Id] <Guid> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
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

### -ExcludeManaged
Exclude solutions marked as managed.

```yaml
Type: SwitchParameter
Parameter Sets: GetSolution
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
Type: UInt64
Parameter Sets: (All)
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
Type: Guid
Parameter Sets: GetSolutionById
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeTotalCount
Return the total count (and accuracy) of the number of records before returning the result.

Because of the limitations of Dynamics CRM, the total count is only returned accurate when the result is limited to 5000 items.

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

### -Name
The unique name or friendly name of the solution to retrieve.

```yaml
Type: String
Parameter Sets: GetSolutionByName
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Skips (does not return) the specified number of records.

```yaml
Type: UInt64
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### None


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

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
