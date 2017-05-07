---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/New-CrmOptionSet.html
schema: 2.0.0
---

# New-CrmOptionSet

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### NewOptionSetByInputObject
```
New-CrmOptionSet [-OptionSet] <OptionSetMetadata> [<CommonParameters>]
```

### NewOptionSet
```
New-CrmOptionSet [-Name] <String> [-DisplayName] <String> [-Values] <PSOptionSetValue[]>
 [-Description <String>] [-Customizable <Boolean>] [<CommonParameters>]
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

### -Customizable
{{Fill Customizable Description}}

```yaml
Type: Boolean
Parameter Sets: NewOptionSet
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
{{Fill Description Description}}

```yaml
Type: String
Parameter Sets: NewOptionSet
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
Parameter Sets: NewOptionSet
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
{{Fill Name Description}}

```yaml
Type: String
Parameter Sets: NewOptionSet
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
Type: OptionSetMetadata
Parameter Sets: NewOptionSetByInputObject
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Values
{{Fill Values Description}}

```yaml
Type: PSOptionSetValue[]
Parameter Sets: NewOptionSet
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Xrm.Sdk.Metadata.OptionSetMetadata

## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/New-CrmOptionSet.html](http://crmpowershell.amsoftware.nl/New-CrmOptionSet.html)

