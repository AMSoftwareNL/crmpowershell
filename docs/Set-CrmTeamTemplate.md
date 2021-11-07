---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Set-CrmTeamTemplate.md
schema: 2.0.0
---

# Set-CrmTeamTemplate

## SYNOPSIS
Update a Team Template

## SYNTAX

```
Set-CrmTeamTemplate [-Id] <Guid> [-Name <String>] [-Description <String>] [-ObjectTypeCode <Int32>]
 [-DefaultAccessRight <CrmAccessRight>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Update a Team Template

## EXAMPLES

## PARAMETERS

### -DefaultAccessRight
The Default Access Right for the Access Team based on the template

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmAccessRight
Parameter Sets: (All)
Aliases:
Accepted values: None, Read, Write, Append, AppendTo, Create, Delete, Share, Assign

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
Description of the Team Template

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

### -Id
Id of the Team Template to update

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The new name for the Team Template

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

### -ObjectTypeCode
The ObjectTypeCode of the Entity the Team Template is linked to

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns an object that represents the Team Template. By default, this cmdlet does not generate any output.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[Set-CrmTeamTemplate](Set-CrmTeamTemplate.md)

