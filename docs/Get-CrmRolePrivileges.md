---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmRolePrivileges.md
schema: 2.0.0
---

# Get-CrmRolePrivileges

## SYNOPSIS
Retrieve the privileges that are assigned to the specified role.

## SYNTAX

```
Get-CrmRolePrivileges [[-Role] <Guid>] [-Include <String>] [-Exclude <String>] [-EntityPrivilegesOnly]
 [-OtherPrivilegesOnly] [<CommonParameters>]
```

## DESCRIPTION
Retrieve the privileges that are assigned to the specified role.

## EXAMPLES

## PARAMETERS

### -EntityPrivilegesOnly
Only retrieve the priviliges linked to Entities.

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

### -Exclude
Priviliges - based on name - to exclude in the result.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -Include
Priviliges - based on name - to include in the result.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -OtherPrivilegesOnly
Only retrieve the priviliges not linked to Entities.

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

### -Role
The security role to retrieve the privileges for.

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases: Id

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
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

[Get-CrmRolePrivileges](Get-CrmRolePrivileges.md)

[RetrieveRolePrivilegesRole Request](https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrieveroleprivilegesrolerequest)