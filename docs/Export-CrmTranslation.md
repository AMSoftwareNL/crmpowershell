---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Export-CrmTranslation.md
schema: 2.0.0
---

# Export-CrmTranslation

## SYNOPSIS
Export all translations for a specific solution to a compressed file.

## SYNTAX

```
Export-CrmTranslation [-Solution] <Guid> [-Path] <String> [<CommonParameters>]
```

## DESCRIPTION
Export all translations for a specific solution to a compressed file.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmSolution -Name 'product1' | Export-CrmTranslation -Path c:\temp\product1_translations.zip
```

Export the translation of solution 'product1'.

## PARAMETERS

### -Path
The file system path to export to translations to. This must include the filename.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Solution
The id of the solution to export the translations for.

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[Import-CrmTranslation](Import-CrmTranslation.md)
