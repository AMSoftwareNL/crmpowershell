#escape=`
FROM mcr.microsoft.com/windows/servercore:20H2

LABEL maintainer="AMSoftware <info@amsoftware.nl>" `
      name="powerplatformtools" `
      version="1.0.0" `
      description="Collection of tools to work with Microsoft Power Platform. `
Tools included: `
* Microsoft Power Platform CLI `
* Powershell: Microsoft.Xrm.Tooling.CrmConnector.PowerShell `
* Powershell: Microsoft.Xrm.Tooling.ConfigurationMigration `
* Powershell: Microsoft.Xrm.Tooling.PackageDeployment.Powershell `
* Powershell: Microsoft.Xrm.OnlineManagementAPI `
* Powershell: Microsoft.PowerApps.Administration.PowerShell `
* Powershell: Microsoft.PowerApps.PowerShell `
* Powershell: Microsoft.PowerApps.Checker.PowerShell `
* Powershell: AMSoftware.Crm"

WORKDIR /tools

# Install Microsoft Power Platform CLI 
# https://docs.microsoft.com/en-us/powerapps/developer/data-platform/powerapps-cli
ADD "https://aka.ms/PowerAppsCLI" "powerappscli.msi"
RUN "msiexec /I powerappscli.msi /QN"
RUN "pac install latest"

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'Continue'; $verbosePreference='Continue';"]
USER ContainerAdministrator
RUN `
    # Install-Module uses the NuGet Package provider. Must be the first action `
    Install-PackageProvider -Name 'NuGet' -MinimumVersion '2.8.5.201' -Force; `
    # Set Powershell Gallery as Trusted Repository (just in case) `
    Set-PSRepository -Name 'PSGallery' -InstallationPolicy Trusted; `
    # Install all Powershell module for the Power Platform provide by CrmSdk `
    # https://www.powershellgallery.com/profiles/Crmsdk
    Install-Module -Name 'Microsoft.Xrm.Tooling.CrmConnector.PowerShell' -Repository 'PSGallery' -Force -SkipPublisherCheck; `
    Install-Module -Name 'Microsoft.Xrm.Tooling.ConfigurationMigration' -Repository 'PSGallery' -Force -SkipPublisherCheck; `
    Install-Module -Name 'Microsoft.Xrm.Tooling.PackageDeployment.Powershell' -Repository 'PSGallery' -Force -SkipPublisherCheck; `
    Install-Module -Name 'Microsoft.Xrm.OnlineManagementAPI' -Repository 'PSGallery' -Force -SkipPublisherCheck; `
    Install-Module -Name 'Microsoft.PowerApps.Administration.PowerShell' -Repository 'PSGallery' -Force -SkipPublisherCheck; `
    Install-Module -Name 'Microsoft.PowerApps.PowerShell' -AllowClobber -Repository 'PSGallery' -Force -SkipPublisherCheck; `
    Install-Module -Name 'Microsoft.PowerApps.Checker.PowerShell' -Repository 'PSGallery' -Force -SkipPublisherCheck; `
    # Install AMSoftware.Crm Powershell module `
    # https://www.powershellgallery.com/packages/AMSoftware.Crm `
    Install-Module -Name 'AMSoftware.Crm' -Repository 'PSGallery' -Force -SkipPublisherCheck; `
    # Restore Powershell Gallery repository to default (untrusted) `
    Set-PSRepository -Name 'PSGallery' -InstallationPolicy Untrusted;

CMD ["powershell"]
