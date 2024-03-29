---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Set-CrmUserTeams.md
schema: 2.0.0
---

# Set-CrmUserTeams

## SYNOPSIS
Set the teams a user is a member of.

## SYNTAX

```
Set-CrmUserTeams [-User] <Guid[]> [-Teams] <Guid[]> [-Overwrite] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Set the teams a user is a member of.

## EXAMPLES

## PARAMETERS

### -Overwrite
Overwrite the current teams for the user. If omitted the existing and new teams will be merged.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns an object that represents the user. By default, this cmdlet does not generate any output.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Teams
The id of the teams the user is a member of.

```yaml
Type: System.Guid[]
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -User
The id of the user to set the teams for.

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

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[Get-CrmTeamUsers](Get-CrmTeamUsers.md)

[Get-CrmUser](Get-CrmUser.md)

[Get-CrmUserTeams](Get-CrmUserTeams.md)

[New-CrmUser](New-CrmUser.md)

[Set-CrmTeamUsers](Set-CrmTeamUsers.md)
