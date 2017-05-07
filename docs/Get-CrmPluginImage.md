---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmPluginImage.html
schema: 2.0.0
---

# Get-CrmPluginImage

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### GetPluginIMageByFilter (Default)
```
Get-CrmPluginImage [[-PluginStep] <Guid>] [-ImageType <CrmPluginImageType>] [-IncludeTotalCount]
 [-Skip <UInt64>] [-First <UInt64>]
```

### GetPluginImageById
```
Get-CrmPluginImage [-Id] <Guid> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
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
Parameter Sets: GetPluginImageById
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageType
{{Fill ImageType Description}}

```yaml
Type: CrmPluginImageType
Parameter Sets: GetPluginIMageByFilter
Aliases: 
Accepted values: PreImage, PostImage

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

### -PluginStep
{{Fill PluginStep Description}}

```yaml
Type: Guid
Parameter Sets: GetPluginIMageByFilter
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

[http://crmpowershell.amsoftware.nl/Get-CrmPluginImage.html](http://crmpowershell.amsoftware.nl/Get-CrmPluginImage.html)

