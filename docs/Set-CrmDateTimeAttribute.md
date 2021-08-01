---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Set-CrmDateTimeAttribute.md
schema: 2.0.0
---

# Set-CrmDateTimeAttribute

## SYNOPSIS
Update an attribute of type DateTime.

## SYNTAX

```
Set-CrmDateTimeAttribute [-Format <CrmDateTimeAttributeFormat>] [-ImeType <CrmImeType>]
 [-CanChangeBehavior <Boolean>] [-Behavior <CrmDateTimeBehavior>] [-Entity] <String> [-Name] <String>
 [-DisplayName <String>] [-Description <String>] [-ExternalName <String>]
 [-CanModifyAdditionalSettings <Boolean>] [-IsAuditEnabled <Boolean>] [-IsCustomizable <Boolean>]
 [-IsRenameable <Boolean>] [-IsSecured <Boolean>] [-IsValidForAdvancedFind <Boolean>]
 [-Required <CrmRequiredLevel>] [-IsGlobalFilterEnabled <Boolean>] [-IsSortableEnabled <Boolean>] [-PassThru]
 [<CommonParameters>]
```

## DESCRIPTION
Update an attribute of type DateTime.

## EXAMPLES

## PARAMETERS

### -Behavior
The behavior of the attribute.

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmDateTimeBehavior
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
Type: System.Boolean
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
Type: System.Boolean
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
Type: System.String
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
Type: System.String
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
Type: System.String
Parameter Sets: (All)
Aliases: EntityLogicalName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ExternalName
The ExternalName when used in a Virtual Entity

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Format
The date/time display format.

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmDateTimeAttributeFormat
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
Type: AMSoftware.Crm.PowerShell.Common.CrmImeType
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
Type: System.Boolean
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
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsGlobalFilterEnabled
Determines whether this column appears as an available filter when using interactive experiences dashboards.

```yaml
Type: System.Boolean
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
Type: System.Boolean
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
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsSortableEnabled
Determines whether data can be sorted by this column when using interactive experience dashboards.

```yaml
Type: System.Boolean
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
Type: System.Boolean
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
Type: System.String
Parameter Sets: (All)
Aliases: LogicalName

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PassThru
Returns an object that represents the DateTimeAttributeMetadata. By default, this cmdlet does not generate any output.

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

### -Required
The data entry requirement level enforced for the attribute.

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmRequiredLevel
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

### Microsoft.Xrm.Sdk.Metadata.DateTimeAttributeMetadata

## NOTES

## RELATED LINKS

[Set-CrmBigIntAttribute](Set-CrmBigIntAttribute.md)

[Set-CrmBooleanAttribute](Set-CrmBooleanAttribute.md)

[Set-CrmDecimalAttribute](Set-CrmDecimalAttribute.md)

[Set-CrmDoubleAttribute](Set-CrmDoubleAttribute.md)

[Set-CrmImageAttribute](Set-CrmImageAttribute.md)

[Set-CrmIntegerAttribute](Set-CrmIntegerAttribute.md)

[Set-CrmMemoAttribute](Set-CrmMemoAttribute.md)

[Set-CrmMoneyAttribute](Set-CrmMoneyAttribute.md)

[Set-CrmOptionSetAttribute](Set-CrmOptionSetAttribute.md)

[Set-CrmStringAttribute](Set-CrmStringAttribute.md)

[DateTimeAttributeMetadata Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.metadata.datetimeattributemetadata)
