---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Start-CrmProcess.html
schema: 2.0.0
---

# Start-CrmProcess

## SYNOPSIS
Execute a workflow.

## SYNTAX

```
Start-CrmProcess [-Process] <Guid> [-Record] <Guid> [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Execute a workflow.

The return value is the ID of the asynchronous operation (system job) that is created.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmContent -Entity account | Execute-Process -Process 'AA5C6340-D76D-44E1-B3B8-1D3EFA0C4B8D'
```

Execute the workflow on all records in the 'account' entity.

## PARAMETERS

### -Process
The id of the workflow (process) to execute.

```yaml
Type: Guid
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Record
the ID of the record on which the workflow executes. 

The entity is determined by the entity the workflow is associated with.

```yaml
Type: Guid
Parameter Sets: (All)
Aliases: 

Required: True
Position: 5
Default value: None
Accept pipeline input: True (ByValue)
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid

## OUTPUTS

### System.Guid

## NOTES

## RELATED LINKS

[Get-CrmProcess](Get-CrmProcess.md)

[Stop-CrmProcess](Stop-CrmProcess.md)
