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
using AMSoftware.Crm.PowerShell.Common.ArgumentCompleters;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Commands.Content
{
    [Cmdlet(VerbsCommon.Remove, "CrmContent", HelpUri = HelpUrlConstants.RemoveContentHelpUrl, SupportsShouldProcess = true, DefaultParameterSetName = RemoveContentByInputObjectParameterSet)]
    public sealed class RemoveContentCommand : CrmOrganizationConfirmActionCmdlet
    {
        private const string RemoveContentParameterSet = "RemoveContent";
        private const string RemoveContentByInputObjectParameterSet = "RemoveContentByInputObject";

        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = RemoveContentByInputObjectParameterSet, ValueFromPipeline = true)]
        [Alias("Record")]
        [ValidateNotNullOrEmpty]
        public Entity[] InputObject { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = RemoveContentParameterSet)]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string Entity { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = RemoveContentParameterSet, ValueFromPipeline = true)]
        public Guid[] Id { get; set; }

        [Parameter]
        public SwitchParameter AsBatch { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (AsBatch.ToBool() && !CrmContext.Session.BatchActive)
            {
                throw new InvalidOperationException("No active batch to use.");
            }

            switch (this.ParameterSetName)
            {
                case RemoveContentParameterSet:
                    foreach (Guid id in Id)
                    {
                        if (AsBatch.ToBool())
                        {
                            CrmContext.Session.BatchRequestCollection.Add(_repository.DeleteRequest(Entity, id));
                        }
                        else
                        {
                            ExecuteAction(string.Format("{0}: {1}", Entity, Id), delegate
                            {
                                _repository.Delete(Entity, id);
                            });
                        }
                    }
                    break;
                case RemoveContentByInputObjectParameterSet:
                    foreach (Entity input in InputObject)
                    {
                        if (AsBatch.ToBool())
                        {
                            CrmContext.Session.BatchRequestCollection.Add(_repository.DeleteRequest(input.LogicalName, input.Id));
                        }
                        else
                        {
                            ExecuteAction(string.Format("{0}: {1}", input.LogicalName, input.Id), delegate
                            {
                                _repository.Delete(input.LogicalName, input.Id);
                            });
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
