---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmTeamUsers.html
schema: 2.0.0
---

# Get-CrmTeamUsers

## SYNOPSIS
Get the users assinged to a team.

## SYNTAX

```
Get-CrmTeamUsers [-Team] <Guid>
```

## DESCRIPTION
Get the users assinged to a team.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmTeam -Include 'Sales' | get-CrmTeamUsers
```

Get the users from the team 'Sales'.

## PARAMETERS

### -Team
The id of the team to retrieve the assinged user for.

```yaml
Type: Guid
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

## INPUTS

### System.Guid


## OUTPUTS

### Microsoft.Xrm.Sdk.Entity


## NOTES

## RELATED LINKS

[Get-CrmTeam](Get-CrmTeam.md)

[New-CrmTeam](New-CrmTeam.md)

[Get-CrmUserTeams](Get-CrmUserTeams.md)

[Set-CrmTeamUsers](Set-CrmTeamUsers.md)

[Set-CrmUserTeams](Set-CrmUserTeams.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
