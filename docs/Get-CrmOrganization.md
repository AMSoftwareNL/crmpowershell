---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmOrganization.md
schema: 2.0.0
---

# Get-CrmOrganization

## SYNOPSIS
Retrieve the organizations available in the connected deployment.

## SYNTAX

```
Get-CrmOrganization [[-Name] <String>] [-Exclude <String>] [<CommonParameters>]
```

## DESCRIPTION
Retrieve the organizations available in the connected deployment, based on unique name, organization service URL or friendly name.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmOrganization -Name amsoftwarecrm
```

Get the organization information for the organization in the connected deployment with the name 'amsoftwarecrm'.

## PARAMETERS

### -Exclude
Exclude organizations whose name matches the provided pattern.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The unique name, organization service url or friendly name of the organization. The first organization matching the name is returned.

```yaml
Type: String
Parameter Sets: (All)
Aliases: Include

Required: False
Position: 0
Default value: None
Accept pipeline input: False
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

[Connect-CrmDeployment](Get-CrmDeployment.md)

[Connect-CrmOrganization](Connect-CrmOrganization.md)

[OrganizationDetail Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.organization.organizationdetail.aspx)
