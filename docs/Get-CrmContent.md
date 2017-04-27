---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Get-CrmContent.html
schema: 2.0.0
---

# Get-CrmContent

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### GetContentForEntityByQuery (Default)
```
Get-CrmContent [-Entity] <String> [[-Query] <Hashtable>] [[-Order] <Hashtable>] [-Columns <String[]>]
 [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
```

### GetContentForEntityById
```
Get-CrmContent [-Entity] <String> [-Id] <Guid> [-RelatedEntities <Hashtable>] [-Columns <String[]>]
 [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
```

### GetContentForEntityByKeys
```
Get-CrmContent [-Entity] <String> [-Keys] <Hashtable> [-RelatedEntities <Hashtable>] [-Columns <String[]>]
 [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
```

### GetContentWithFetchXml
```
Get-CrmContent [-FetchXml] <XmlDocument> [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
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

### -Columns
{{Fill Columns Description}}

```yaml
Type: String[]
Parameter Sets: GetContentForEntityByQuery, GetContentForEntityById, GetContentForEntityByKeys
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
Parameter Sets: GetContentForEntityByQuery, GetContentForEntityById, GetContentForEntityByKeys
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FetchXml
{{Fill FetchXml Description}}

```yaml
Type: XmlDocument
Parameter Sets: GetContentWithFetchXml
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -First
{{Fill First Description}}

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
{{Fill Id Description}}

```yaml
Type: Guid
Parameter Sets: GetContentForEntityById
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeTotalCount
{{Fill IncludeTotalCount Description}}

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

### -Keys
{{Fill Keys Description}}

```yaml
Type: Hashtable
Parameter Sets: GetContentForEntityByKeys
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Order
{{Fill Order Description}}

```yaml
Type: Hashtable
Parameter Sets: GetContentForEntityByQuery
Aliases: 

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Query
{{Fill Query Description}}

```yaml
Type: Hashtable
Parameter Sets: GetContentForEntityByQuery
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RelatedEntities
{{Fill RelatedEntities Description}}

```yaml
Type: Hashtable
Parameter Sets: GetContentForEntityById, GetContentForEntityByKeys
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
{{Fill Skip Description}}

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

### System.String[]


## OUTPUTS

### Microsoft.Xrm.Sdk.Entity


## NOTES

## RELATED LINKS

[http://crmpowershell.amsoftware.nl/Get-CrmContent.html](http://crmpowershell.amsoftware.nl/Get-CrmContent.html)

