# CRM PowerShell Library
# Copyright (C) 2017 Arjan Meskers / AMSoftware
# 
# This program is free software: you can redistribute it and/or modify
# it under the terms of the GNU Affero General Public License as published
# by the Free Software Foundation, either version 3 of the License, or
# (at your option) any later version.
# 
# This program is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# GNU Affero General Public License for more details.
# 
# You should have received a copy of the GNU Affero General Public License
# along with this program.  If not, see <http://www.gnu.org/licenses/>.
@{
	# Version number of this module.
	ModuleVersion = '2.2.0.0'

	# ID used to uniquely identify this module
	GUID = '1e7f1ebc-e035-4d73-86af-3c07a6a85260'

	# Author of this module
	Author = 'Arjan Meskers'

	# Company or vendor of this module
	CompanyName = 'AMSoftware'

	# Copyright statement for this module
	Copyright = 'Copyright (C) 2017 Arjan Meskers / AMSoftware'

	# Description of the functionality provided by this module
	Description = 'Manage Power Platform Dataverse metadata and content, and administer the environment. Use on-premises and online.'
	
	# Modules to import as nested modules of the module specified in RootModule/ModuleToProcess
	RootModule = 'AMSoftware.Crm.Powershell.Commands.dll'

	# Minimum version of Microsoft .NET Framework required by this module.
	DotNetFrameworkVersion = '4.6.2'

	# Minimum version of the common language runtime (CLR) required by this module.
	CLRVersion = '4.0'

	# Assemblies that must be loaded prior to importing this module
	RequiredAssemblies = @('AMSoftware.Crm.PowerShell.Commands.dll','AMSoftware.Crm.PowerShell.Common.dll')

	# Type files (.ps1xml) to be loaded when importing this module
	TypesToProcess = 'AMSoftware.Crm.Powershell.Types.ps1xml'
	
	# Format files (.ps1xml) to be loaded when importing this module
	FormatsToProcess = 'AMSoftware.Crm.Powershell.Format.ps1xml'
	
	# Cmdlets to export from this module
	CmdletsToExport = '*'

	# Specifies the aliases to export from this module
	AliasesToExport = '*'
	
	# List of all files packaged with this module
	FileList = @()

	# Private data to pass to the module specified in RootModule/ModuleToProcess
	PrivateData = @{ 
		PSData = @{
			# Tags applied to this module. These help with module discovery in online galleries.
			Tags = 'dynamics-crm', 'dynamics-365','powerplatform','dataverse','cds','xrm','dynamics365','dynamics','powerapps','crm'
			
			# A URL to the license for this module.
			LicenseUri = 'https://github.com/AMSoftwareNL/crmpowershell/blob/master/LICENSE'
			
			# A URL to the main website for this project.
			ProjectUri = 'https://github.com/AMSoftwareNL/crmpowershell'
			
			# ReleaseNotes of this module
			ReleaseNotes = 'https://github.com/AMSoftwareNL/crmpowershell/releases/tag/v2.2.0.0'
			
			# Flag to indicate whether the module requires explicit user acceptance for install/update/save
			RequireLicenseAcceptance = $false

			# A list of external modules that this module is dependent upon.
			ExternalModuleDependencies = @('Microsoft.Xrm.Tooling.CrmConnector.PowerShell')
		} 
	}
	# HelpInfo URI of this module
	# HelpInfoURI = 'http://www.amsoftware.nl/tools/crmpowershell/help/'
}

