---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Set-CrmRolePrivileges.md
schema: 2.0.0
---

# Set-CrmRolePrivilege

## SYNOPSIS
Add a set of existing privileges to an existing role.

## SYNTAX

### SetRolePrivilegeForEntity (Default)
```
Set-CrmRolePrivilege [-Role] <Guid[]> [-EntityLogicalName] <String> [-AccessRight] <CrmAccessRight>
 [-Scope] <CrmAccessScope> [<CommonParameters>]
```

### SetRolePrivilegesByName
```
Set-CrmRolePrivilege [-Role] <Guid[]> -PrivilegeName <String[]> [-Scope] <CrmAccessScope> [<CommonParameters>]
```

## DESCRIPTION
Add a set of existing privileges to an existing role.

## EXAMPLES

## PARAMETERS

### -AccessRight
The Access Right mask to set

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmAccessRight
Parameter Sets: SetRolePrivilegeForEntity
Aliases:
Accepted values: None, Read, Write, Append, AppendTo, Create, Delete, Share, Assign

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EntityLogicalName
The LogicalName of the Entity to set Privileges for

```yaml
Type: System.String
Parameter Sets: SetRolePrivilegeForEntity
Aliases: LogicalName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivilegeName
Name of the Privilege to set

```yaml
Type: System.String[]
Parameter Sets: SetRolePrivilegesByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Role
The Security Role to Add to Privilege to

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

### -Scope
The scope the Privilege applies to

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmAccessScope
Parameter Sets: (All)
Aliases:
Accepted values: User, BusinessUnit, ChildBusinessUnit, Organization, None

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid[]

### System.String[]

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[Set-CrmRolePrivileges](Set-CrmRolePrivileges.md)

[AddPrivilegesRole Request](https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.addprivilegesrolerequest)