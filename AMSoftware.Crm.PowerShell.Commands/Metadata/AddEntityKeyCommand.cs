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
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace AMSoftware.Crm.PowerShell.Commands.Metadata
{
    [Cmdlet(VerbsCommon.Add, "EntityKey", HelpUri = HelpUrlConstants.AddEntityKeyHelpUrl)]
    [OutputType(typeof(EntityKeyMetadata))]
    public class AddEntityKeyCommand : CrmOrganizationCmdlet
    {
        protected MetadataRepository _repository = new MetadataRepository();

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateNotNullOrEmpty]
        public string Entity { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 3)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        [ValidateCount(1, int.MaxValue)]
        public string[] Attributes { get; set; }

        [Parameter]
        [ValidateNotNull]
        public string SchemaName { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            EntityKeyMetadata key = new EntityKeyMetadata()
            {
                LogicalName = Name,
                SchemaName = Name,
                DisplayName = new Label(DisplayName, CrmContext.Language)
            };
            key.KeyAttributes = Attributes;
            if (!string.IsNullOrWhiteSpace(SchemaName)) key.SchemaName = SchemaName;
            
            Guid id = _repository.AddEntityKey(Entity, key);
            WriteObject(_repository.GetEntityKey(id));
        }
    }
}
