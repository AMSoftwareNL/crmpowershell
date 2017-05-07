---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Add-CrmSolutionComponent.html
schema: 2.0.0
---

# Add-CrmSolutionComponent

## SYNOPSIS
Add a component to a customization solution.

## SYNTAX

### AddSolutionComponentSimple
```
Add-CrmSolutionComponent [-Solution] <Guid> -Type <CrmComponentType> -ComponentId <Guid> [-IncludeRequired]
 [-ExcludeSubComponents] [-ExcludeMetadata] [<CommonParameters>]
```

### AddSolutionComponentAdvanced
```
Add-CrmSolutionComponent [-Solution] <Guid> -ComponentType <Int32> -ComponentId <Guid> [-IncludeRequired]
 [-ExcludeSubComponents] [-ExcludeMetadata] [<CommonParameters>]
```

## DESCRIPTION
Add a component to a customization solution.

## EXAMPLES

## PARAMETERS

### -ComponentId
The id of the component to add.

```yaml
Type: Guid
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComponentType
The type of component to add. Matches a value from the global optionset 'Component Type'(componenttype).

```yaml
Type: Int32
Parameter Sets: AddSolutionComponentAdvanced
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExcludeMetadata
Specifies if the component is added to the solution without its metadata.

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

### -ExcludeSubComponents
Whether the subcomponents should be excluded.

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

### -IncludeRequired
Whether other solution components that are required by the solution component that you are adding should also be added to the unmanaged solution.

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

### -Solution
The id of the solution to add the component to.

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
The type of component to add.

```yaml
Type: CrmComponentType
Parameter Sets: AddSolutionComponentSimple
Aliases: 
Accepted values: Unknown, Entity, OptionSet, Role, Dashboard, Process, Report, EmailTemplate, ContractTemplate, ArticleTemplate, MailMergeTemplate, Ribbon, WebResource, SiteMap, ConnectionRole, FieldSecurityProfile, SdkAssembly, SdkMessageStep, ServiceEndpoint, RoutingRuleSet, SLA, ConvertRule

Required: True
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

### None

## NOTES

## RELATED LINKS

[Get-CrmSolution](Get-CrmSolution.md)

[Get-CrmSolutionComponent](Get-CrmSolutionComponent.md)

[Remove-CrmSolutionComponent](Remove-CrmSolutionComponent.md)

[Test-CrmSolutionComponent](Test-CrmSolutionComponent.md)
