---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Register-CrmPluginStep.md
schema: 2.0.0
---

# Register-CrmPluginStep

## SYNOPSIS
Register a SDK Message Processing Step.

## SYNTAX

```
Register-CrmPluginStep [-EventSource] <Guid> [-Message] <String> [[-PrimaryEntity] <String>]
 [-SecondaryEntity <String>] [-ExecutionOrder <Int32>] [-Name <String>] [-Description <String>]
 -Stage <CrmPluginStepStage> -Mode <CrmPluginStepMode> -Deployment <CrmPluginStepDeployment>
 [-DeleteAsyncOperation] [-UnsecureConfig <String>] [-SecureConfig <String>] [-User <Guid>]
 [-Attributes <String[]>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Register a SDK Message Processing Step.

## EXAMPLES

## PARAMETERS

### -Attributes
The LogicalName of the filtering attributes for the SDK Message Processing Step.

```yaml
Type: System.String[]
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
Type: System.Management.Automation.SwitchParameter
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
Type: AMSoftware.Crm.PowerShell.Common.CrmPluginStepDeployment
Parameter Sets: (All)
Aliases:
Accepted values: ServerOnly, OfflineOnly, Both

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
The description for the SDK Message Processing Step.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventSource
The id of the plugin or serviceendpoint for the SDK Message Processing Step.

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ExecutionOrder
The execution order for the SDK Message Processing Step.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Message
The message to register the SDK Message Processing Step for.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Mode
The mode for the SDK Message Processing Step.

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmPluginStepMode
Parameter Sets: (All)
Aliases:
Accepted values: Synchronous, Asynchronous

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name for the SDK Message Processing Step.

```yaml
Type: System.String
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrimaryEntity
The primary entity the SDK Message Processing Step is registered for.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecondaryEntity
The secondary entity the SDK Message Processing Step is registered for.

```yaml
Type: System.String
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
Type: System.String
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
Type: AMSoftware.Crm.PowerShell.Common.CrmPluginStepStage
Parameter Sets: (All)
Aliases:
Accepted values: PreValidation, PreOperation, PostOperation

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UnsecureConfig
The unsecure configuration for the SDK Message Processing Step.

```yaml
Type: System.String
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
Type: System.Guid
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

[Disable-CrmPluginStep](Disable-CrmPluginStep.md)

[Enable-CrmPluginStep](Enable-CrmPluginStep.md)

[Get-CrmPluginStep](Get-CrmPluginStep.md)

[Set-CrmPluginStep](Set-CrmPluginStep.md)

[Unregister-CrmPluginStep](Unregister-CrmPluginStep.md)

[Entity Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.entity)
