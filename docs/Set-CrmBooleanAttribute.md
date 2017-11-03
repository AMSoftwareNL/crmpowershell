---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Set-CrmBooleanAttribute.md
schema: 2.0.0
---

# Set-CrmBooleanAttribute

## SYNOPSIS
Update an attribute of type Boolean.

## SYNTAX

```
Set-CrmBooleanAttribute [-DefaultValue <Boolean>] [-TrueValue <PSOptionSetValue>]
 [-FalseValue <PSOptionSetValue>] [-Entity] <String> [-Name] <String> [-DisplayName <String>]
 [-Description <String>] [-CanModifyAdditionalSettings <Boolean>] [-IsAuditEnabled <Boolean>]
 [-IsCustomizable <Boolean>] [-IsRenameable <Boolean>] [-IsSecured <Boolean>]
 [-IsValidForAdvancedFind <Boolean>] [-Required <CrmRequiredLevel>] [-PassThru]
 [-IsGlobalFilterEnabled <Boolean>] [-IsSortableEnabled <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
Update an attribute of type Boolean.

## EXAMPLES

## PARAMETERS

### -CanModifyAdditionalSettings
Whether any settings not controlled by managed properties can be changed.

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

### -DefaultValue
The default form value for the attribute.

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

### -Description
The description of the attribute.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
The display name for the attribute.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entity
The LogicalName of the entity containing the attribute.

```yaml
Type: String
Parameter Sets: (All)
Aliases: EntityLogicalName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -FalseValue
OptionSetValue to assign to the false choice of the boolean.

```yaml
Type: PSOptionSetValue
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsAuditEnabled
Whether the attribute is enabled for auditing.

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

### -IsCustomizable
Whether the attribute is a custom attribute.

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

### -IsGlobalFilterEnabled
Whether the attribute is enabled for global filtering.

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

### -IsRenameable
Whether the attribute display name can be changed.

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

### -IsSecured
Whether the attribute is secured for field-level security.

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

### -IsSortableEnabled
Whether the attribute is sortable.

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

### -IsValidForAdvancedFind
Whether the attribute appears in Advanced Find.

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

### -Name
The LogicalName of the attribute to update.

```yaml
Type: String
Parameter Sets: (All)
Aliases: LogicalName

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PassThru
Returns an object that represents the BooleanAttributeMetadata. By default, this cmdlet does not generate any output.

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

### -Required
The data entry requirement level enforced for the attribute.

```yaml
Type: CrmRequiredLevel
Parameter Sets: (All)
Aliases: 
Accepted values: Unknown, Required, Recommended, Optional

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrueValue
OptionSetValue to assign to the true choice of the boolean.

```yaml
Type: PSOptionSetValue
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

### None

## NOTES

## RELATED LINKS

[Set-CrmBigIntAttribute](Set-CrmBigIntAttribute.md)

[Set-CrmDateTimeAttribute](Set-CrmDateTimeAttribute.md)

[Set-CrmDecimalAttribute](Set-CrmDecimalAttribute.md)

[Set-CrmDoubleAttribute](Set-CrmDoubleAttribute.md)

[Set-CrmImageAttribute](Set-CrmImageAttribute.md)

[Set-CrmIntegerAttribute](Set-CrmIntegerAttribute.md)

[Set-CrmMemoAttribute](Set-CrmMemoAttribute.md)

[Set-CrmMoneyAttribute](Set-CrmMoneyAttribute.md)

[Set-CrmOptionSetAttribute](Set-CrmOptionSetAttribute.md)

[Set-CrmStringAttribute](Set-CrmStringAttribute.md)

[BooleanAttributeMetadata Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.metadata.booleanattributemetadata.aspx)
