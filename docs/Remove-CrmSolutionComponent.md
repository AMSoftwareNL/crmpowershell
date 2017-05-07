---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Remove-CrmSolutionComponent.html
schema: 2.0.0
---

# Remove-CrmSolutionComponent

## SYNOPSIS
Remove a component from a customization solution.

## SYNTAX

### RemoveSolutionComponentSimple
```
Remove-CrmSolutionComponent [-Solution] <Guid> -Type <CrmComponentType> -ComponentId <Guid>
 [<CommonParameters>]
```

### RemoveSolutionComponentAdvanced
```
Remove-CrmSolutionComponent [-Solution] <Guid> -ComponentType <Int32> -ComponentId <Guid> [<CommonParameters>]
```

## DESCRIPTION
Remove a component from a customization solution.

## EXAMPLES

## PARAMETERS

### -ComponentId
The id of the component to remove.

This can be the MetadataId or the id of the record.

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
The type of component to remove. Matches a value from the global optionset 'Component Type'(componenttype).

```yaml
Type: Int32
Parameter Sets: RemoveSolutionComponentAdvanced
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Solution
The id of the solution to remove the component from.

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
The type of component to remove.

```yaml
Type: CrmComponentType
Parameter Sets: RemoveSolutionComponentSimple
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

[Add-CrmSolutionComponent](Add-CrmSolutionComponent.md)

[Get-CrmSolutionComponent](Get-CrmSolutionComponent.md)

[Test-CrmSolutionComponent](Test-CrmSolutionComponent.md)
