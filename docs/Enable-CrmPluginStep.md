---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Enable-CrmPluginStep.md
schema: 2.0.0
---

# Enable-CrmPluginStep

## SYNOPSIS
Enable a SDK Message Processing Step.

## SYNTAX

```
Enable-CrmPluginStep [-Id] <Guid[]> [<CommonParameters>]
```

## DESCRIPTION
Enable a SDK Message Processing Step.

## EXAMPLES

### Example 1
```
PS C:\> Enable-CrmPluginStep -Id 'BD1D1AF1-D43F-4B00-96DC-979DC0709CDE'
```

## PARAMETERS

### -Id
The id of the SDK Message Processing Step to enable.

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

[Get-CrmPluginStep](Get-CrmPluginStep.md)

[Register-CrmPluginStep](Register-CrmPluginStep.md)

[Set-CrmPluginStep](Set-CrmPluginStep.md)

[Unregister-CrmPluginStep](Unregister-CrmPluginStep.md)
