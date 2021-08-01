Import-Module '.\AMSoftware.Crm.PowerShell.Commands\bin\Debug\AMSoftware.Crm.psd1'
Update-MarkdownHelpModule '.\docs\' -RefreshModulePage -AlphabeticParamsOrder -UseFullTypeName -UpdateInputOutput -Force

Copy-Item -Path '.\docs\AMsoftware.Crm.md' -Destination '.\docs\index.md' -Force