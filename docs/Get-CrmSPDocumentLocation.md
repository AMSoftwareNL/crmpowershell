---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmSPDocumentLocation.md
schema: 2.0.0
---

# Get-CrmSPDocumentLocation

## SYNOPSIS
Retrieve SharePoint Document locations

## SYNTAX

### GetBySharePointDocumentLocationId (Default)
```
Get-CrmSPDocumentLocation [-Id] <Guid[]> [<CommonParameters>]
```

### GetByRegardingObjectId
```
Get-CrmSPDocumentLocation [-RegardingObjectId] <Guid[]> [<CommonParameters>]
```

## DESCRIPTION
Retrieve SharePoint Document locations.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-CrmSPDocumentLocation -Id '54D31946-8901-44F7-994D-29F6564B6D56'
```

Retrieve a specific location by Id.

### Example 2
```powershell
PS C:\> $accountId = Get-CrmContent -Entity account -First 1 | Select-Object Id
PS C:\> Get-CrmSPDocumentLocation -RegardingObjectId $accountId
```

Retrieve the document locations for a specific entity.

## PARAMETERS

### -Id
Id of a Sharepoint Document location entity.

```yaml
Type: Guid[]
Parameter Sets: GetBySharePointDocumentLocationId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegardingObjectId
Id of an entity to retrieve SharePoint Document location for.

```yaml
Type: Guid[]
Parameter Sets: GetByRegardingObjectId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### Microsoft.Crm.Sdk.Messages.RetrieveAbsoluteAndSiteCollectionUrlResponse
## NOTES

## RELATED LINKS

[https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmSPDocumentLocation.md](https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmSPDocumentLocation.md)

