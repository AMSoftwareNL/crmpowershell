---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Set-CrmRelationshipCascadeConfig.md
schema: 2.0.0
---

# Set-CrmRelationshipCascadeConfig

## SYNOPSIS
Set the cascading behavior for a relationship.

## SYNTAX

```
Set-CrmRelationshipCascadeConfig [-Relationship] <String> [-Assign <CrmCascadeType>] [-Delete <CrmCascadeType>]
 [-Merge <CrmCascadeType>] [-Reparent <CrmCascadeType>] [-Share <CrmCascadeType>] [-Unshare <CrmCascadeType>]
 [<CommonParameters>]
```

## DESCRIPTION
Set the cascading behavior for a relationship.

## EXAMPLES

## PARAMETERS

### -Assign
The referenced entity record owner is changed.

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmCascadeType
Parameter Sets: (All)
Aliases:
Accepted values: None, Cascade, Active, UserOwned, RemoveLink, Restrict

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Delete
The referenced entity record is deleted.

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmCascadeType
Parameter Sets: (All)
Aliases:
Accepted values: None, Cascade, Active, UserOwned, RemoveLink, Restrict

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Merge
The record is merged with another record.

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmCascadeType
Parameter Sets: (All)
Aliases:
Accepted values: None, Cascade, Active, UserOwned, RemoveLink, Restrict

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Relationship
The SchemaName of the relationship to set the cascade configuration for.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SchemaName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Reparent
The value of the referencing attribute in a parental relationship changes.

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmCascadeType
Parameter Sets: (All)
Aliases:
Accepted values: None, Cascade, Active, UserOwned, RemoveLink, Restrict

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Share
The referenced entity record is shared with another user.

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmCascadeType
Parameter Sets: (All)
Aliases:
Accepted values: None, Cascade, Active, UserOwned, RemoveLink, Restrict

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Unshare
Sharing is removed for the referenced entity record.

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmCascadeType
Parameter Sets: (All)
Aliases:
Accepted values: None, Cascade, Active, UserOwned, RemoveLink, Restrict

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[Get-CrmRelationship](Get-CrmRelationship.md)

[Set-CrmRelationship](Set-CrmRelationship.md)

[CascadeConfiguration Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.metadata.cascadeconfiguration)
