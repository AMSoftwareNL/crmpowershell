---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Import-CrmWebresource.html
schema: 2.0.0
---

# Import-CrmWebresource

## SYNOPSIS
Import content for an existing webresource.

## SYNTAX

### ImportWebresourceFromValue
```
Import-CrmWebresource [-Id] <Guid> -Value <Byte[]>
```

### ImportWebresourceFromPath
```
Import-CrmWebresource [-Id] <Guid> -LiteralPath <String> [-Encoding <FileSystemCmdletProviderEncoding>]
```

## DESCRIPTION
Import content for an existing webresource.

## EXAMPLES

### Example 1
```
PS C:\> Import-CrmWebresource -Id '49C1B629-DEAB-4EBD-9A37-2E4477ABAD9A' -LiteralPath c:\temp\NewAccount.js -Encoding UTF8
```

Import the content from NewAccount.js into the specified webresource.

## PARAMETERS

### -Encoding
The encoding to use when reading the file from the filesystem.

```yaml
Type: FileSystemCmdletProviderEncoding
Parameter Sets: ImportWebresourceFromPath
Aliases: 
Accepted values: Unknown, String, Unicode, Byte, BigEndianUnicode, UTF8, UTF7, UTF32, Ascii, Default, Oem

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The id of the webresource to import the content for.

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

### -LiteralPath
The path to the file containing the content for the webresource.

```yaml
Type: String
Parameter Sets: ImportWebresourceFromPath
Aliases: PSPath, Path

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
A byte-array containing the content for the webresource to import.

```yaml
Type: Byte[]
Parameter Sets: ImportWebresourceFromValue
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### System.Guid


## OUTPUTS

### None

## NOTES

## RELATED LINKS

[Export-CrmWebresource](Export-CrmWebresource.md)

[Get-CrmWebresource](Get-CrmWebresource.md)

[New-CrmWebresource](New-CrmWebresource.md)

[Remove-CrmWebresource](Remove-CrmWebresource.md)

[Set-CrmWebresource](Set-CrmWebresource.md)
