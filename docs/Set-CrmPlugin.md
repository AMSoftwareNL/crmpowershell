---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Set-CrmPlugin.md
schema: 2.0.0
---

# Set-CrmPlugin

## SYNOPSIS
Update a plugin.

## SYNTAX

```
Set-CrmPlugin [-Id] <Guid> [-Name <String>] [-FriendlyName <String>] [-Description <String>]
 [-WorkflowActivityGroupName <String>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Update a plugin.

## EXAMPLES

## PARAMETERS

### -Description
The description for the plugin.

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

### -FriendlyName
The friendly name for the plugin.

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

### -Id
The id of the plugin to update.

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

### -Name
The name for the plugin.

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

### -PassThru
Returns an object that represents the Plugin. By default, this cmdlet does not generate any output.

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

### -WorkflowActivityGroupName
The workflow activity group name for the plugin.

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

[Get-CrmPlugin](Get-CrmPlugin.md)

[Register-CrmPlugin](Register-CrmPlugin.md)

[Unregister-CrmPlugin](Unregister-CrmPlugin.md)

[Get-CrmPluginAssembly](Get-CrmPluginAssembly.md)

[Unregister-CrmPluginAssembly](Unregister-CrmPluginAssembly.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
