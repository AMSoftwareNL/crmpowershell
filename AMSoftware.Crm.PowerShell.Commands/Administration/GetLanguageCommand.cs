/*
CRM PowerShell Library
Copyright (C) 2017 Arjan Meskers / AMSoftware

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published
by the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Commands.Administration
{
    [Cmdlet(VerbsCommon.Get, "CrmLanguage", HelpUri = HelpUrlConstants.GetLanguageHelpUrl)]
    [OutputType(typeof(CultureInfo))]
    public sealed class GetLanguageCommand : CrmOrganizationCmdlet
    {
        private ContentRepository _repository = new ContentRepository();

        [Parameter]
        public SwitchParameter All { get; set; }

        [Parameter]
        public SwitchParameter ListAvailable { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            int[] languageIds = null;
            if (All.IsPresent)
            {
                OrganizationResponse response = _repository.Execute("RetrieveAvailableLanguages");
                languageIds = (int[])response.Results["LocaleIds"];
            }
            else if (ListAvailable.IsPresent)
            {
                OrganizationResponse response = _repository.Execute("RetrieveDeprovisionedLanguages");
                languageIds = (int[])response.Results["RetrieveDeprovisionedLanguages"];
            }
            else
            {
                OrganizationResponse response = _repository.Execute("RetrieveProvisionedLanguages");
                languageIds = (int[])response.Results["RetrieveProvisionedLanguages"];
            }

            if (languageIds != null)
            {
                WriteObject(languageIds.Select(l => CultureInfo.GetCultureInfo(l)).OrderBy(c => c.Name));
            }
        }
    }
}
