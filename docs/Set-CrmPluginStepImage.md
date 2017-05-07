---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Set-CrmPluginStepImage.html
schema: 2.0.0
---

# Set-CrmPluginStepImage

## SYNOPSIS
Update a SDK Message Processing Step image.

## SYNTAX

```
Set-CrmPluginStepImage [-Id] <Guid> [-Name <String>] [-Alias <String>] [-ImageType <CrmPluginStepImageType>]
 [-Attributes <String[]>] [<CommonParameters>]
```

## DESCRIPTION
Update a SDK Message Processing Step image.

## EXAMPLES

## PARAMETERS

### -Alias
The alias for the SDK Message Processing Step image.

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

### -Id
The id of the SDK Message Processing Step image to update.

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

### -ImageType
The type of the SDK Message Processing Step image.

```yaml
Type: CrmPluginStepImageType
Parameter Sets: (All)
Aliases: 
Accepted values: PreImage, PostImage, Both

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

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid

### System.String[]

## OUTPUTS

### None

## NOTES

## RELATED LINKS

[Get-CrmPluginStepImage](Get-CrmPluginStepImage.md)

[Register-CrmPluginStepImage](Register-CrmPluginStepImage.md)

[Unregister-CrmPluginStepImage](Unregister-CrmPluginStepImage.md)