---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmPublisher.md
schema: 2.0.0
---

# Get-CrmPublisher

## SYNOPSIS
Get a publisher for customizations.

## SYNTAX

### GetAllPublishers (Default)
```
Get-CrmPublisher [[-Name] <String>] [-Exclude <String>] [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
 [<CommonParameters>]
```

### GetPublisherById
```
Get-CrmPublisher [-Id] <Guid[]> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

## DESCRIPTION
Get a publisher for customizations.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmPublisher -Include 'AMSoftware'
```

Get publisher with the name 'AMSoftware'.

## PARAMETERS

### -Exclude
Exclude publishers whose name matches the provided pattern.

```yaml
Type: System.String
Parameter Sets: GetAllPublishers
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -Id
The id of the publisher to retrieve.

```yaml
Type: System.Guid[]
Parameter Sets: GetPublisherById
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Include publishers whose name matches the provided pattern.

```yaml
Type: System.String
Parameter Sets: GetAllPublishers
Aliases: Include

Required: False
Position: 1
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

[New-CrmPublisher](New-CrmPublisher.md)

[Entity Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.entity)
