---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Remove-CrmUserTeams.md
schema: 2.0.0
---

# Remove-CrmUserTeams

## SYNOPSIS
Remove the teams a user is a member of.

## SYNTAX

### RemoveUserTeamsSelected (Default)
```
Remove-CrmUserTeams [-User] <Guid[]> [-Teams] <Guid[]> [<CommonParameters>]
```

### RemoveUserTeamsAll
```
Remove-CrmUserTeams [-User] <Guid[]> [-All] [<CommonParameters>]
```

## DESCRIPTION
Remove the teams a user is a member of.

## EXAMPLES

## PARAMETERS

### -All
Remove the user from all teams it is a member of.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RemoveUserTeamsAll
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Teams
The id of the teams to remove the user from.

```yaml
Type: System.Guid[]
Parameter Sets: RemoveUserTeamsSelected
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -User
The id of the user to remove the teams from.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid[]

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Remove-CrmUserTeams.md](https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Remove-CrmUserTeams.md)

