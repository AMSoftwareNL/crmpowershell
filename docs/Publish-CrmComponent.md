---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Publish-CrmComponent.md
schema: 2.0.0
---

# Publish-CrmComponent

## SYNOPSIS
Publish customization components.

## SYNTAX

### PublishSolution (Default)
```
Publish-CrmComponent -Solution <Guid> [<CommonParameters>]
```

### PublishAll
```
Publish-CrmComponent [-All] [<CommonParameters>]
```

### PublishComponents
```
Publish-CrmComponent [-Entities <String[]>] [-Webresources <Guid[]>] [-Optionsets <String[]>]
 [-Dashboards <Guid[]>] [-PublishRibbon] [-PublishSiteMap] [<CommonParameters>]
```

## DESCRIPTION
Publish customization components.

## EXAMPLES

### Example 1
```
PS C:\> Publish-CrmComponent -Entities @('account'','contact')
```

Publish customization for the entities 'account' and 'contact'.

## PARAMETERS

### -All
Publish all customizations in the organization.

```yaml
Type: SwitchParameter
Parameter Sets: PublishAll
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Dashboards
The id of the dashboards to publish. 

The id must match id for records in the entity 'systemform'.

```yaml
Type: Guid[]
Parameter Sets: PublishComponents
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entities
The LogicalName of entities to publish.

```yaml
Type: String[]
Parameter Sets: PublishComponents
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Optionsets
The name of global optionsets to publish.

```yaml
Type: String[]
Parameter Sets: PublishComponents
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublishRibbon
Include the ribbon in publishing.

```yaml
Type: SwitchParameter
Parameter Sets: PublishComponents
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublishSiteMap
Publish the sitemap.

```yaml
Type: SwitchParameter
Parameter Sets: PublishComponents
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Solution
The id of the solution containing the components to publish.

```yaml
Type: Guid
Parameter Sets: PublishSolution
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Webresources
The id of the webresources to publish. 

The id must match id for records in the entity 'webresource'.

```yaml
Type: Guid[]
Parameter Sets: PublishComponents
Aliases:

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

### None
## NOTES

## RELATED LINKS

[Get-CrmSolution](Get-CrmSolution.md)

[Add-CrmSolutionComponent](Add-CrmSolutionComponent.md)

[Get-CrmSolutionComponent](Get-CrmSolutionComponent.md)

[Remove-CrmSolutionComponent](Remove-CrmSolutionComponent.md)

[Test-CrmSolutionComponent](Test-CrmSolutionComponent.md)
