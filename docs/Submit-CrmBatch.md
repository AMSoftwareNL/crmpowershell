---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Submit-CrmBatch.md
schema: 2.0.0
---

# Submit-CrmBatch

## SYNOPSIS
Execute the active batch request against Dataverse.

## SYNTAX

### AsMultiple (Default)
```
Submit-CrmBatch [-ContinueOnError] [-ReturnResponses] [<CommonParameters>]
```

### AsTransaction
```
Submit-CrmBatch [-AsTransaction] [-ReturnResponses] [<CommonParameters>]
```

## DESCRIPTION
Execute the active batch request against Dataverse. A batch is execute as a transaction or a batch.
Completion (success or failure) stops the active batch and clears the collected requests.

## EXAMPLES

### Example 1
```powershell
Start-CrmBatch

Add-CrmContent -Entity 'account' -Attributes @{name='Account 1'} -AsBatch
Add-CrmContent -Entity 'account' -Attributes @{name='Account 2'} -AsBatch
Add-CrmContent -Entity 'account' -Attributes @{name='Account 3'} -AsBatch
Add-CrmContent -Entity 'account' -Attributes @{name='Account 4'} -AsBatch

Submit-CrmBatch -AsTransaction -ReturnResponses
```

Executes the requests in the batch as a single transaction which succeeds or fails. Failure will throw an exception.
When ReturnResponse is omitted the results of the individual request won't be returned.

### Example 2
```powershell
Start-CrmBatch

Add-CrmContent -Entity 'account' -Attributes @{name='Account 1'} -AsBatch
Add-CrmContent -Entity 'account' -Attributes @{name='Account 2'} -AsBatch
Add-CrmContent -Entity 'account' -Attributes @{name='Account 3'} -AsBatch
Add-CrmContent -Entity 'account' -Attributes @{name='Account 4'} -AsBatch

Submit-CrmBatch -ReturnResponses -ContinueOnError
```

Executes the requests in the batch which succeeds or fails. ContinueOnError determines of all requests in the batch are executed or the batch is terminated on the first error.
Failure won't throw an exception. Check the results to determine if the batch succeeded. Without ReturnResponses the cmdlet returns a boolean indicating success.

## PARAMETERS

### -AsTransaction
{{ Fill AsTransaction Description }}

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AsTransaction
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContinueOnError
{{ Fill ContinueOnError Description }}

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AsMultiple
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReturnResponses
{{ Fill ReturnResponses Description }}

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Xrm.Sdk.OrganizationResponse

### Microsoft.Xrm.Sdk.ExecuteMultipleResponseItem

## NOTES

## RELATED LINKS

[https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Submit-CrmBatch.md](https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Submit-CrmBatch.md)

