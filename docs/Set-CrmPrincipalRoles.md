---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Set-CrmPrincipalRoles.html
schema: 2.0.0
---

# Set-CrmPrincipalRoles

## SYNOPSIS
Set the roles for a user or team.

## SYNTAX

```
Set-CrmPrincipalRoles [-Principal] <Guid> [-PrincipalType] <CrmPrincipalType> -Roles <Guid[]> [-Overwrite]
 [<CommonParameters>]
```

## DESCRIPTION
Set the roles for a user or team.

## EXAMPLES

## PARAMETERS

### -Overwrite
Overwrite the existing roles for the user or team. If omitted the roles will be merged.

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

### -Principal
The id of the user or team to set the roles for.

```yaml
Type: Guid
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrincipalType
The type of principal to set the roles for.

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
The id of the roles to assigned to the user or team.

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

[Set-CrmRolePrincipals](Set-CrmRolePrincipals.md)
