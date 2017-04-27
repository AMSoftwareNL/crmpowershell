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
using System.Collections;
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Commands.Customizations
{
    [Cmdlet(VerbsDiagnostic.Test, "SolutionComponent", HelpUri = HelpUrlConstants.TestSolutionComponentHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class TestSolutionComponentCommand : CrmOrganizationCmdlet
    {
        private const string TestDeleteSolutionComponentEntityParameterSet = "TestDeleteSolutionComponentEntity";
        private const string TestDependenciesSolutionComponentEntityParameterSet = "TestDependenciesSolutionComponentEntity";
        private const string TestRequriedSolutionComponentEntityParameterSet = "TestRequiredSolutionComponentEntity";

        private const string TestDeleteSolutionComponentParameterSet = "TestDeleteSolutionComponent";
        private const string TestDependenciesSolutionComponentParameterSet = "TestDependenciesSolutionComponent";
        private const string TestRequriedSolutionComponentParameterSet = "TestRequiredSolutionComponent";

        private ContentRepository _repository = new ContentRepository();

        [Parameter(Position = 1, ValueFromPipeline = true, ParameterSetName = TestDeleteSolutionComponentEntityParameterSet)]
        [Parameter(Position = 1, ValueFromPipeline = true, ParameterSetName = TestDependenciesSolutionComponentEntityParameterSet)]
        [Parameter(Position = 1, ValueFromPipeline = true, ParameterSetName = TestRequriedSolutionComponentEntityParameterSet)]
        [ValidateNotNull]
        public Entity SolutionComponent { get; set; }

        [Parameter(Position = 1, ValueFromPipeline = true, ParameterSetName = TestDeleteSolutionComponentParameterSet)]
        [Parameter(Position = 1, ValueFromPipeline = true, ParameterSetName = TestDependenciesSolutionComponentParameterSet)]
        [Parameter(Position = 1, ValueFromPipeline = true, ParameterSetName = TestRequriedSolutionComponentParameterSet)]
        [ValidateNotNull]
        public Guid ObjectId { get; set; }

        [Parameter(Position = 2, ParameterSetName = TestDeleteSolutionComponentParameterSet)]
        [Parameter(Position = 2, ParameterSetName = TestDependenciesSolutionComponentParameterSet)]
        [Parameter(Position = 2, ParameterSetName = TestRequriedSolutionComponentParameterSet)]
        [ValidateNotNull]
        public int ComponentType { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = TestDeleteSolutionComponentParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = TestDeleteSolutionComponentEntityParameterSet)]
        public SwitchParameter Delete { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = TestDependenciesSolutionComponentParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = TestDependenciesSolutionComponentEntityParameterSet)]
        public SwitchParameter Dependencies { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = TestRequriedSolutionComponentParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = TestRequriedSolutionComponentEntityParameterSet)]
        public SwitchParameter Required { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Guid objectId = ObjectId;
            int componentType = ComponentType;

            switch (ParameterSetName)
            {
                case TestDeleteSolutionComponentEntityParameterSet:
                case TestDependenciesSolutionComponentEntityParameterSet:
                case TestRequriedSolutionComponentEntityParameterSet:
                    objectId = SolutionComponent.GetAttributeValue<Guid>("objectid");
                    componentType = SolutionComponent.GetAttributeValue<OptionSetValue>("componenttype").Value;
                break;
            }

            switch (ParameterSetName)
            {
                case TestDeleteSolutionComponentEntityParameterSet:
                case TestDeleteSolutionComponentParameterSet:
                    ExecuteTestDelete(componentType, objectId);
                    break;
                case TestDependenciesSolutionComponentEntityParameterSet:
                case TestDependenciesSolutionComponentParameterSet:
                    ExecuteTestDependencies(componentType, objectId);
                    break;
                case TestRequriedSolutionComponentEntityParameterSet:
                case TestRequriedSolutionComponentParameterSet:
                    ExecuteTestRequired(componentType, objectId);
                    break;
                default:
                    break;
            }
        }

        private void ExecuteTestDelete(int componentType, Guid objectId)
        {
            OrganizationResponse response = _repository.Execute("RetrieveDependenciesForDelete", new Hashtable() {
                { "ComponentType", componentType},
                { "ObjectId", objectId}
            });

            EntityCollection collection = (EntityCollection)response["EntityCollection"];
            WriteObject(collection.Entities, true);
        }

        private void ExecuteTestDependencies(int componentType, Guid objectId)
        {
            OrganizationResponse response = _repository.Execute("RetrieveDependentComponents", new Hashtable() {
                { "ComponentType", componentType},
                { "ObjectId", objectId}
            });

            EntityCollection collection = (EntityCollection)response["EntityCollection"];
            WriteObject(collection.Entities, true);
        }

        private void ExecuteTestRequired(int componentType, Guid objectId)
        {
            OrganizationResponse response = _repository.Execute("RetrieveRequiredComponents", new Hashtable() {
                { "ComponentType", componentType},
                { "ObjectId", objectId}
            });

            EntityCollection collection = (EntityCollection)response["EntityCollection"];
            WriteObject(collection.Entities, true);
        }        
    }
}
