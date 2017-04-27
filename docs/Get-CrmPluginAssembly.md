---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmPluginAssembly.html
schema: 2.0.0
---

# Get-CrmPluginAssembly

## SYNOPSIS
{{Fill in the Synopsis}}

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
{{Fill in the Description}}

## EXAMPLES

### Example 1
```
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Exclude
{{Fill Exclude Description}}

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
{{Fill ExcludeManaged Description}}

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
{{Fill First Description}}

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
{{Fill Id Description}}

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
{{Fill Include Description}}

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

### -IncludeHidden
{{Fill IncludeHidden Description}}

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
{{Fill IncludeTotalCount Description}}

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
{{Fill Name Description}}

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
{{Fill Skip Description}}

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

[http://crmpowershell.amsoftware.nl/Get-CrmPluginAssembly.html](http://crmpowershell.amsoftware.nl/Get-CrmPluginAssembly.html)

