---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Get-CrmTeamTemplate.md
schema: 2.0.0
---

# Get-CrmTeamTemplate

## SYNOPSIS
Get team template from the connected organization.

## SYNTAX

### GetAllTeamTemplates (Default)
```
Get-CrmTeamTemplate [[-Name] <String>] [-Exclude <String>] [-ObjectTypeCode <Int32>] [-IncludeTotalCount]
 [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

### GetTeamTemplateById
```
Get-CrmTeamTemplate [-Id] <Guid[]> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

## DESCRIPTION
Get team template from the connected organization.

## EXAMPLES

## PARAMETERS

### -Exclude
Exclude team templates whose name matches the provided pattern.

```yaml
Type: System.String
Parameter Sets: GetAllTeamTemplates
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -Id
The id of the team template to retrieve.

```yaml
Type: System.Guid[]
Parameter Sets: GetTeamTemplateById
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Include team templates whose name matches the provided pattern.

```yaml
Type: System.String
Parameter Sets: GetAllTeamTemplates
Aliases: Include

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -ObjectTypeCode
The ObjectTypeCode of the entity the team template is connected to.

```yaml
Type: System.Int32
Parameter Sets: GetAllTeamTemplates
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeTotalCount
Reports the total number of objects in the data set (an integer) followed by the selected objects.
If the cmdlet cannot determine the total count, it displays "Unknown total count." The integer has an Accuracy property that indicates the reliability of the total count value.
The value of Accuracy ranges from 0.0 to 1.0 where 0.0 means that the cmdlet could not count the objects, 1.0 means that the count is exact, and a value between 0.0 and 1.0 indicates an increasingly reliable estimate.

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

### -Skip
Ignores the specified number of objects and then gets the remaining objects.
Enter the number of objects to skip.

```yaml
Type: System.UInt64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -First
Gets only the specified number of objects.
Enter the number of objects to get.

```yaml
Type: System.UInt64
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

### System.Guid[]

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[Get-CrmTeamTemplate](Get-CrmTeamTemplate.md)

