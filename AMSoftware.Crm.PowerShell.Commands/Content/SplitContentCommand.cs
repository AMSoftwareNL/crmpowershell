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
    [Cmdlet(VerbsCommon.Split, "CrmContent", HelpUri = HelpUrlConstants.SplitContentHelpUrl, DefaultParameterSetName = SplitContentByInputObjectParameterSet)]
    public sealed class SplitContentCommand : CrmOrganizationCmdlet
    {
        private const string SplitContentParameterSet = "SplitContent";
        private const string SplitContentByInputObjectParameterSet = "SplitContentByInputObject";

        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = SplitContentByInputObjectParameterSet, ValueFromPipeline = true)]
        [Alias("Record")]
        [ValidateNotNullOrEmpty]
        public Entity InputObject { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = SplitContentParameterSet)]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string Entity { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = SplitContentParameterSet, ValueFromPipeline = true)]
        public Guid Id { get; set; }

        [Parameter(Mandatory = true, Position = 3, ParameterSetName = SplitContentParameterSet)]
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = SplitContentByInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string FromEntity { get; set; }

        [Parameter(Mandatory = true, Position = 4, ParameterSetName = SplitContentParameterSet)]
        [Parameter(Mandatory = true, Position = 4, ParameterSetName = SplitContentByInputObjectParameterSet)]
        public Guid FromId { get; set; }

        [Parameter(ParameterSetName = SplitContentParameterSet)]
        [Parameter(ParameterSetName = SplitContentByInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(AttributeArgumentCompleter))]
        public string Attribute { get; set; }

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
                case SplitContentParameterSet:
                    if (AsBatch.ToBool())
                    {
                        CrmContext.Session.BatchRequestCollection.Add(_repository.DisassociateRequest(Entity, Id, FromEntity, FromId, Attribute));
                    }
                    else
                    {
                        _repository.Disassociate(Entity, Id, FromEntity, FromId, Attribute);
                    }
                    break;
                case SplitContentByInputObjectParameterSet:
                    if (AsBatch.ToBool())
                    {
                        CrmContext.Session.BatchRequestCollection.Add(_repository.DisassociateRequest(InputObject.LogicalName, InputObject.Id, FromEntity, FromId, Attribute));
                    }
                    else
                    {
                        _repository.Disassociate(InputObject.LogicalName, InputObject.Id, FromEntity, FromId, Attribute);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
