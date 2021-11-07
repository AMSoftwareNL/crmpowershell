---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Remove-CrmRolePrivileges.md
schema: 2.0.0
---

# Remove-CrmRolePrivilege

## SYNOPSIS
Remove a privilege from an existing role

## SYNTAX

### RemoveRolePrivilegeForEntity (Default)
```
Remove-CrmRolePrivilege [-Role] <Guid[]> [-EntityLogicalName] <String> [-AccessRight] <CrmAccessRight> [-Force]
 [<CommonParameters>]
```

### RemoveRolePrivilegesByName
```
Remove-CrmRolePrivilege [-Role] <Guid[]> -PrivilegeName <String[]> [-Force] [<CommonParameters>]
```

## DESCRIPTION
Remove a privilege from an existing role

## EXAMPLES

## PARAMETERS

### -AccessRight
The Access Right for the Privilege to remove

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmAccessRight
Parameter Sets: RemoveRolePrivilegeForEntity
Aliases:
Accepted values: None, Read, Write, Append, AppendTo, Create, Delete, Share, Assign

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EntityLogicalName
LogicalName of the Entity to remove the access for

```yaml
Type: System.String
Parameter Sets: RemoveRolePrivilegeForEntity
Aliases: LogicalName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Execute the removal without confirmation

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

### -PrivilegeName
Name of the Privilige to remove

```yaml
Type: System.String[]
Parameter Sets: RemoveRolePrivilegesByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Role
The Role to remove to privilige from

```yaml
Type: System.Guid[]
Parameter Sets: (All)
Aliases: Id

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid[]

### System.String[]

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[Remove-CrmRolePrivileges](Remove-CrmRolePrivileges.md)

[RemovePrivilegeRole Request](https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.removeprivilegerolerequest)