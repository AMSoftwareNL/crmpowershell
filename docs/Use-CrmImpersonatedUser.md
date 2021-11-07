---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Use-CrmImpersonatedUser.md
schema: 2.0.0
---

# Use-CrmImpersonatedUser

## SYNOPSIS
Set the user to impersonate in the session context. All following request will be impersonated.

## SYNTAX

```
Use-CrmImpersonatedUser [[-ImpersonatedUserId] <Guid>] [<CommonParameters>]
```

## DESCRIPTION
Set the user to impersonate in the session context. All following request will be impersonated.

## EXAMPLES

## PARAMETERS

### -ImpersonatedUserId
The Id of the user to impersonate. When not supplied impersonation will stop.

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases: UserId

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[Use-CrmImpersonatedUser](Use-CrmImpersonatedUser.md)

