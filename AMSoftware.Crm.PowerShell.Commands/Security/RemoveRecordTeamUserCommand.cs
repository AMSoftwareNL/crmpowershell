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
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Commands.Security
{
    [Cmdlet(VerbsCommon.Remove, "CrmRecordTeamUser", HelpUri = HelpUrlConstants.RemoveRecordTeamUserHelpUrl)]
    [OutputType(typeof(OrganizationResponse))]
    public sealed class RemoveRecordTeamUserCommand : CrmOrganizationCmdlet
    {
        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateNotNullOrEmpty]
        public Guid User { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        [ValidateNotNullOrEmpty]
        public Guid TeamTemplate { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromRemainingArguments = true)]
        [ValidateNotNullOrEmpty]
        public EntityReference[] Record { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            foreach (var item in Record)
            {
                Hashtable requestParameters = new Hashtable()
                {
                    { "Record ", item },
                    { "SystemUserId", User },
                    { "TeamTemplateId", TeamTemplate }
                };

                WriteObject(_repository.ExecuteRequest("RemoveUserFromRecordTeamRequest", requestParameters));
            }
        }
    }
}
