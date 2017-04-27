---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Set-CrmPluginStep.html
schema: 2.0.0
---

# Set-CrmPluginStep

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

```
Set-CrmPluginStep [-Id] <Guid> [-ExecutionOrder <Int32>] [-Name <String>] [-Description <String>]
 [-Stage <CrmPluginStepStage>] [-Mode <CrmPluginStepMode>] [-Deployment <CrmPluginStepDeployment>]
 [-DeleteAsyncOperation] [-UnsecureConfig <String>] [-SecureConfig <String>] [-User <Guid>]
 [-Attributes <String[]>]
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

### -Attributes
{{Fill Attributes Description}}

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeleteAsyncOperation
{{Fill DeleteAsyncOperation Description}}

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

### -Deployment
{{Fill Deployment Description}}

```yaml
Type: CrmPluginStepDeployment
Parameter Sets: (All)
Aliases: 
Accepted values: ServerOnly, OfflineOnly, Both

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
{{Fill Description Description}}

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExecutionOrder
{{Fill ExecutionOrder Description}}

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
{{Fill Id Description}}

```yaml
Type: Guid
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Mode
{{Fill Mode Description}}

```yaml
Type: CrmPluginStepMode
Parameter Sets: (All)
Aliases: 
Accepted values: Synchronous, Asynchronous

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
{{Fill Name Description}}

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecureConfig
{{Fill SecureConfig Description}}

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Stage
{{Fill Stage Description}}

```yaml
Type: CrmPluginStepStage
Parameter Sets: (All)
Aliases: 
Accepted values: PreValidation, PreOperation, PostOperation

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UnsecureConfig
{{Fill UnsecureConfig Description}}

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -User
{{Fill User Description}}

```yaml
Type: Guid
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### System.Guid
System.String[]


## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/Set-CrmPluginStep.html](http://crmpowershell.amsoftware.nl/Set-CrmPluginStep.html)

