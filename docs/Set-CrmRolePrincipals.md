---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Set-CrmRolePrincipals.md
schema: 2.0.0
---

# Set-CrmRolePrincipals

## SYNOPSIS
Set the teams or users assigned to a role.

## SYNTAX

```
Set-CrmRolePrincipals [-Role] <Guid[]> [-PrincipalType] <CrmPrincipalType> -Principals <Guid[]> [-Overwrite]
 [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Set the teams or users assigned to a role.

## EXAMPLES

## PARAMETERS

### -Overwrite
Overwrite the existing users and teams assigned to the role. If omitted the users and teams will be merged.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns an object that represents the role. By default, this cmdlet does not generate any output.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrincipalType
The type of principal to assign.

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

### -Principals
The id of the users or teams to assign to the role.

```yaml
Type: Guid[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Role
The id of the role to assign the principals to.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid
## OUTPUTS

### None
## NOTES

## RELATED LINKS

[Get-CrmPrincipalRoles](Get-CrmPrincipalRoles.md)

[Get-CrmRolePrincipals](Get-CrmRolePrincipals.md)

[Set-CrmPrincipalRoles](Set-CrmPrincipalRoles.md)
