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
using AMSoftware.Crm.PowerShell.Commands.Helpers;
using AMSoftware.Crm.PowerShell.Common.ArgumentCompleters;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk.Metadata;

namespace AMSoftware.Crm.PowerShell.Commands.Metadata
{
    [Cmdlet(VerbsCommon.Remove, "CrmEntity", HelpUri = HelpUrlConstants.RemoveEntityHelpUrl, SupportsShouldProcess = true)]
    public sealed class RemoveEntityCommand : CrmOrganizationConfirmActionCmdlet
    {
        private readonly MetadataRepository _repository = new MetadataRepository();
        private readonly ContentRepository _contentRepository = new ContentRepository();

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Alias("EntityLogicalName", "LogicalName")]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string Name { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteAction(Name, delegate
            {
                EntityMetadata entity = _repository.GetEntity(Name);

                // Is DataSource Entity
                if (entity.DataProviderId != null && entity.DataProviderId == new Guid("b2112a7e-b26c-42f7-9b63-9a809a9d716f"))
                {
                    Guid? dataProviderId = EntitiesHelper.GetVirtualDataProvider(_contentRepository, Name);
                    // Found DataProvider
                    if (dataProviderId != null && dataProviderId != Guid.Empty)
                    {
                        // Delete DataProvider Related to DataSource entity
                        _contentRepository.Delete("entitydataprovider", dataProviderId.Value);
                    }
                }

                _repository.DeleteEntity(Name);
            });
        }
    }
}
