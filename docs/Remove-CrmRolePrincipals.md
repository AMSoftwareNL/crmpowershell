---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Remove-CrmRolePrincipals.md
schema: 2.0.0
---

# Remove-CrmRolePrincipals

## SYNOPSIS
Remove the teams or users assigned to a role.

## SYNTAX

### RemoveRolePrincipalsSelected (Default)
```
Remove-CrmRolePrincipals [-Role] <Guid[]> [-PrincipalType] <CrmPrincipalType> -Principals <Guid[]>
 [<CommonParameters>]
```

### RemoveRolePrincipalsAll
```
Remove-CrmRolePrincipals [-Role] <Guid[]> [[-PrincipalType] <CrmPrincipalType>] [-All] [<CommonParameters>]
```

## DESCRIPTION
Remove the teams or users assigned to a role.

## EXAMPLES

## PARAMETERS

### -All
Remove all principals from the role. Provide PrincipalType to only remove principals of the specifiec type.

```yaml
Type: SwitchParameter
Parameter Sets: RemoveRolePrincipalsAll
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrincipalType
The type of principal to remove.

```yaml
Type: CrmPrincipalType
Parameter Sets: RemoveRolePrincipalsSelected
Aliases:
Accepted values: User, Team, User, Team, User, Team, User, Team

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: CrmPrincipalType
Parameter Sets: RemoveRolePrincipalsAll
Aliases:
Accepted values: User, Team, User, Team, User, Team, User, Team

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Principals
The id of the users or teams to remove from the role.

```yaml
Type: Guid[]
Parameter Sets: RemoveRolePrincipalsSelected
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Role
The id of the role to remove the principals from.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid[]
## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Remove-CrmRolePrincipals.md](https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Remove-CrmRolePrincipals.md)

