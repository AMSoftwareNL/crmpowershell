---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmAttribute.html
schema: 2.0.0
---

# Get-CrmAttribute

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### GetAttributesByFilter (Default)
```
Get-CrmAttribute [-Entity] <String> [-Include <String>] [-Exclude <String>] [-CustomOnly] [-ExcludeManaged]
 [-IncludeLinked] [-AttributeType <String>]
```

### GetAttributeById
```
Get-CrmAttribute [-Id] <Guid>
```

### GetAttributeByName
```
Get-CrmAttribute [-Entity] <String> [-Name] <String>
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

### -AttributeType
{{Fill AttributeType Description}}

```yaml
Type: String
Parameter Sets: GetAttributesByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomOnly
{{Fill CustomOnly Description}}

```yaml
Type: SwitchParameter
Parameter Sets: GetAttributesByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entity
{{Fill Entity Description}}

```yaml
Type: String
Parameter Sets: GetAttributesByFilter, GetAttributeByName
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Exclude
{{Fill Exclude Description}}

```yaml
Type: String
Parameter Sets: GetAttributesByFilter
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
Parameter Sets: GetAttributesByFilter
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
Parameter Sets: GetAttributeById
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
Parameter Sets: GetAttributesByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeLinked
{{Fill IncludeLinked Description}}

```yaml
Type: SwitchParameter
Parameter Sets: GetAttributesByFilter
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
Parameter Sets: GetAttributeByName
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### None


## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/Get-CrmAttribute.html](http://crmpowershell.amsoftware.nl/Get-CrmAttribute.html)

