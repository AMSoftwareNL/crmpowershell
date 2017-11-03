---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Add-CrmOptionSetAttribute.md
schema: 2.0.0
---

# Add-CrmOptionSetAttribute

## SYNOPSIS
Add an attribute of type OptionSet.

## SYNTAX

### AddOptionSetNew (Default)
```
Add-CrmOptionSetAttribute [-DefaultValue <Int32>] [-Values <PSOptionSetValue[]>] [-Entity] <String>
 [-Name] <String> [-DisplayName] <String> [-Description <String>] [-CanModifyAdditionalSettings <Boolean>]
 [-IsAuditEnabled <Boolean>] [-IsCustomizable <Boolean>] [-IsRenameable <Boolean>] [-IsSecured <Boolean>]
 [-IsValidForAdvancedFind <Boolean>] [-Required <CrmRequiredLevel>] [-SchemaName <String>] [-PassThru]
 [-IsGlobalFilterEnabled <Boolean>] [-IsSortableEnabled <Boolean>] [<CommonParameters>]
```

### AddOptionSetExisting
```
Add-CrmOptionSetAttribute -OptionSet <String> [-Entity] <String> [-Name] <String> [-DisplayName] <String>
 [-Description <String>] [-CanModifyAdditionalSettings <Boolean>] [-IsAuditEnabled <Boolean>]
 [-IsCustomizable <Boolean>] [-IsRenameable <Boolean>] [-IsSecured <Boolean>]
 [-IsValidForAdvancedFind <Boolean>] [-Required <CrmRequiredLevel>] [-SchemaName <String>] [-PassThru]
 [-IsGlobalFilterEnabled <Boolean>] [-IsSortableEnabled <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
Add an attribute of type OptionSet.

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
Type: Int32
Parameter Sets: AddOptionSetNew
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

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entity
The LogicalName of the entity to add the attribute to.

```yaml
Type: String
Parameter Sets: (All)
Aliases: EntityLogicalName, LogicalName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
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
The LogicalName for the attribute.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionSet
The name of an existing global optionset to associate with the attribute.

```yaml
Type: String
Parameter Sets: AddOptionSetExisting
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns an object that represents the PicklistAttributeMetadata. By default, this cmdlet does not generate any output.

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

### -SchemaName
The SchemaName for the attribute. If omitted the Name will be used as the SchemaName.

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

### -Values
The OptionSetValues available in the attribute.

```yaml
Type: PSOptionSetValue[]
Parameter Sets: AddOptionSetNew
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

### Microsoft.Xrm.Sdk.Metadata.PicklistAttributeMetadata

## NOTES

## RELATED LINKS

[New-CrmOptionSetValue](New-CrmOptionSetValue.md)

[Add-CrmBigIntAttribute](Add-CrmBigIntAttribute.md)

[Add-CrmBooleanAttribute](Add-CrmBooleanAttribute.md)

[Add-CrmDateTimeAttribute](Add-CrmDateTimeAttribute.md)

[Add-CrmDecimalAttribute](Add-CrmDecimalAttribute.md)

[Add-CrmDoubleAttribute](Add-CrmDoubleAttribute.md)

[Add-CrmImageAttribute](Add-CrmImageAttribute.md)

[Add-CrmIntegerAttribute](Add-CrmIntegerAttribute.md)

[Add-CrmMemoAttribute](Add-CrmMemoAttribute.md)

[Add-CrmMoneyAttribute](Add-CrmMoneyAttribute.md)

[Add-CrmStringAttribute](Add-CrmStringAttribute.md)

[PicklistAttributeMetadata Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.metadata.picklistattributemetadata.aspx)
