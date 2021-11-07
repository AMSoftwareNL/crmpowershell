---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/New-CrmTeamTemplate.md
schema: 2.0.0
---

# New-CrmTeamTemplate

## SYNOPSIS
Team template for an entity enabled for automatically created access teams

## SYNTAX

```
New-CrmTeamTemplate [-Name] <String> [-Description <String>] -ObjectTypeCode <Int32>
 -DefaultAccessRight <CrmAccessRight> [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Team template for an entity enabled for automatically created access teams

## EXAMPLES

## PARAMETERS

### -DefaultAccessRight
Default access rights mask for the access teams associated with entity instances

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmAccessRight
Parameter Sets: (All)
Aliases:
Accepted values: None, Read, Write, Append, AppendTo, Create, Delete, Share, Assign

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
The description for the Etam Template

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
The Name of the Team Template

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ObjectTypeCode
Object type code of entity which is enabled for access teams

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -PassThru
Return the created Team Template

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

### System.Int32

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[New-CrmTeamTemplate](New-CrmTeamTemplate.md)

