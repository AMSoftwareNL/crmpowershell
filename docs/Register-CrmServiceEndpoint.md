---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Register-CrmServiceEndpoint.md
schema: 2.0.0
---

# Register-CrmServiceEndpoint

## SYNOPSIS
Register a serviceendpoint.

## SYNTAX

### RelayEndpointWithToken
```
Register-CrmServiceEndpoint [-Id <Guid>] [-Name] <String> [-Endpoint] <String> [-EndpointPathOrName] <String>
 [-Description <String>] -RelayContract <CrmServiceEndpointContract> -SASToken <String> -SASKey <String>
 [-Claim <CrmServiceEndpointUserClaim>] [-PassThru] [<CommonParameters>]
```

### RelayEndpointWithKey
```
Register-CrmServiceEndpoint [-Id <Guid>] [-Name] <String> [-Endpoint] <String> [-EndpointPathOrName] <String>
 [-Description <String>] -RelayContract <CrmServiceEndpointContract> -SASKeyName <String>
 [-Claim <CrmServiceEndpointUserClaim>] [-PassThru] [<CommonParameters>]
```

### QueueuEndpointWithToken
```
Register-CrmServiceEndpoint [-Id <Guid>] [-Name] <String> [-Endpoint] <String> [-EndpointPathOrName] <String>
 [-Description <String>] -QueueContract <CrmServiceEndpointContract>
 [-MessageFormat <CrmServiceEndpointMessageFormat>] -SASToken <String> -SASKey <String>
 [-Claim <CrmServiceEndpointUserClaim>] [-PassThru] [<CommonParameters>]
```

### QueueuEndpointWithKey
```
Register-CrmServiceEndpoint [-Id <Guid>] [-Name] <String> [-Endpoint] <String> [-EndpointPathOrName] <String>
 [-Description <String>] -QueueContract <CrmServiceEndpointContract>
 [-MessageFormat <CrmServiceEndpointMessageFormat>] -SASKeyName <String> [-Claim <CrmServiceEndpointUserClaim>]
 [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Register a serviceendpoint.

## EXAMPLES

## PARAMETERS

### -Claim
The type of claim for the serviceendpoint.

```yaml
Type: CrmServiceEndpointUserClaim
Parameter Sets: (All)
Aliases: UserInformation
Accepted values: None, UserId, UserInfo

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
The description for the serviceendpoint.

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

### -Endpoint
{{ Fill Endpoint Description }}

```yaml
Type: String
Parameter Sets: (All)
Aliases: NamespaceAddress, Namespace

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointPathOrName
{{ Fill EndpointPathOrName Description }}

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
{{ Fill Id Description }}

```yaml
Type: Guid
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -MessageFormat
{{ Fill MessageFormat Description }}

```yaml
Type: CrmServiceEndpointMessageFormat
Parameter Sets: QueueuEndpointWithToken, QueueuEndpointWithKey
Aliases:
Accepted values: DOTNETBinary, JSON, XML

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name for the serviceendpoint.

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

### -PassThru
Returns an object that represents the Service Endpoint. By default, this cmdlet does not generate any output.

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

### -QueueContract
{{ Fill QueueContract Description }}

```yaml
Type: CrmServiceEndpointContract
Parameter Sets: QueueuEndpointWithToken, QueueuEndpointWithKey
Aliases:
Accepted values: Queue, Topic, Eventhub

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RelayContract
{{ Fill RelayContract Description }}

```yaml
Type: CrmServiceEndpointContract
Parameter Sets: RelayEndpointWithToken, RelayEndpointWithKey
Aliases:
Accepted values: Oneway, Twoway, Rest

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SASKey
{{ Fill SASKey Description }}

```yaml
Type: String
Parameter Sets: RelayEndpointWithToken, QueueuEndpointWithToken
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SASKeyName
{{ Fill SASKeyName Description }}

```yaml
Type: String
Parameter Sets: RelayEndpointWithKey, QueueuEndpointWithKey
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SASToken
{{ Fill SASToken Description }}

```yaml
Type: String
Parameter Sets: RelayEndpointWithToken, QueueuEndpointWithToken
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[Get-CrmServiceEndpoint](Get-CrmServiceEndpoint.md)

[Set-CrmServiceEndpoint](Set-CrmServiceEndpoint.md)

[Unregister-CrmServiceEndpoint](Unregister-CrmServiceEndpoint.md)

[Entity Class](https://msdn.microsoft.com/en-us/library/microsoft.xrm.sdk.entity.aspx)
