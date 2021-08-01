---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Set-CrmRelationship.md
schema: 2.0.0
---

# Set-CrmRelationship

## SYNOPSIS
Update a relationship.

## SYNTAX

### SetRelationshipByInputObject (Default)
```
Set-CrmRelationship [-InputObject] <RelationshipMetadataBase> [-PassThru] [<CommonParameters>]
```

### SetRelationship
```
Set-CrmRelationship [-Name] <String> [-AdvancedFind <Boolean>] [-IsHierarchical <Boolean>]
 [-Customizable <Boolean>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Update a relationship.

## EXAMPLES

## PARAMETERS

### -AdvancedFind
Whether the relationship appears in Advanced Find.

```yaml
Type: System.Boolean
Parameter Sets: SetRelationship
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Customizable
Whether the relationship is a custom relationship.

```yaml
Type: System.Boolean
Parameter Sets: SetRelationship
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The updated RelationshipMetadata for the relationship.

```yaml
Type: Microsoft.Xrm.Sdk.Metadata.RelationshipMetadataBase
Parameter Sets: SetRelationshipByInputObject
Aliases: Relationship

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsHierarchical
Whether this relationship is the designated hierarchical self-referential relationship for this entity

```yaml
Type: System.Boolean
Parameter Sets: SetRelationship
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The SchemaName of the relationship.

```yaml
Type: System.String
Parameter Sets: SetRelationship
Aliases: SchemaName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns an object that represents the RelationshipMetadata. By default, this cmdlet does not generate any output.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Xrm.Sdk.Metadata.RelationshipMetadataBase

## OUTPUTS

### Microsoft.Xrm.Sdk.Metadata.RelationshipMetadataBase

## NOTES

## RELATED LINKS

[Add-CrmRelationship](Add-CrmRelationship.md)

[Get-CrmRelationship](Get-CrmRelationship.md)

[Set-CrmRelationshipCascadeConfig](Set-CrmRelationshipCascadeConfig.md)

[Remove-CrmRelationship](Remove-CrmRelationship.md)

[ManyToManyRelationshipMetadata Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.metadata.manytomanyrelationshipmetadata)

[OneToManyRelationshipMetadata Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.metadata.onetomanyrelationshipmetadata)
