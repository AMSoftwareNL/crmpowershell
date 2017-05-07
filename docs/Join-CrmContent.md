---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Join-CrmContent.html
schema: 2.0.0
---

# Join-CrmContent

## SYNOPSIS
Associate one record with another.

## SYNTAX

```
Join-CrmContent [-Entity] <String> [-Id] <Guid> [-ToEntity] <String> [-ToId] <Guid> [-Attribute <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Associate one record with another.

This can be used to set lookups (instead of Set-CrmContent), but is most usefull for setting associated records in many-to-many relations.

## EXAMPLES

### Example 1
```
PS C:\> Join-CrmEnity -Entity 'contact' -Id '53B38B4C-7A26-4731-84A3-6A3229F9CC60' -ToEntity 'account' -ToId '76629DD4-7A1A-4F47-BEEA-5D881676938C' -Attribute 'primarycontactid'
```

Associate the specified contact with the specified account for attribute 'primarycontactid'

## PARAMETERS

### -Attribute
The LogicalName of the attribute on the target entity to set the association for.

If the relationship between the entity and target entity is unique this parameter is not required. 

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

### -Entity
The LogicalName of the entity to associate.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The id of the record of the entity to associate.

```yaml
Type: Guid
Parameter Sets: (All)
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ToEntity
The LogicalName of the entity associate the record with.

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

### -ToId
The id of the record of the entity to associate the record with.

```yaml
Type: Guid
Parameter Sets: (All)
Aliases: 

Required: True
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### None

## NOTES

## RELATED LINKS

[Add-CrmContent](Add-CrmContent.md)

[Get-CrmContent](Get-CrmContent.md)

[Remove-CrmContent](Remove-CrmContent.md)

[Set-CrmContent](Set-CrmContent.md)

[Split-CrmContent](Split-CrmContent.md)
