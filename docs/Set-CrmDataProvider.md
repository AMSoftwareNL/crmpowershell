---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Set-CrmDataProvider.md
schema: 2.0.0
---

# Set-CrmDataProvider

## SYNOPSIS
Update a registered Data Provider

## SYNTAX

```
Set-CrmDataProvider [-Id] <Guid> [-Name <String>] [-RetrievePlugin <Guid>] [-RetrieveMultiplePlugin <Guid>]
 [-CreatePlugin <Guid>] [-UpdatePlugin <Guid>] [-DeletePlugin <Guid>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Update a registered Data Provider

## EXAMPLES

## PARAMETERS

### -CreatePlugin
Id of the plugin that handles Create events for the Data Provider

```yaml
Type: System.Nullable`1[System.Guid]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeletePlugin
Id of the plugin that handles Delete events for the Data Provider

```yaml
Type: System.Nullable`1[System.Guid]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Id of the Data Provider to update

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
New Name for the Data Provider

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Return the resulting data provider to the pipeline

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
Type: System.Nullable`1[System.Guid]
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
Type: System.Nullable`1[System.Guid]
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
Type: System.Nullable`1[System.Guid]
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

### System.Guid

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[Set-CrmDataProvider](Set-CrmDataProvider.md)

