---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmServiceEndpoint.html
schema: 2.0.0
---

# Get-CrmServiceEndpoint

## SYNOPSIS
Get a registered serviceendpoint.

## SYNTAX

### GetServiceEndPointByFilter (Default)
```
Get-CrmServiceEndpoint [-Include <String>] [-Exclude <String>] [-IncludeTotalCount] [-Skip <UInt64>]
 [-First <UInt64>]
```

### GetServiceEndPointById
```
Get-CrmServiceEndpoint [-Id] <Guid> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
```

### GetServiceEndPointByName
```
Get-CrmServiceEndpoint [-Name] <String> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
```

## DESCRIPTION
Get a registered serviceendpoint.

## EXAMPLES

### Example 1
```
PS C:\> Get-CrmServiceEndpoint -Name 'AMSoftware.AzureServiceBus'
```

Retrieve the serviceendpoint named 'AMSoftware.AzureServiceBus'.

## PARAMETERS

### -Exclude
Exclude serviceendpoints whose name matches the provided pattern.

```yaml
Type: String
Parameter Sets: GetServiceEndPointByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -First
Specifies the number of records to retrieve from the beginning.

```yaml
Type: UInt64
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The id of the serviceendpoint to retrieve.

```yaml
Type: Guid
Parameter Sets: GetServiceEndPointById
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Include
Include serviceendpoints whose name matches the provided pattern.

```yaml
Type: String
Parameter Sets: GetServiceEndPointByFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeTotalCount
Return the total count (and accuracy) of the number of records before returning the result.

Because of the limitations of Dynamics CRM, the total count is only returned accurate when the result is limited to 5000 items.

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

### -Name
The name of the serviceendpoint to retrieve.

```yaml
Type: String
Parameter Sets: GetServiceEndPointByName
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Skips (does not return) the specified number of records.

```yaml
Type: UInt64
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### None


## OUTPUTS

### Microsoft.Xrm.Sdk.Entity


## NOTES

## RELATED LINKS

[Register-CrmServiceEndpoint](Register-CrmServiceEndpoint.md)

[Set-CrmServiceEndpoint](Set-CrmServiceEndpoint.md)

[Unregister-CrmServiceEndpoint](Unregister-CrmServiceEndpoint.md)

[Entity Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.entity.aspx)
