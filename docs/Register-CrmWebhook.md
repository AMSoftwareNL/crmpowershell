---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Register-CrmWebhook.md
schema: 2.0.0
---

# Register-CrmWebhook

## SYNOPSIS
Register a WebHook

## SYNTAX

### RegisterWebhookWithKeyAuth (Default)
```
Register-CrmWebhook [-Id <Guid>] [-Name] <String> [-Endpoint] <String> -WebhookKey <String> [-PassThru]
 [<CommonParameters>]
```

### RegisterWebhookWithQuerystringAuth
```
Register-CrmWebhook [-Id <Guid>] [-Name] <String> [-Endpoint] <String> -Querystring <Hashtable> [-PassThru]
 [<CommonParameters>]
```

### RegisterWebhookWithHeaderAuth
```
Register-CrmWebhook [-Id <Guid>] [-Name] <String> [-Endpoint] <String> -Headers <Hashtable> [-PassThru]
 [<CommonParameters>]
```

## DESCRIPTION
Register a WebHook

## EXAMPLES

## PARAMETERS

### -Endpoint
Endpoint URI of the WebHook

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Headers
Key Value pairs of Headers to include in the WebHook request

```yaml
Type: System.Collections.Hashtable
Parameter Sets: RegisterWebhookWithHeaderAuth
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
If provided the Id an existing WebHook to update

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

### -Name
Name of the WebHook

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
Return the resulting WebHook registration to the pipeline

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

### -Querystring
Key Value pairs of querystring parameters to include in the WebHook request

```yaml
Type: System.Collections.Hashtable
Parameter Sets: RegisterWebhookWithQuerystringAuth
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WebhookKey
Key value for the WebHookKey Authorization Type

```yaml
Type: System.String
Parameter Sets: RegisterWebhookWithKeyAuth
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

[Register-CrmWebhook](Register-CrmWebhook.md)

