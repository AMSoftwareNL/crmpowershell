---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Remove-CrmTeamUsers.md
schema: 2.0.0
---

# Remove-CrmTeamUsers

## SYNOPSIS
Remove users from a team.

## SYNTAX

### RemoveTeamUsersSelected (Default)
```
Remove-CrmTeamUsers [-Team] <Guid[]> [-Users] <Guid[]> [<CommonParameters>]
```

### RemoveTeamUsersAll
```
Remove-CrmTeamUsers [-Team] <Guid[]> [-All] [<CommonParameters>]
```

## DESCRIPTION
Remove users from a team.

## EXAMPLES

## PARAMETERS

### -All
Remove all users from the team.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RemoveTeamUsersAll
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Team
The id of the team to remove the users from.

```yaml
Type: System.Guid[]
Parameter Sets: (All)
Aliases: Id

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Users
The id of the users to remove from the team.

```yaml
Type: System.Guid[]
Parameter Sets: RemoveTeamUsersSelected
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid[]

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[Remove-CrmTeamUsers](Remove-CrmTeamUsers.md)

