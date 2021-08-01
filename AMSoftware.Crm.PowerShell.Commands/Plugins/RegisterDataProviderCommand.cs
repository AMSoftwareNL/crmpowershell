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
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using System;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands.Plugins
{
    [Cmdlet(VerbsLifecycle.Register, "CrmDataProvider", HelpUri = HelpUrlConstants.RegisterDataProviderHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class RegisterDataProviderCommand : CrmOrganizationCmdlet
    {
        private readonly ContentRepository _repository = new ContentRepository();
        private readonly Guid NotImplementedPluginId = new Guid("c1919979-0021-4f11-a587-a8f904bdfdf9");

        [Parameter(Position = 1, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public object Name { get; set; }

        [Parameter(Position = 2, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string DataSourceLogicalName { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public Guid RetrievePlugin { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public Guid RetrieveMultiplePlugin { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public Guid CreatePlugin { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public Guid UpdatePlugin { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public Guid DeletePlugin { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (CrmContext.Session.ActiveSolutionId == Guid.Empty || string.IsNullOrWhiteSpace(CrmContext.Session.ActiveSolutionName))
            {
                throw new Exception("Registration of Data Provider requires active solution. Run Use-CrmSolution.");
            }

            Entity entity = new Entity("entitydataprovider");
            entity.Attributes.Add("name", Name);
            entity.Attributes.Add("datasourcelogicalname", DataSourceLogicalName);
            entity.Attributes.Add("solutionid", CrmContext.Session.ActiveSolutionId);

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(RetrievePlugin)))
                SetEventHandlerId(entity, "retrieveplugin", RetrievePlugin);
            else
                SetEventHandlerId(entity, "retrieveplugin", null);

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(RetrieveMultiplePlugin)))
                SetEventHandlerId(entity, "retrievemultipleplugin", RetrieveMultiplePlugin);
            else
                SetEventHandlerId(entity, "retrievemultipleplugin", null);

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(CreatePlugin)))
                SetEventHandlerId(entity, "createplugin", CreatePlugin);
            else
                SetEventHandlerId(entity, "createplugin", null);

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(UpdatePlugin)))
                SetEventHandlerId(entity, "updateplugin", UpdatePlugin);
            else
                SetEventHandlerId(entity, "updateplugin", null);

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(DeletePlugin)))
                SetEventHandlerId(entity, "deleteplugin", DeletePlugin);
            else
                SetEventHandlerId(entity, "deleteplugin", null);

            Guid id = _repository.Add(entity);
            if (PassThru)
            {
                WriteObject(_repository.Get("entitydataprovider", id));
            }
        }

        private void SetEventHandlerId(Entity entity, string attributeName, Guid? value)
        {
            Guid pluginId = NotImplementedPluginId;
            if (value != null && value != Guid.Empty)
            {
                pluginId = value.Value;
            }

            if (entity.Attributes.ContainsKey(attributeName))
            {
                entity.Attributes[attributeName] = pluginId;
            }
            else
            {
                entity.Attributes.Add(attributeName, pluginId);
            }
        }
    }
}
