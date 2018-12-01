Import-Module '.\AMSoftware.Crm.PowerShell.Commands\bin\Release\AMSoftware.Crm.psd1'
Update-MarkdownHelp -Path '.\docs\' -AlphabeticParamsOrder -UseFullTypeName -UpdateInputOutput -Force
Update-MarkdownHelpModule '.\docs\' -RefreshModulePage
New-ExternalHelp -Path '.\docs\' -OutputPath '.\AMSoftware.Crm.PowerShell.Commands\bin\Release\en-US\' -Force
New-ExternalHelpCab -CabFilesFolder '.\AMSoftware.Crm.PowerShell.Commands\bin\Release\en-US\' -LandingPagePath '.\docs\AMSoftware.Crm.md' -OutputFolder '.\AMSoftware.Crm.PowerShell.Commands\bin\Release\online\'