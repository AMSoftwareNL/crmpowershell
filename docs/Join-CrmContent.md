---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Join-CrmContent.md
schema: 2.0.0
---

# Join-CrmContent

## SYNOPSIS
Associate one record with another.

## SYNTAX

### JoinContentByInputObject (Default)
```
Join-CrmContent [-InputObject] <Entity> [-ToEntity] <String> [-ToId] <Guid> [-Attribute <String>] [-AsBatch]
 [<CommonParameters>]
```

### JoinContent
```
Join-CrmContent [-Entity] <String> [-Id] <Guid> [-ToEntity] <String> [-ToId] <Guid> [-Attribute <String>]
 [-AsBatch] [<CommonParameters>]
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
The LogicalName of the attribute on the target entity to set the association for.

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
The LogicalName of the entity to associate.

```yaml
Type: System.String
Parameter Sets: JoinContent
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
Type: System.Guid
Parameter Sets: JoinContent
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
The entity record of the entity to associate.

```yaml
Type: Microsoft.Xrm.Sdk.Entity
Parameter Sets: JoinContentByInputObject
Aliases: Record

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ToEntity
The LogicalName of the entity associate the record with.

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

### -ToId
The id of the record of the entity to associate the record with.

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

[Remove-CrmContent](Remove-CrmContent.md)

[Set-CrmContent](Set-CrmContent.md)

[Split-CrmContent](Split-CrmContent.md)
