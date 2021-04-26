Import-Module '.\AMSoftware.Crm.PowerShell.Commands\bin\Debug\AMSoftware.Crm.psd1'

$conn = Get-CrmConnection -InteractiveMode
Connect-CrmOrganization $conn
