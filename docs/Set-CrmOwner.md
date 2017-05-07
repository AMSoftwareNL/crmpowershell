---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Set-CrmOwner.html
schema: 2.0.0
---

# Set-CrmOwner

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### AssignOwnerEntity
```
Set-CrmOwner [-InputObject] <Entity> -ToPrincipalType <CrmPrincipalType> -ToPrincipalId <Guid>
 [<CommonParameters>]
```

### AssignOwnerRecord
```
Set-CrmOwner [-Entity] <String> [-Id] <Guid> -ToPrincipalType <CrmPrincipalType> -ToPrincipalId <Guid>
 [<CommonParameters>]
```

### ReassignOwner
```
Set-CrmOwner [-FromPrincipalType] <CrmPrincipalType> [-FromPrincipalId] <Guid>
 -ToPrincipalType <CrmPrincipalType> -ToPrincipalId <Guid> [<CommonParameters>]
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

### -Entity
{{Fill Entity Description}}

```yaml
Type: String
Parameter Sets: AssignOwnerRecord
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FromPrincipalId
{{Fill FromPrincipalId Description}}

```yaml
Type: Guid
Parameter Sets: ReassignOwner
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FromPrincipalType
{{Fill FromPrincipalType Description}}

```yaml
Type: CrmPrincipalType
Parameter Sets: ReassignOwner
Aliases: 
Accepted values: User, Team

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
{{Fill Id Description}}

```yaml
Type: Guid
Parameter Sets: AssignOwnerRecord
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
{{Fill InputObject Description}}

```yaml
Type: Entity
Parameter Sets: AssignOwnerEntity
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ToPrincipalId
{{Fill ToPrincipalId Description}}

```yaml
Type: Guid
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ToPrincipalType
{{Fill ToPrincipalType Description}}

```yaml
Type: CrmPrincipalType
Parameter Sets: (All)
Aliases: 
Accepted values: User, Team

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Xrm.Sdk.Entity

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/Set-CrmOwner.html](http://crmpowershell.amsoftware.nl/Set-CrmOwner.html)

