---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Invoke-CrmRequest.html
schema: 2.0.0
---

# Invoke-CrmRequest

## SYNOPSIS
Execute any Dynamics CRM request.

## SYNTAX

```
Invoke-CrmRequest [-Request] <String> [[-Parameters] <Hashtable>]
```

## DESCRIPTION
Execute any Dynamics CRM request.

## EXAMPLES

### Example 1
```
PS C:\> Invoke-CrmRequest -Request WhoAmI
```

Executes the WhoAmI request.

## PARAMETERS

### -Parameters
A hashtable of parameter names and values to pass to the request.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Request
The name of the request to execute.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
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
