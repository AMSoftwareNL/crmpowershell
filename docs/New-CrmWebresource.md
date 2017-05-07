---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/New-CrmWebresource.html
schema: 2.0.0
---

# New-CrmWebresource

## SYNOPSIS
Add new new webresource.

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
Add new new webresource.

## EXAMPLES

## PARAMETERS

### -Content
The content for the webresource.

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
The description for the webresource.

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
The displayname for the webresource.

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
The encoding to use reading the content for the file system.

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
Whether the webresource is customizable.

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
The path to a file the get the content of the webresource from.

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
The name for the webresource.

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
The type of the webresource.

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

[Export-CrmWebresource](Export-CrmWebresource.md)

[Get-CrmWebresource](Get-CrmWebresource.md)

[Import-CrmWebresource](Import-CrmWebresource.md)

[Remove-CrmWebresource](Remove-CrmWebresource.md)

[Set-CrmWebresource](Set-CrmWebresource.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
