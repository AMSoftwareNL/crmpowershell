---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Import-CrmWebresource.html
schema: 2.0.0
---

# Import-CrmWebresource

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### ImportWebresourceFromValue
```
Import-CrmWebresource [-Id] <Guid> -Value <Byte[]>
```

### ImportWebresourceFromPath
```
Import-CrmWebresource [-Id] <Guid> -Path <String> [-Encoding <FileSystemCmdletProviderEncoding>]
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

### -Encoding
{{Fill Encoding Description}}

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

### -Path
{{Fill Path Description}}

```yaml
Type: String
Parameter Sets: ImportWebresourceFromPath
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
{{Fill Value Description}}

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

### System.Object

## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/Import-CrmWebresource.html](http://crmpowershell.amsoftware.nl/Import-CrmWebresource.html)

