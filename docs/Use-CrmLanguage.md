---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Use-CrmLanguage.html
schema: 2.0.0
---

# Use-CrmLanguage

## SYNOPSIS
Set the active language to use in the PowerShell session.

## SYNTAX

```
Use-CrmLanguage [[-Language] <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Set the active language to use in the PowerShell session. This must be one of the installed languages in Dynamics CRM. Omit the language to return to the default (base) language of Dynamics CRM.

Setting the language will affect all properties of type Label (Microsoft.Xrm.Sdk.Label) like DisplayName and Description for metadata. These will be returned in the active language of the session, and when set the provided text will set to the Label of the active language. This last is used to set multi language Labels for metadat.

## EXAMPLES

### Example 1
```
PS C:\> Use-CrmLanguage -Language 1043
```

Set the active language of the session to Dutch.

### Example 2
```
PS C:\> Use-CrmLanguage -Language 1033
PS C:\> Set-CrmEntity -Name account -DisplayName 'Organization'
PS C:\> Use-CrmLanguage -Language 1043
PS C:\> Set-CrmEntity -Name account -DisplayName 'Organisatie'
```

Set the DisplayName for the entity 'account' for English and Dutch.

## PARAMETERS

### -Language
The LCID of the language to set. Omit this parameter to reset to the default (base) language.

The provide LCID must match an installed languagepack.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Int32

## OUTPUTS

### None

## NOTES

## RELATED LINKS

[Get-CrmLanguage](Get-CrmLanguage.md)
