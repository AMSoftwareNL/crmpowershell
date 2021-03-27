---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Connect-CrmOrganization.md
schema: 2.0.0
---

# Connect-CrmOrganization

## SYNOPSIS
Connect to a Dataverse environment.

## SYNTAX

### Connectionstring (Default)
```
Connect-CrmOrganization [-Connectionstring] <String> [<CommonParameters>]
```

### Connection
```
Connect-CrmOrganization [-Connection] <CrmServiceClient> [<CommonParameters>]
```

## DESCRIPTION
Connect to a Dataverse environment.

Use the Microsoft.Xrm.Tooling.CrmConnector.PowerShell module to connect to an environment. Supply the connection to this Cmdlet.

Provide a connectionstring to an environment. See [Use connection strings in XRM tooling to connect to Microsoft Dataverse](https://docs.microsoft.com/en-us/powerapps/developer/data-platform/xrm-tooling/use-connection-strings-xrm-tooling-connect) 

## EXAMPLES

### Example 1
```
PS C:\> Install-Module 'Microsoft.Xrm.Tooling.CrmConnector.PowerShell'
PS C:\> $connection = Get-CrmConnection -InteractiveMode
PS C:\> Connect-CrmOrganization -Connection $connection
```

### Example 2
```
PS C:\> Connect-CrmOrganization -Connectionstring 'AuthType=Office365;Username=jsmith@contoso.onmicrosoft.com;Password=passcode;Url=https://contoso.crm.dynamics.com'
```

## PARAMETERS

### -Connection
CrmServiceClient object from Get-CrmOrganization.

```yaml
Type: CrmServiceClient
Parameter Sets: Connection
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Connectionstring
Connectionstring to connect using the CrmServiceClient. See [Use connection strings in XRM tooling to connect to Microsoft Dataverse](https://docs.microsoft.com/en-us/powerapps/developer/data-platform/xrm-tooling/use-connection-strings-xrm-tooling-connect) 

```yaml
Type: String
Parameter Sets: Connectionstring
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

### None
## OUTPUTS

### Microsoft.Xrm.Sdk.Discovery.OrganizationDetail
## NOTES

## RELATED LINKS

[OrganizationDetail Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.organization.organizationdetail.aspx)

[Use connection strings in XRM tooling to connect to Microsoft Dataverse](https://docs.microsoft.com/en-us/powerapps/developer/data-platform/xrm-tooling/use-connection-strings-xrm-tooling-connect) 

[Microsoft.Xrm.Tooling.CrmConnector.PowerShell](https://docs.microsoft.com/en-us/powershell/module/microsoft.xrm.tooling.crmconnector.powershell)

[PowerShell Gallery: Microsoft.Xrm.Tooling.CrmConnector.PowerShell](https://www.powershellgallery.com/packages/Microsoft.Xrm.Tooling.CrmConnector.PowerShell)
