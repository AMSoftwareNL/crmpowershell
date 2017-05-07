---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmUser.html
schema: 2.0.0
---

# Get-CrmUser

## SYNOPSIS
Get user from the connected organization.

## SYNTAX

### GetAllUsers (Default)
```
Get-CrmUser [-Include <String>] [-Exclude <String>] [-BusinessUnit <Guid>] [-IncludeDisabled]
 [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

### GetUserByUserName
```
Get-CrmUser [-UserName] <String> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

### GetUserById
```
Get-CrmUser [-Id] <Guid> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

## DESCRIPTION
Get user from the connected organization.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmUser -UserName 'user1@organization.com'
```

Gets the user matching username 'user1@organization.com'.

## PARAMETERS

### -BusinessUnit
The id of a business unit to retrieve the related users for.

```yaml
Type: Guid
Parameter Sets: GetAllUsers
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Exclude
Exclude users whose name matches the provided pattern.

```yaml
Type: String
Parameter Sets: GetAllUsers
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
The id of the user to retrieve.

```yaml
Type: Guid
Parameter Sets: GetUserById
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Include
Include users whose name matches the provided pattern.

```yaml
Type: String
Parameter Sets: GetAllUsers
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeDisabled
Include inactive users in the result.

```yaml
Type: SwitchParameter
Parameter Sets: GetAllUsers
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeTotalCount
Return the total count (and accuracy) of the number of records before returning the result.

Because of the limitations of Dynamics CRM, the total count is only returned accurate when the result is limited to 5000 items

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

### -UserName
The username of the user to retrieve.

```yaml
Type: String
Parameter Sets: GetUserByUserName
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

### None

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[Get-CrmTeamUsers](Get-CrmTeamUsers.md)

[Get-CrmUserTeams](Get-CrmUserTeams.md)

[New-CrmUser](New-CrmUser.md)

[Remove-CrmUserParent](Remove-CrmUserParent.md)

[Set-CrmTeamUsers](Set-CrmTeamUsers.md)

[Set-CrmUserTeams](Set-CrmUserTeams.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
