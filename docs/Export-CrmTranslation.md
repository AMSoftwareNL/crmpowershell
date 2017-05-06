---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Export-CrmTranslation.html
schema: 2.0.0
---

# Export-CrmTranslation

## SYNOPSIS
Export all translations for a specific solution to a compressed file.

## SYNTAX

```
Export-CrmTranslation [-Solution] <Guid> [-Path] <String>
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
Type: String
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
Type: Guid
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

## INPUTS

### System.Guid


## OUTPUTS

### None

## NOTES

## RELATED LINKS

[Import-CrmTranslation](Import-CrmTranslation.md)
