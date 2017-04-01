---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmOptionSet.html
schema: 2.0.0
---

# Get-CrmOptionSet

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### GetOptionSetByFilter (Default)
```
Get-CrmOptionSet [-Include <String>] [-Exclude <String>] [-CustomOnly] [-ExcludeManaged]
```

### GetOptionSetById
```
Get-CrmOptionSet [-Id] <Guid>
```

### GetOptionSetByName
```
Get-CrmOptionSet [-Name] <String>
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
Parameter Sets: GetOptionSetByFilter
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
Parameter Sets: GetOptionSetByFilter
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
Parameter Sets: GetOptionSetByFilter
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
Parameter Sets: GetOptionSetById
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
Parameter Sets: GetOptionSetByFilter
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
Parameter Sets: GetOptionSetByName
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

### Microsoft.Xrm.Sdk.Metadata.OptionSetMetadataBase


## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/Get-CrmOptionSet.html](http://crmpowershell.amsoftware.nl/Get-CrmOptionSet.html)

