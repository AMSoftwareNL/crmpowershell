---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/New-CrmBusinessUnit.md
schema: 2.0.0
---

# New-CrmBusinessUnit

## SYNOPSIS
Add a new business unit.

## SYNTAX

```
New-CrmBusinessUnit [-Name] <String> [-Parent <Guid>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Add a new business unit.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmBusinessUnit -Include amsoftwarecrm | New-CrmBusinessUnit -Name 'sales'
```

Add a business unit 'sales' below the parent 'amsoftwarecrm'.

## PARAMETERS

### -Name
The name of the new business unit.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parent
The id of the parent business unit.

```yaml
Type: Guid
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns an object that represents the Business Unit. By default, this cmdlet does not generate any output.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[Get-CrmBusinessUnit](Get-CrmBusinessUnit.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
