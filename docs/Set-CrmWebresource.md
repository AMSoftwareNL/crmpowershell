---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Set-CrmWebresource.html
schema: 2.0.0
---

# Set-CrmWebresource

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### SetWebresource (Default)
```
Set-CrmWebresource [-Id] <Guid> [-DisplayName <String>] [-Description <String>] [-IsCustomizable <Boolean>]
 [<CommonParameters>]
```

### SetWebresourceFromContent
```
Set-CrmWebresource [-Id] <Guid> [-DisplayName <String>] [-Description <String>] [-Content <Byte[]>]
 [-IsCustomizable <Boolean>] [<CommonParameters>]
```

### SetWebresourceFromPath
```
Set-CrmWebresource [-Id] <Guid> [-DisplayName <String>] [-Description <String>] [-LiteralPath <String>]
 [-IsCustomizable <Boolean>] [-Encoding <FileSystemCmdletProviderEncoding>] [<CommonParameters>]
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
Parameter Sets: SetWebresourceFromContent
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
Parameter Sets: SetWebresourceFromPath
Aliases: 
Accepted values: Unknown, String, Unicode, Byte, BigEndianUnicode, UTF8, UTF7, UTF32, Ascii, Default, Oem

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
{{Fill Id Description}}

```yaml
Type: Guid
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
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
Parameter Sets: SetWebresourceFromPath
Aliases: PSPath, Path

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/Set-CrmWebresource.html](http://crmpowershell.amsoftware.nl/Set-CrmWebresource.html)

