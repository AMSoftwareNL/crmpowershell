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
using Microsoft.Xrm.Sdk.Metadata;

namespace AMSoftware.Crm.PowerShell.Commands.Metadata
{
    [Cmdlet(VerbsCommon.Add, "CrmEntityKey", HelpUri = HelpUrlConstants.AddEntityKeyHelpUrl, DefaultParameterSetName = AddEntityKeyByInputObjectParameterSet)]
    [OutputType(typeof(EntityKeyMetadata))]
    public sealed class AddEntityKeyCommand : CrmOrganizationCmdlet
    {
        private const string AddEntityKeyParameterSet = "AddEntityKey";
        private const string AddEntityKeyByInputObjectParameterSet = "AddEntityKeyByInputObject";

        private readonly MetadataRepository _repository = new MetadataRepository();

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = AddEntityKeyByInputObjectParameterSet)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = AddEntityKeyParameterSet, ValueFromPipelineByPropertyName = true)]
        [Alias("EntityLogicalName", "LogicalName")]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string Entity { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = AddEntityKeyByInputObjectParameterSet, ValueFromPipeline = true)]
        [Alias("EntityKey")]
        [ValidateNotNullOrEmpty]
        public EntityKeyMetadata InputObject { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = AddEntityKeyParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 3, ParameterSetName = AddEntityKeyParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = AddEntityKeyParameterSet)]
        [ValidateNotNull]
        [ValidateCount(1, int.MaxValue)]
        [ArgumentCompleter(typeof(AttributeArgumentCompleter))]
        public string[] Attributes { get; set; }

        [Parameter(ParameterSetName = AddEntityKeyParameterSet)]
        [ValidateNotNull]
        public string SchemaName { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case AddEntityKeyParameterSet:
                    EntityKeyMetadata key = new EntityKeyMetadata()
                    {
                        LogicalName = Name,
                        SchemaName = Name,
                        DisplayName = new Label(DisplayName, CrmContext.Session.Language)
                    };
                    key.KeyAttributes = Attributes;
                    if (!string.IsNullOrWhiteSpace(SchemaName)) key.SchemaName = SchemaName;

                    Guid id1 = _repository.AddEntityKey(Entity, key);
                    if (PassThru)
                    {
                        WriteObject(_repository.GetEntityKey(id1));
                    }
                    break;
                case AddEntityKeyByInputObjectParameterSet:
                    Guid id2 = _repository.AddEntityKey(Entity, InputObject);
                    if (PassThru) {
                        WriteObject(_repository.GetEntityKey(id2));
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
