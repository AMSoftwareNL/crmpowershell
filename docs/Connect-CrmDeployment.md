---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Connect-CrmDeployment.html
schema: 2.0.0
---

# Connect-CrmDeployment

## SYNOPSIS
Connect and authenticate to a Dynamics CRM deployment.

## SYNTAX

### ConnectOnline
```
Connect-CrmDeployment [-Region] <String> [-Credential] <PSCredential>
```

### ConnectOnPremises
```
Connect-CrmDeployment [-DiscoveryUrl] <Uri> [[-Credential] <PSCredential>]
```

## DESCRIPTION
Connect and authenticate with a Dynamics CRM deployment. This can be a on premises deployment (using the Discovery URL) or a Dynamics 365 deployment (specifying the region).

When connecting to an on premises deployment the credentials are optional. If not provided the current Windows credentials will be used.

This cmdlet should be the first to execute in the PowerShell session. The connection to the deployment will be stored in the session, and will remain until connecting to another deployment.

## EXAMPLES

### Example 1
```
PS C:\> Connect-CrmDeployment -Region crm4 -Credentials (Get-Credentials)
```

Connect to Dynamics 365 in the European region, and ask for the credentials.

### Example 2
```
PS C:\> Connect-CrmDeployment -DiscoveryUrl https://crmdiscovery.amsoftware.nl
```

Connect to an on premises Dynamics CRM deployment using the credentials of the current logged in Windows user.

## PARAMETERS

### -Credential
The credentials to authenticate with the deployment.

```yaml
Type: PSCredential
Parameter Sets: ConnectOnline
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: PSCredential
Parameter Sets: ConnectOnPremises
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiscoveryUrl
The URL of the Dynamics CRM Discovery Services. Provide the full URL or just the unique part for the deployment. '/XRMServices/2011/Discovery.svc' will be added to the end of the URL if not provided.

```yaml
Type: Uri
Parameter Sets: ConnectOnPremises
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Region
The region of Dynamics 365 to connect to. Region must be provided as 'crm[0..9]' i.e. 'crm4'.

```yaml
Type: String
Parameter Sets: ConnectOnline
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

For on premises deployments the following form of authetnication are supported: Windows Authentication, Claims Based Authentication (CBA) and Internet Facing Deployment (IFD).

## RELATED LINKS

[Get-CrmOrganization](Get-CrmOrganization.md)

[Connect-CrmOrganization](Get-CrmOrganization.md)

[OrganizationDetail Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.discovery.organizationdetail.aspx)

