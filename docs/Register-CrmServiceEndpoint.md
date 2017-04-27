---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Register-CrmServiceEndpoint.html
schema: 2.0.0
---

# Register-CrmServiceEndpoint

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

```
Register-CrmServiceEndpoint -Name <String> [-Description <String>] -Namespace <String> -Path <String>
 -Contract <CrmServiceEndpointContract> [-Claim <CrmServiceEndpointUserClaim>] [-Federated]
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

### -Claim
{{Fill Claim Description}}

```yaml
Type: CrmServiceEndpointUserClaim
Parameter Sets: (All)
Aliases: 
Accepted values: None, UserId, UserInfo

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Contract
{{Fill Contract Description}}

```yaml
Type: CrmServiceEndpointContract
Parameter Sets: (All)
Aliases: 
Accepted values: OneWay, Queue, Rest, TwoWay, Topic, PersistentQueue

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
{{Fill Description Description}}

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

### -Federated
{{Fill Federated Description}}

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
{{Fill Name Description}}

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Namespace
{{Fill Namespace Description}}

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Path
{{Fill Path Description}}

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### None


## OUTPUTS

### Microsoft.Xrm.Sdk.Entity


## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/Register-CrmServiceEndpoint.html](http://crmpowershell.amsoftware.nl/Register-CrmServiceEndpoint.html)

