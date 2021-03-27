---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Register-CrmPluginStepImage.md
schema: 2.0.0
---

# Register-CrmPluginStepImage

## SYNOPSIS
Register a SDK Message Processing Step image.

## SYNTAX

```
Register-CrmPluginStepImage [-PluginStep] <Guid> [-Name] <String> -Alias <String>
 -ImageType <CrmPluginStepImageType> [-MessagePropertyName <String>] [-Attributes <String[]>] [-PassThru]
 [<CommonParameters>]
```

## DESCRIPTION
Register a SDK Message Processing Step image.

## EXAMPLES

## PARAMETERS

### -Alias
The alias for the SDK Message Processing Step image.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Attributes
The LogicalName of the filtering attributes for the SDK Message Processing Step image.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageType
The type of the SDK Message Processing Step image.

```yaml
Type: CrmPluginStepImageType
Parameter Sets: (All)
Aliases:
Accepted values: PreImage, PostImage, Both

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MessagePropertyName
The property name for the SDK Message Processing Step image.

Only needed for Messages supporting multiple properties as the trigger. Can be omitted in most cases.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name for the SDK Message Processing Step image.

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

### -PassThru
Returns an object that represents the Plugin Step Image. By default, this cmdlet does not generate any output.

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

### -PluginStep
The id of the SDK Message Processing Step to register the SDK Message Processing Step image for.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid
### System.String[]
## OUTPUTS

### Microsoft.Xrm.Sdk.Entity
## NOTES

## RELATED LINKS

[Get-CrmPluginStepImage](Get-CrmPluginStepImage.md)

[Set-CrmPluginStepImage](Set-CrmPluginStepImage.md)

[Unregister-CrmPluginStepImage](Unregister-CrmPluginStepImage.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
