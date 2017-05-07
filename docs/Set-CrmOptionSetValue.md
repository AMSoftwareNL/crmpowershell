---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Set-CrmOptionSetValue.html
schema: 2.0.0
---

# Set-CrmOptionSetValue

## SYNOPSIS
{{Fill in the Synopsis}}

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
{{Fill in the Description}}

## EXAMPLES

### Example 1
```
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Attribute
{{Fill Attribute Description}}

```yaml
Type: String
Parameter Sets: SetOptionSetValueEntity
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
{{Fill Description Description}}

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
{{Fill DisplayName Description}}

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
{{Fill Entity Description}}

```yaml
Type: String
Parameter Sets: SetOptionSetValueEntity
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionSet
{{Fill OptionSet Description}}

```yaml
Type: String
Parameter Sets: SetOptionSetValueGlobal
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
{{Fill Value Description}}

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

### System.Object

## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/Set-CrmOptionSetValue.html](http://crmpowershell.amsoftware.nl/Set-CrmOptionSetValue.html)

