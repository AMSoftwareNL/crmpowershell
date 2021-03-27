---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmWebresource.md
schema: 2.0.0
---

# Get-CrmWebresource

## SYNOPSIS
Get a webresource.

## SYNTAX

### GetAllWebresources (Default)
```
Get-CrmWebresource [[-Name] <String>] [-Exclude <String>] [-WebresourceType <CrmWebresourceType>]
 [-ExcludeManaged] [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

### GetWebresourceById
```
Get-CrmWebresource [-Id] <Guid[]> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

## DESCRIPTION
Get a webresource.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmWebresource -WebresourceType JS
```

Get all JavaScript webresources.

## PARAMETERS

### -Exclude
Exclude web resources whose name matches the provided pattern.

```yaml
Type: String
Parameter Sets: GetAllWebresources
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExcludeManaged
Exclude webresources marked as managed.

```yaml
Type: SwitchParameter
Parameter Sets: GetAllWebresources
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
The id of the webresource to retrieve.

```yaml
Type: Guid[]
Parameter Sets: GetWebresourceById
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
The name of the webresource to retrieve.

```yaml
Type: String
Parameter Sets: GetAllWebresources
Aliases: Include

Required: False
Position: 0
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

### -WebresourceType
The type of webresource to retrieve. If not provided all types are returned.

```yaml
Type: CrmWebresourceType
Parameter Sets: GetAllWebresources
Aliases:
Accepted values: All, HTML, CSS, JS, XML, PNG, JPG, GIF, XAP, XSL, ICO

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

[Export-CrmWebresource](Export-CrmWebresource.md)

[Import-CrmWebresource](Import-CrmWebresource.md)

[New-CrmWebresource](New-CrmWebresource.md)

[Remove-CrmWebresource](Remove-CrmWebresource.md)

[Set-CrmWebresource](Set-CrmWebresource.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
