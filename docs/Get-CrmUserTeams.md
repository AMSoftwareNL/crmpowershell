---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmUserTeams.html
schema: 2.0.0
---

# Get-CrmUserTeams

## SYNOPSIS
Get the teams a user is assinged to.

## SYNTAX

```
Get-CrmUserTeams [-User] <Guid>
```

## DESCRIPTION
Get the teams a user is assinged to.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmUser -UserName 'user1@organization.com' | Get-CrmUserTeams
```

Get the assinged teams for the user with username 'user1@organization.com'.

## PARAMETERS

### -User
The id of the user to get the assinged teams for.

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

[Get-CrmTeamUsers](Get-CrmTeamUsers.md)

[Get-CrmUser](Get-CrmUser.md)

[New-CrmUser](New-CrmUser.md)

[Remove-CrmUserParent](Remove-CrmUserParent.md)

[Set-CrmTeamUsers](Set-CrmTeamUsers.md)

[Set-CrmUserTeams](Set-CrmUserTeams.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
