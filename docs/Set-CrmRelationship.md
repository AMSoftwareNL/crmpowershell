---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Set-CrmRelationship.html
schema: 2.0.0
---

# Set-CrmRelationship

## SYNOPSIS
Update a relationship.

## SYNTAX

### SetRelationshipByInputObject
```
Set-CrmRelationship [-Relationship] <RelationshipMetadataBase> [<CommonParameters>]
```

### SetRelationship
```
Set-CrmRelationship [-Name] <String> [-AdvancedFind <Boolean>] [-Customizable <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
Update a relationship.

## EXAMPLES

## PARAMETERS

### -AdvancedFind
Whether the relationship appears in Advanced Find.

```yaml
Type: Boolean
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
Type: Boolean
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
Type: String
Parameter Sets: SetRelationship
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Relationship
The updated RelationshipMetadata for the relationship.

```yaml
Type: RelationshipMetadataBase
Parameter Sets: SetRelationshipByInputObject
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### None

## NOTES

## RELATED LINKS

[Add-CrmRelationship](Add-CrmRelationship.md)

[Get-CrmRelationship](Get-CrmRelationship.md)

[Set-CrmRelationshipCascadeConfig](Set-CrmRelationshipCascadeConfig.md)

[Remove-CrmRelationship](Remove-CrmRelationship.md)

[ManyToManyRelationshipMetadata Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.metadata.manytomanyrelationshipmetadata.aspx)

[OneToManyRelationshipMetadata Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.metadata.onetomanyrelationshipmetadata.aspx)
