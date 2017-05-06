---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Disable-CrmPluginStep.html
schema: 2.0.0
---

# Disable-CrmPluginStep

## SYNOPSIS
Disable a SDK Message Processing Step.

## SYNTAX

```
Disable-CrmPluginStep [-Id] <Guid>
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

[Enable-CrmPluginStep](Enable-CrmPluginStep.md)

[Get-CrmPluginStep](Get-CrmPluginStep.md)

[Register-CrmPluginStep](Register-CrmPluginStep.md)

[Set-CrmPluginStep](Set-CrmPluginStep.md)

[Unregister-CrmPluginStep](Unregister-CrmPluginStep.md)
