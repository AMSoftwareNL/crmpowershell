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
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Commands.Security
{
    [Cmdlet(VerbsCommon.New, "CrmTeamTemplate", HelpUri = HelpUrlConstants.NewTeamTemplateHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class NewTeamTemplateCommand : CrmOrganizationCmdlet
    {
        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty] 
        public string Description { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull] 
        public int ObjectTypeCode { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        public CrmAccessRight DefaultAccessRight { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Entity newTeamTemplate = new Entity("teamtemplate")
            {
                Attributes = new AttributeCollection()
            };
            newTeamTemplate.Attributes.Add("teamtemplatename", Name);
            newTeamTemplate.Attributes.Add("defaultaccessrightsmask", (int)DefaultAccessRight);
            newTeamTemplate.Attributes.Add("objecttypecode", ObjectTypeCode);
            if (!string.IsNullOrWhiteSpace(Description))
            {
                newTeamTemplate.Attributes.Add("description", Description);
            }

            Guid newTeamTemplateId = _repository.Add(newTeamTemplate);

            if (PassThru)
            {
                WriteObject(_repository.Get("teamtemplate", newTeamTemplateId));
            }
        }
    }
}
