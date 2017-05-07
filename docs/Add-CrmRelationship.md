---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Add-CrmRelationship.html
schema: 2.0.0
---

# Add-CrmRelationship

## SYNOPSIS
Add a relationship.

## SYNTAX

### AddManyToManyRelationship
```
Add-CrmRelationship [-Entity1] <String> [-Entity2] <String> [-Name] <String> [-IntersectName] <String>
 [-AdvancedFind <Boolean>] [-Customizable <Boolean>] [<CommonParameters>]
```

### AddOneToManyRelationship
```
Add-CrmRelationship [-Entity] <String> [-ToEntity] <String> [-Name] <String> -AttributeName <String>
 -AttributeDisplayName <String> [-AttributeDescription <String>] [-AttributeRequired <CrmRequiredLevel>]
 [-AdvancedFind <Boolean>] [-Customizable <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
Add a relationship.

## EXAMPLES

## PARAMETERS

### -AdvancedFind
Whether the relationship appears in Advanced Find.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributeDescription
The description for the lookup attribute.

```yaml
Type: String
Parameter Sets: AddOneToManyRelationship
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributeDisplayName
The displayname for the lookup attribute.

```yaml
Type: String
Parameter Sets: AddOneToManyRelationship
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributeName
The LogicalName for the lookup attribute

```yaml
Type: String
Parameter Sets: AddOneToManyRelationship
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributeRequired
The data entry requirement level enforced for the lookup attribute.

```yaml
Type: CrmRequiredLevel
Parameter Sets: AddOneToManyRelationship
Aliases: 
Accepted values: Unknown, Required, Recommended, Optional

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
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entity
The entity to add the one-to-many relationship for.

```yaml
Type: String
Parameter Sets: AddOneToManyRelationship
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entity1
The entity to add the many-to-many relationship for.

```yaml
Type: String
Parameter Sets: AddManyToManyRelationship
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entity2
The entity to add the many-to-many relationship for.

```yaml
Type: String
Parameter Sets: AddManyToManyRelationship
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IntersectName
The LogicalName for the intersect entity to create.

```yaml
Type: String
Parameter Sets: AddManyToManyRelationship
Aliases: 

Required: True
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The SchemaName of the relationship.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ToEntity
The entity to add the one-to-many relationship to.

```yaml
Type: String
Parameter Sets: AddOneToManyRelationship
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Xrm.Sdk.Metadata.RelationshipMetadataBase

## NOTES

## RELATED LINKS

[Get-CrmRelationship](Get-CrmRelationship.md)

[Set-CrmRelationship](Set-CrmRelationship.md)

[Set-CrmRelationshipCascadeConfig](Set-CrmRelationshipCascadeConfig.md)

[Remove-CrmRelationship](Remove-CrmRelationship.md)

[ManyToManyRelationshipMetadata Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.metadata.manytomanyrelationshipmetadata.aspx)

[OneToManyRelationshipMetadata Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.metadata.onetomanyrelationshipmetadata.aspx)
