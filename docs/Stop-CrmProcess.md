---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Stop-CrmProcess.md
schema: 2.0.0
---

# Stop-CrmProcess

## SYNOPSIS
Stop a running asynchronous operation (System Job).

## SYNTAX

### StopProcessByAsyncOperation (Default)
```
Stop-CrmProcess [-ASyncOperation] <Guid> [-PassThru] [-Force] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### StopProcessByWorkflow
```
Stop-CrmProcess [-Process] <Guid> [[-Record] <Guid>] [-PassThru] [-Force] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Stop a running asynchronous operation (System Job).

## EXAMPLES

### Example 1
```
PS C:\> Stop-CrmProcess -Process 'AA5C6340-D76D-44E1-B3B8-1D3EFA0C4B8D' -Record '146C4190-4D68-4A98-9B6E-AD911F4351D9'
```

Stop any System Job associated to the sepcified process and record.

## PARAMETERS

### -ASyncOperation
The id of the System Job to stop.

```yaml
Type: Guid
Parameter Sets: StopProcessByAsyncOperation
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Stops the specified processes without prompting for confirmation.

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

### -PassThru
Returns an object that represents the asyncoperation. By default, this cmdlet does not generate any output.

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

### -Process
The id of the process (workflow) to stop all associated System Jobs for.

```yaml
Type: Guid
Parameter Sets: StopProcessByWorkflow
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Record
The id of the record to stop the associated System Jobs for.

```yaml
Type: Guid
Parameter Sets: StopProcessByWorkflow
Aliases: Id

Required: False
Position: 5
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

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

[Get-CrmProcess](Get-CrmProcess.md)

[Start-CrmProcess](Start-CrmProcess.md)
