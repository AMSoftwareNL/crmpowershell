---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Unregister-CrmPluginStepImage.html
schema: 2.0.0
---

# Unregister-CrmPluginStepImage

## SYNOPSIS
Unregister SDK Message Processing Step Image.

## SYNTAX

```
Unregister-CrmPluginStepImage [-Id] <Guid> [-Force]
```

## DESCRIPTION
Unregister SDK Message Processing Step Image.

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
The id of the SDK Message Processing Step Image to unregister.

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

[Get-CrmPluginStepImage](Get-CrmPluginStepImage.md)

[Register-CrmPluginStepImage](Register-CrmPluginStepImage.md)

[Set-CrmPluginStepImage](Set-CrmPluginStepImage.md)
