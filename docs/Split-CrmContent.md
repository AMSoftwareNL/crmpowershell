---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Split-CrmContent.md
schema: 2.0.0
---

# Split-CrmContent

## SYNOPSIS
Disassociate one record from another.

## SYNTAX

### SplitContentByInputObject (Default)
```
Split-CrmContent [-InputObject] <Entity> [-FromEntity] <String> [-FromId] <Guid> [-Attribute <String>]
 [-AsBatch] [<CommonParameters>]
```

### SplitContent
```
Split-CrmContent [-Entity] <String> [-Id] <Guid> [-FromEntity] <String> [-FromId] <Guid> [-Attribute <String>]
 [-AsBatch] [<CommonParameters>]
```

## DESCRIPTION
Disassociate one record from another.

This can be used to clear lookups (instead of Set-CrmContent), but is most usefull for breaking associated records in many-to-many relations.

## EXAMPLES

### Example 1
```
PS C:\> Split-CrmEnity -Entity 'contact' -Id '53B38B4C-7A26-4731-84A3-6A3229F9CC60' -FromEntity 'account' -FromId '76629DD4-7A1A-4F47-BEEA-5D881676938C' -Attribute 'primarycontactid'
```

Disassociate the specified contact from the specified account for attribute 'primarycontactid'

## PARAMETERS

### -AsBatch
Execute the request as part of a batch (ExecuteMultiple or ExecuteTransaction). 
See Start-CrmBatch, Stop-CrmBatch and Submit-CrmBatch.

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

### -Attribute
The LogicalName of the attribute on the target entity to clear the association for.

If the relationship between the entity and target entity is unique this parameter is not required.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entity
The LogicalName of the entity to disassociate.

```yaml
Type: System.String
Parameter Sets: SplitContent
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FromEntity
The LogicalName of the entity disassociate the record from.

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

### -FromId
The id of the record of the entity to disassociate the record from.

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases:

Required: True
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The id of the record of the entity to disassociate.

```yaml
Type: System.Guid
Parameter Sets: SplitContent
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
The entity record to disassociate.

```yaml
Type: Microsoft.Xrm.Sdk.Entity
Parameter Sets: SplitContentByInputObject
Aliases: Record

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Xrm.Sdk.Entity

### System.Guid

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[Add-CrmContent](Add-CrmContent.md)

[Get-CrmContent](Get-CrmContent.md)

[Join-CrmContent](Join-CrmContent.md)

[Remove-CrmContent](Remove-CrmContent.md)

[Set-CrmContent](Set-CrmContent.md)
