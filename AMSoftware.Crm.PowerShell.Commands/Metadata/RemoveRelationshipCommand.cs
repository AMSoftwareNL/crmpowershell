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
using AMSoftware.Crm.PowerShell.Common.ArgumentCompleters;
using AMSoftware.Crm.PowerShell.Common.Repositories;

namespace AMSoftware.Crm.PowerShell.Commands.Metadata
{
    [Cmdlet(VerbsCommon.Remove, "CrmRelationship", HelpUri = HelpUrlConstants.RemoveRelationshipHelpUrl, SupportsShouldProcess = true)]
    public sealed class RemoveRelationshipCommand : CrmOrganizationConfirmActionCmdlet
    {
        private const string RemoveRelationshipByNameParameterSet = "RemoveRelationshipByName";
        private const string RemoveRelationshipByEntityParameterSet = "RemoveRelationshipByEntity";

        private readonly MetadataRepository _repository = new MetadataRepository();

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = RemoveRelationshipByNameParameterSet, ValueFromPipelineByPropertyName = true)]
        [Alias("SchemaName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = RemoveRelationshipByEntityParameterSet, ValueFromPipelineByPropertyName = true)]
        [Alias("EntityLogicalName")]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string Entity { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = RemoveRelationshipByEntityParameterSet)]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string FromEntity { get; set; }

        [Parameter(ParameterSetName = RemoveRelationshipByEntityParameterSet)]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(AttributeArgumentCompleter))]
        public string Attribute { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            switch (this.ParameterSetName)
            {
                case RemoveRelationshipByNameParameterSet:
                    ExecuteAction(Name, delegate
                    {
                        _repository.DeleteRelationship(Name);
                    });
                    break;
                case RemoveRelationshipByEntityParameterSet:
                    ExecuteAction(string.Format("{0}: {1}", Entity, FromEntity), delegate
                    {
                        _repository.DeleteRelationship(Entity, FromEntity, Attribute);
                    });
                    break;
                default:
                    break;
            }
        }
    }
}
