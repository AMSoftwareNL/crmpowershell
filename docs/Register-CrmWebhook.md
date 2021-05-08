---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Register-CrmWebhook.md
schema: 2.0.0
---

# Register-CrmWebhook

## SYNOPSIS
{{ Fill in the Synopsis }}

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
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Endpoint
{{ Fill Endpoint Description }}

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Headers
{{ Fill Headers Description }}

```yaml
Type: Hashtable
Parameter Sets: RegisterWebhookWithHeaderAuth
Aliases:

Required: True
Position: Named
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

### -Name
{{ Fill Name Description }}

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
{{ Fill PassThru Description }}

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

### -Querystring
{{ Fill Querystring Description }}

```yaml
Type: Hashtable
Parameter Sets: RegisterWebhookWithQuerystringAuth
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WebhookKey
{{ Fill WebhookKey Description }}

```yaml
Type: String
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

[https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Register-CrmWebhook.md](https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Register-CrmWebhook.md)

