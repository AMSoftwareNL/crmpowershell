## Dynamics CRM PowerShell Library

**Project Description**

PowerShell CmdLet Library for use with Dynamics CRM Organization.
Manage Metadata and content, and administer the organization. 


CRM PowerShell Library is a collection of PowerShell Cmdlets for working with Dynamics CRM. 

Connect to your on premises CRM using Windows Authentication, Claims Based Authentication or IFD. Or connect to CRM Online (Dynamics 365) by specifying the Region. List and select an available organization, and you are ready to go.

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

The library uses the Dynamics CRM SDK for interaction with Dynamics CRM. Dynamics CRM 2011 and up are supported.
Parameters for the Cmdlets are automatically updated based on the Organization and loaded SDK version.

## Getting Started

To get started using the PowerShell with Dynamics CRM:

Download the latest release (https://github.com/AMSoftwareNL/crmpowershell/releases) and run 

```Import-Module AMSoftware.Crm.psd1```

**OR**

Install the latest version from the PowerShell Gallery (https://www.powershellgallery.com/packages/AMSoftware.Crm/)

```Install-Module AMSoftware.Crm```

### Connect to Dynamics CRM

To connect with Dynamics CRM use `Connect-CrmDeployment` and `Connect-CrmOrganization`.

**Online**

```Connect-CrmDeployment -Region crm4 -Credential (Get-Credential)```

**On Premises**

```Connect-CrmDeployment -DiscoveryUrl 'https://crm.organization.com'```

**NOTE:** If no credentails are provided the current Windows Credentials are used. Add `-Credential (Get-Credential)` to provide other credentials.

Now you can connect to the organization using `Connect-CrmOrganization`.

```Connect-CrmOrganization -Name 'mycrmorg'```

**NOTE:** Name can by the uniquename, the displayname, or the weburl of the organization.

The get all the available commands use `Get-Command -Module 'AMSoftware.Crm'`.
