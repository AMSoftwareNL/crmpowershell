---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Remove-CrmSolutionComponent.html
schema: 2.0.0
---

# Remove-CrmSolutionComponent

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### RemoveSolutionComponentSimple
```
Remove-CrmSolutionComponent [-Solution] <Guid> -Type <CrmComponentType> -ComponentId <Guid>
```

### RemoveSolutionComponentAdvanced
```
Remove-CrmSolutionComponent [-Solution] <Guid> -ComponentType <Int32> -ComponentId <Guid>
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

### -ComponentId
{{Fill ComponentId Description}}

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
{{Fill ComponentType Description}}

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
{{Fill Solution Description}}

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
{{Fill Type Description}}

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

## INPUTS

### System.Guid


## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/Remove-CrmSolutionComponent.html](http://crmpowershell.amsoftware.nl/Remove-CrmSolutionComponent.html)

