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
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Commands.Content
{
    [Cmdlet(VerbsLifecycle.Invoke, "CrmRequest", HelpUri = HelpUrlConstants.InvokeRequestHelpUrl)]
    [OutputType(typeof(OrganizationResponse))]
    public sealed class InvokeRequestCommand : CrmOrganizationCmdlet
    {
        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateNotNullOrEmpty]
        public string Request { get; set; }

        [Parameter(Position = 2, ValueFromPipeline = true)]
        public Hashtable Parameters { get; set; }

        [Parameter]
        public SwitchParameter AsBatch { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (AsBatch.ToBool() && !CrmContext.Session.BatchActive)
            {
                throw new InvalidOperationException("No active batch to use.");
            }

            if (AsBatch.ToBool())
            {
                CrmContext.Session.BatchRequestCollection.Add(_repository.ExecuteRequest(Request, Parameters));
            }
            else
            {
                OrganizationResponse response = _repository.Execute(Request, Parameters);
                WriteObject(response);
            }
        }
    }
}
