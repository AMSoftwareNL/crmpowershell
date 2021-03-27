---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmRole.md
schema: 2.0.0
---

# Get-CrmRole

## SYNOPSIS
Get role from the connected organization.

## SYNTAX

### GetAllRoles (Default)
```
Get-CrmRole [[-Name] <String>] [-Exclude <String>] [-BusinessUnit <Guid>] [-IncludeTotalCount] [-Skip <UInt64>]
 [-First <UInt64>] [<CommonParameters>]
```

### GetRoleById
```
Get-CrmRole [-Id] <Guid[]> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

## DESCRIPTION
Get role from the connected organization.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmBusinessUnit -Include 'amsoftwarecrm' | Get-CrmRole
```

Get all roles for the business unit 'amsoftwarecrm'.

## PARAMETERS

### -BusinessUnit
The id of a business unit to retrieve the related roles for.

```yaml
Type: Guid
Parameter Sets: GetAllRoles
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Exclude
Exclude roles whose name matches the provided pattern.

```yaml
Type: String
Parameter Sets: GetAllRoles
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -First
Specifies the number of records to retrieve from the beginning.

```yaml
Type: UInt64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The id of the role to retrieve.

```yaml
Type: Guid[]
Parameter Sets: GetRoleById
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IncludeTotalCount
Return the total count (and accuracy) of the number of records before returning the result.

Because of the limitations of Dynamics CRM, the total count is only returned accurate when the result is limited to 5000 items.

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

### -Name
Include roles whose name matches the provided pattern.

```yaml
Type: String
Parameter Sets: GetAllRoles
Aliases: Include

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Skips (does not return) the specified number of records.

```yaml
Type: UInt64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid[]
## OUTPUTS

### Microsoft.Xrm.Sdk.Entity
## NOTES

## RELATED LINKS

[New-CrmRole](New-CrmRole.md)

[Get-CrmRolePrincipals](Get-CrmRolePrincipals.md)

[Get-CrmPrincipalRoles](Get-CrmPrincipalRoles.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
