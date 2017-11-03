---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Export-CrmSolution.md
schema: 2.0.0
---

# Export-CrmSolution

## SYNOPSIS
Export a customization solution.

## SYNTAX

```
Export-CrmSolution [-Id] <Guid> [-Path] <String> [-Managed] [-AutoNumberingSettings] [-CalendarSettings]
 [-CustomizationSettings] [-EmailTrackingSettings] [-GeneralSettings] [-IsvConfig] [-MarketingSettings]
 [-OutlookSynchronizationSettings] [-RelationshipRoles] [-Target <String>] [<CommonParameters>]
```

## DESCRIPTION
Export a customization solution as a file to the file system.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmSolution -Name 'Product 1' | Export-CrmSolution -Managed -Path c:\temp\product1.zip
```

Export the solution 'Product 1' as a managed solution to 'product1.zip'.

## PARAMETERS

### -AutoNumberingSettings
Include auto-numbering settings in the exported solution.

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

### -CalendarSettings
Include calendar settings in the exported solution.

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

### -CustomizationSettings
Include customization settings in the exported solution.

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

### -EmailTrackingSettings
Include email tracking settings in the exported solution.

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

### -GeneralSettings
Include general settings in the exported solution.

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

### -Id
The id of the solution to export.

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

### -IsvConfig
Include ISV configuration in the exported solution.

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

### -Managed
Export as managed solution

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

### -MarketingSettings
Include marketing settings in the exported solution.

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

### -OutlookSynchronizationSettings
Include Outlook synchronization settings in the exported solution.

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

### -Path
The file ystem path to export the solution to. This must include to filename.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RelationshipRoles
Include relationship roles in the exported solution.

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

### -Target
Sets the version that the exported solution will support.

```yaml
Type: String
Parameter Sets: (All)
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

[https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Export-CrmSolution.md](https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Export-CrmSolution.md)

[Get-CrmSolution](Get-CrmSolution.md)

[Import-CrmSolution](Import-CrmSolution.md)

[New-CrmSolution](New-CrmSolution.md)

[Test-CrmSolution](Test-CrmSolution.md)

[Use-CrmSolution](Use-CrmSolution.md)
