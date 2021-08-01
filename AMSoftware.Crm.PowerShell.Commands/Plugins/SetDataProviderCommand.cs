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
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using System;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands.Plugins
{
    [Cmdlet(VerbsCommon.Set, "CrmDataProvider", HelpUri = HelpUrlConstants.SetDataProviderHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class SetDataProviderCommand : CrmOrganizationCmdlet
    {
        private readonly ContentRepository _repository = new ContentRepository();
        private readonly Guid NotImplementedPluginId = new Guid("c1919979-0021-4f11-a587-a8f904bdfdf9");

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Guid Id { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter]
        public Guid? RetrievePlugin { get; set; }

        [Parameter]
        public Guid? RetrieveMultiplePlugin { get; set; }

        [Parameter]
        public Guid? CreatePlugin { get; set; }

        [Parameter]
        public Guid? UpdatePlugin { get; set; }

        [Parameter]
        public Guid? DeletePlugin { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Entity entity = _repository.Get("entitydataprovider", Id);

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
            {
                if (entity.Contains("name")) entity.Attributes["name"] = Name;
                else entity.Attributes.Add("name", Name);
            }

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(RetrievePlugin)))
                SetEventHandlerId(entity, "retrieveplugin", RetrievePlugin);

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(RetrieveMultiplePlugin)))
                SetEventHandlerId(entity, "retrievemultipleplugin", RetrieveMultiplePlugin);

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(CreatePlugin)))
                SetEventHandlerId(entity, "createplugin", CreatePlugin);

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(UpdatePlugin)))
                SetEventHandlerId(entity, "updateplugin", UpdatePlugin);

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(DeletePlugin)))
                SetEventHandlerId(entity, "deleteplugin", DeletePlugin);

            Guid id = _repository.Add(entity);
            if (PassThru)
            {
                WriteObject(_repository.Get("entitydataprovider", id));
            }

            _repository.Update(entity);
            if (PassThru)
            {
                WriteObject(_repository.Get("entitydataprovider", Id));
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
