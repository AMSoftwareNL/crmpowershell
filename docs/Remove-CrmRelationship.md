---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Remove-CrmRelationship.html
schema: 2.0.0
---

# Remove-CrmRelationship

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### RemoveRelationshipByName
```
Remove-CrmRelationship [-Name] <String> [-Force] [-WhatIf] [-Confirm]
```

### RemoveRelationshipByEntity
```
Remove-CrmRelationship [-Entity] <String> [-FromEntity] <String> [-Attribute <String>] [-Force] [-WhatIf]
 [-Confirm]
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

### -Attribute
{{Fill Attribute Description}}

```yaml
Type: String
Parameter Sets: RemoveRelationshipByEntity
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entity
{{Fill Entity Description}}

```yaml
Type: String
Parameter Sets: RemoveRelationshipByEntity
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
{{Fill Force Description}}

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

### -FromEntity
{{Fill FromEntity Description}}

```yaml
Type: String
Parameter Sets: RemoveRelationshipByEntity
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
{{Fill Name Description}}

```yaml
Type: String
Parameter Sets: RemoveRelationshipByName
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### None


## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/Remove-CrmRelationship.html](http://crmpowershell.amsoftware.nl/Remove-CrmRelationship.html)

