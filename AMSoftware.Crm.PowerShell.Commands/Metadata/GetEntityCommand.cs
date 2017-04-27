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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk.Metadata;

namespace AMSoftware.Crm.PowerShell.Commands.Metadata
{
    [Cmdlet(VerbsCommon.Get, "Entity", HelpUri = HelpUrlConstants.GetEntityHelpUrl, DefaultParameterSetName = GetEntitiesByFilterParameterSet)]
    [OutputType(typeof(EntityMetadata))]
    public sealed class GetEntityCommand : CrmOrganizationCmdlet
    {
        private const string GetEntityByNameParameterSet = "GetEntityByName";
        private const string GetEntityByIdParameterSet = "GetEntityById";
        private const string GetEntitiesByFilterParameterSet = "GetEntitiesByFilter";

        private MetadataRepository _repository = new MetadataRepository();

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = GetEntityByIdParameterSet)]
        [ValidateNotNull]
        public Guid Id { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = GetEntityByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = GetEntitiesByFilterParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Include { get; set; }

        [Parameter(ParameterSetName = GetEntitiesByFilterParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Exclude { get; set; }
        
        [Parameter(ParameterSetName = GetEntitiesByFilterParameterSet)]
        public SwitchParameter CustomOnly { get; set; }

        [Parameter(ParameterSetName = GetEntitiesByFilterParameterSet)]
        public SwitchParameter ExcludeManaged { get; set; }

        [Parameter(ParameterSetName = GetEntitiesByFilterParameterSet)]
        public SwitchParameter IncludeIntersects { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case GetEntityByNameParameterSet:
                    WriteObject(_repository.GetEntity(Name));
                    break;
                case GetEntityByIdParameterSet:
                    WriteObject(_repository.GetEntity(Id));
                    break;
                case GetEntitiesByFilterParameterSet:
                    IEnumerable<EntityMetadata> result = _repository.GetEntity(CustomOnly.ToBool(), ExcludeManaged.ToBool(), IncludeIntersects.ToBool());
                    if (!string.IsNullOrWhiteSpace(Include))
                    {
                        WildcardPattern includePattern = new WildcardPattern(Include, WildcardOptions.IgnoreCase);
                        result = result.Where(e => includePattern.IsMatch(e.LogicalName));
                    }
                    if (!string.IsNullOrWhiteSpace(Exclude))
                    {
                        WildcardPattern excludePattern = new WildcardPattern(Exclude, WildcardOptions.IgnoreCase);
                        result = result.Where(e => !excludePattern.IsMatch(e.LogicalName));
                    }

                    WriteObject(result, true);

                    break;
                default:
                    break;
            }
        }
    }
}
