---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/New-CrmRole.md
schema: 2.0.0
---

# New-CrmRole

## SYNOPSIS
Add a new role.

## SYNTAX

```
New-CrmRole [-Name] <String> [-BusinessUnit <Guid>] [-Inheritance <CrmRoleInheritance>] [-PassThru]
 [<CommonParameters>]
```

## DESCRIPTION
Add a new role.

## EXAMPLES

## PARAMETERS

### -BusinessUnit
The id of the business unit the new role is associated with.

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

Required: True
Position: 0
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

[Get-CrmRole](Get-CrmRole.md)

[Entity Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.entity)
