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
    [Cmdlet(VerbsCommon.Add, "CrmRelationship", HelpUri = HelpUrlConstants.AddRelationshipHelpUrl)]
    [OutputType(typeof(RelationshipMetadataBase))]
    public sealed class AddRelationshipCommand : CrmOrganizationCmdlet, IDynamicParameters
    {
        private const string AddOneToManyRelationshipParameterSet = "AddOneToManyRelationship";
        private const string AddManyToManyRelationsipParameterSet = "AddManyToManyRelationship";

        private MetadataRepository _repository = new MetadataRepository();
        private AddRelationshipDynamicParameters _context;

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = AddManyToManyRelationsipParameterSet)]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string Entity1 { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = AddManyToManyRelationsipParameterSet)]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string Entity2 { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = AddOneToManyRelationshipParameterSet, ValueFromPipelineByPropertyName = true)]
        [Alias("EntityLogicalName", "LogicalName")]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string Entity { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = AddOneToManyRelationshipParameterSet)]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string ToEntity { get; set; }

        [Parameter(Mandatory = true, Position = 3)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 4, ParameterSetName = AddManyToManyRelationsipParameterSet)]
        [ValidateNotNullOrEmpty]
        public string IntersectName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = AddOneToManyRelationshipParameterSet)]
        [ValidateNotNullOrEmpty]
        public string AttributeName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = AddOneToManyRelationshipParameterSet)]
        [ValidateNotNullOrEmpty]
        public string AttributeDisplayName { get; set; }

        [Parameter(ParameterSetName = AddOneToManyRelationshipParameterSet)]
        [ValidateNotNull]
        public string AttributeDescription { get; set; }

        [Parameter(ParameterSetName = AddOneToManyRelationshipParameterSet)]
        [PSDefaultValue(Value = CrmRequiredLevel.Required)]
        public CrmRequiredLevel AttributeRequired { get; set; }

        [Parameter]
        [ValidateNotNull]
        public bool? AdvancedFind { get; set; }

        [Parameter]
        [ValidateNotNull]
        public bool? Customizable { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case AddManyToManyRelationsipParameterSet:
                    AddManyToMany();
                    break;
                case AddOneToManyRelationshipParameterSet:
                    AddOneToMany();
                    break;
                default:
                    break;
            }
        }

        public object GetDynamicParameters()
        {
            if (CrmVersionManager.IsSupported(CrmVersion.CRM2016_RTM))
            {
                _context = new AddRelationshipDynamicParameters2016();
            }

            return _context;
        }

        private void AddOneToMany()
        {
            OneToManyRelationshipMetadata relationship = new OneToManyRelationshipMetadata
            {
                ReferencedEntity = ToEntity,
                ReferencingEntity = Entity,
                SchemaName = Name
            };
            if (_context != null) _context.SetParametersOnRelationship(relationship);

            LookupAttributeMetadata lookup = new LookupAttributeMetadata
            {
                SchemaName = AttributeName,
                DisplayName = new Label(AttributeDisplayName, CrmContext.Language),
                Description = new Label(AttributeDescription ?? string.Empty, CrmContext.Language)
            };
            AttributeRequiredLevel requiredLevel = AttributeRequiredLevel.ApplicationRequired;
            if (AttributeRequired == CrmRequiredLevel.Required) requiredLevel = AttributeRequiredLevel.ApplicationRequired;
            if (AttributeRequired == CrmRequiredLevel.Recommended) requiredLevel = AttributeRequiredLevel.Recommended;
            if (AttributeRequired == CrmRequiredLevel.Optional) requiredLevel = AttributeRequiredLevel.None;
            lookup.RequiredLevel = new AttributeRequiredLevelManagedProperty(requiredLevel);

            Guid result = _repository.AddRelationship(relationship, lookup);
            if (PassThru)
            {
                WriteObject(_repository.GetRelationship(result));
            }
        }

        private void AddManyToMany()
        {
            ManyToManyRelationshipMetadata data = new ManyToManyRelationshipMetadata()
            {
                SchemaName = Name,
                Entity1LogicalName = Entity1,
                Entity2LogicalName = Entity2
            };
            if (AdvancedFind.HasValue) data.IsValidForAdvancedFind = AdvancedFind;
            if (Customizable.HasValue) data.IsCustomizable = new BooleanManagedProperty(Customizable.Value);

            Guid result = _repository.AddRelationship(data, IntersectName);
            if (PassThru)
            {
                WriteObject(_repository.GetRelationship(result));
            }
        }
    }

    public abstract class AddRelationshipDynamicParameters
    {
        internal protected virtual void SetParametersOnRelationship(RelationshipMetadataBase relationship)
        {
        }
    }

    public sealed class AddRelationshipDynamicParameters2016 : AddRelationshipDynamicParameters
    {
        [Parameter, ValidateNotNull]
        public bool? IsHierarchical { get; set; }

        protected internal override void SetParametersOnRelationship(RelationshipMetadataBase relationship)
        {
            base.SetParametersOnRelationship(relationship);

            if (relationship is OneToManyRelationshipMetadata internalRelationship)
            {
                if (IsHierarchical.HasValue)
                {
                    if (string.Equals(internalRelationship.ReferencingEntity, internalRelationship.ReferencedEntity, StringComparison.InvariantCultureIgnoreCase))
                    {
                        ((OneToManyRelationshipMetadata)relationship).IsHierarchical = IsHierarchical.Value;
                    }
                }
            }
        }
    }
}
