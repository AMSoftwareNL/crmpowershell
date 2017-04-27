---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmServiceEndpoint.html
schema: 2.0.0
---

# Get-CrmServiceEndpoint

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### GetServiceEndPointByFilter (Default)
```
Get-CrmServiceEndpoint [-Include <String>] [-Exclude <String>] [-IncludeTotalCount] [-Skip <UInt64>]
 [-First <UInt64>]
```

### GetServiceEndPointById
```
Get-CrmServiceEndpoint [-Id] <Guid> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
```

### GetServiceEndPointByName
```
Get-CrmServiceEndpoint [-Name] <String> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
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
Parameter Sets: GetServiceEndPointByFilter
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
Parameter Sets: GetServiceEndPointById
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
Parameter Sets: GetServiceEndPointByFilter
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
Parameter Sets: GetServiceEndPointByName
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

[http://crmpowershell.amsoftware.nl/Get-CrmServiceEndpoint.html](http://crmpowershell.amsoftware.nl/Get-CrmServiceEndpoint.html)

