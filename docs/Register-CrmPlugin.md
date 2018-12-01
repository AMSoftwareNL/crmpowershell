---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Register-CrmPlugin.md
schema: 2.0.0
---

# Register-CrmPlugin

## SYNOPSIS
Register a plugin and assembly.

## SYNTAX

### RegisterPluginFromPath (Default)
```
Register-CrmPlugin [-Path] <String[]> [-IsolationMode <CrmAssemblyIsolationMode>]
 [-AssemblyLocation <CrmAssemblySourceType>] [-Description <String>] [-Force] [-Plugins <String[]>] [-PassThru]
 [<CommonParameters>]
```

### RegisterPluginFromLiteralPath
```
Register-CrmPlugin [-LiteralPath] <String[]> [-IsolationMode <CrmAssemblyIsolationMode>]
 [-AssemblyLocation <CrmAssemblySourceType>] [-Description <String>] [-Force] [-Plugins <String[]>] [-PassThru]
 [<CommonParameters>]
```

## DESCRIPTION
Register a plugin and assembly.

## EXAMPLES

## PARAMETERS

### -AssemblyLocation
The location to store the plugin assembly.

```yaml
Type: CrmAssemblySourceType
Parameter Sets: (All)
Aliases:
Accepted values: Database, Disk, GAC

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Force
Executes the action without prompting for confirmation.

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

### -IsolationMode
The isolation mode for the plugin assembly.

```yaml
Type: CrmAssemblyIsolationMode
Parameter Sets: (All)
Aliases:
Accepted values: None, Sandbox

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LiteralPath
The path to the plugin assembly.

```yaml
Type: String[]
Parameter Sets: RegisterPluginFromLiteralPath
Aliases: PSPath

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -Path
The path to the plugin assembly.

```yaml
Type: String[]
Parameter Sets: RegisterPluginFromPath
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -Plugins
The names of the plugins to register from the assembly.

```yaml
Type: String[]
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

### System.String[]
## OUTPUTS

### Microsoft.Xrm.Sdk.Entity
## NOTES

## RELATED LINKS

[Get-CrmPlugin](Get-CrmPlugin.md)

[Set-CrmPlugin](Set-CrmPlugin.md)

[Unregister-CrmPlugin](Unregister-CrmPlugin.md)

[Get-CrmPluginAssembly](Get-CrmPluginAssembly.md)

[Unregister-CrmPluginAssembly](Unregister-CrmPluginAssembly.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
