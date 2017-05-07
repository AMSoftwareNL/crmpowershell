---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmSolutionComponent.html
schema: 2.0.0
---

# Get-CrmSolutionComponent

## SYNOPSIS
Get the component in a customizations solution.

## SYNTAX

### GetSolutionComponentSimple (Default)
```
Get-CrmSolutionComponent [-Solution] <Guid> [-Type <CrmComponentType>] [-IncludeTotalCount] [-Skip <UInt64>]
 [-First <UInt64>] [<CommonParameters>]
```

### GetSolutionComponentAdvanced
```
Get-CrmSolutionComponent [-Solution] <Guid> [-ComponentType <Int32>] [-IncludeTotalCount] [-Skip <UInt64>]
 [-First <UInt64>] [<CommonParameters>]
```

## DESCRIPTION
Get the component in a customizations solution.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmSolution 'Product 1' | Get-CrmSolutionComponent -Type Entity
```

Get the entities that are part of the 'Product 1' solution.

## PARAMETERS

### -ComponentType
The type of component to retrieve. Matches a value from the global optionset 'Component Type'(componenttype).

```yaml
Type: Int32
Parameter Sets: GetSolutionComponentAdvanced
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
Type: UInt64
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeTotalCount
Return the total count (and accuracy) of the number of records before returning the result.

Because of the limitations of Dynamics CRM, the total count is only returned accurate when the result is limited to 5000 items.

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

### -Skip
Skips (does not return) the specified number of records.

```yaml
Type: UInt64
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Solution
The id of the solution to retrieve components from.

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

### -Type
The type of component to retrieve. 

```yaml
Type: CrmComponentType
Parameter Sets: GetSolutionComponentSimple
Aliases: 
Accepted values: Unknown, Entity, OptionSet, Role, Dashboard, Process, Report, EmailTemplate, ContractTemplate, ArticleTemplate, MailMergeTemplate, Ribbon, WebResource, SiteMap, ConnectionRole, FieldSecurityProfile, SdkAssembly, SdkMessageStep, ServiceEndpoint, RoutingRuleSet, SLA, ConvertRule

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

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[Get-CrmSolution](Get-CrmSolution.md)

[Add-CrmSolutionComponent](Add-CrmSolutionComponent.md)

[Remove-CrmSolutionComponent](Remove-CrmSolutionComponent.md)

[Test-CrmSolutionComponent](Test-CrmSolutionComponent.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
