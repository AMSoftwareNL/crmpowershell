---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmProcess.md
schema: 2.0.0
---

# Get-CrmProcess

## SYNOPSIS
Get Workflow, Dialog, BusinessRule, Action or BusinessProcessFlow.

## SYNTAX

### GetAllProcesses (Default)
```
Get-CrmProcess [[-Name] <String>] [-Exclude <String>] [[-Entity] <String>] [[-ProcessType] <CrmProcessType>]
 [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

### GetProcessById
```
Get-CrmProcess [-Id] <Guid[]> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

## DESCRIPTION
Get Workflow, Dialog, BusinessRule, Action or BusinessProcessFlow.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmProcess -ProcessType Workflow
```

Get all workflows in the connected organization.

## PARAMETERS

### -Entity
The logicalname of the entity to retrieve the records from.

```yaml
Type: System.String
Parameter Sets: GetAllProcesses
Aliases:

Required: False
Position: 10
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Exclude
Exclude processes whose name matches the provided pattern.

```yaml
Type: System.String
Parameter Sets: GetAllProcesses
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -Id
The id of the process to retrieve.

```yaml
Type: System.Guid[]
Parameter Sets: GetProcessById
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the process to retrieve.

```yaml
Type: System.String
Parameter Sets: GetAllProcesses
Aliases: Include

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -ProcessType
The type of process to retrieve. If not provide all processes will be returned.

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmProcessType
Parameter Sets: GetAllProcesses
Aliases:
Accepted values: Workflow, Dialog, BusinessRule, Action, BusinessProcessFlow, All

Required: False
Position: 30
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeTotalCount
Return the total count (and accuracy) of the number of records before returning the result.

Because of the limitations of Dynamics CRM, the total count is only returned accurate when the result is limited to 5000 items.

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

### System.Guid[]

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[Start-CrmProcess](Start-CrmProcess.md)

[Stop-CrmProcess](Stop-CrmProcess.md)

[Entity Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.entity)
