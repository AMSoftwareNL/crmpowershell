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

```
Register-CrmServiceEndpoint -Name <String> [-Description <String>] -Namespace <String> -Path <String>
 -Contract <CrmServiceEndpointContract> [-Claim <CrmServiceEndpointUserClaim>] [-Federated] [-PassThru]
 [<CommonParameters>]
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
Aliases:
Accepted values: None, UserId, UserInfo

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Contract
The contract for the serviceendpoint.

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

### -Federated
Whether the serviceendpoint is federated.

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
The name for the serviceendpoint.

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
The namespace for the serviceendpoint.

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

### -Path
The path for the serviceendpoint.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### Microsoft.Xrm.Sdk.Entity
## NOTES

## RELATED LINKS

[Get-CrmServiceEndpoint](Get-CrmServiceEndpoint.md)

[Set-CrmServiceEndpoint](Set-CrmServiceEndpoint.md)

[Unregister-CrmServiceEndpoint](Unregister-CrmServiceEndpoint.md)

[Entity Class](https://msdn.microsoft.com/en-us/library/microsoft.xrm.sdk.entity.aspx)
