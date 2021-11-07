## Dataverse PowerShell Library

__IMPORTANT__
This project is no longer being developed. Bugs will be fixed, but no additional features will be added.

**Project Description**

PowerShell CmdLet Library for use with Power Platform Dataverse and Dynamics 365 environments.
Manage Metadata and content, and administer the organization. 

CRM PowerShell Library is a collection of PowerShell Cmdlets for working with Power Platform Dataverse and Dynamics 365 environments. 

Connect to your on-premises environment, or Power Platform Dataverse and Dynamics 365 environment in the Cloud.

**Work with Metadata**

View, Add, Edit, and Delete Metadata like Entities, Attributes, Relationships, OptionSets and Keys.

**Work with content**

Retrieve, Add, Edit, Associate, Disassociate and Delete records in any entity. Attributes & FormattedValues are available as named properties on the result.

**Administration**

Manage Business Units, Teams, Users, Roles, etc. Also manage processes like workflows, manage language packs, or invoke any available CRM request.

**Customization and Solutions**

Manage WebResources, and Translations. Manage and Publish solutions and components.

**Plugin Registration**

Register, update and unregister plugins, steps, images and serviceendpoints.

**Supported Version**

The library uses the Micrsoft Dynamics 365 SDK and Microsoft XRM Tooling Connector. So the library supports all versions Microsoft is currently supporting.
Parameters for the Cmdlets are automatically updated based on the Organization and loaded SDK version.

## Getting Started

To get started using the PowerShell:

Install the latest version from the PowerShell Gallery (https://www.powershellgallery.com/packages/AMSoftware.Crm/)

``` powershell
Install-Module AMSoftware.Crm
```

**OR**

Download the latest release (https://github.com/AMSoftwareNL/crmpowershell/releases) and run 

``` powershell
Import-Module AMSoftware.Crm.psd1
```

### Connect to environment

Use the Microsoft.Xrm.Tooling.CrmConnector.PowerShell module to connect to an environment, or supply a connectionstring to Connect-CrmOrganization.

To provide a connectionstring to an environment see [Use connection strings in XRM tooling to connect to Microsoft Dataverse](https://docs.microsoft.com/en-us/powerapps/developer/data-platform/xrm-tooling/use-connection-strings-xrm-tooling-connect) 

``` powershell
Install-Module 'Microsoft.Xrm.Tooling.CrmConnector.PowerShell'
$connection = Get-CrmConnection -InteractiveMode
Connect-CrmOrganization -Connection $connection
```

``` powershell
Connect-CrmOrganization -Connectionstring 'AuthType=Office365;Username=jsmith@contoso.onmicrosoft.com;Password=passcode;Url=https://contoso.crm.dynamics.com'
```

[Use connection strings in XRM tooling to connect to Microsoft Dataverse](https://docs.microsoft.com/en-us/powerapps/developer/data-platform/xrm-tooling/use-connection-strings-xrm-tooling-connect) 

[Microsoft.Xrm.Tooling.CrmConnector.PowerShell](https://docs.microsoft.com/en-us/powershell/module/microsoft.xrm.tooling.crmconnector.powershell)

[PowerShell Gallery: Microsoft.Xrm.Tooling.CrmConnector.PowerShell](https://www.powershellgallery.com/packages/Microsoft.Xrm.Tooling.CrmConnector.PowerShell)

### Cmdlet overview

The get all the available commands use `Get-Command -Module 'AMSoftware.Crm'`. Or go to the online documentation [here](https://github.com/AMSoftwareNL/crmpowershell/blob/master/docs/index.md).

