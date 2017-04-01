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
function Get-ScriptDirectory
{
    $Invocation = (Get-Variable MyInvocation -Scope 1).Value
    Split-Path $Invocation.MyCommand.Path
}

$modulePath = Join-Path $(Get-ScriptDirectory) "AMSoftware.Crm.psd1"
Import-Module $modulePath
cd c:\
$welcomeMessage = @"
For a list of all cmdlets type 'Get-Command -Module AMSoftware.Crm'.
For help on a cmdlet type 'Get-Help [Name of cmdlet] -full'.
To get started connect to a CRM Deployment using Connect-CrmDeployment.
Set the active organization using Connect-CrmOrganization.
"@
Write-Output $welcomeMessage

$VerbosePreference="Continue"
