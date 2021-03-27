---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Use-CrmSolution.md
schema: 2.0.0
---

# Use-CrmSolution

## SYNOPSIS
Set the active CRM solution to use in the PowerShell session.

## SYNTAX

```
Use-CrmSolution [[-Solution] <Guid>] [<CommonParameters>]
```

## DESCRIPTION
Set the active CRM solution to use in the PowerShell session. Omit the solution to return to the default (base) solution of Dynamics CRM.

Setting the solution will affect all CmdLets capable of making changes to a CRM solution. The active solution will be included in all supporting actions. This includes all actions on metadata, but also actions creating and updating records.

## EXAMPLES

### Example 1
```
PS C:\> Use-CrmSolution -Solution '155f4747-2c32-4954-9b06-2f9f9bf19e51'
```

Set the active CRM solution of the session to the solution with ID '155f4747-2c32-4954-9b06-2f9f9bf19e51'.

## PARAMETERS

### -Solution
The unique ID of the CRM solution. Omit this parameter to reset the the default (base) solution.

```yaml
Type: Guid
Parameter Sets: (All)
Aliases: Id

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Nullable`1[[System.Guid, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]
## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[Get-CrmSolution](Get-CrmSolution.md)
