---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Disable-CrmPluginStep.md
schema: 2.0.0
---

# Disable-CrmPluginStep

## SYNOPSIS
Disable a SDK Message Processing Step.

## SYNTAX

```
Disable-CrmPluginStep [-Id] <Guid[]> [<CommonParameters>]
```

## DESCRIPTION
Disable a SDK Message Processing Step.

## EXAMPLES

### Example 1
```
PS C:\> Disable-CrmPluginStep -Id 'BD1D1AF1-D43F-4B00-96DC-979DC0709CDE'
```

## PARAMETERS

### -Id
The id of the SDK Message Processing Step to disable.

```yaml
Type: System.Guid[]
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

[Enable-CrmPluginStep](Enable-CrmPluginStep.md)

[Get-CrmPluginStep](Get-CrmPluginStep.md)

[Register-CrmPluginStep](Register-CrmPluginStep.md)

[Set-CrmPluginStep](Set-CrmPluginStep.md)

[Unregister-CrmPluginStep](Unregister-CrmPluginStep.md)
