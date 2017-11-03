---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/New-CrmPublisher.md
schema: 2.0.0
---

# New-CrmPublisher

## SYNOPSIS
Add a new customizations publisher.

## SYNTAX

```
New-CrmPublisher [-Name] <String> -DisplayName <String> -Prefix <String> [-OptionSetValuePrefix <Int32>]
 [-Description <String>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Add a new customizations publisher.

## EXAMPLES

### Example 1
```
PS C:\> New-CrmPublisher -Name 'amsoftware' -DisplayName 'AMSoftware' -Prefix 'ams'
```

## PARAMETERS

### -Description
The description for the publisher.

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
The displayname for the publisher.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name for the publisher.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionSetValuePrefix
The optionset value prefix for the publisher.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns an object that represents the Solution Publisher. By default, this cmdlet does not generate any output.

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

### -Prefix
The prefix for the publisher.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[Get-CrmPublisher](Get-CrmPublisher.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
