---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Invoke-CrmRequest.md
schema: 2.0.0
---

# Invoke-CrmRequest

## SYNOPSIS
Execute any Dynamics CRM request.

## SYNTAX

```
Invoke-CrmRequest [-Request] <String> [[-Parameters] <Hashtable>] [-AsBatch] [<CommonParameters>]
```

## DESCRIPTION
Execute any Dynamics CRM request.

## EXAMPLES

### Example 1
```
PS C:\> Invoke-CrmRequest -Request WhoAmI
```

Executes the WhoAmI request.

## PARAMETERS

### -AsBatch
Execute the request as part of a batch (ExecuteMultiple or ExecuteTransaction). 
See Start-CrmBatch, Stop-CrmBatch and Submit-CrmBatch.

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

### -Parameters
A hashtable of parameter names and values to pass to the request.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Request
The name of the request to execute.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Collections.Hashtable

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS
