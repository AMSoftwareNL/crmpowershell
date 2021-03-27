---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Unregister-CrmServiceEndpoint.md
schema: 2.0.0
---

# Unregister-CrmServiceEndpoint

## SYNOPSIS
Unregister a serviceendpoint.

## SYNTAX

```
Unregister-CrmServiceEndpoint [-Id] <Guid[]> [-Force] [<CommonParameters>]
```

## DESCRIPTION
Unregister a serviceendpoint.

## EXAMPLES

## PARAMETERS

### -Force
Executes the action without prompting for confirmation.

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

### -Id
The id of the serviceendpoint to unregister.

```yaml
Type: Guid[]
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid[]
## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[Get-CrmServiceEndpoint](Get-CrmServiceEndpoint.md)

[Register-CrmServiceEndpoint](Register-CrmServiceEndpoint.md)

[Set-CrmServiceEndpoint](Set-CrmServiceEndpoint.md)
