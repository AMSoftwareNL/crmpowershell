---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmContent.md
schema: 2.0.0
---

# Get-CrmContent

## SYNOPSIS
Retrieve data records from an entity.

## SYNTAX

### GetContentForEntityByQuery (Default)
```
Get-CrmContent [-Entity] <String> [[-Query] <Hashtable>] [[-Order] <Hashtable>] [-Columns <String[]>]
 [-AsBatch] [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

### GetContentForEntityById
```
Get-CrmContent [-Entity] <String> [-Id] <Guid[]> [-Columns <String[]>] [-AsBatch] [-IncludeTotalCount]
 [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

### GetContentForEntityByKeys
```
Get-CrmContent [-Entity] <String> [-Keys] <Hashtable> [-Columns <String[]>] [-AsBatch] [-IncludeTotalCount]
 [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

### GetContentWithFetchXml
```
Get-CrmContent [-FetchXml] <XmlDocument> [-AsBatch] [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
 [<CommonParameters>]
```

## DESCRIPTION
Retrieve data-records from an entity using attribute values, key values, the id or FetchXML. 

Paging is applied when retrieving the records to ensure all items are returned instead of only the first 5000.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmContent -Entity account -Query @{accountnumber='123456'} -Columns@('accountnumber','accountname')
```

Retrieve the record from the entity 'account' where the accountnumber is '123456'. Include only the accountnumber and accountname in the result.

### Example 2
```
PS C:\> Get-CrmContent -Entity account -Order @{accountname='Descending'}
```

Retrieve  records from the entity 'account'. Sort the result by accountname in descending order.

### Example 3
```
PS C:\> [xml]$fetchxml = Get-Content -LiteralPath c:\temp\fetch.xml -Encoding UTF8
PS C:\> Get-CrmContent -FetchXml $fecthxml
```

Retrieve records based on a FetchXML query stored in fetch.xml.

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

### -Columns
The logicalnames of the attributes to include in the result.

NOTE: This parameter is case sensitive. i.e. it must match the case of the LogicalName exactly.

```yaml
Type: System.String[]
Parameter Sets: GetContentForEntityByQuery, GetContentForEntityById, GetContentForEntityByKeys
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entity
The logicalname of the entity to retrieve the records from.

NOTE: This parameter is case sensitive. i.e. it must match the case of the LogicalName exactly.

```yaml
Type: System.String
Parameter Sets: GetContentForEntityByQuery, GetContentForEntityById, GetContentForEntityByKeys
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FetchXml
The XmlDocument containing a FecthXML query.

```yaml
Type: System.Xml.XmlDocument
Parameter Sets: GetContentWithFetchXml
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Id
The Id of the record to retrieve. 

This can be an Entity object or EntityReference object. These will be converted to Guid as required.

```yaml
Type: System.Guid[]
Parameter Sets: GetContentForEntityById
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Keys
A hashtable of attribute logicalnames and values which match an entity key. The record is retrieved using the unique key.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: GetContentForEntityByKeys
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Order
A hashtable of attribute logicalnames and the order the sort the result. Provide the attribute logicalname as the key and the sort order as the value.

Valid values for the sort order are:

 -- Ascending : Sort the attribute ascending.
 
 -- Decending : Sort the attribute decending.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: GetContentForEntityByQuery
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Query
A hashtable of attribute logicalnames and values to filter the results. 

```yaml
Type: System.Collections.Hashtable
Parameter Sets: GetContentForEntityByQuery
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeTotalCount
Return the total count (and accuracy) of the number of records before returning the result.

Because of the limitations of Dynamics CRM, the total count is only returned accurate when the result is limited to 5000 items.

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

### -Skip
Skips (does not return) the specified number of records.

```yaml
Type: System.UInt64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -First
Specifies the number of records to retrieve from the beginning.

```yaml
Type: System.UInt64
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

### System.Guid[]

### System.String[]

### System.Xml.XmlDocument

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES
Referenced LogicalNames and SchemaNames are case sensitive. i.e. These must match the case of the LogicalName or SchemaName exactly.

## RELATED LINKS

[Add-CrmContent](Add-CrmContent.md)

[Join-CrmContent](Join.CrmContent.md)

[Set-CrmContent](Set-CrmContent.md)

[Split-CrmContent](Split-CrmContent.md)

[Remove-CrmContent](Remove-CrmContent.md)

[Entity Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.entity)
