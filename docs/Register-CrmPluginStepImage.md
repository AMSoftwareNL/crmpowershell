---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Register-CrmPluginStepImage.html
schema: 2.0.0
---

# Register-CrmPluginStepImage

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

```
Register-CrmPluginStepImage [-PluginStep] <Guid> [-Name] <String> -Alias <String>
 -ImageType <CrmPluginStepImageType> [-MessagePropertyName <String>] [-Attributes <String[]>]
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

### -Alias
{{Fill Alias Description}}

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Attributes
{{Fill Attributes Description}}

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageType
{{Fill ImageType Description}}

```yaml
Type: CrmPluginStepImageType
Parameter Sets: (All)
Aliases: 
Accepted values: PreImage, PostImage, Both

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MessagePropertyName
{{Fill MessagePropertyName Description}}

```yaml
Type: String
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
Parameter Sets: (All)
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PluginStep
{{Fill PluginStep Description}}

```yaml
Type: Guid
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

## INPUTS

### System.Guid
System.String[]


## OUTPUTS

### Microsoft.Xrm.Sdk.Entity


## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/Register-CrmPluginStepImage.html](http://crmpowershell.amsoftware.nl/Register-CrmPluginStepImage.html)

