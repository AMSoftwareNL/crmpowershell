---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmPlugin.html
schema: 2.0.0
---

# Get-CrmPlugin

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### GetPluginByFilter (Default)
```
Get-CrmPlugin [[-PluginAssembly] <Guid>] [-Include <String>] [-Exclude <String>] [-IncludeTotalCount]
 [-Skip <UInt64>] [-First <UInt64>]
```

### GetPluginById
```
Get-CrmPlugin [-Id] <Guid> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
```

### GetPluginByName
```
Get-CrmPlugin [-Name] <String> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
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
Parameter Sets: GetPluginByFilter
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
Parameter Sets: GetPluginById
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
Parameter Sets: GetPluginByFilter
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
Parameter Sets: GetPluginByName
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PluginAssembly
{{Fill PluginAssembly Description}}

```yaml
Type: Guid
Parameter Sets: GetPluginByFilter
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
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

### System.Guid


## OUTPUTS

### Microsoft.Xrm.Sdk.Entity


## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/Get-CrmPlugin.html](http://crmpowershell.amsoftware.nl/Get-CrmPlugin.html)

