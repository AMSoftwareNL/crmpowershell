---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Set-CrmTeamUsers.md
schema: 2.0.0
---

# Set-CrmTeamUsers

## SYNOPSIS
Set the users who are members of team.

## SYNTAX

```
Set-CrmTeamUsers [-Team] <Guid[]> [-Users] <Guid[]> [-Overwrite] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Set the users who are members of team.

## EXAMPLES

## PARAMETERS

### -Overwrite
Overwrite the current users for the team. If omitted the existing and new users will be merged.

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

### -PassThru
Returns an object that represents the team. By default, this cmdlet does not generate any output.

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

### -Team
The id of the team to set the users for.

```yaml
Type: Guid[]
Parameter Sets: (All)
Aliases: Id

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Users
The id of the users to set as members of the team.

```yaml
Type: Guid[]
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid
System.Guid[]

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[Get-CrmTeam](Get-CrmTeam.md)

[Get-CrmTeamUsers](Get-CrmTeamUsers.md)

[Get-CrmUserTeams](Get-CrmUserTeams.md)

[New-CrmTeam](New-CrmTeam.md)

[Set-CrmUserTeams](Set-CrmUserTeams.md)
