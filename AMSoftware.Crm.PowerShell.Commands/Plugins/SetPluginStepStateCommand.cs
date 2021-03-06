﻿/*
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

namespace AMSoftware.Crm.PowerShell.Commands.Plugins
{
    [Cmdlet(VerbsLifecycle.Enable, "CrmPluginStep", HelpUri = HelpUrlConstants.EnablePluginStepHelpUrl)]
    public sealed class EnablePluginStepCommand : CrmOrganizationCmdlet
    {
        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Guid[] Id { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            foreach (Guid id in Id)
            {
                OrganizationRequest request = new OrganizationRequest("SetState")
                {
                    Parameters = new ParameterCollection()
                };
                request.Parameters.Add("EntityMoniker", new EntityReference("sdkmessageprocessingstep", id));
                request.Parameters.Add("State", new OptionSetValue(0));
                request.Parameters.Add("Status", new OptionSetValue(-1));

                _repository.Execute(request);
            }
        }
    }

    [Cmdlet(VerbsLifecycle.Disable, "CrmPluginStep", HelpUri = HelpUrlConstants.DisablePluginStepHelpUrl)]
    public sealed class DisbalePluginStepCommand : CrmOrganizationCmdlet
    {
        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Guid[] Id { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            foreach (Guid id in Id)
            {
                OrganizationRequest request = new OrganizationRequest("SetState")
                {
                    Parameters = new ParameterCollection()
                };
                request.Parameters.Add("EntityMoniker", new EntityReference("sdkmessageprocessingstep", id));
                request.Parameters.Add("State", new OptionSetValue(1));
                request.Parameters.Add("Status", new OptionSetValue(-1));

                _repository.Execute(request);
            }
        }
    }
}
