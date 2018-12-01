---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Set-CrmOwner.md
schema: 2.0.0
---

# Set-CrmOwner

## SYNOPSIS
Update the owner of a record.

## SYNTAX

### AssignOwnerRecord (Default)
```
Set-CrmOwner [-Entity] <String> [-Id] <Guid> -ToPrincipalType <CrmPrincipalType> -ToPrincipalId <Guid>
 [<CommonParameters>]
```

### ReassignOwner
```
Set-CrmOwner [-FromPrincipalType] <CrmPrincipalType> [-FromPrincipalId] <Guid>
 -ToPrincipalType <CrmPrincipalType> -ToPrincipalId <Guid> [<CommonParameters>]
```

## DESCRIPTION
Update the owner of a record. This can be a user or a team.

## EXAMPLES

## PARAMETERS

### -Entity
The LogicalName of the entity.

```yaml
Type: String
Parameter Sets: AssignOwnerRecord
Aliases: LogicalName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -FromPrincipalId
The id of the current user or team.

```yaml
Type: Guid
Parameter Sets: ReassignOwner
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FromPrincipalType
The team of principal of the current owner.

```yaml
Type: CrmPrincipalType
Parameter Sets: ReassignOwner
Aliases:
Accepted values: User, Team

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The id of the record to update the owner for.

```yaml
Type: Guid
Parameter Sets: AssignOwnerRecord
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ToPrincipalId
The id of the team or user of the new owner.

```yaml
Type: Guid
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ToPrincipalType
The type of principal of the new owner.

```yaml
Type: CrmPrincipalType
Parameter Sets: (All)
Aliases:
Accepted values: User, Team

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Xrm.Sdk.Entity
## OUTPUTS

### None
## NOTES

## RELATED LINKS

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
