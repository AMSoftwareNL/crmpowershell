---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Set-CrmAttribute.html
schema: 2.0.0
---

# Set-CrmAttribute

## SYNOPSIS
Update an attribute.

## SYNTAX

```
Set-CrmAttribute [-Entity] <String> [-Attribute] <AttributeMetadata> [<CommonParameters>]
```

## DESCRIPTION
Update an attribute.

## EXAMPLES

## PARAMETERS

### -Attribute
The updated AttributeMetadata of the attribute.

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
The LogicalName of the entity to update the attribute for.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

[Set-CrmBigIntAttribute](Set-CrmBigIntAttribute.md)

[Set-CrmBooleanAttribute](Set-CrmBooleanAttribute.md)

[Set-CrmDateTimeAttribute](Set-CrmDateTimeAttribute.md)

[Set-CrmDecimalAttribute](Set-CrmDecimalAttribute.md)

[Set-CrmDoubleAttribute](Set-CrmDoubleAttribute.md)

[Set-CrmImageAttribute](Set-CrmImageAttribute.md)

[Set-CrmIntegerAttribute](Set-CrmIntegerAttribute.md)

[Set-CrmMemoAttribute](Set-CrmMemoAttribute.md)

[Set-CrmMoneyAttribute](Set-CrmMoneyAttribute.md)

[Set-CrmOptionSetAttribute](Set-CrmOptionSetAttribute.md)

[Set-CrmStringAttribute](Set-CrmStringAttribute.md)

[AttributeMetadata Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.metadata.attributemetadata.aspx)
