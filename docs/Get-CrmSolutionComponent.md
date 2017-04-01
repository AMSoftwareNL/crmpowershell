---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmSolutionComponent.html
schema: 2.0.0
---

# Get-CrmSolutionComponent

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### GetSolutionComponentSimple (Default)
```
Get-CrmSolutionComponent [-Solution] <Guid> [-Type <CrmComponentType>] [-IncludeTotalCount] [-Skip <UInt64>]
 [-First <UInt64>]
```

### GetSolutionComponentAdvanced
```
Get-CrmSolutionComponent [-Solution] <Guid> [-ComponentType <Int32>] [-IncludeTotalCount] [-Skip <UInt64>]
 [-First <UInt64>]
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

### -ComponentType
{{Fill ComponentType Description}}

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
{{Fill First Description}}

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
{{Fill IncludeTotalCount Description}}

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
{{Fill Skip Description}}

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
Parameter Sets: GetSolutionComponentSimple
Aliases: 
Accepted values: Unknown, Entity, OptionSet, Role, Dashboard, Process, Report, EmailTemplate, ContractTemplate, ArticleTemplate, MailMergeTemplate, Ribbon, WebResource, SiteMap, ConnectionRole, FieldSecurityProfile, SdkAssembly, SdkMessageStep, ServiceEndpoint, RoutingRuleSet, SLA, ConvertRule

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### System.Guid


## OUTPUTS

### Microsoft.Xrm.Sdk.Entity


## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/Get-CrmSolutionComponent.html](http://crmpowershell.amsoftware.nl/Get-CrmSolutionComponent.html)

