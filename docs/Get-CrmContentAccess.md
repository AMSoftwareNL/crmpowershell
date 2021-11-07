---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmContentAccess.md
schema: 2.0.0
---

# Get-CrmContentAccess

## SYNOPSIS
Retrieve all security principals (users or teams) that have access to, and access rights for, the specified record.

## SYNTAX

### GetContentAccessByInputObject (Default)
```
Get-CrmContentAccess [-InputObject] <Entity> [<CommonParameters>]
```

### GetContentAccess
```
Get-CrmContentAccess [-Entity] <String> [-Id] <Guid> [<CommonParameters>]
```

## DESCRIPTION
Retrieve all security principals (users or teams) that have access to, and access rights for, the specified record.

## EXAMPLES

## PARAMETERS

### -Entity
Entity LogicalName of the record to get the principals for.

```yaml
Type: System.String
Parameter Sets: GetContentAccess
Aliases: LogicalName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Id of the record to get the principals for.

```yaml
Type: System.Guid
Parameter Sets: GetContentAccess
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Record to get the principals for.

```yaml
Type: Microsoft.Xrm.Sdk.Entity
Parameter Sets: GetContentAccessByInputObject
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

## OUTPUTS

### Microsoft.Crm.Sdk.Messages.PrincipalAccess

## NOTES

## RELATED LINKS

[Get-CrmContentAccess](Get-CrmContentAccess.md)

[RetrieveSharedPrincipalsAndAccess Request](https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrievesharedprincipalsandaccessrequest)
