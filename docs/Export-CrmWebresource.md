---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Export-CrmWebresource.md
schema: 2.0.0
---

# Export-CrmWebresource

## SYNOPSIS
Export the content of a webresource to the pipeline.

## SYNTAX

```
Export-CrmWebresource [-Id] <Guid> [-Encoding <FileSystemCmdletProviderEncoding>] [<CommonParameters>]
```

## DESCRIPTION
Export the content of a webresource to the file system.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmWebResource -WebResourceType JS | Export-CrmWebResource -Encoding UTF8
```

Export the content of all JavaScript webresource to the pipeline.

## PARAMETERS

### -Encoding
The encoding to apply to the exported content. If not provided byte encoding is used.

```yaml
Type: FileSystemCmdletProviderEncoding
Parameter Sets: (All)
Aliases: 
Accepted values: Unknown, String, Unicode, Byte, BigEndianUnicode, UTF8, UTF7, UTF32, Ascii, Default, Oem, BigEndianUTF32

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The id of the webresource to export.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

[Get-CrmWebresource](Get-CrmWebresource.md)

[Import-CrmWebresource](Import-CrmWebresource.md)

[New-CrmWebresource](New-CrmWebresource.md)

[Remove-CrmWebresource](Remove-CrmWebresource.md)

[Set-CrmWebresource](Set-CrmWebresource.md)
