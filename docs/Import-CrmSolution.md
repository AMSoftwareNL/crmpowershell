---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/Import-CrmSolution.md
schema: 2.0.0
---

# Import-CrmSolution

## SYNOPSIS
Import a customizations solution into Dynamics CRM.

## SYNTAX

### ImportSolutionFromPath (Default)
```
Import-CrmSolution [-Path] <String[]> [-ConvertToManaged] [-Overwrite] [-PublishWorkflows] [-SkipDependencies]
 [-Async] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ImportSolutionFromLiteralPath
```
Import-CrmSolution [-LiteralPath] <String[]> [-ConvertToManaged] [-Overwrite] [-PublishWorkflows]
 [-SkipDependencies] [-Async] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Import a customizations solution into Dynamics CRM from the file system.

## EXAMPLES

### Example 1
```
PS C:\> Import-CrmSolution -Path c:\temp\product1.zip -ConvertToManaged -Overwrite -PublishWorkflows
```

Import the solution 'product1.zip' into Dynamics CRM as managed solution and publish the workflows contained in the solution. Overwrite if the solution already exists.

## PARAMETERS

### -Async
Execute the import of the solution asynchronously. Returns an asyncoperation instead of an importjob.

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

### -ConvertToManaged
Direct the system to convert any matching unmanaged customizations into your managed solution.

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

### -LiteralPath
The literal path of the solution file to import.

```yaml
Type: System.String[]
Parameter Sets: ImportSolutionFromLiteralPath
Aliases: PSPath

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Overwrite
Whether any unmanaged customizations that have been applied over existing managed solution components should be overwritten.

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

### -Path
The path of the solution file to import.

```yaml
Type: System.String[]
Parameter Sets: ImportSolutionFromPath
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -PublishWorkflows
Whether any processes (workflows) included in the solution should be activated after they are imported.

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

### -SkipDependencies
Whether enforcement of dependencies related to product updates should be skipped.

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String[]

## OUTPUTS

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[Export-CrmSolution](Export-CrmSolution.md)

[Get-CrmSolution](Get-CrmSolution.md)

[New-CrmSolution](New-CrmSolution.md)

[Test-CrmSolution](Test-CrmSolution.md)

[Use-CrmSolution](Use-CrmSolution.md)

[Entity Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.entity)
