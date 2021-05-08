Import-Module '.\AMSoftware.Crm.PowerShell.Commands\bin\Debug\AMSoftware.Crm.psd1'

$connection = Get-CrmConnection -InteractiveMode
Connect-CrmOrganization $connection

