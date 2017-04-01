---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Stop-CrmProcess.html
schema: 2.0.0
---

# Stop-CrmProcess

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### StopProcessByAsyncOperation (Default)
```
Stop-CrmProcess [-ASyncOperation] <Guid> [-Force] [-WhatIf] [-Confirm]
```

### StopProcessByWorkflow
```
Stop-CrmProcess [-Process] <Guid> [[-Record] <Guid>] [-Force] [-WhatIf] [-Confirm]
```

## DESCRIPTION
{{Fill in the Description}}

## EXAMPLES

### Example 1
```
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -ASyncOperation
{{Fill ASyncOperation Description}}

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
{{Fill Force Description}}

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
{{Fill Process Description}}

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
{{Fill Record Description}}

```yaml
Type: Guid
Parameter Sets: StopProcessByWorkflow
Aliases: 

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

## INPUTS

### System.Guid


## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/Stop-CrmProcess.html](http://crmpowershell.amsoftware.nl/Stop-CrmProcess.html)

