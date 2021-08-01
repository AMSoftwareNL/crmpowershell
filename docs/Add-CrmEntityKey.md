---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Add-CrmEntityKey.md
schema: 2.0.0
---

# Add-CrmEntityKey

## SYNOPSIS
Add a key to an entity.

## SYNTAX

### AddEntityKeyByInputObject (Default)
```
Add-CrmEntityKey [-Entity] <String> [-InputObject] <EntityKeyMetadata> [-PassThru] [<CommonParameters>]
```

### AddEntityKey
```
Add-CrmEntityKey [-Entity] <String> [-Name] <String> [-DisplayName] <String> -Attributes <String[]>
 [-SchemaName <String>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Add a key to an entity.

## EXAMPLES

### Example 1
```
PS C:\> Add-CrmEntityKey -Entity account -Name accountnumber -DisplayName Accountnumber -Attributes @('accountnumber')
```

Add accountnumber as unique key on account.

## PARAMETERS

### -Attributes
The LogicalName of the attributes for the key.

```yaml
Type: System.String[]
Parameter Sets: AddEntityKey
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
The displayname for the key.

```yaml
Type: System.String
Parameter Sets: AddEntityKey
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entity
The LogicalName of the entity the add the key to.

```yaml
Type: System.String
Parameter Sets: AddEntityKeyByInputObject
Aliases: EntityLogicalName, LogicalName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: AddEntityKey
Aliases: EntityLogicalName, LogicalName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The EntityKeyMetadata of the key to add.

```yaml
Type: Microsoft.Xrm.Sdk.Metadata.EntityKeyMetadata
Parameter Sets: AddEntityKeyByInputObject
Aliases: EntityKey

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name for the key.

```yaml
Type: System.String
Parameter Sets: AddEntityKey
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns an object that represents the EntityKeyMetadata. By default, this cmdlet does not generate any output.

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

### -SchemaName
The SchemaName for the key. If omitted the Name will be used as the SchemaName.

```yaml
Type: System.String
Parameter Sets: AddEntityKey
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

### System.String

### Microsoft.Xrm.Sdk.Metadata.EntityKeyMetadata

## OUTPUTS

### Microsoft.Xrm.Sdk.Metadata.EntityKeyMetadata

## NOTES

## RELATED LINKS

[Get-CrmEntityKey](Get-CrmEntityKey.md)

[Remove-CrmEntityKey](Remove-CrmEntityKey.md)

[EntityMetadata Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.metadata.entitymetadata)
