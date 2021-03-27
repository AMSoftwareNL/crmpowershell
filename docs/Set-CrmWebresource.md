---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Set-CrmWebresource.md
schema: 2.0.0
---

# Set-CrmWebresource

## SYNOPSIS
Update a webresource.

## SYNTAX

### SetWebresource (Default)
```
Set-CrmWebresource [-Id] <Guid> [-DisplayName <String>] [-Description <String>] [-IsCustomizable <Boolean>]
 [-PassThru] [<CommonParameters>]
```

### SetWebresourceFromContent
```
Set-CrmWebresource [-Id] <Guid> [-DisplayName <String>] [-Description <String>] [-Content <Byte[]>]
 [-IsCustomizable <Boolean>] [-PassThru] [<CommonParameters>]
```

### SetWebresourceFromPath
```
Set-CrmWebresource [-Id] <Guid> [-DisplayName <String>] [-Description <String>] [-LiteralPath <String>]
 [-IsCustomizable <Boolean>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Update a webresource.

## EXAMPLES

## PARAMETERS

### -Content
The content for the webresource.

```yaml
Type: Byte[]
Parameter Sets: SetWebresourceFromContent
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
The description for the webresource.

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

### -DisplayName
The displayname for the webresource.

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
The id of the webresource to update.

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

### -IsCustomizable
Whether the webresource is customizable.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LiteralPath
The path to the file containing the content for the webresource.

```yaml
Type: String
Parameter Sets: SetWebresourceFromPath
Aliases: PSPath, Path

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns an object that represents the webresource. By default, this cmdlet does not generate any output.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[Export-CrmWebresource](Export-CrmWebresource.md)

[Get-CrmWebresource](Get-CrmWebresource.md)

[Import-CrmWebresource](Import-CrmWebresource.md)

[New-CrmWebresource](New-CrmWebresource.md)

[Remove-CrmWebresource](Remove-CrmWebresource.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
