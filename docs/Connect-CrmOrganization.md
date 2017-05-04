---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Connect-CrmOrganization.html
schema: 2.0.0
---

# Connect-CrmOrganization

## SYNOPSIS
Connect to a specific organization in the connected deployment.

## SYNTAX

```
Connect-CrmOrganization [-Name] <String>
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
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### None


## OUTPUTS

### Microsoft.Xrm.Sdk.Discovery.OrganizationDetail


## NOTES

## RELATED LINKS

[Connect-CrmDeployment](Connect-CrmDeployment.md)

[Get-CrmOrganization](Get-CrmOrganization.md)

[OrganizationDetail Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.organization.organizationdetail.aspx)