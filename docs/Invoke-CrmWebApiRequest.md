---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Invoke-CrmWebApiRequest.md
schema: 2.0.0
---

# Invoke-CrmWebApiRequest

## SYNOPSIS
Invoke the WebAPI

## SYNTAX

```
Invoke-CrmWebApiRequest [-Url] <Uri> [-Method <String>] [-Body <Object>] [-ContentType <String>]
 [-FormattedValues] [<CommonParameters>]
```

## DESCRIPTION
Invoke the WebAPI

## EXAMPLES

### Example 1
```powershell
PS C:\> Invoke-CrmWebApiRequest -Url 'accounts' -Method GET -FormattedValues
```

Retrieve all accounts directly through the WebAPI. Include the formatted values.

## PARAMETERS

### -Body
The body for the request. Ignored if the request is a GET. If Body is a string it is passed on to the request directly. IF the Body is an object it is serialized to a JSON string which is passed on to the request.

```yaml
Type: Object
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ContentType
ContentType of the request. if not included application/json is used.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: application/json
Accept pipeline input: False
Accept wildcard characters: False
```

### -Method
HTTPMethod of the request. If not included GET is used.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: Get, Post, Put, Delete, Patch

Required: False
Position: Named
Default value: GET
Accept pipeline input: False
Accept wildcard characters: False
```

### -Url
URI relative to the WebAPI base URI to execute.

```yaml
Type: Uri
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FormattedValues
Include the formatted values in the response. Adds the header 'Prefer: odata.include-annotations="OData.Community.Display.V1.FormattedValue"'

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Object
## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Invoke-CrmWebApiRequest.md](https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Invoke-CrmWebApiRequest.md)

