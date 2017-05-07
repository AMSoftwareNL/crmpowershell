---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmEntityKey.html
schema: 2.0.0
---

# Get-CrmEntityKey

## SYNOPSIS
Get entity key metadata for an entity.

## SYNTAX

### GetEntityKeysByFilter (Default)
```
Get-CrmEntityKey [-Entity] <String> [-Attributes <String[]>] [-Include <String>] [-Exclude <String>]
 [-ExcludeManaged] [<CommonParameters>]
```

### GetEntityKeyById
```
Get-CrmEntityKey [-Id] <Guid> [<CommonParameters>]
```

### GetEntityKeyByName
```
Get-CrmEntityKey [-Entity] <String> [-Name] <String> [<CommonParameters>]
```

## DESCRIPTION
Get entity key metadata for an entity. This is only available with Dynamics CRM 2015 and later.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmEntityKey -Entity account -Attributes accountnumber -ExcludeManaged
```

Get the metadata for entity keys from the entity 'account' using attribute 'accountnumber'. Exclude keys marked as managed.

## PARAMETERS

### -Attributes
An array of LogicalNames of attributes which are part of the key. Any key containing at least the provided attributes is returned. 

NOTE: This parameter is case sensitive. i.e. it must match the case of the LogicalName exactly.

```yaml
Type: String[]
Parameter Sets: GetEntityKeysByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entity
The LogicalName of the entity to retrieve attribute metadata for.

NOTE: This parameter is case sensitive. i.e. it must match the case of the LogicalName exactly.

```yaml
Type: String
Parameter Sets: GetEntityKeysByFilter, GetEntityKeyByName
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Exclude
Exclude the metadata for entitie keys whose LogicalName matches the provided pattern.

```yaml
Type: String
Parameter Sets: GetEntityKeysByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExcludeManaged
Do not retrieve metadata for entitie keys that are marked as managed.

```yaml
Type: SwitchParameter
Parameter Sets: GetEntityKeysByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The MetadataId of the entity key to retrieve.

```yaml
Type: Guid
Parameter Sets: GetEntityKeyById
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Include
Include the metadata for entitie keys whose LogicalName matches the provided pattern.

```yaml
Type: String
Parameter Sets: GetEntityKeysByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The LogicalName of the entity key to retrieve the metadata for.

NOTE: This parameter is case sensitive. i.e. it must match the case of the LogicalName exactly.

```yaml
Type: String
Parameter Sets: GetEntityKeyByName
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Xrm.Sdk.Metadata.EntityKeyMetadata

## NOTES
The Name and Attributes parameters are case sensitive. i.e. these must match the case of the LogicalName exactly.

## RELATED LINKS

[Get-CrmEntity](Get-CrmEntity.md)

[Get-CrmAttribute](Get-CrmAttribute.md)

[Get-CrmOptionSet](Get-CrmOptionSet.md)

[Get-CrmRelationship](Get-CrmRelationship.md)

[Add-CrmEntityKey](Add-CrmEntityKey.md)

[Remove-CrmEntityKey](Remove-CrmEntityKey.md)

[EntityKeyMetadata Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.metadata.entitykeymetadata.aspx)
