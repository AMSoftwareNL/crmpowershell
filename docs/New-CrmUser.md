---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/New-CrmUser.html
schema: 2.0.0
---

# New-CrmUser

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

```
New-CrmUser [-UserName] <String> [-Firstname] <String> [-Lastname] <String> [-Access <CrmUserAccessMode>]
 [-License <CrmUserClientLicense>] [-BusinessUnit <Guid>] [-Roles <Guid[]>]
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

### -Access
{{Fill Access Description}}

```yaml
Type: CrmUserAccessMode
Parameter Sets: (All)
Aliases: 
Accepted values: ReadWrite, Admin, Read, Support, NonInteractive, DelegatedAdmin

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BusinessUnit
{{Fill BusinessUnit Description}}

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

### -Firstname
{{Fill Firstname Description}}

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

### -Lastname
{{Fill Lastname Description}}

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -License
{{Fill License Description}}

```yaml
Type: CrmUserClientLicense
Parameter Sets: (All)
Aliases: 
Accepted values: Pro, Admin, Basic, DevicePro, DeviceBasic, Essential, DeviceEssential, Enterprise, DeviceEnterprise, Sales, Service, FieldService, ProjectService

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Roles
{{Fill Roles Description}}

```yaml
Type: Guid[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserName
{{Fill UserName Description}}

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

## INPUTS

### System.Nullable`1[[System.Guid, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]
System.Guid[]


## OUTPUTS

### Microsoft.Xrm.Sdk.Entity


## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/New-CrmUser.html](http://crmpowershell.amsoftware.nl/New-CrmUser.html)

