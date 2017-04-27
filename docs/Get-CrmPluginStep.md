---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmPluginStep.html
schema: 2.0.0
---

# Get-CrmPluginStep

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### GetPluginStepByFilter (Default)
```
Get-CrmPluginStep [[-EventSource] <Guid>] [-Message <String>] [-Entity <String>] [-Stage <CrmPluginStepStage>]
 [-Mode <CrmPluginStepMode>] [-IncludeInternalStages] [-IncludeHidden] [-IncludeTotalCount] [-Skip <UInt64>]
 [-First <UInt64>]
```

### GetPluginStepById
```
Get-CrmPluginStep [-Id] <Guid> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
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

### -Entity
{{Fill Entity Description}}

```yaml
Type: String
Parameter Sets: GetPluginStepByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventSource
{{Fill EventSource Description}}

```yaml
Type: Guid
Parameter Sets: GetPluginStepByFilter
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
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
Parameter Sets: GetPluginStepById
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeHidden
{{Fill IncludeHidden Description}}

```yaml
Type: SwitchParameter
Parameter Sets: GetPluginStepByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeInternalStages
{{Fill IncludeInternalStages Description}}

```yaml
Type: SwitchParameter
Parameter Sets: GetPluginStepByFilter
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

### -Message
{{Fill Message Description}}

```yaml
Type: String
Parameter Sets: GetPluginStepByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Mode
{{Fill Mode Description}}

```yaml
Type: CrmPluginStepMode
Parameter Sets: GetPluginStepByFilter
Aliases: 
Accepted values: Synchronous, Asynchronous

Required: False
Position: Named
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

### -Stage
{{Fill Stage Description}}

```yaml
Type: CrmPluginStepStage
Parameter Sets: GetPluginStepByFilter
Aliases: 
Accepted values: PreValidation, PreOperation, PostOperation

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

[http://crmpowershell.amsoftware.nl/Get-CrmPluginStep.html](http://crmpowershell.amsoftware.nl/Get-CrmPluginStep.html)

