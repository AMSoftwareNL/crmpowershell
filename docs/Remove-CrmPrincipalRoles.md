---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Remove-CrmPrincipalRoles.md
schema: 2.0.0
---

# Remove-CrmPrincipalRoles

## SYNOPSIS
Remove the roles for a user or team.

## SYNTAX

### RemovePrincipalRolesSelected (Default)
```
Remove-CrmPrincipalRoles [-Principal] <Guid[]> [-PrincipalType] <CrmPrincipalType> -Roles <Guid[]>
 [<CommonParameters>]
```

### RemovePrincipalRolesAll
```
Remove-CrmPrincipalRoles [-Principal] <Guid[]> [-PrincipalType] <CrmPrincipalType> [-All] [<CommonParameters>]
```

## DESCRIPTION
Remove the roles for a user or team.

## EXAMPLES

## PARAMETERS

### -All
Remove all roles from the user or team.

```yaml
Type: SwitchParameter
Parameter Sets: RemovePrincipalRolesAll
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Principal
The id of the user or team to remove the roles from.

```yaml
Type: Guid[]
Parameter Sets: (All)
Aliases: Id

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrincipalType
The type of principal to remove the roles from.

```yaml
Type: CrmPrincipalType
Parameter Sets: (All)
Aliases:
Accepted values: User, Team

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Roles
The id of the roles to remove from the user or team.

```yaml
Type: Guid[]
Parameter Sets: RemovePrincipalRolesSelected
Aliases:

Required: True
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

### System.Object
## NOTES

## RELATED LINKS

[https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Remove-CrmPrincipalRoles.md](https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Remove-CrmPrincipalRoles.md)

