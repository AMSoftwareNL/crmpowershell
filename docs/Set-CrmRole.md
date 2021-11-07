---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Set-CrmRole.md
schema: 2.0.0
---

# Set-CrmRole

## SYNOPSIS
Update a Security Role

## SYNTAX

```
Set-CrmRole [-Id] <Guid> [-Name <String>] [-Inheritance <CrmRoleInheritance>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Update a Security Role

## EXAMPLES

## PARAMETERS

### -Id
Id of the Role to update

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases: Role

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -Inheritance
Is Role inherited by users from team membership, if role associated with team.

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmRoleInheritance
Parameter Sets: (All)
Aliases:
Accepted values: TeamOnly, DirectUser

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name for the role.

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

### -PassThru
Returns an object that represents the Role. By default, this cmdlet does not generate any output.

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

### System.Guid

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[Set-CrmRole](Set-CrmRole.md)

