---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmEntity.html
schema: 2.0.0
---

# Get-CrmEntity

## SYNOPSIS
Get the metadata of an entity.

## SYNTAX

### GetEntitiesByFilter (Default)
```
Get-CrmEntity [-Include <String>] [-Exclude <String>] [-CustomOnly] [-ExcludeManaged] [-IncludeIntersects]
```

### GetEntityById
```
Get-CrmEntity [-Id] <Guid>
```

### GetEntityByName
```
Get-CrmEntity [-Name] <String>
```

## DESCRIPTION
Get the metadata of an entity. 

The first time retrieving the metadata will take some time. In consecutive calls the performance will improve as the metadata will be cached in the session. For Dynamics CRM 2011 Rollup 12 and later the cache will be automatically updated as required based on metadata changes. Before Dynamics CRM 2011 Rollup 12 the cache will be updated after 5 minutes. To force and update of the cache reconnect to the organization.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmEntity -Name account
```

Get the metadata of the entity 'account'.

### Example 2
```
PS C:\> Get-CrmEntity -Include '*account*' -CustomOnly -ExcludeManaged
```

Get the metadata of all entities with 'account' in the LogicalName. Retrieve only custom entities, that are not managed.

## PARAMETERS

### -CustomOnly
Retrieve only the metadata for entities that are marked as custom.

```yaml
Type: SwitchParameter
Parameter Sets: GetEntitiesByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Exclude
Exclude the metadata for entities whose LogicalName matches the provided pattern.

```yaml
Type: String
Parameter Sets: GetEntitiesByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -ExcludeManaged
Do not retrieve metadata for entities that are marked as managed.

```yaml
Type: SwitchParameter
Parameter Sets: GetEntitiesByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The MetadataId of the entity to retrieve.

```yaml
Type: Guid
Parameter Sets: GetEntityById
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Include
Include the metadata for entities whose LogicalName matches the provided pattern.

```yaml
Type: String
Parameter Sets: GetEntitiesByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -IncludeIntersects
Include the metadata for entities marked as intersect. These are entities which are created by Dynamics CRM to support N:N relationships.

```yaml
Type: SwitchParameter
Parameter Sets: GetEntitiesByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The LogicalName of the entity to retrieve the metadata for.

NOTE: This parameter is case sensitive. i.e. it must match the case of the LogicalName exactly.

```yaml
Type: String
Parameter Sets: GetEntityByName
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### None


## OUTPUTS

### Microsoft.Xrm.Sdk.Metadata.EntityMetadata


## NOTES

The Name parameter is case sensitive. i.e. it must match the case of the LogicalName exactly.

## RELATED LINKS

[Get-CrmAttribute](Get-CrmAttribute.md)

[Get-CrmEntityKey](Get-CrmEntityKey.md)

[Get-CrmOptionSet](Get-CrmOptionSet.md)

[Get-CrmRelationship](Get-CrmRelationship.md)

[New-CrmEntity](New-CrmEntity.md)

[Set-CrmEntity](Set-CrmEntity.md)

[Remove-CrmEntity](Remove-CrmEntity.md)

[EntityMetadata Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.metadata.entitymetadata.aspx)
