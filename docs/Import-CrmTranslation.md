---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Import-CrmTranslation.html
schema: 2.0.0
---

# Import-CrmTranslation

## SYNOPSIS
Import translations from a compressed file.

## SYNTAX

### ImportTranslationFromPath (Default)
```
Import-CrmTranslation [-Path] <String[]> [-WhatIf] [-Confirm]
```

### ImportTranslationFromLiteralPath
```
Import-CrmTranslation [-LiteralPath] <String[]> [-WhatIf] [-Confirm]
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
Type: String[]
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
Type: String[]
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
Type: SwitchParameter
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### System.String[]


## OUTPUTS

### Microsoft.Xrm.Sdk.Entity


## NOTES

## RELATED LINKS

[Export-CrmTranslation](Export-CrmTranslation.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
