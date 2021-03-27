---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Set-CrmStringAttribute.md
schema: 2.0.0
---

# Set-CrmStringAttribute

## SYNOPSIS
Update an attribute of type String.

## SYNTAX

```
Set-CrmStringAttribute [-Format <CrmStringAttributeFormat>] [-ImeType <CrmImeType>] [-Length <Int32>]
 [-Entity] <String> [-Name] <String> [-DisplayName <String>] [-Description <String>]
 [-CanModifyAdditionalSettings <Boolean>] [-IsAuditEnabled <Boolean>] [-IsCustomizable <Boolean>]
 [-IsRenameable <Boolean>] [-IsSecured <Boolean>] [-IsValidForAdvancedFind <Boolean>]
 [-Required <CrmRequiredLevel>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Update an attribute of type String.

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

### -Format
The format options for the string attribute.

```yaml
Type: CrmStringAttributeFormat
Parameter Sets: (All)
Aliases:
Accepted values: Text, Email, Phone, PhoneticGuide, TextArea, TickerSymbol, Url, VersionNumber

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

### -Length
The maximum length for the attribute.

```yaml
Type: Int32
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
Returns an object that represents the StringAttributeMetadata. By default, this cmdlet does not generate any output.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Xrm.Sdk.Metadata.StringAttributeMetadata

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

[StringAttributeMetadata Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.metadata.stringattributemetadata.aspx)
