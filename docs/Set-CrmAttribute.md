---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Set-CrmAttribute.md
schema: 2.0.0
---

# Set-CrmAttribute

## SYNOPSIS
Update an attribute.

## SYNTAX

```
Set-CrmAttribute [-Entity] <String> [-InputObject] <AttributeMetadata> [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Update an attribute.

## EXAMPLES

## PARAMETERS

### -Entity
The LogicalName of the entity to update the attribute for.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The updated AttributeMetadata of the attribute.

```yaml
Type: Microsoft.Xrm.Sdk.Metadata.AttributeMetadata
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

### Microsoft.Xrm.Sdk.Metadata.AttributeMetadata

## OUTPUTS

### Microsoft.Xrm.Sdk.Metadata.AttributeMetadata

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

[AttributeMetadata Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.metadata.attributemetadata)
