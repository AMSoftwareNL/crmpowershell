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
using System.IO;
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common.Helpers;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Commands.Customizations
{
    [Cmdlet(VerbsDiagnostic.Test, "Solution", HelpUri = HelpUrlConstants.TestSolutionHelpUrl)]
    public sealed class TestSolutionCommand : CrmOrganizationCmdlet
    {
        private const string TestUninstallSolutionParameterSet = "TestUninstallSolution";
        private const string TestDependenciesSolutionParameterSet = "TestDependenciesSolution";
        private const string TestMissingSolutionParameterSet = "TestMissingSolution";

        private ContentRepository _repository = new ContentRepository();

        [Parameter(Position = 1, ParameterSetName = TestUninstallSolutionParameterSet, ValueFromPipeline = true)]
        [Parameter(Position = 1, ParameterSetName = TestDependenciesSolutionParameterSet, ValueFromPipeline = true)]
        [ValidateNotNull]
        public Guid Solution { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = TestMissingSolutionParameterSet)]
        [Alias("PSPath", "Path")]
        [ValidateNotNullOrEmpty]
        public string LiteralPath { get; set; }

        [Parameter(Mandatory=true, ParameterSetName=TestUninstallSolutionParameterSet)]
        public SwitchParameter Uninstall { get; set; }

        [Parameter(Mandatory=true, ParameterSetName=TestDependenciesSolutionParameterSet)]
        public SwitchParameter Dependencies { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (ParameterSetName)
            {
                case TestUninstallSolutionParameterSet:
                    string solutionUniqueName1 = SolutionManagementHelper.GetSolutionUniqueName(_repository, Solution);
                    ExecuteTestUninstall(solutionUniqueName1);
                    break;
                case TestDependenciesSolutionParameterSet:
                    string solutionUniqueName2 = SolutionManagementHelper.GetSolutionUniqueName(_repository, Solution);
                    ExecuteTestDependencies(solutionUniqueName2);
                    break;
                case TestMissingSolutionParameterSet:
                    byte[] content = File.ReadAllBytes(LiteralPath);
                    ExecuteTestMissing(content);
                    break;
                default:
                    break;
            }
        }

        private void ExecuteTestUninstall(string solutionUniqueName)
        {
            OrganizationResponse response = _repository.Execute("RetrieveDependenciesForUninstall", new Hashtable() {
                { "SolutionUniqueName", solutionUniqueName}
            });

            EntityCollection collection = (EntityCollection)response["EntityCollection"];
            WriteObject(collection.Entities, true);
        }

        private void ExecuteTestDependencies(string solutionUniqueName)
        {
            OrganizationResponse response = _repository.Execute("RetrieveMissingDependencies", new Hashtable() {
                { "SolutionUniqueName", solutionUniqueName}
            });

            EntityCollection collection = (EntityCollection)response["EntityCollection"];
            WriteObject(collection.Entities, true);
        }

        private void ExecuteTestMissing(byte[] solutionFile)
        {
            OrganizationResponse response = _repository.Execute("RetrieveMissingComponents", new Hashtable() {
                { "CustomizationFile", solutionFile}
            });

            MissingComponent[] collection = (MissingComponent[])response["MissingComponents"];
            WriteObject(collection, true);
        }
    }
}
