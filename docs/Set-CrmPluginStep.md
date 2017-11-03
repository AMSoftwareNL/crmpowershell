---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Set-CrmPluginStep.md
schema: 2.0.0
---

# Set-CrmPluginStep

## SYNOPSIS
Update a SDK Message Processing Step.

## SYNTAX

```
Set-CrmPluginStep [-Id] <Guid> [-ExecutionOrder <Int32>] [-Name <String>] [-Description <String>]
 [-Stage <CrmPluginStepStage>] [-Mode <CrmPluginStepMode>] [-Deployment <CrmPluginStepDeployment>]
 [-DeleteAsyncOperation] [-UnsecureConfig <String>] [-SecureConfig <String>] [-User <Guid>]
 [-Attributes <String[]>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Update a SDK Message Processing Step.

## EXAMPLES

## PARAMETERS

### -Attributes
The LogicalName of the filtering attributes for the SDK Message Processing Step.

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

### -DeleteAsyncOperation
Set Delete async operation when completed for the SDK Message Processing Step.

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

### -Deployment
The deployment type for the SDK Message Processing Step.

```yaml
Type: CrmPluginStepDeployment
Parameter Sets: (All)
Aliases: 
Accepted values: ServerOnly, OfflineOnly, Both

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
The description for the SDK Message Processing Step.

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

### -ExecutionOrder
The execution order for the SDK Message Processing Step.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The id of the SDK Message Processing Step to update.

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

### -Mode
The mode for the SDK Message Processing Step.

```yaml
Type: CrmPluginStepMode
Parameter Sets: (All)
Aliases: 
Accepted values: Synchronous, Asynchronous

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name for the SDK Message Processing Step.

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

### -PassThru
Returns an object that represents the Plugin Step. By default, this cmdlet does not generate any output.

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

### -SecureConfig
The secure configuration for the SDK Message Processing Step.

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

### -Stage
The stage for the SDK Message Processing Step.

```yaml
Type: CrmPluginStepStage
Parameter Sets: (All)
Aliases: 
Accepted values: PreValidation, PreOperation, PostOperation

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UnsecureConfig
The unsecure configuration for the SDK Message Processing Step.

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

### -User
The id of the user for the SDK Message Processing Step context.

```yaml
Type: Guid
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

[Disable-CrmPluginStep](Disable-CrmPluginStep.md)

[Enable-CrmPluginStep](Enable-CrmPluginStep.md)

[Get-CrmPluginStep](Get-CrmPluginStep.md)

[Register-CrmPluginStep](Register-CrmPluginStep.md)

[Unregister-CrmPluginStep](Unregister-CrmPluginStep.md)
