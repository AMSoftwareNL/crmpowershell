---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmTeam.md
schema: 2.0.0
---

# Get-CrmTeam

## SYNOPSIS
Get team from the connected organization.

## SYNTAX

### GetAllTeams (Default)
```
Get-CrmTeam [[-Name] <String>] [-Exclude <String>] [-BusinessUnit <Guid>] [-TeamType <CrmTeamType>]
 [-Administrator <Guid>] [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

### GetTeamById
```
Get-CrmTeam [-Id] <Guid> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

## DESCRIPTION
Get team from the connected organization.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmBusinessUnit -Include 'amsoftwarecrm' | Get-CrmTeam
```

Get all teams for the business unit 'amsoftwarecrm'.

## PARAMETERS

### -Administrator
The id of the user who is administrator of the team.

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
The id of the business unit the team is related to.

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
Exclude teams whose name matches the provided pattern.

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
Specifies the number of records to retrieve from the beginning.

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
The id of the team to retrieve.

```yaml
Type: Guid
Parameter Sets: GetTeamById
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IncludeTotalCount
Return the total count (and accuracy) of the number of records before returning the result.

Because of the limitations of Dynamics CRM, the total count is only returned accurate when the result is limited to 5000 items.

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
Include teams whose name matches the provided pattern.

```yaml
Type: String
Parameter Sets: GetAllTeams
Aliases: Include

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Skips (does not return) the specified number of records.

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
The type of team to retrieve. If not provide all types of teams will be returned.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[New-CrmTeam](New-CrmTeam.md)

[Get-CrmTeamUsers](Get-CrmTeamUsers.md)

[Get-CrmUserTeams](Get-CrmUserTeams.md)

[Set-CrmTeamUsers](Set-CrmTeamUsers.md)

[Set-CrmUserTeams](Set-CrmUserTeams.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
