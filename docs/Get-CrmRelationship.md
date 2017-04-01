---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmRelationship.html
schema: 2.0.0
---

# Get-CrmRelationship

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### GetRelationshipByName
```
Get-CrmRelationship [-Name] <String>
```

### GetRelationshipById
```
Get-CrmRelationship [-Id] <Guid>
```

### GetRelationshipByFilter
```
Get-CrmRelationship [[-Entity] <String>] [[-RelatedEntity] <String>] [-Include <String>] [-Exclude <String>]
 [-Type <CrmRelationshipType>] [-CustomOnly] [-ExcludeManaged]
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

### -CustomOnly
{{Fill CustomOnly Description}}

```yaml
Type: SwitchParameter
Parameter Sets: GetRelationshipByFilter
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
Parameter Sets: GetRelationshipByFilter
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Exclude
{{Fill Exclude Description}}

```yaml
Type: String
Parameter Sets: GetRelationshipByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExcludeManaged
{{Fill ExcludeManaged Description}}

```yaml
Type: SwitchParameter
Parameter Sets: GetRelationshipByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
{{Fill Id Description}}

```yaml
Type: Guid
Parameter Sets: GetRelationshipById
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Include
{{Fill Include Description}}

```yaml
Type: String
Parameter Sets: GetRelationshipByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
{{Fill Name Description}}

```yaml
Type: String
Parameter Sets: GetRelationshipByName
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RelatedEntity
{{Fill RelatedEntity Description}}

```yaml
Type: String
Parameter Sets: GetRelationshipByFilter
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
{{Fill Type Description}}

```yaml
Type: CrmRelationshipType
Parameter Sets: GetRelationshipByFilter
Aliases: 
Accepted values: All, OneToMany, ManyToMany

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### None


## OUTPUTS

### Microsoft.Xrm.Sdk.Metadata.RelationshipMetadataBase


## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/Get-CrmRelationship.html](http://crmpowershell.amsoftware.nl/Get-CrmRelationship.html)

