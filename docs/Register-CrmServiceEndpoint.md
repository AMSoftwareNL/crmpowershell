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
 [-Description <String>] -RelayContract <CrmServiceEndpointContract> -SASToken <String>
 [-Claim <CrmServiceEndpointUserClaim>] [-PassThru] [<CommonParameters>]
```

### RelayEndpointWithKey
```
Register-CrmServiceEndpoint [-Id <Guid>] [-Name] <String> [-Endpoint] <String> [-EndpointPathOrName] <String>
 [-Description <String>] -RelayContract <CrmServiceEndpointContract> -SASKeyName <String> -SASKey <String>
 [-Claim <CrmServiceEndpointUserClaim>] [-PassThru] [<CommonParameters>]
```

### QueueuEndpointWithToken
```
Register-CrmServiceEndpoint [-Id <Guid>] [-Name] <String> [-Endpoint] <String> [-EndpointPathOrName] <String>
 [-Description <String>] -QueueContract <CrmServiceEndpointContract>
 [-MessageFormat <CrmServiceEndpointMessageFormat>] -SASToken <String> [-Claim <CrmServiceEndpointUserClaim>]
 [-PassThru] [<CommonParameters>]
```

### QueueuEndpointWithKey
```
Register-CrmServiceEndpoint [-Id <Guid>] [-Name] <String> [-Endpoint] <String> [-EndpointPathOrName] <String>
 [-Description <String>] -QueueContract <CrmServiceEndpointContract>
 [-MessageFormat <CrmServiceEndpointMessageFormat>] -SASKeyName <String> -SASKey <String>
 [-Claim <CrmServiceEndpointUserClaim>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Register a serviceendpoint.

## EXAMPLES

## PARAMETERS

### -Claim
The type of claim for the serviceendpoint.

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmServiceEndpointUserClaim
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Endpoint
The Endpoint URI of the service endpoint. URI depends on the type of service endpoint. Can be an Azure ServiceBus namespace URI, of a HTTP endpoint.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: NamespaceAddress, Namespace

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointPathOrName
Name or Path specifier for the service endpoint. The name of the Topic or Queue, etc.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
If provided the Id of an existing Service Endpoint to update

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -MessageFormat
The format of the messages send to an Azure ServiceBus.

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmServiceEndpointMessageFormat
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
Type: System.String
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QueueContract
The type of async messaging contract to use.

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmServiceEndpointContract
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
The type of async relay contract to use.


```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmServiceEndpointContract
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
The SASKey value to use with SASKey Authorization type

```yaml
Type: System.String
Parameter Sets: RelayEndpointWithKey, QueueuEndpointWithKey
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SASKeyName
The SASKey name to use with SASKey Authorization type

```yaml
Type: System.String
Parameter Sets: RelayEndpointWithKey, QueueuEndpointWithKey
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SASToken
The SASToken value to use with SASToken Authorization type

```yaml
Type: System.String
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

[Entity Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.entity)
