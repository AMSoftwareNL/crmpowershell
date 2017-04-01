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
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk.Metadata;

namespace AMSoftware.Crm.PowerShell.Commands.Metadata
{
    [Cmdlet(VerbsCommon.Get, "Relationship", HelpUri = HelpUrlConstants.GetRelationshipHelpUrl)]
    [OutputType(typeof(RelationshipMetadataBase))]
    public class GetRelationshipCommand : CrmOrganizationCmdlet
    {
        private const string GetRelationshipByNameParameterSet = "GetRelationshipByName";
        private const string GetRelationshipByIdParameterSet = "GetRelationshipById";
        private const string GetRelationshipByFilterParameterSet = "GetRelationshipByFilter";

        private MetadataRepository _repository = new MetadataRepository();

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = GetRelationshipByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = GetRelationshipByIdParameterSet)]
        [ValidateNotNull]
        public Guid Id { get; set; }

        [Parameter(Position = 1, ParameterSetName = GetRelationshipByFilterParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Entity { get; set; }

        [Parameter(Position = 2, ParameterSetName = GetRelationshipByFilterParameterSet)]
        [ValidateNotNullOrEmpty]
        public string RelatedEntity { get; set; }

        [Parameter(ParameterSetName = GetRelationshipByFilterParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Include { get; set; }

        [Parameter(ParameterSetName = GetRelationshipByFilterParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Exclude { get; set; }

        [Parameter(ParameterSetName = GetRelationshipByFilterParameterSet)]
        [PSDefaultValue(Value = CrmRelationshipType.All)]
        public CrmRelationshipType Type { get; set; }

        [Parameter(ParameterSetName = GetRelationshipByFilterParameterSet)]
        public SwitchParameter CustomOnly { get; set; }

        [Parameter(ParameterSetName = GetRelationshipByFilterParameterSet)]
        public SwitchParameter ExcludeManaged { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case GetRelationshipByNameParameterSet:
                    WriteObject(_repository.GetRelationship(Name));
                    break;
                case GetRelationshipByIdParameterSet:
                    WriteObject(_repository.GetRelationship(Id));
                    break;
                case GetRelationshipByFilterParameterSet:
                    GetRelationshipByFilter();
                    break;
                default:
                    break;
            }
        }

        private void GetRelationshipByFilter()
        {
            IEnumerable<RelationshipMetadataBase> result = _repository.GetRelationship(Entity, RelatedEntity, Type, CustomOnly.ToBool(), ExcludeManaged.ToBool());
            if (string.IsNullOrWhiteSpace(RelatedEntity))
            {
                if (!string.IsNullOrWhiteSpace(Include))
                {
                    WildcardPattern includePattern = new WildcardPattern(Include, WildcardOptions.IgnoreCase);
                    result = result.Where(r =>
                        (r.RelationshipType == RelationshipType.OneToManyRelationship && (
                            includePattern.IsMatch(((OneToManyRelationshipMetadata)r).ReferencingEntity) ||
                            includePattern.IsMatch(((OneToManyRelationshipMetadata)r).ReferencedEntity))) ||
                        (r.RelationshipType == RelationshipType.ManyToManyRelationship && (
                            includePattern.IsMatch(((ManyToManyRelationshipMetadata)r).Entity1LogicalName) ||
                            includePattern.IsMatch(((ManyToManyRelationshipMetadata)r).Entity2LogicalName))));
                }
                if (!string.IsNullOrWhiteSpace(Exclude))
                {
                    WildcardPattern excludePattern = new WildcardPattern(Exclude, WildcardOptions.IgnoreCase);
                    result = result.Where(r =>
                        (r.RelationshipType == RelationshipType.OneToManyRelationship && (
                            (!excludePattern.IsMatch(((OneToManyRelationshipMetadata)r).ReferencingEntity) && ((OneToManyRelationshipMetadata)r).ReferencedEntity.Equals(Entity, StringComparison.InvariantCultureIgnoreCase)) ||
                            (!excludePattern.IsMatch(((OneToManyRelationshipMetadata)r).ReferencedEntity) && ((OneToManyRelationshipMetadata)r).ReferencingEntity.Equals(Entity, StringComparison.InvariantCultureIgnoreCase)))) ||
                        (r.RelationshipType == RelationshipType.ManyToManyRelationship && (
                            (!excludePattern.IsMatch(((ManyToManyRelationshipMetadata)r).Entity1LogicalName) && ((ManyToManyRelationshipMetadata)r).Entity2LogicalName.Equals(Entity, StringComparison.InvariantCultureIgnoreCase)) ||
                            (!excludePattern.IsMatch(((ManyToManyRelationshipMetadata)r).Entity2LogicalName) && ((ManyToManyRelationshipMetadata)r).Entity1LogicalName.Equals(Entity, StringComparison.InvariantCultureIgnoreCase)))));
                }
            }

            WriteObject(result, true);
        }
    }
}
