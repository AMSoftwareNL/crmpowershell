---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmPrincipalRoles.html
schema: 2.0.0
---

# Get-CrmPrincipalRoles

## SYNOPSIS
Get the roles related to a user or team.

## SYNTAX

```
Get-CrmPrincipalRoles [-Principal] <Guid>
```

## DESCRIPTION
Get the roles related to a user or team.

## EXAMPLES

### Example 1
```
PS C:\> Get-Team -Name 'Sales Team' | Get-PrincipalRoles
```

Get the roles for the team 'Sales Team'.

## PARAMETERS

### -Principal
The id of a user or team to get the roles for.

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

## INPUTS

### System.Guid


## OUTPUTS

### Microsoft.Xrm.Sdk.Entity


## NOTES

## RELATED LINKS

[Get-CrmRole](Get-CrmRole.md)

[Get-CrmUser](Get-CrmUser.md)

[Get-CrmTeam](Get-CrmTeam.md)

[Get-CrmRolePrincipals](Get-CrmRolePrincipals.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
