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
using AMSoftware.Crm.PowerShell.Common.ArgumentCompleters;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk.Metadata;

namespace AMSoftware.Crm.PowerShell.Commands.Metadata
{
    [Cmdlet(VerbsCommon.Get, "CrmEntity", HelpUri = HelpUrlConstants.GetEntityHelpUrl, DefaultParameterSetName = GetEntitiesByFilterParameterSet)]
    [OutputType(typeof(EntityMetadata))]
    public sealed class GetEntityCommand : CrmOrganizationCmdlet
    {
        private const string GetEntityByIdParameterSet = "GetEntityById";
        private const string GetEntityByEtcParameterSet = "GetEntityByEtc";
        private const string GetEntitiesByFilterParameterSet = "GetEntitiesByFilter";

        private readonly MetadataRepository _repository = new MetadataRepository();

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = GetEntityByIdParameterSet, ValueFromPipeline = true)]
        [Alias("MetadataId")]
        [ValidateNotNull]
        public Guid[] Id { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = GetEntityByEtcParameterSet)]
        [Alias("ObjectTypeCode")]
        [ValidateNotNull]
        public int EntityTypeCode { get; set; }

        [Parameter(Position = 1, ParameterSetName = GetEntitiesByFilterParameterSet)]
        [Alias("Include")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string Name { get; set; }

        [Parameter(ParameterSetName = GetEntitiesByFilterParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string Exclude { get; set; }

        [Parameter(ParameterSetName = GetEntitiesByFilterParameterSet)]
        public SwitchParameter CustomOnly { get; set; }

        [Parameter(ParameterSetName = GetEntitiesByFilterParameterSet)]
        public SwitchParameter ExcludeManaged { get; set; }

        [Parameter(ParameterSetName = GetEntitiesByFilterParameterSet)]
        public SwitchParameter IncludeIntersects { get; set; }

        [Parameter(ParameterSetName = GetEntitiesByFilterParameterSet)]
        public SwitchParameter VirtualOnly { get; set; }


        [Parameter(ParameterSetName = GetEntitiesByFilterParameterSet)]
        public SwitchParameter DataSourcesOnly { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case GetEntityByIdParameterSet:
                    foreach (Guid id in Id)
                    {
                        WriteObject(_repository.GetEntity(id));
                    }
                    break;
                case GetEntityByEtcParameterSet:
                    WriteObject(_repository.GetEntity(EntityTypeCode));
                    break;
                case GetEntitiesByFilterParameterSet:
                    IEnumerable<EntityMetadata> result = _repository.GetEntity();

                    if (CustomOnly.ToBool()) result = result.Where(e => e.IsCustomEntity == true);
                    if (VirtualOnly.ToBool()) result = result.Where(e => e.DataProviderId != null);
                    if (DataSourcesOnly.ToBool()) result = result.Where(e => e.DataProviderId == new Guid("b2112a7e-b26c-42f7-9b63-9a809a9d716f"));  //JSON Converter Provider
                    if (ExcludeManaged.ToBool()) result = result.Where(e => e.IsManaged != true);
                    if (!IncludeIntersects.ToBool()) result = result.Where(e => e.IsIntersect != true);

                    if (!string.IsNullOrWhiteSpace(Name))
                    {
                        WildcardPattern includePattern = new WildcardPattern(Name, WildcardOptions.IgnoreCase);
                        result = result.Where(e => includePattern.IsMatch(e.LogicalName));
                    }
                    if (!string.IsNullOrWhiteSpace(Exclude))
                    {
                        WildcardPattern excludePattern = new WildcardPattern(Exclude, WildcardOptions.IgnoreCase);
                        result = result.Where(e => !excludePattern.IsMatch(e.LogicalName));
                    }

                    result = result.OrderBy(e => e.LogicalName).ToList();

                    WriteObject(result, true);

                    break;
                default:
                    break;
            }
        }
    }
}
