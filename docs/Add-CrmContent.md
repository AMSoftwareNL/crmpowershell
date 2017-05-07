---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Add-CrmContent.html
schema: 2.0.0
---

# Add-CrmContent

## SYNOPSIS
Add a data record to an entity.

## SYNTAX

### AddContentByInputObject (Default)
```
Add-CrmContent [-Record] <Entity> [<CommonParameters>]
```

### AddContent
```
Add-CrmContent [-Entity] <String> [[-Id] <Guid>] [-Attributes] <Hashtable> [<CommonParameters>]
```

## DESCRIPTION
Add a data record to an entity.

## EXAMPLES

### Example 1
```
PS C:\> Add-CrmContent -Entity account -Attributes @{accountnumber='123456';'accountname'='AMSoftware'}
```

Add an record to account.

## PARAMETERS

### -Attributes
A hashtable containing to attribute LogicalNames and values of the record.

```yaml
Type: Hashtable
Parameter Sets: AddContent
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entity
The LogicalName of the entity to add the record to.

```yaml
Type: String
Parameter Sets: AddContent
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The unique id of the new record.

```yaml
Type: Guid
Parameter Sets: AddContent
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Record
An entity object containing the attributes and values of the record.

```yaml
Type: Entity
Parameter Sets: AddContentByInputObject
Aliases: 

Required: True
Position: 1
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

[Get-CrmContent](Get-CrmContent.md)

[Join-CrmContent](Join-CrmContent.md)

[Remove-CrmContent](Remove-CrmContent.md)

[Set-CrmContent](Set-CrmContent.md)

[Split-CrmContent](Split-CrmContent.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
