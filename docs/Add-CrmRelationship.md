---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Add-CrmRelationship.html
schema: 2.0.0
---

# Add-CrmRelationship

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### AddManyToManyRelationship
```
Add-CrmRelationship [-Entity1] <String> [-Entity2] <String> [-Name] <String> [-IntersectName] <String>
 [-AdvancedFind <Boolean>] [-Customizable <Boolean>] [<CommonParameters>]
```

### AddOneToManyRelationship
```
Add-CrmRelationship [-Entity] <String> [-ToEntity] <String> [-Name] <String> -AttributeName <String>
 -AttributeDisplayName <String> [-AttributeDescription <String>] [-AttributeRequired <CrmRequiredLevel>]
 [-AdvancedFind <Boolean>] [-Customizable <Boolean>] [<CommonParameters>]
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

### -AdvancedFind
{{Fill AdvancedFind Description}}

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

### -AttributeDescription
{{Fill AttributeDescription Description}}

```yaml
Type: String
Parameter Sets: AddOneToManyRelationship
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributeDisplayName
{{Fill AttributeDisplayName Description}}

```yaml
Type: String
Parameter Sets: AddOneToManyRelationship
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributeName
{{Fill AttributeName Description}}

```yaml
Type: String
Parameter Sets: AddOneToManyRelationship
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributeRequired
{{Fill AttributeRequired Description}}

```yaml
Type: CrmRequiredLevel
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
{{Fill Customizable Description}}

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

### -Entity
{{Fill Entity Description}}

```yaml
Type: String
Parameter Sets: AddOneToManyRelationship
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entity1
{{Fill Entity1 Description}}

```yaml
Type: String
Parameter Sets: AddManyToManyRelationship
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entity2
{{Fill Entity2 Description}}

```yaml
Type: String
Parameter Sets: AddManyToManyRelationship
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IntersectName
{{Fill IntersectName Description}}

```yaml
Type: String
Parameter Sets: AddManyToManyRelationship
Aliases: 

Required: True
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
{{Fill Name Description}}

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ToEntity
{{Fill ToEntity Description}}

```yaml
Type: String
Parameter Sets: AddOneToManyRelationship
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

### Microsoft.Xrm.Sdk.Metadata.RelationshipMetadataBase

## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/Add-CrmRelationship.html](http://crmpowershell.amsoftware.nl/Add-CrmRelationship.html)

