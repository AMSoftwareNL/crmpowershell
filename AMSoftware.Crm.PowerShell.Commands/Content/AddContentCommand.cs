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
using AMSoftware.Crm.PowerShell.Common.ArgumentCompleters;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands.Content
{
    [Cmdlet(VerbsCommon.Add, "CrmContent", HelpUri = HelpUrlConstants.AddContentHelpUrl, DefaultParameterSetName = AddContentByInputObjectParameterSet)]
    [OutputType(typeof(Entity))]
    public sealed class AddContentCommand : CrmOrganizationCmdlet
    {
        private const string AddContentParameterSet = "AddContent";
        private const string AddContentByInputObjectParameterSet = "AddContentByInputObject";

        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = AddContentByInputObjectParameterSet, ValueFromPipeline = true)]
        [Alias("Record")]
        [ValidateNotNullOrEmpty]
        public Entity InputObject { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = AddContentParameterSet)]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string Entity { get; set; }

        [Parameter(Position = 2, ParameterSetName = AddContentParameterSet)]
        public Guid Id { get; set; }

        [Parameter(Mandatory = true, Position = 3, ParameterSetName = AddContentParameterSet)]
        [ValidateNotNull]
        public Hashtable Attributes { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        [Parameter]
        public SwitchParameter AsBatch { get; set; }

        [Parameter]
        public SwitchParameter Upsert { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (AsBatch.ToBool() && !CrmContext.Session.BatchActive)
            {
                throw new InvalidOperationException("No active batch to use.");
            }

            switch (this.ParameterSetName)
            {
                case AddContentParameterSet:
                    if (AsBatch.ToBool())
                    {
                        if (Upsert.ToBool()) CrmContext.Session.BatchRequestCollection.Add(_repository.UpsertRequest(Entity, Id, Attributes));
                        else CrmContext.Session.BatchRequestCollection.Add(_repository.AddRequest(Entity, Id, Attributes));
                    }
                    else
                    {
                        Guid newId1;
                        if (Upsert.ToBool()) newId1 = _repository.Upsert(Entity, Id, Attributes);
                        else newId1 = _repository.Add(Entity, Id, Attributes);

                        if (PassThru)
                        {
                            WriteObject(_repository.Get(Entity, newId1, null));
                        }
                    }
                    break;
                case AddContentByInputObjectParameterSet:
                    if (AsBatch.ToBool())
                    {
                        if (Upsert.ToBool()) CrmContext.Session.BatchRequestCollection.Add(_repository.UpsertRequest(InputObject));
                        else CrmContext.Session.BatchRequestCollection.Add(_repository.AddRequest(InputObject));
                    }
                    else
                    {
                        Guid newId2;
                        if (Upsert.ToBool()) newId2 = _repository.Upsert(InputObject); 
                        else newId2 = _repository.Add(InputObject);

                        if (PassThru)
                        {
                            WriteObject(_repository.Get(InputObject.LogicalName, newId2, null));
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
