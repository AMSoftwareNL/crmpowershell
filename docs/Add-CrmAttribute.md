---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Add-CrmAttribute.md
schema: 2.0.0
---

# Add-CrmAttribute

## SYNOPSIS
Add an attribute to an entity.

## SYNTAX

```
Add-CrmAttribute [-Entity] <String> [-InputObject] <AttributeMetadata> [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Add an attribute to an entity.

## EXAMPLES

## PARAMETERS

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

### -InputObject
The AttributeMetadata of the attribute to add.

```yaml
Type: AttributeMetadata
Parameter Sets: (All)
Aliases: Attribute

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns an object that represents the AttributeMetadata. By default, this cmdlet does not generate any output.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

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
