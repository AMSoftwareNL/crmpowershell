---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmEntityKey.html
schema: 2.0.0
---

# Get-CrmEntityKey

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### GetEntityKeysByFilter (Default)
```
Get-CrmEntityKey [-Entity] <String> [-Attributes <String[]>] [-Include <String>] [-Exclude <String>]
 [-ExcludeManaged]
```

### GetEntityKeyById
```
Get-CrmEntityKey [-Id] <Guid>
```

### GetEntityKeyByName
```
Get-CrmEntityKey [-Entity] <String> [-Name] <String>
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

### -Attributes
{{Fill Attributes Description}}

```yaml
Type: String[]
Parameter Sets: GetEntityKeysByFilter
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
Parameter Sets: GetEntityKeysByFilter, GetEntityKeyByName
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
Parameter Sets: GetEntityKeysByFilter
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
Parameter Sets: GetEntityKeysByFilter
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
Parameter Sets: GetEntityKeyById
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
Parameter Sets: GetEntityKeysByFilter
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
Parameter Sets: GetEntityKeyByName
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

### Microsoft.Xrm.Sdk.Metadata.EntityKeyMetadata


## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/Get-CrmEntityKey.html](http://crmpowershell.amsoftware.nl/Get-CrmEntityKey.html)

