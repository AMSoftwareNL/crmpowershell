---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Remove-CrmTeamTemplate.md
schema: 2.0.0
---

# Remove-CrmTeamTemplate

## SYNOPSIS
Remove a Team Template

## SYNTAX

```
Remove-CrmTeamTemplate [-Id] <Guid[]> [-Force] [<CommonParameters>]
```

## DESCRIPTION
Remove a Team Template

## EXAMPLES

## PARAMETERS

### -Force
Remove the Team Template without confirmation

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

### -Id
Id of the Team Template to remove

```yaml
Type: System.Guid[]
Parameter Sets: (All)
Aliases: TeamTemplate

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
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

[Remove-CrmTeamTemplate](Remove-CrmTeamTemplate.md)

