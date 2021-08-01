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
    [Cmdlet(VerbsCommon.Join, "CrmContent", HelpUri = HelpUrlConstants.JoinContentHelpUrl, DefaultParameterSetName = JoinContentByInputObjectParameterSet)]
    public sealed class JoinContentCommand : CrmOrganizationCmdlet
    {
        private const string JoinContentParameterSet = "JoinContent";
        private const string JoinContentByInputObjectParameterSet = "JoinContentByInputObject";

        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = JoinContentByInputObjectParameterSet, ValueFromPipeline = true)]
        [Alias("Record")]
        [ValidateNotNullOrEmpty]
        public Entity InputObject { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = JoinContentParameterSet)]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string Entity { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = JoinContentParameterSet, ValueFromPipeline = true)]
        public Guid Id { get; set; }

        [Parameter(Mandatory = true, Position = 3, ParameterSetName = JoinContentParameterSet)]
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = JoinContentByInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string ToEntity { get; set; }

        [Parameter(Mandatory = true, Position = 4, ParameterSetName = JoinContentParameterSet)]
        [Parameter(Mandatory = true, Position = 4, ParameterSetName = JoinContentByInputObjectParameterSet)]
        public Guid ToId { get; set; }

        [Parameter(ParameterSetName = JoinContentParameterSet)]
        [Parameter(ParameterSetName = JoinContentByInputObjectParameterSet)]
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
                case JoinContentParameterSet:
                    if (AsBatch.ToBool())
                    {
                        CrmContext.Session.BatchRequestCollection.Add(_repository.AssociateRequest(Entity, Id, ToEntity, ToId, Attribute));
                    }
                    else
                    {
                        _repository.Associate(Entity, Id, ToEntity, ToId, Attribute);
                    }
                    break;
                case JoinContentByInputObjectParameterSet:
                    if (AsBatch.ToBool())
                    {
                        CrmContext.Session.BatchRequestCollection.Add(_repository.AssociateRequest(InputObject.LogicalName, InputObject.Id, ToEntity, ToId, Attribute));
                    }
                    else
                    {
                        _repository.Associate(InputObject.LogicalName, InputObject.Id, ToEntity, ToId, Attribute);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
