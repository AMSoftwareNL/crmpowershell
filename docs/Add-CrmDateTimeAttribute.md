---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Add-CrmDateTimeAttribute.md
schema: 2.0.0
---

# Add-CrmDateTimeAttribute

## SYNOPSIS
Add an attribute of type DateTime.

## SYNTAX

```
Add-CrmDateTimeAttribute [-Format <CrmDateTimeAttributeFormat>] [-ImeType <CrmImeType>]
 [-CanChangeBehavior <Boolean>] [-Behavior <CrmDateTimeBehavior>] [-Entity] <String> [-Name] <String>
 [-DisplayName] <String> [-Description <String>] [-CanModifyAdditionalSettings <Boolean>]
 [-IsAuditEnabled <Boolean>] [-IsCustomizable <Boolean>] [-IsRenameable <Boolean>] [-IsSecured <Boolean>]
 [-IsValidForAdvancedFind <Boolean>] [-Required <CrmRequiredLevel>] [-SchemaName <String>] [-PassThru]
 [<CommonParameters>]
```

## DESCRIPTION
Add an attribute of type DateTime.

## EXAMPLES

## PARAMETERS

### -Behavior
The behavior of the attribute.

```yaml
Type: CrmDateTimeBehavior
Parameter Sets: (All)
Aliases:
Accepted values: UserSettings, DateOnly, TimeZoneIndependent

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CanChangeBehavior
Whether the date and time behavior can be changed for the attribute.

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

### -Format
The date/time display format.
 


```yaml
Type: CrmDateTimeAttributeFormat
Parameter Sets: (All)
Aliases:
Accepted values: DateOnly, DateAndTime

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImeType
The input method editor (IME) mode for the attribute.

```yaml
Type: CrmImeType
Parameter Sets: (All)
Aliases:
Accepted values: Auto, Active, Disabled, Inactive

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

### -PassThru
Returns an object that represents the DateTimeAttributeMetadata. By default, this cmdlet does not generate any output.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
## OUTPUTS

### Microsoft.Xrm.Sdk.Metadata.DateTimeAttributeMetadata
## NOTES

## RELATED LINKS

[Add-CrmBigIntAttribute](Add-CrmBigIntAttribute.md)

[Add-CrmBooleanAttribute](Add-CrmBooleanAttribute.md)

[Add-CrmDecimalAttribute](Add-CrmDecimalAttribute.md)

[Add-CrmDoubleAttribute](Add-CrmDoubleAttribute.md)

[Add-CrmImageAttribute](Add-CrmImageAttribute.md)

[Add-CrmIntegerAttribute](Add-CrmIntegerAttribute.md)

[Add-CrmMemoAttribute](Add-CrmMemoAttribute.md)

[Add-CrmMoneyAttribute](Add-CrmMoneyAttribute.md)

[Add-CrmOptionSetAttribute](Add-CrmOptionSetAttribute.md)

[Add-CrmStringAttribute](Add-CrmStringAttribute.md)

[DateTimeAttributeMetadata Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.metadata.datetimeattributemetadata.aspx)
