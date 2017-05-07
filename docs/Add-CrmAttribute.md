---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Add-CrmAttribute.html
schema: 2.0.0
---

# Add-CrmAttribute

## SYNOPSIS
Add an attribute to an entity.

## SYNTAX

```
Add-CrmAttribute [-Entity] <String> [-Attribute] <AttributeMetadata>
```

## DESCRIPTION
Add an attribute to an entity.

## EXAMPLES


## PARAMETERS

### -Attribute
The AttributeMetadata of the attribute to add.

```yaml
Type: AttributeMetadata
Parameter Sets: (All)
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entity
The LogicalName of the entity to add the attribute to.

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

## INPUTS

### None


## OUTPUTS

### Microsoft.Xrm.Sdk.Metadata.AttributeMetadata


## NOTES

## RELATED LINKS

[Add-CrmBigIntAttribute](Add-CrmBigIntAttribute.md)

[Add-CrmBooleanAttribute](Add-CrmBooleanAttribute.md)

[Add-CrmDateTimeAttribute](Add-CrmDateTimeAttribute.md)

[Add-CrmDecimalAttribute](Add-CrmDecimalAttribute.md)

[Add-CrmDoubleAttribute](Add-CrmDoubleAttribute.md)

[Add-CrmImageAttribute](Add-CrmImageAttribute.md)

[Add-CrmIntegerAttribute](Add-CrmIntegerAttribute.md)

[Add-CrmMemoAttribute](Add-CrmMemoAttribute.md)

[Add-CrmMoneyAttribute](Add-CrmMoneyAttribute.md)

[Add-CrmOptionSetAttribute](Add-CrmOptionSetAttribute.md)

[Add-CrmStringAttribute](Add-CrmStringAttribute.md)

[AttributeMetadata Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.metadata.attributemetadata.aspx)
