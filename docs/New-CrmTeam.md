---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/New-CrmTeam.md
schema: 2.0.0
---

# New-CrmTeam

## SYNOPSIS
Add a new team.

## SYNTAX

```
New-CrmTeam [-Name] <String> [-TeamType] <CrmTeamType> [-Administrator] <Guid> [-BusinessUnit <Guid>]
 [-Description <String>] [-Users <Guid[]>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Add a new team.

## EXAMPLES

## PARAMETERS

### -Administrator
The id of the user who administers the team.

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BusinessUnit
The id of the business unit the team is associated with.

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Description
The description for the team.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name for the team.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns an object that represents the Team. By default, this cmdlet does not generate any output.

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

### -TeamType
The team of team to create.

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmTeamType
Parameter Sets: (All)
Aliases:
Accepted values: Owner, Access

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Users
The id of users who will be members of the team.

```yaml
Type: System.Guid[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid

### System.Guid[]

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[Get-CrmTeam](Get-CrmTeam.md)

[Entity Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.entity)
