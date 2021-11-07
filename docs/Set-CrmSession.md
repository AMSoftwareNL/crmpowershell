---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Set-CrmSession.md
schema: 2.0.0
---

# Set-CrmSession

## SYNOPSIS
Set properties on the active session

## SYNTAX

```
Set-CrmSession [-Language <Int32>] [-Solution <Guid>] [-UseMetadataCache <Boolean>]
 [-ImpersonatedUserId <Guid>] [<CommonParameters>]
```

## DESCRIPTION
Set properties on the active session

## EXAMPLES

## PARAMETERS

### -ImpersonatedUserId
Id of the User to impersonate

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Language
Set the active language for the session (0 = default organization language)

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Solution
Set the active solution for the session (Guig.Emoty = default solution)

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseMetadataCache
Enable or disable the use of Entity Metadata Cache

```yaml
Type: System.Boolean
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

### None

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[Set-CrmSession](Set-CrmSession.md)

