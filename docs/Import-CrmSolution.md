---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Import-CrmSolution.html
schema: 2.0.0
---

# Import-CrmSolution

## SYNOPSIS
Import a customizations solution into Dynamics CRM.

## SYNTAX

### ImportSolutionFromPath (Default)
```
Import-CrmSolution [-Path] <String[]> [-ConvertToManaged] [-Overwrite] [-PublishWorkflows] [-SkipDependencies]
 [-WhatIf] [-Confirm]
```

### ImportSolutionFromLiteralPath
```
Import-CrmSolution [-LiteralPath] <String[]> [-ConvertToManaged] [-Overwrite] [-PublishWorkflows]
 [-SkipDependencies] [-WhatIf] [-Confirm]
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

### -ConvertToManaged
Direct the system to convert any matching unmanaged customizations into your managed solution.

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

### -LiteralPath
The literal path of the solution file to import.

```yaml
Type: String[]
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
Type: SwitchParameter
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
Type: String[]
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
Type: SwitchParameter
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
Type: SwitchParameter
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

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
