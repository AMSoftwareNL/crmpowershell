---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmAttribute.md
schema: 2.0.0
---

# Get-CrmAttribute

## SYNOPSIS
Get the metadata of an attribute.

## SYNTAX

### GetAttributesByFilter (Default)
```
Get-CrmAttribute [-Entity] <String> [[-Name] <String>] [-Exclude <String>] [-CustomOnly] [-ExcludeManaged]
 [-IncludeLinked] [-AttributeType <String>] [<CommonParameters>]
```

### GetAttributeById
```
Get-CrmAttribute [-Id] <Guid> [<CommonParameters>]
```

## DESCRIPTION
Get the metadata of an attribute.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmAttribute -Entity account -Include 'address1*'
```

Get the metadata for the attributes on the entity 'account' whose LogicalName starts with 'address1'.

## PARAMETERS

### -AttributeType
The type of attribute to retrieve the metadata for.

Accepted values are:

 -- Any string matching an AttributeTypeDisplayName (Microsoft.Xrm.Sdk.Metadata.AttributeTypeDisplayName)

 -- Any string matching a member name of the AttributeTypeCode enumeration (Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode)

```yaml
Type: String
Parameter Sets: GetAttributesByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomOnly
Retrieve only the metadata for attributes that are marked as custom.

```yaml
Type: SwitchParameter
Parameter Sets: GetAttributesByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entity
The LogicalName of the entity to retrieve attribute metadata for.

NOTE: This parameter is case sensitive. i.e. it must match the case of the LogicalName exactly.

```yaml
Type: String
Parameter Sets: GetAttributesByFilter
Aliases: EntityLogicalName, LogicalName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Exclude
Exclude the metadata for attributes whose LogicalName matches the provided pattern.

```yaml
Type: String
Parameter Sets: GetAttributesByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExcludeManaged
Do not retrieve metadata for attributes that are marked as managed.

```yaml
Type: SwitchParameter
Parameter Sets: GetAttributesByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The MetadataId of the attribute to retrieve.

```yaml
Type: Guid
Parameter Sets: GetAttributeById
Aliases: MetadataId

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IncludeLinked
Include metadata for attributes marked as linked attributes. This are attributes automatically added by Dynamics CRM to store data of related entities.

```yaml
Type: SwitchParameter
Parameter Sets: GetAttributesByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The LogicalName of the attribute to retrieve the metadata for.

NOTE: This parameter is case sensitive. i.e. it must match the case of the LogicalName exactly.

```yaml
Type: String
Parameter Sets: GetAttributesByFilter
Aliases: Include

Required: False
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

### Microsoft.Xrm.Sdk.Metadata.AttributeMetadata

## NOTES
The Entity and Name parameters are case sensitive. i.e. these must match the case of the LogicalName exactly.

## RELATED LINKS

[Get-CrmEntity](Get-CrmEntity.md)

[Get-CrmEntityKey](Get-CrmEntityKey.md)

[Get-CrmOptionSet](Get-CrmOptionSet.md)

[Get-CrmRelationship](Get-CrmRelationship.md)

[Add-CrmAttribute](Add-CrmAttribute.md)

[Set-CrmAttribute](Set-CrmAttribute.md)

[Remove-CrmAttribute](Remove-CrmAttribute.md)

[AttributeMetadata Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.metadata.attributemetadata.aspx)

[AttributeTypeDisplayName Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.metadata.attributetypedisplayname.aspx)

[AttributeTypeCode Enumeration](https://msdn.microsoft.com/library/microsoft.xrm.sdk.metadata.attributetypecode.aspx)
