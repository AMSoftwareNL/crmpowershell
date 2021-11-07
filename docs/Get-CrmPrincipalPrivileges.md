---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmPrincipalPrivileges.md
schema: 2.0.0
---

# Get-CrmPrincipalPrivileges

## SYNOPSIS
Retrieve the privileges a system user (user) or team has through roles in the specified business unit.

## SYNTAX

```
Get-CrmPrincipalPrivileges [-InputObject] <Entity> [<CommonParameters>]
```

## DESCRIPTION
Retrieve the privileges a system user (user) or team has through roles in the specified business unit.

## EXAMPLES

## PARAMETERS

### -InputObject
Team or System User record to get privilges for.

```yaml
Type: Microsoft.Xrm.Sdk.Entity
Parameter Sets: (All)
Aliases: User, Team

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Xrm.Sdk.Entity

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[Get-CrmPrincipalPrivileges](Get-CrmPrincipalPrivileges.md)

[RetrieveUserPrivileges Request](https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrieveuserprivilegesrequest)

[RetrieveTeamPrivilegesRequest](https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrieveteamprivilegesrequest)