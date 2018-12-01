---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmBusinessUnit.md
schema: 2.0.0
---

# Get-CrmBusinessUnit

## SYNOPSIS
Get a Business Unit.

## SYNTAX

### GetAllBusinessUnits (Default)
```
Get-CrmBusinessUnit [[-Name] <String>] [-Exclude <String>] [-Parent <Guid>] [-IncludeTotalCount]
 [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

### GetBusinessUnitById
```
Get-CrmBusinessUnit [-Id] <Guid[]> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

## DESCRIPTION
Get a Business Unit from the connected organization.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmBusinessUnit -Include 'amsoftwarecrm' | Get-CrmBusinessUnit
```

Get the business units which are children of the business unit 'amsoftwarecrm'.

## PARAMETERS

### -Exclude
Exclude business units whose name matches the provided pattern.

```yaml
Type: String
Parameter Sets: GetAllBusinessUnits
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -First
Specifies the number of objects to select from the beginning.

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
The id of the business unit.

```yaml
Type: Guid[]
Parameter Sets: GetBusinessUnitById
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
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
Include business units whose name matches the provided pattern.

```yaml
Type: String
Parameter Sets: GetAllBusinessUnits
Aliases: Include

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parent
The id of the parent business unit. When included only direct children of this business unit are returned.

```yaml
Type: Guid
Parameter Sets: GetAllBusinessUnits
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
Type: UInt64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid
## OUTPUTS

### Microsoft.Xrm.Sdk.Entity
## NOTES

## RELATED LINKS

[New-CrmBusinessUnit](New-CrmBusinessUnit.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
