---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Set-CrmOptionSetValue.md
schema: 2.0.0
---

# Set-CrmOptionSetValue

## SYNOPSIS
Update the value of an optionset.

## SYNTAX

### SetOptionSetValueGlobal (Default)
```
Set-CrmOptionSetValue [-OptionSet] <String> [-Value <Int32>] [-DisplayName <String>] [-Description <String>]
 [<CommonParameters>]
```

### SetOptionSetValueEntity
```
Set-CrmOptionSetValue [-Entity] <String> [-Attribute] <String> [-Value <Int32>] [-DisplayName <String>]
 [-Description <String>] [<CommonParameters>]
```

## DESCRIPTION
Update the value of an optionset.

## EXAMPLES

## PARAMETERS

### -Attribute
The LogicalName of the Attribute to update.

```yaml
Type: String
Parameter Sets: SetOptionSetValueEntity
Aliases: LogicalName

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Description
The description for the optionset value.

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
The displayname for the optionset value.

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
The LogicalName of the entity to update.

```yaml
Type: String
Parameter Sets: SetOptionSetValueEntity
Aliases: EntityLogicalName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -OptionSet
The name of the global optionset to update.

```yaml
Type: String
Parameter Sets: SetOptionSetValueGlobal
Aliases: Name

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Value
The value of the optionset value to update.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### None

## NOTES

## RELATED LINKS

[New-CrmOptionSetValue](New-CrmOptionSetValue.md)

[Remove-CrmOptionSetValue](Remove-CrmOptionSetValue.md)
