---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Connect-CrmDeployment.html
schema: 2.0.0
---

# Connect-CrmDeployment

## SYNOPSIS
{{Fill in the Synopsis}}

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
{{Fill in the Description}}

## EXAMPLES

### Example 1
```
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Credential
{{Fill Credential Description}}

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
{{Fill DiscoveryUrl Description}}

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
{{Fill Region Description}}

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

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/Connect-CrmDeployment.html](http://crmpowershell.amsoftware.nl/Connect-CrmDeployment.html)

