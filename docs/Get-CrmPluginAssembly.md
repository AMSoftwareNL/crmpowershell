---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmPluginAssembly.html
schema: 2.0.0
---

# Get-CrmPluginAssembly

## SYNOPSIS
Get plugin assembly.

## SYNTAX

### GetAssemblyByFilter (Default)
```
Get-CrmPluginAssembly [-Include <String>] [-Exclude <String>] [-ExcludeManaged] [-IncludeHidden]
 [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
```

### GetAssemblyById
```
Get-CrmPluginAssembly [-Id] <Guid> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
```

### GetAssemblyByName
```
Get-CrmPluginAssembly [-Name] <String> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
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
Accept wildcard characters: True
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
Type: Guid
Parameter Sets: GetAssemblyById
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Include
Include assemblies whose name matches the provided pattern.

```yaml
Type: String
Parameter Sets: GetAssemblyByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
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
Parameter Sets: GetAssemblyByName
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

[Get-CrmPlugin](Get-CrmPlugin.md)

[Register-CrmPlugin](Register-CrmPlugin.md)

[Unregister-CrmPlugin](Unregister-CrmPlugin.md)

[Unregister-CrmPluginAssembly](Unregister-CrmPluginAssembly.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
