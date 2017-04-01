---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Publish-CrmComponent.html
schema: 2.0.0
---

# Publish-CrmComponent

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### PublishSolution (Default)
```
Publish-CrmComponent -Solution <Guid>
```

### PublishAll
```
Publish-CrmComponent [-All]
```

### PublishComponents
```
Publish-CrmComponent [-Entities <String[]>] [-Webresources <Guid[]>] [-Optionsets <String[]>]
 [-Dashboards <Guid[]>] [-PublishRibbon] [-PublishSiteMap]
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

### -All
{{Fill All Description}}

```yaml
Type: SwitchParameter
Parameter Sets: PublishAll
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Dashboards
{{Fill Dashboards Description}}

```yaml
Type: Guid[]
Parameter Sets: PublishComponents
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entities
{{Fill Entities Description}}

```yaml
Type: String[]
Parameter Sets: PublishComponents
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Optionsets
{{Fill Optionsets Description}}

```yaml
Type: String[]
Parameter Sets: PublishComponents
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublishRibbon
{{Fill PublishRibbon Description}}

```yaml
Type: SwitchParameter
Parameter Sets: PublishComponents
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublishSiteMap
{{Fill PublishSiteMap Description}}

```yaml
Type: SwitchParameter
Parameter Sets: PublishComponents
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Solution
{{Fill Solution Description}}

```yaml
Type: Guid
Parameter Sets: PublishSolution
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Webresources
{{Fill Webresources Description}}

```yaml
Type: Guid[]
Parameter Sets: PublishComponents
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

### System.Object

## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/Publish-CrmComponent.html](http://crmpowershell.amsoftware.nl/Publish-CrmComponent.html)

