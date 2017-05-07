---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmRolePrincipals.html
schema: 2.0.0
---

# Get-CrmRolePrincipals

## SYNOPSIS
Get the users and teams assigned to a role.

## SYNTAX

```
Get-CrmRolePrincipals [-Role] <Guid> [<CommonParameters>]
```

## DESCRIPTION
Get the users and teams assigned to a role.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmRole -Include 'Sales Person' | Get-CrmRolePrincipals
```

Get the users and teams assigned to the 'Sales Person' role.

## PARAMETERS

### -Role
The id of the role to get the users and teams for.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[Set-CrmRolePrincipals](Set-CrmRolePrincipals.md)

[Get-CrmRole](Get-CrmRole.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
