---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Test-CrmUserPrivilege.md
schema: 2.0.0
---

# Test-CrmUserPrivilege

## SYNOPSIS
Retrieves the list of privileges for a system user (user) from all direct roles associated with the system user and from all indirect roles associated with teams in which the system user is a member

## SYNTAX

### TestUserPrivilegesByName
```
Test-CrmUserPrivilege [-User] <Guid> [-PrivilegeName] <String> [<CommonParameters>]
```

### TestUserPrivilegeForEntity
```
Test-CrmUserPrivilege [-User] <Guid> [-EntityLogicalName] <String> [-AccessRight] <CrmAccessRight>
 [<CommonParameters>]
```

## DESCRIPTION
Retrieves the list of privileges for a system user (user) from all direct roles associated with the system user and from all indirect roles associated with teams in which the system user is a member

## EXAMPLES

## PARAMETERS

### -AccessRight
The Access Right mask to test for

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmAccessRight
Parameter Sets: TestUserPrivilegeForEntity
Aliases:
Accepted values: None, Read, Write, Append, AppendTo, Create, Delete, Share, Assign

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EntityLogicalName
The LogicalName of the Entity to test the access for

```yaml
Type: System.String
Parameter Sets: TestUserPrivilegeForEntity
Aliases: LogicalName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivilegeName
The name of the Privilige to test for

```yaml
Type: System.String
Parameter Sets: TestUserPrivilegesByName
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -User
The Id of the User to test access for

```yaml
Type: System.Guid
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

### System.Guid

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[Test-CrmUserPrivilege](Test-CrmUserPrivilege.md)

[RetrieveUserPrivilegeByPrivilegeName Request](https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrieveuserprivilegebyprivilegenamerequest)