---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Register-CrmPlugin.html
schema: 2.0.0
---

# Register-CrmPlugin

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### RegisterPluginFromPath (Default)
```
Register-CrmPlugin [-Path] <String[]> [-IsolationMode <CrmAssemblyIsolationMode>]
 [-AssemblyLocation <CrmAssemblySourceType>] [-Description <String>] [-Force] [-Plugins <String[]>]
 [<CommonParameters>]
```

### RegisterPluginFromLiteralPath
```
Register-CrmPlugin [-LiteralPath] <String[]> [-IsolationMode <CrmAssemblyIsolationMode>]
 [-AssemblyLocation <CrmAssemblySourceType>] [-Description <String>] [-Force] [-Plugins <String[]>]
 [<CommonParameters>]
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

### -AssemblyLocation
{{Fill AssemblyLocation Description}}

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
{{Fill Description Description}}

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
{{Fill Force Description}}

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
{{Fill IsolationMode Description}}

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
{{Fill LiteralPath Description}}

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

### -Path
{{Fill Path Description}}

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
{{Fill Plugins Description}}

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

[http://crmpowershell.amsoftware.nl/Register-CrmPlugin.html](http://crmpowershell.amsoftware.nl/Register-CrmPlugin.html)

