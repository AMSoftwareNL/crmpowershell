---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Connect-CrmOrganization.md
schema: 2.0.0
---

# Connect-CrmOrganization

## SYNOPSIS
Connect to a specific organization in the connected deployment.

## SYNTAX

```
Connect-CrmOrganization [-Name] <String> [<CommonParameters>]
```

## DESCRIPTION
Connect to a specific organization in the connected deployment. This will set the organization as the active organization in the PowerShell session, until connection to another Deployment or Organization.

## EXAMPLES

### Example 1
```
PS C:\> Connect-CrmOrganization -Name amsoftwarecrm
```

## PARAMETERS

### -Name
The unique name or friendly name of the organization to connect to.

```yaml
Type: String
Parameter Sets: (All)
Aliases: UniqueName, FriendlyName, UrlName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### Microsoft.Xrm.Sdk.Discovery.OrganizationDetail
## NOTES

## RELATED LINKS

[Connect-CrmDeployment](Connect-CrmDeployment.md)

[Get-CrmOrganization](Get-CrmOrganization.md)

[OrganizationDetail Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.organization.organizationdetail.aspx)
