---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Add-RecordTeamUser.md
schema: 2.0.0
---

# Add-CrmRecordTeamUser

## SYNOPSIS
Add a user to the Team for a record

## SYNTAX

```
Add-CrmRecordTeamUser [-User] <Guid> [-TeamTemplate] <Guid> -Record <EntityReference[]> [<CommonParameters>]
```

## DESCRIPTION
Add a user to the Team for a record

## EXAMPLES

## PARAMETERS

### -Record
A Dataverse table record. Accepts input from the pipeline.

```yaml
Type: Microsoft.Xrm.Sdk.EntityReference[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -TeamTemplate
Id of the Team Template to use.

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -User
The Id of the User to add

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Xrm.Sdk.EntityReference[]

## OUTPUTS

### Microsoft.Xrm.Sdk.OrganizationResponse

## NOTES

## RELATED LINKS

[Add-RecordTeamUser](Add-RecordTeamUser.md)

[AddUserToRecordTeamRequest Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.addusertorecordteamrequest)
