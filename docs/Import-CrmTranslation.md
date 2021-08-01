---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Import-CrmTranslation.md
schema: 2.0.0
---

# Import-CrmTranslation

## SYNOPSIS
Import translations from a compressed file.

## SYNTAX

### ImportTranslationFromPath (Default)
```
Import-CrmTranslation [-Path] <String[]> [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ImportTranslationFromLiteralPath
```
Import-CrmTranslation [-LiteralPath] <String[]> [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Import translations from a compressed file.

## EXAMPLES

### Example 1
```
PS C:\> Import-CrmTranslation -Path c:\temp\product1-translations.zip
```

Import the translations from 'product1-translations.zip'.

## PARAMETERS

### -LiteralPath
The path to the file containing the translations.

```yaml
Type: System.String[]
Parameter Sets: ImportTranslationFromLiteralPath
Aliases: PSPath

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Path
The path to the file containing the translations.

```yaml
Type: System.String[]
Parameter Sets: ImportTranslationFromPath
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String[]

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[Export-CrmTranslation](Export-CrmTranslation.md)

[Entity Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.entity)
