---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Register-CrmDataProvider.md
schema: 2.0.0
---

# Register-CrmDataProvider

## SYNOPSIS
Register a new Data Provider

## SYNTAX

```
Register-CrmDataProvider [-Name] <Object> [-DataSourceLogicalName] <String> [-RetrievePlugin <Guid>]
 [-RetrieveMultiplePlugin <Guid>] [-CreatePlugin <Guid>] [-UpdatePlugin <Guid>] [-DeletePlugin <Guid>]
 [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Register a new Data Provider

## EXAMPLES

### Example 1
```powershell
$publisher = New-CrmPublisher -Name 'amsoftware_test' -DisplayName 'AMSoftware (Test)' -Prefix 'ams' -PassThru
$solution = New-CrmSolution -Name 'ams_virtual_data' -DisplayName 'Virtual Data' -Version '1.0.0.0' -Publisher $publisher -PassThru
Use-CrmSolution $solution

$plugin = Register-CrmPlugin -LiteralPath '.\DSPlugin.dll' -IsolationMode Sandbox -AssemblyLocation Database -PassThru

# Create the Data Source Virtual Table to hold the actual Data Sources (configurations)
New-CrmEntity -DataSource -Name 'ams_rssfeed' -DisplayName 'RSS Feed Data Source' -DisplayCollectionName 'RSS Feed Data Sources' -AttributeName 'ams_name' -AttributeDisplayName 'Name' -AttributeExternalName 'name' -AttributeRequired Required -PassThru
Add-CrmStringAttribute -Entity 'ams_rssfeed' -Name 'ams_feeduri' -Format Url -Length 250 -DisplayName 'Feed URI' -Required Required -ExternalName 'feeduri'
Add-CrmStringAttribute -Entity 'ams_rssfeed' -Name 'ams_feedkey' -Format Url -Length 25 -DisplayName 'Feed Key' -Required Required -ExternalName 'feedkey' -IsDataSourceSecret

# Add a Data Source Configuration. The ID is needed for creation of the Virtual Table
$feedconfig = Add-CrmContent -Entity 'ams_rssfeed' -Attributes @{ams_name='Microsoft Power Platform Blog';ams_feeduri='https://cloudblogs.microsoft.com/powerplatform/feed/';ams_feedkey='secret'} -PassThru

# Register the Data Provider with the Data Source
$dataprovider = Register-CrmDataProvider -Name 'RSS Feed Data Provider' -DataSourceLogicalName 'ams_rssfeed' -RetrievePlugin $plugin -RetrieveMultiplePlugin $plugin -CreatePlugin $plugin -UpdatePlugin $plugin -DeletePlugin $plugin -PassThru

# Create the Virtual Table to hold the 'Microsoft Power Platform Blog' feed
New-CrmEntity -Virtual -Name 'ams_powerplatformblogfeed' -DisplayName 'Microsoft Power Platform Blog' -DisplayCollectionName 'Microsoft Power Platform Blogs' -ExternalName 'powerplatformblogfeed' -ExternalCollectionName 'powerplatformblogfeeds' -DataSourceConfiguration $feedconfig.ToEntityReference() -AttributeName 'ams_title' -AttributeDisplayName 'Title' -AttributeExternalName 'title' -AttributeRequired Required -AttributeLength 255 -HasNotes $true
```

To use Virtual Entities with a custom Data Provider and Data Source the following steps must be performed:
* Register the Plugins to use with the Data Provider
* Create a Data Source entity
* Create a Data Source configuration record
* Register the Data Provider
* Create the Virtual Entity connected to the Data Source (configuration)

## PARAMETERS

### -CreatePlugin
Id of the plugin that handles Create events for the Data Provider

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSourceLogicalName
The LogicalName of the Data Source Entity for this Data Provider

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeletePlugin
Id of the plugin that handles Delete events for the Data Provider

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Data Provider

```yaml
Type: System.Object
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Return the resulting Data Provider to the pipeline

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

### -RetrieveMultiplePlugin
Id of the plugin that handles RetrieveMultiple events for the Data Provider

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetrievePlugin
Id of the plugin that handles Retrieve events for the Data Provider

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpdatePlugin
Id of the plugin that handles Update events for the Data Provider

```yaml
Type: System.Guid
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

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Register-CrmDataProvider.md](https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Register-CrmDataProvider.md)

