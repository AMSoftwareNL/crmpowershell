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
	ModuleVersion = '1.2.3.0'
	GUID = '1e7f1ebc-e035-4d73-86af-3c07a6a85260'
	Author = 'Arjan Meskers'
	CompanyName = 'AMSoftware'
	Copyright = 'Copyright (C) 2017 Arjan Meskers / AMSoftware'
	Description = 'AMSoftware CRM PowerShell Library'
	PowerShellVersion = '3.0'
	DotNetFrameworkVersion = '4.0'
	CLRVersion = '4.0'
	ProcessorArchitecture = 'None'
	RequiredAssemblies = @(
		'AMSoftware.Crm.Powershell.Commands.dll', 
		'AMSoftware.Crm.Powershell.Common.dll', 
		'Microsoft.Xrm.Sdk.dll')
	TypesToProcess = @('AMSoftware.Crm.Powershell.Types.ps1xml')
	FormatsToProcess = @('AMSoftware.Crm.Powershell.Format.ps1xml')
	NestedModules = @('AMSoftware.Crm.Powershell.Commands.dll')
	FunctionsToExport = '*'
	CmdletsToExport = '*'
	VariablesToExport = '*'
	AliasesToExport = '*'
	PrivateData = @{
		PSData = @{
			ProjectUri = 'https://github.com/AMSoftwareNL/crmpowershell/'
		}
	}
	HelpInfoURI = 'http://crmpowershell.amsoftware.nl/'
	DefaultCommandPrefix = 'Crm'
}

