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
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace AMSoftware.Crm.PowerShell.Commands.Metadata
{
    [Cmdlet(VerbsCommon.Set, "CrmRelationship", HelpUri = HelpUrlConstants.SetRelationshipHelpUrl, DefaultParameterSetName = SetRelationshipByInputObjectParameterSet)]
    [OutputType(typeof(RelationshipMetadataBase))]
    public sealed class SetRelationshipCommand : CrmOrganizationCmdlet, IDynamicParameters
    {
        private const string SetRelationshipParameterSet = "SetRelationship";
        private const string SetRelationshipByInputObjectParameterSet = "SetRelationshipByInputObject";

        private MetadataRepository _repository = new MetadataRepository();
        private SetRelationshipDynamicParameters _context;

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = SetRelationshipByInputObjectParameterSet, ValueFromPipeline = true)]
        [Alias("Relationship")]
        [ValidateNotNull]
        public RelationshipMetadataBase InputObject { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = SetRelationshipParameterSet)]
        [Alias("SchemaName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = SetRelationshipParameterSet)]
        [ValidateNotNull]
        public bool? AdvancedFind { get; set; }

        [Parameter(ParameterSetName = SetRelationshipParameterSet)]
        [ValidateNotNull]
        public bool? Customizable { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case SetRelationshipParameterSet:
                    RelationshipMetadataBase internalRelationship = _repository.GetRelationship(Name);
                    if (AdvancedFind.HasValue) internalRelationship.IsValidForAdvancedFind = AdvancedFind.Value;
                    if (Customizable.HasValue) internalRelationship.IsCustomizable = new BooleanManagedProperty(Customizable.Value);
                    if (_context != null) _context.SetParametersOnRelationship(internalRelationship);

                    _repository.UpdateRelationship(internalRelationship);
                    if (PassThru)
                    {
                        WriteObject(_repository.GetRelationship(internalRelationship.MetadataId.Value));
                    }
                    break;
                case SetRelationshipByInputObjectParameterSet:
                    _repository.UpdateRelationship(InputObject);
                    if (PassThru)
                    {
                        WriteObject(_repository.GetRelationship(InputObject.MetadataId.Value));
                    }
                    break;
                default:
                    break;
            }
        }

        public object GetDynamicParameters()
        {
            if (this.ParameterSetName == SetRelationshipParameterSet)
            {
                if (CrmVersionManager.IsSupported(CrmVersion.CRM2016_RTM))
                {
                    _context = new SetRelationshipDynamicParameters2016();
                }

                return _context;
            }
            else
            {
                return null;
            }
        }
    }

    public abstract class SetRelationshipDynamicParameters
    {
        internal protected virtual void SetParametersOnRelationship(RelationshipMetadataBase relationship)
        {
        }
    }

    public sealed class SetRelationshipDynamicParameters2016 : SetRelationshipDynamicParameters
    {
        [Parameter, ValidateNotNull]
        public bool? IsHierarchical { get; set; }

        protected internal override void SetParametersOnRelationship(RelationshipMetadataBase relationship)
        {
            base.SetParametersOnRelationship(relationship);

            if (relationship is OneToManyRelationshipMetadata)
            {
                if (IsHierarchical.HasValue) ((OneToManyRelationshipMetadata)relationship).IsHierarchical = IsHierarchical.Value;
            }
        }
    }
}
