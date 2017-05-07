---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/New-CrmWebresource.html
schema: 2.0.0
---

# New-CrmWebresource

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### NewWebresourceFromContent (Default)
```
New-CrmWebresource [-Name] <String> [-DisplayName <String>] [-Description <String>]
 -WebresourceType <CrmWebresourceType> -Content <Byte[]> [-IsCustomizable <Boolean>] [<CommonParameters>]
```

### NewWebresourceFromPath
```
New-CrmWebresource [-Name] <String> [-DisplayName <String>] [-Description <String>]
 -WebresourceType <CrmWebresourceType> -LiteralPath <String> [-IsCustomizable <Boolean>]
 [-Encoding <FileSystemCmdletProviderEncoding>] [<CommonParameters>]
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

### -Content
{{Fill Content Description}}

```yaml
Type: Byte[]
Parameter Sets: NewWebresourceFromContent
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Encoding
{{Fill Encoding Description}}

```yaml
Type: FileSystemCmdletProviderEncoding
Parameter Sets: NewWebresourceFromPath
Aliases: 
Accepted values: Unknown, String, Unicode, Byte, BigEndianUnicode, UTF8, UTF7, UTF32, Ascii, Default, Oem

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsCustomizable
{{Fill IsCustomizable Description}}

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

### -LiteralPath
{{Fill LiteralPath Description}}

```yaml
Type: String
Parameter Sets: NewWebresourceFromPath
Aliases: PSPath, Path

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
{{Fill Name Description}}

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

### -WebresourceType
{{Fill WebresourceType Description}}

```yaml
Type: CrmWebresourceType
Parameter Sets: (All)
Aliases: 
Accepted values: All, HTML, CSS, JS, XML, PNG, JPG, GIF, XAP, XSL, ICO

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Byte[]

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/New-CrmWebresource.html](http://crmpowershell.amsoftware.nl/New-CrmWebresource.html)

