---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Add-CrmRelationship.md
schema: 2.0.0
---

# Add-CrmRelationship

## SYNOPSIS
Add a relationship.

## SYNTAX

### AddManyToManyRelationship
```
Add-CrmRelationship [-Entity1] <String> [-Entity2] <String> [-Name] <String> [-IntersectName] <String>
 [-AdvancedFind <Boolean>] [-Customizable <Boolean>] [-PassThru] [<CommonParameters>]
```

### AddOneToManyRelationship
```
Add-CrmRelationship [-Entity] <String> [-ToEntity] <String> [-Name] <String> -AttributeName <String>
 -AttributeDisplayName <String> [-AttributeDescription <String>] [-AttributeRequired <CrmRequiredLevel>]
 [-AdvancedFind <Boolean>] [-IsHierarchical <Boolean>] [-Customizable <Boolean>] [-Polymorphic] [-PassThru]
 [<CommonParameters>]
```

## DESCRIPTION
Add a relationship.

## EXAMPLES

## PARAMETERS

### -AdvancedFind
Whether the relationship appears in Advanced Find.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributeDescription
The description for the lookup attribute.

```yaml
Type: System.String
Parameter Sets: AddOneToManyRelationship
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributeDisplayName
The displayname for the lookup attribute.

```yaml
Type: System.String
Parameter Sets: AddOneToManyRelationship
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributeName
The LogicalName for the lookup attribute.

```yaml
Type: System.String
Parameter Sets: AddOneToManyRelationship
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributeRequired
The data entry requirement level enforced for the lookup attribute.

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmRequiredLevel
Parameter Sets: AddOneToManyRelationship
Aliases:
Accepted values: Unknown, Required, Recommended, Optional

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Customizable
Whether the entity relationship is customizable.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entity
The entity to add the one-to-many relationship for.

```yaml
Type: System.String
Parameter Sets: AddOneToManyRelationship
Aliases: EntityLogicalName, LogicalName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Entity1
The entity to add the many-to-many relationship for.

```yaml
Type: System.String
Parameter Sets: AddManyToManyRelationship
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entity2
The entity to add the many-to-many relationship for.

```yaml
Type: System.String
Parameter Sets: AddManyToManyRelationship
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IntersectName
The LogicalName for the intersect entity to create.

```yaml
Type: System.String
Parameter Sets: AddManyToManyRelationship
Aliases:

Required: True
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsHierarchical
Whether this relationship is the designated hierarchical self-referential relationship for this entity

```yaml
Type: System.Boolean
Parameter Sets: AddOneToManyRelationship
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The SchemaName of the relationship.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns an object that represents the RelationshipMetadata. By default, this cmdlet does not generate any output.

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

### -Polymorphic
Create a Polymorphic (Multi-table) Lookup Attribute. 
Include this switch when adding Relationship to an existing Polymorpic Lookup Attribute.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AddOneToManyRelationship
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ToEntity
The entity to add the one-to-many relationship to.

```yaml
Type: System.String
Parameter Sets: AddOneToManyRelationship
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Xrm.Sdk.Metadata.RelationshipMetadataBase

## NOTES

## RELATED LINKS

[Add-CrmRelationship](Add-CrmRelationship.md)

