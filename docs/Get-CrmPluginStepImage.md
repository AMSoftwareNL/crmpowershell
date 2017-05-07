---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmPluginStepImage.html
schema: 2.0.0
---

# Get-CrmPluginStepImage

## SYNOPSIS
Get SDK Message Processing Step Image.

## SYNTAX

### GetPluginStepImageByFilter (Default)
```
Get-CrmPluginStepImage [[-PluginStep] <Guid>] [-ImageType <CrmPluginImageType>] [-IncludeTotalCount]
 [-Skip <UInt64>] [-First <UInt64>]
```

### GetPluginStepImageById
```
Get-CrmPluginStepImage [-Id] <Guid> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
```

## DESCRIPTION
Get SDK Message Processing Step Image.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmPluginStepImage -PluginStep '1F1DE3ED-7CC0-497F-8A9A-DB9F1EE67B6F' -ImageType PostImage
```

Get post images for the specified SDK Message Processing Step.

## PARAMETERS

### -First
Specifies the number of records to retrieve from the beginning.

```yaml
Type: UInt64
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The id of the SDK Message Processing Step image to retrieve.

```yaml
Type: Guid
Parameter Sets: GetPluginStepImageById
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageType
The type of SDK Message Procesing Step image to retrieve. If not specified all image types are retrieved.

```yaml
Type: CrmPluginImageType
Parameter Sets: GetPluginStepImageByFilter
Aliases: 
Accepted values: PreImage, PostImage

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeTotalCount
Return the total count (and accuracy) of the number of records before returning the result.

Because of the limitations of Dynamics CRM, the total count is only returned accurate when the result is limited to 5000 items.

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
The id of the SDK Message Processing Step to retrieve images for.

```yaml
Type: Guid
Parameter Sets: GetPluginStepImageByFilter
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Skip
Skips (does not return) the specified number of records.

```yaml
Type: UInt64
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### System.Guid


## OUTPUTS

### Microsoft.Xrm.Sdk.Entity


## NOTES

## RELATED LINKS

[Register-CrmPluginStepImage](Register-CrmPluginStepImage.md)

[Set-CrmPluginStepImage](Set-CrmPluginStepImage.md)

[Unregister-CrmPluginStepImage](Unregister-CrmPluginStepImage.md)

[Get-CrmPluginStep](Get-CrmPluginStep.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
