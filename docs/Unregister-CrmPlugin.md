---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Unregister-CrmPlugin.html
schema: 2.0.0
---

# Unregister-CrmPlugin

## SYNOPSIS
Unregister a plugin.

## SYNTAX

```
Unregister-CrmPlugin [-Id] <Guid> [-Force] [<CommonParameters>]
```

## DESCRIPTION
Unregister a plugin.

## EXAMPLES

## PARAMETERS

### -Force
Executes the action without prompting for confirmation.

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

### -Id
The id of the plugin to unregister.

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

### None

## NOTES

## RELATED LINKS

[Get-CrmPlugin](Get-CrmPlugin.md)

[Register-CrmPlugin](Register-CrmPlugin.md)

[Set-CrmPlugin](Set-CrmPlugin.md)
