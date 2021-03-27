---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Unregister-CrmPluginStep.md
schema: 2.0.0
---

# Unregister-CrmPluginStep

## SYNOPSIS
Unregister a SDK Messgae Processing Step.

## SYNTAX

```
Unregister-CrmPluginStep [-Id] <Guid[]> [-Force] [<CommonParameters>]
```

## DESCRIPTION
Unregister a SDK Messgae Processing Step.

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
The id of the SDK Messgae Processing Step to unregister.

```yaml
Type: Guid[]
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

### System.Guid[]

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[Disable-CrmPluginStep](Disable-CrmPluginStep.md)

[Enable-CrmPluginStep](Enable-CrmPluginStep.md)

[Get-CrmPluginStep](Get-CrmPluginStep.md)

[Register-CrmPluginStep](Register-CrmPluginStep.md)

[Set-CrmPluginStep](Set-CrmPluginStep.md)
