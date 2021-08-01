---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Add-CrmContent.md
schema: 2.0.0
---

# Add-CrmContent

## SYNOPSIS
Add a data record to an entity.

## SYNTAX

### AddContentByInputObject (Default)
```
Add-CrmContent [-InputObject] <Entity> [-PassThru] [-AsBatch] [-Upsert] [<CommonParameters>]
```

### AddContent
```
Add-CrmContent [-Entity] <String> [[-Id] <Guid>] [-Attributes] <Hashtable> [-PassThru] [-AsBatch] [-Upsert]
 [<CommonParameters>]
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

### -Attributes
A hashtable containing to attribute LogicalNames and values of the record.

```yaml
Type: System.Collections.Hashtable
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
Type: System.String
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
Type: System.Guid
Parameter Sets: AddContent
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
An entity object containing the attributes and values of the record.

```yaml
Type: Microsoft.Xrm.Sdk.Entity
Parameter Sets: AddContentByInputObject
Aliases: Record

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns an object that represents the new record. By default, this cmdlet does not generate any output.

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

### -Upsert
Try Upsert instead of Create of the record.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Xrm.Sdk.Entity

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[Get-CrmContent](Get-CrmContent.md)

[Join-CrmContent](Join-CrmContent.md)

[Remove-CrmContent](Remove-CrmContent.md)

[Set-CrmContent](Set-CrmContent.md)

[Split-CrmContent](Split-CrmContent.md)

[Entity Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.entity)

[Use Upsert to insert or update a record](https://docs.microsoft.com/en-us/powerapps/developer/data-platform/use-upsert-insert-update-record)
