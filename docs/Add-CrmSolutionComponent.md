---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Add-CrmSolutionComponent.html
schema: 2.0.0
---

# Add-CrmSolutionComponent

## SYNOPSIS
{{Fill in the Synopsis}}

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
Parameter Sets: AddSolutionComponentAdvanced
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExcludeMetadata
{{Fill ExcludeMetadata Description}}

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
{{Fill ExcludeSubComponents Description}}

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
{{Fill IncludeRequired Description}}

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

### System.Object

## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/Add-CrmSolutionComponent.html](http://crmpowershell.amsoftware.nl/Add-CrmSolutionComponent.html)

