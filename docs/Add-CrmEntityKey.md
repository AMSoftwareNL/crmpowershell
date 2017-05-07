---
external help file: AMSoftware.Crm.Powershell.Commands.dll-Help.xml
online version: http://crmpowershell.amsoftware.nl/Add-CrmEntityKey.html
schema: 2.0.0
---

# Add-CrmEntityKey

## SYNOPSIS
Add a key to an entity.

## SYNTAX

```
Add-CrmEntityKey [-Entity] <String> [-Name] <String> [-DisplayName] <String> -Attributes <String[]>
 [-SchemaName <String>]
```

## DESCRIPTION
Add a key to an entity.

## EXAMPLES

### Example 1
```
PS C:\> Add-CrmEntityKey -Entity account -Name accountnumber -DisplayName Accountnumber -Attributes @('accountnumber')
```

Add accountnumber as unique key on account.

## PARAMETERS

### -Attributes
The LogicalName of the attributes for the key.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
The displayname for the key.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Entity
The LogicalName of the entity the add the key to.

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

### -Name
The name for the key.

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

### -SchemaName
The SchemaName for the key. If omitted the Name will be used as the SchemaName.

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

## INPUTS

### None


## OUTPUTS

### Microsoft.Xrm.Sdk.Metadata.EntityKeyMetadata


## NOTES

## RELATED LINKS

[Get-CrmEntityKey](Get-CrmEntityKey.md)

[Remove-CrmEntityKey](Remove-CrmEntityKey.md)

[EntityMetadata Class](https://msdn.microsoft.com/library/microsoft.xrm.sdk.metadata.entitymetadata.aspx)
