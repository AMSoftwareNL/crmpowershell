---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmPluginStep.md
schema: 2.0.0
---

# Get-CrmPluginStep

## SYNOPSIS
Get SDK Message Processing Step.

## SYNTAX

### GetPluginStepByFilter (Default)
```
Get-CrmPluginStep [[-EventSource] <Guid>] [-Message <String>] [-Entity <String>] [-Stage <CrmPluginStepStage>]
 [-Mode <CrmPluginStepMode>] [-IncludeInternalStages] [-IncludeHidden] [-IncludeTotalCount] [-Skip <UInt64>]
 [-First <UInt64>] [<CommonParameters>]
```

### GetPluginStepById
```
Get-CrmPluginStep -Id <Guid> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

## DESCRIPTION
Get SDK Message Processing Step.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmPlugin -Name 'AMSoftware.Plugins.CreateAccount' | Get-CrmPluginStep -Message 'Create' -Entity 'account'
```

Get SDK Message Processing Steps from assembly 'amsoftware.plugins' registered for Create messages on account.

## PARAMETERS

### -Entity
The LogicalName of the entity the SDK Message Processing Step is registered on.

```yaml
Type: System.String
Parameter Sets: GetPluginStepByFilter
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventSource
The plugin or serviceendpoint the SDK Message Processing Step is registered on.

```yaml
Type: System.Guid
Parameter Sets: GetPluginStepByFilter
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Id
The id of the SDK Message Processing Step to retrieve.

```yaml
Type: System.Guid
Parameter Sets: GetPluginStepById
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeHidden
Include SDK Message Processing Steps marked as hidden.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GetPluginStepByFilter
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeInternalStages
Include SDK Message Processing Steps registered on internal stages.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GetPluginStepByFilter
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Message
The name of the message the SDK Message Processing Step is registered on.

```yaml
Type: System.String
Parameter Sets: GetPluginStepByFilter
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Mode
The mode of the SDK Message Processing Step to retrieve. If not provided all modes are returned.

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmPluginStepMode
Parameter Sets: GetPluginStepByFilter
Aliases:
Accepted values: Synchronous, Asynchronous

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Stage
The stage of the SDK Message Processing Step to retrieve. If not provided all stages are returned.

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmPluginStepStage
Parameter Sets: GetPluginStepByFilter
Aliases:
Accepted values: PreValidation, PreOperation, PostOperation

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeTotalCount
Include SDK Message Processing Steps whose name matches the provided pattern.

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

### -Skip
Skips (does not return) the specified number of records.

```yaml
Type: System.UInt64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -First
Specifies the number of records to retrieve from the beginning.

```yaml
Type: System.UInt64
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

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[Disable-CrmPluginStep](Disable-CrmPluginStep.md)

[Enable-CrmPluginStep](Enable-CrmPluginStep.md)

[Register-CrmPluginStep](Register-CrmPluginStep.md)

[Set-CrmPluginStep](Set-CrmPluginStep.md)

[Unregister-CrmPluginStep](Unregister-CrmPluginStep.md)

[Entity Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.entity)
