---
external help file: AMSoftware.Crm.PowerShell.Commands.dll-Help.xml
Module Name: AMSoftware.Crm
online version: https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/New-CrmEnvironmentVariable.md
schema: 2.0.0
---

# New-CrmEnvironmentVariable

## SYNOPSIS
Create a new environment variable

## SYNTAX

```
New-CrmEnvironmentVariable [-Name] <String> -DisplayName <String> [-Description <String>]
 -VariableType <CrmEnvironmentVariableType> [-DefaultValue <Object>] [-Value <Object>] [-PassThru]
 [<CommonParameters>]
```

## DESCRIPTION
Create a new environment variable

## EXAMPLES

## PARAMETERS

### -DefaultValue
The default value for the environment variable

```yaml
Type: System.Object
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
The description of the environment variable

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
The displayname of the environment variable

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the environment variable

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Return the newly created environment variale to the pipeline

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

### -Value
The value of the environment variable

```yaml
Type: System.Object
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VariableType
The value type of the environment variable

```yaml
Type: AMSoftware.Crm.PowerShell.Common.CrmEnvironmentVariableType
Parameter Sets: (All)
Aliases:
Accepted values: All, String, Number, Boolean, JSON, DataSource

Required: True
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

### Microsoft.Xrm.Sdk.Entity

## NOTES

## RELATED LINKS

[https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/New-CrmEnvironmentVariable.md](https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/New-CrmEnvironmentVariable.md)

