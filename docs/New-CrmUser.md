---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/New-CrmUser.md
schema: 2.0.0
---

# New-CrmUser

## SYNOPSIS
Add a new user.

## SYNTAX

```
New-CrmUser [-UserName] <String> [-Firstname] <String> [-Lastname] <String> [-Access <CrmUserAccessMode>]
 [-License <CrmUserClientLicense>] [-BusinessUnit <Guid>] [-Roles <Guid[]>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Add a new user.

## EXAMPLES

## PARAMETERS

### -Access
The type of access for the user.

```yaml
Type: CrmUserAccessMode
Parameter Sets: (All)
Aliases:
Accepted values: ReadWrite, Admin, Read, Support, NonInteractive, DelegatedAdmin

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BusinessUnit
The id of the business unit the user is associated with.

```yaml
Type: Guid
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Firstname
The firstname of the user.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Lastname
The lastname of the user.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -License
The type of license for the user.

```yaml
Type: CrmUserClientLicense
Parameter Sets: (All)
Aliases:
Accepted values: Pro, Admin, Basic, DevicePro, DeviceBasic, Essential, DeviceEssential, Enterprise, DeviceEnterprise, Sales, Service, FieldService, ProjectService

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns an object that represents the User. By default, this cmdlet does not generate any output.

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

### -Roles
The id of the roles the user will be assigned to.

```yaml
Type: Guid[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserName
The username of the user.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid[]
## OUTPUTS

### Microsoft.Xrm.Sdk.Entity
## NOTES

## RELATED LINKS

[Get-CrmUser](Get-CrmUser.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
