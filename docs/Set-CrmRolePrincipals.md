---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Set-CrmRolePrincipals.html
schema: 2.0.0
---

# Set-CrmRolePrincipals

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

```
Set-CrmRolePrincipals [-Role] <Guid> [-PrincipalType] <CrmPrincipalType> -Principals <Guid[]> [-Overwrite]
 [<CommonParameters>]
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

### -Overwrite
{{Fill Overwrite Description}}

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

### -Principals
{{Fill Principals Description}}

```yaml
Type: Guid[]
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrincipalType
{{Fill PrincipalType Description}}

```yaml
Type: CrmPrincipalType
Parameter Sets: (All)
Aliases: 
Accepted values: User, Team

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Role
{{Fill Role Description}}

```yaml
Type: Guid
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid
System.Guid[]

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/Set-CrmRolePrincipals.html](http://crmpowershell.amsoftware.nl/Set-CrmRolePrincipals.html)

