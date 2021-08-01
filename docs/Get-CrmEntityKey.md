---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmEntityKey.md
schema: 2.0.0
---

# Get-CrmEntityKey

## SYNOPSIS
Get Keys for Entity

## SYNTAX

### GetEntityKeysByFilter (Default)
```
Get-CrmEntityKey [-Entity] <String> [[-Name] <String>] [-Exclude <String>] [-ExcludeManaged]
 [-Attributes <String[]>] [<CommonParameters>]
```

### GetEntityKeyById
```
Get-CrmEntityKey [-Id] <Guid[]> [<CommonParameters>]
```

## DESCRIPTION
Get Keys for Entity

## EXAMPLES

## PARAMETERS

### -Attributes
Return keys containing the provided Attributes.

```yaml
Type: System.String[]
Parameter Sets: GetEntityKeysByFilter
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entity
The LogicalName of the Entity to return the Keys for.

```yaml
Type: System.String
Parameter Sets: GetEntityKeysByFilter
Aliases: LogicalName, EntityLogicalName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Exclude
Keys to exclude

```yaml
Type: System.String
Parameter Sets: GetEntityKeysByFilter
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -ExcludeManaged
Exclude any managed Keys

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GetEntityKeysByFilter
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Id of the Key to return

```yaml
Type: System.Guid[]
Parameter Sets: GetEntityKeyById
Aliases: MetadataId

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Key to return

```yaml
Type: System.String
Parameter Sets: GetEntityKeysByFilter
Aliases: Include

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid[]

### System.String

### System.String[]

## OUTPUTS

### Microsoft.Xrm.Sdk.Metadata.EntityKeyMetadata

## NOTES

## RELATED LINKS

[https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmEntityKey.md](https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmEntityKey.md)

