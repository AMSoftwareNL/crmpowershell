---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmDataProvider.md
schema: 2.0.0
---

# Get-CrmDataProvider

## SYNOPSIS
Get a registered data provider.

## SYNTAX

### GetDataProviderByFilter (Default)
```
Get-CrmDataProvider [[-Name] <String>] [-Exclude <String>] [-IncludeTotalCount] [-Skip <UInt64>]
 [-First <UInt64>] [<CommonParameters>]
```

### GetDataProviderById
```
Get-CrmDataProvider [-Id] <Guid[]> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

## DESCRIPTION
Get a registered data provider.

## EXAMPLES

## PARAMETERS

### -Exclude
Exclude data providers whose name matches the provided pattern.

```yaml
Type: System.String
Parameter Sets: GetDataProviderByFilter
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -Id
The id of the data provider to retrieve.

```yaml
Type: System.Guid[]
Parameter Sets: GetDataProviderById
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the data provider to retrieve.

```yaml
Type: System.String
Parameter Sets: GetDataProviderByFilter
Aliases: Include

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
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

[Get-CrmDataProvider](Get-CrmDataProvider.md)

