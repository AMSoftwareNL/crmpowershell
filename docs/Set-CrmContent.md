---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Set-CrmContent.md
schema: 2.0.0
---

# Set-CrmContent

## SYNOPSIS
Update a data record of an entity.

## SYNTAX

### SetContentByInputObject (Default)
```
Set-CrmContent [-InputObject] <Entity> [-PassThru] [<CommonParameters>]
```

### SetContent
```
Set-CrmContent [-Entity] <String> [-Id] <Guid> [-Attributes] <Hashtable> [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Update a data record of an entity.

## EXAMPLES

### Example 1
```
PS C:\> Set-CrmContent -Entity account -Id 'A0B7A137-8CBF-4D4B-BF2A-7305126BDA4A' -Attributes @{accountnumber='123456';'accountname'='AMSoftware'}
```

Update a record for an account.

## PARAMETERS

### -Attributes
A hashtable containing to attribute LogicalNames and values of the record.

```yaml
Type: Hashtable
Parameter Sets: SetContent
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entity
The LogicalName of the entity to update the record for.

```yaml
Type: String
Parameter Sets: SetContent
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The unique id of the record to update.

```yaml
Type: Guid
Parameter Sets: SetContent
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
An entity object containing the attributes and values of the record.

```yaml
Type: Entity
Parameter Sets: SetContentByInputObject
Aliases: Record

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns an object that represents the entity record. By default, this cmdlet does not generate any output.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Xrm.Sdk.Entity
### System.Guid
## OUTPUTS

### Microsoft.Xrm.Sdk.Entity
## NOTES

## RELATED LINKS

[Add-CrmContent](Add-CrmContent.md)

[Get-CrmContent](Get-CrmContent.md)

[Join-CrmContent](Join-CrmContent.md)

[Remove-CrmContent](Remove-CrmContent.md)

[Split-CrmContent](Split-CrmContent.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
