---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Import-CrmWebresource.md
schema: 2.0.0
---

# Import-CrmWebresource

## SYNOPSIS
Import content for an existing webresource.

## SYNTAX

### ImportWebresourceFromValue
```
Import-CrmWebresource [-Id] <Guid> -Value <Byte[]> [-PassThru] [<CommonParameters>]
```

### ImportWebresourceFromPath
```
Import-CrmWebresource [-Id] <Guid> -LiteralPath <String> [-PassThru] [<CommonParameters>]
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

### -PassThru
Returns an object that represents the WebResource. By default, this cmdlet does not generate any output.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[Export-CrmWebresource](Export-CrmWebresource.md)

[Get-CrmWebresource](Get-CrmWebresource.md)

[New-CrmWebresource](New-CrmWebresource.md)

[Remove-CrmWebresource](Remove-CrmWebresource.md)

[Set-CrmWebresource](Set-CrmWebresource.md)
