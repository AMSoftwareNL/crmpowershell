---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmEntity.html
schema: 2.0.0
---

# Get-CrmEntity

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### GetEntitiesByFilter (Default)
```
Get-CrmEntity [-Include <String>] [-Exclude <String>] [-CustomOnly] [-ExcludeManaged] [-IncludeIntersects]
```

### GetEntityById
```
Get-CrmEntity [-Id] <Guid>
```

### GetEntityByName
```
Get-CrmEntity [-Name] <String>
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

### -CustomOnly
{{Fill CustomOnly Description}}

```yaml
Type: SwitchParameter
Parameter Sets: GetEntitiesByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Exclude
{{Fill Exclude Description}}

```yaml
Type: String
Parameter Sets: GetEntitiesByFilter
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
Parameter Sets: GetEntitiesByFilter
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
Parameter Sets: GetEntityById
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
Parameter Sets: GetEntitiesByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeIntersects
{{Fill IncludeIntersects Description}}

```yaml
Type: SwitchParameter
Parameter Sets: GetEntitiesByFilter
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
Parameter Sets: GetEntityByName
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### None


## OUTPUTS

### Microsoft.Xrm.Sdk.Metadata.EntityMetadata


## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/Get-CrmEntity.html](http://crmpowershell.amsoftware.nl/Get-CrmEntity.html)

