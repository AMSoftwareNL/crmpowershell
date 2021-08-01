---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Unregister-CrmPlugin.md
schema: 2.0.0
---

# Unregister-CrmPlugin

## SYNOPSIS
Unregister a plugin.

## SYNTAX

```
Unregister-CrmPlugin [-Id] <Guid[]> [-Force] [<CommonParameters>]
```

## DESCRIPTION
Unregister a plugin.

## EXAMPLES

## PARAMETERS

### -Force
Executes the action without prompting for confirmation.

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: System.Guid[]
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid[]

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[Get-CrmPlugin](Get-CrmPlugin.md)

[Register-CrmPlugin](Register-CrmPlugin.md)

[Set-CrmPlugin](Set-CrmPlugin.md)
