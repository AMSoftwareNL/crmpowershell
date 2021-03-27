---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmPluginAssembly.md
schema: 2.0.0
---

# Get-CrmPluginAssembly

## SYNOPSIS
Get plugin assembly.

## SYNTAX

### GetAssemblyByFilter (Default)
```
Get-CrmPluginAssembly [[-Name] <String>] [-Exclude <String>] [-ExcludeManaged] [-IncludeHidden]
 [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

### GetAssemblyById
```
Get-CrmPluginAssembly [-Id] <Guid[]> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
 [<CommonParameters>]
```

## DESCRIPTION
Get plugin assembly.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmPluginAssembly -ExcludeManaged
```

Get registered plugin assemblies, excluding assemblies marked as managed.

## PARAMETERS

### -Exclude
Exclude assemblies whose name matches the provided pattern.

```yaml
Type: String
Parameter Sets: GetAssemblyByFilter
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExcludeManaged
Exclude assemblies marked as managed.

```yaml
Type: SwitchParameter
Parameter Sets: GetAssemblyByFilter
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
The id of the assembly to retrieve.

```yaml
Type: Guid[]
Parameter Sets: GetAssemblyById
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IncludeHidden
Include assemblies marked as hidden.

```yaml
Type: SwitchParameter
Parameter Sets: GetAssemblyByFilter
Aliases:

Required: False
Position: Named
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
The name of the assembly to retrieve.

```yaml
Type: String
Parameter Sets: GetAssemblyByFilter
Aliases: Include

Required: False
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid[]
## OUTPUTS

### Microsoft.Xrm.Sdk.Entity
## NOTES

## RELATED LINKS

[Get-CrmPlugin](Get-CrmPlugin.md)

[Register-CrmPlugin](Register-CrmPlugin.md)

[Unregister-CrmPlugin](Unregister-CrmPlugin.md)

[Unregister-CrmPluginAssembly](Unregister-CrmPluginAssembly.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
