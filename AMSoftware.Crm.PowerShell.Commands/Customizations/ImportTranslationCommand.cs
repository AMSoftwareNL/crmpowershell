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
using System;
using System.Collections;
using System.IO;
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Commands.Customizations
{
    [Cmdlet(VerbsData.Import, "Translation", HelpUri = HelpUrlConstants.ImportTranslationHelpUrl, SupportsShouldProcess = true)]
    [OutputType(typeof(Entity))]
    public class ImportTranslationCommand : CrmOrganizationActionCmdlet
    {
        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            byte[] content = File.ReadAllBytes(Path);

            ExecuteAction(Path, delegate
            {
                Guid importjobid = Guid.NewGuid(); 
                
                _repository.Execute("ImportTranslation", new Hashtable() {
                    { "TranslationFile", content },
                    { "ImportJobId", importjobid }
                });

                WriteObject(_repository.Get("importjob", importjobid));
            });
        }
    }
}
