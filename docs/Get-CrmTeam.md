---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmTeam.html
schema: 2.0.0
---

# Get-CrmTeam

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### GetAllTeams (Default)
```
Get-CrmTeam [-TeamType <CrmTeamType>] [-Administrator <Guid>] [-Include <String>] [-Exclude <String>]
 [-BusinessUnit <Guid>] [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
```

### GetTeamById
```
Get-CrmTeam [-Id] <Guid> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
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

### -Administrator
{{Fill Administrator Description}}

```yaml
Type: Guid
Parameter Sets: GetAllTeams
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BusinessUnit
{{Fill BusinessUnit Description}}

```yaml
Type: Guid
Parameter Sets: GetAllTeams
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
Parameter Sets: GetAllTeams
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
Parameter Sets: GetTeamById
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Include
{{Fill Include Description}}

```yaml
Type: String
Parameter Sets: GetAllTeams
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

### -TeamType
{{Fill TeamType Description}}

```yaml
Type: CrmTeamType
Parameter Sets: GetAllTeams
Aliases: 
Accepted values: Owner, Access

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

[http://crmpowershell.amsoftware.nl/Get-CrmTeam.html](http://crmpowershell.amsoftware.nl/Get-CrmTeam.html)

