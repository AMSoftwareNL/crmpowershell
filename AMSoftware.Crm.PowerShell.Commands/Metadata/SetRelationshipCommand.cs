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
    public sealed class SetRelationshipCommand : CrmOrganizationCmdlet
    {
        private const string SetRelationshipParameterSet = "SetRelationship";
        private const string SetRelationshipByInputObjectParameterSet = "SetRelationshipByInputObject";

        private readonly MetadataRepository _repository = new MetadataRepository();

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
        public bool AdvancedFind { get; set; }

        [Parameter(ParameterSetName = SetRelationshipParameterSet)]
        [ValidateNotNull]
        public bool IsHierarchical { get; set; }

        [Parameter(ParameterSetName = SetRelationshipParameterSet)]
        [ValidateNotNull]
        public bool Customizable { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case SetRelationshipParameterSet:
                    RelationshipMetadataBase internalRelationship = _repository.GetRelationship(Name);

                    if (this.MyInvocation.BoundParameters.ContainsKey(nameof(AdvancedFind))) 
                        internalRelationship.IsValidForAdvancedFind = AdvancedFind;
                    if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Customizable)))
                        internalRelationship.IsCustomizable = new BooleanManagedProperty(Customizable);
                    if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsHierarchical)))
                    {
                        if (internalRelationship is OneToManyRelationshipMetadata)
                            ((OneToManyRelationshipMetadata)internalRelationship).IsHierarchical = IsHierarchical;
                    }

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
    }
}
