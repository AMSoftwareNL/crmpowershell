---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmPlugin.md
schema: 2.0.0
---

# Get-CrmPlugin

## SYNOPSIS
Get a plugin.

## SYNTAX

### GetPluginByFilter (Default)
```
Get-CrmPlugin [[-PluginAssembly] <Guid>] [[-Name] <String>] [-Exclude <String>] [-IncludeTotalCount]
 [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

### GetPluginById
```
Get-CrmPlugin -Id <Guid> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

## DESCRIPTION
Get a plugin.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmPlugin -Include 'amsoftware.*'
```

Get the plugins starting with 'amsoftware.'

## PARAMETERS

### -Exclude
Exclude plugins whose name matches the provided pattern.

```yaml
Type: System.String
Parameter Sets: GetPluginByFilter
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -Id
The id of the plugin to retrieve.

```yaml
Type: System.Guid
Parameter Sets: GetPluginById
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the plugin to retrieve.

```yaml
Type: System.String
Parameter Sets: GetPluginByFilter
Aliases: Include

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -PluginAssembly
The id of the assembly containing to plugins to retrieve.

```yaml
Type: System.Guid
Parameter Sets: GetPluginByFilter
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
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

### System.Guid

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[Register-CrmPlugin](Register-CrmPlugin.md)

[Set-CrmPlugin](Set-CrmPlugin.md)

[Unregister-CrmPlugin](Unregister-CrmPlugin.md)

[Entity Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.entity)
