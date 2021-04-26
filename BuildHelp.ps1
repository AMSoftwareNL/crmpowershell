Import-Module '.\AMSoftware.Crm.PowerShell.Commands\bin\Debug\AMSoftware.Crm.psd1'
Update-MarkdownHelp -Path '.\docs\' -AlphabeticParamsOrder -UseFullTypeName -UpdateInputOutput -Force
Update-MarkdownHelpModule '.\docs\' -RefreshModulePage

Copy-Item -Path '.\docs\AMsoftware.Crm.md' -Destination '.\docs\index.md' -Force

# New-ExternalHelp -Path '.\docs\' -OutputPath '.\AMSoftware.Crm.PowerShell.Commands\bin\Release\en-US\' -Force
# New-ExternalHelpCab -CabFilesFolder '.\AMSoftware.Crm.PowerShell.Commands\bin\Release\en-US\' -LandingPagePath '.\docs\AMSoftware.Crm.md' -OutputFolder '.\AMSoftware.Crm.PowerShell.Commands\bin\Release\online\'