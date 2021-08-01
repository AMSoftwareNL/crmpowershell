---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/New-CrmWebresource.md
schema: 2.0.0
---

# New-CrmWebresource

## SYNOPSIS
Add new new webresource.

## SYNTAX

### NewWebresourceFromContent (Default)
```
New-CrmWebresource [-Name] <String> [-DisplayName <String>] [-Description <String>]
 -WebresourceType <CrmWebresourceType> -Content <Byte[]> [-IsCustomizable <Boolean>] [-PassThru]
 [<CommonParameters>]
```

### NewWebresourceFromPath
```
New-CrmWebresource [-Name] <String> [-DisplayName <String>] [-Description <String>]
 -WebresourceType <CrmWebresourceType> -LiteralPath <String> [-IsCustomizable <Boolean>] [-PassThru]
 [<CommonParameters>]
```

## DESCRIPTION
Add new new webresource.

## EXAMPLES

## PARAMETERS

### -Content
The content for the webresource.

```yaml
Type: System.Byte[]
Parameter Sets: NewWebresourceFromContent
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Description
The description for the webresource.

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

### -DisplayName
The displayname for the webresource.

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

### -IsCustomizable
Whether the webresource is customizable.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LiteralPath
The path to a file the get the content of the webresource from.

```yaml
Type: System.String
Parameter Sets: NewWebresourceFromPath
Aliases: PSPath, Path

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name for the webresource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns an object that represents the WebResource. By default, this cmdlet does not generate any output.

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

### -WebresourceType
The type of the webresource.

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmWebresourceType
Parameter Sets: (All)
Aliases:
Accepted values: All, HTML, CSS, JS, XML, PNG, JPG, GIF, XAP, XSL, ICO

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Byte[]

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[Export-CrmWebresource](Export-CrmWebresource.md)

[Get-CrmWebresource](Get-CrmWebresource.md)

[Import-CrmWebresource](Import-CrmWebresource.md)

[Remove-CrmWebresource](Remove-CrmWebresource.md)

[Set-CrmWebresource](Set-CrmWebresource.md)

[Entity Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.entity)
