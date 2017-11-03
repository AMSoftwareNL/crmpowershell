---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmRelationship.md
schema: 2.0.0
---

# Get-CrmRelationship

## SYNOPSIS
Get the metadata of a relationship.

## SYNTAX

### GetRelationshipByFilter (Default)
```
Get-CrmRelationship [[-Entity] <String>] [[-RelatedEntity] <String>] [-Include <String>] [-Exclude <String>]
 [-Type <CrmRelationshipType>] [-CustomOnly] [-ExcludeManaged] [<CommonParameters>]
```

### GetRelationshipByName
```
Get-CrmRelationship [-Name] <String> [<CommonParameters>]
```

### GetRelationshipById
```
Get-CrmRelationship [-Id] <Guid> [<CommonParameters>]
```

## DESCRIPTION
Get the metadata of a relationship. Relationship can be one-to-many or many-to-many.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmRelationship -Entity account -RelatedEntity contact -Type OneToMany
```

Get the metadata for the one-to-many relationships between the entities 'account' and 'contact'.

## PARAMETERS

### -CustomOnly
Retrieve only the metadata for relationships that are marked as custom.

```yaml
Type: SwitchParameter
Parameter Sets: GetRelationshipByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entity
The LogicalName of the entity to retrieve relationship metadata for.

NOTE: This parameter is case sensitive. i.e. it must match the case of the LogicalName exactly.

```yaml
Type: String
Parameter Sets: GetRelationshipByFilter
Aliases: EntityLogicalName, LogicalName

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Exclude
Exclude the metadata for relationships whose SchemaName matches the provided pattern.

```yaml
Type: String
Parameter Sets: GetRelationshipByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExcludeManaged
Do not retrieve metadata for relationships that are marked as managed.

```yaml
Type: SwitchParameter
Parameter Sets: GetRelationshipByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The MetadataId of the relationship to retrieve.

```yaml
Type: Guid
Parameter Sets: GetRelationshipById
Aliases: MetadataId

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Include
Include the metadata for relationships whose SchemaName matches the provided pattern.

```yaml
Type: String
Parameter Sets: GetRelationshipByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The SchemaName of the relationship to retrieve the metadata for.

NOTE: This parameter is case sensitive. i.e. it must match the case of the SchemaName exactly.

```yaml
Type: String
Parameter Sets: GetRelationshipByName
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RelatedEntity
The LogicalName of the related entity participating in the relationship to retrieve the metadata for.

```yaml
Type: String
Parameter Sets: GetRelationshipByFilter
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
The type of relationship to retrieve the metadata for.

Accepted values are:

 -- All : (Default) Retrieve all types of relationships.

 -- OneToMany : Only retrieve the metadata for one-to-many relationships.
 
 -- ManyTOMany : Only retrieve the metadata for many-to-many relationships.

```yaml
Type: CrmRelationshipType
Parameter Sets: GetRelationshipByFilter
Aliases: 
Accepted values: All, OneToMany, ManyToMany

Required: False
Position: Named
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
The Entity, RelatedEntity and Name parameters are case sensitive. i.e. these must match the case of the LogicalName or SchemaName exactly.

## RELATED LINKS

[Get-CrmEntity](Get-CrmEntity.md)

[Get-CrmAttribute](Get-CrmAttribute.md)

[Get-CrmEntityKey](Get-CrmEntityKey.md)

[Get-CrmOptionSet](Get-CrmOptionSet.md)

[Add-CrmRelationship](Add-CrmRelationship.md)

[Set-CrmRelationship](Set-CrmRelationship.md)

[Set-CrmRelationshipCascadeConfig](Set-CrmRelationshipCascadeConfig.md)

[Remove-CrmRelationship](Remove-CrmRelationship.md)

[ManyToManyRelationshipMetadata Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.metadata.manytomanyrelationshipmetadata.aspx)

[OneToManyRelationshipMetadata Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.metadata.onetomanyrelationshipmetadata.aspx)
