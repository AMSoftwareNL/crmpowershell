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
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Commands.Administration
{
    [Cmdlet(VerbsLifecycle.Start, "CrmProcess", HelpUri = HelpUrlConstants.StartProcessHelpUrl, SupportsShouldProcess = true)]
    [OutputType(typeof(Entity))]
    public sealed class StartProcessCommand : CrmOrganizationActionCmdlet
    {
        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Position = 1, Mandatory = true)]
        [ValidateNotNull]
        public Guid Process { get; set; }

        [Parameter(Position = 5, Mandatory = true, ValueFromPipeline = true)]
        [Alias("Id")]
        [ValidateNotNull]
        public Guid[] Record { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            foreach (Guid id in Record)
            {
                ExecuteAction(id.ToString(), Process.ToString(), delegate
                {
                    OrganizationRequest request = new OrganizationRequest()
                    {
                        RequestName = "ExecuteWorkflow"
                    };
                    request.Parameters["EntityId"] = id;
                    request.Parameters["WorkflowId"] = Process;

                    OrganizationResponse response = _repository.Execute(request);

                    if (PassThru)
                    {
                        Guid asyncId = (Guid)response.Results["Id"];
                        WriteObject(_repository.Get("asyncoperation", asyncId));
                    }
                });
            }
        }
    }
}
