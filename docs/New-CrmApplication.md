---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Invoke-CrmNewApplication.md
schema: 2.0.0
---

# New-CrmApplication

## SYNOPSIS
Register a new Application User (S2S) with Dataverse

## SYNTAX

```
New-CrmApplication [-AppId] <Guid> [-BusinessUnit <Guid>] [-Roles <Guid[]>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Register a new Application User (S2S) with Dataverse

## EXAMPLES

## PARAMETERS

### -AppId
The AppId/ClientId in Azure AD of the Application to add

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BusinessUnit
Business Unit the Application User is added to

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns an object that represents the User. By default, this cmdlet does not generate any output.

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

### -Roles
The Security Role to assign to the new Application User

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

### System.Guid[]

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[New-CrmApplication](New-CrmApplication.md)

