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
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Commands.Customizations
{
    [Cmdlet(VerbsData.Import, "Solution", HelpUri = HelpUrlConstants.ImportSolutionHelpUrl, SupportsShouldProcess = true, DefaultParameterSetName = ImportSolutionFromPathParameterSet)]
    [OutputType(typeof(Entity))]
    public sealed class ImportSolutionCommand : CrmOrganizationActionCmdlet
    {
        private const string ImportSolutionFromLiteralPathParameterSet = "ImportSolutionFromLiteralPath";
        private const string ImportSolutionFromPathParameterSet = "ImportSolutionFromPath";

        private ContentRepository _repository = new ContentRepository();

        private string[] _paths;
        private bool _shouldExpandWildcards;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ImportSolutionFromLiteralPathParameterSet)]
        [Alias("PSPath")]
        [ValidateNotNullOrEmpty]
        public string[] LiteralPath
        {
            get { return _paths; }
            set { _paths = value; }
        }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ImportSolutionFromPathParameterSet)]
        [ValidateNotNullOrEmpty]
        public string[] Path
        {
            get { return _paths; }
            set
            {
                _shouldExpandWildcards = true;
                _paths = value;
            }
        }

        [Parameter]
        public SwitchParameter ConvertToManaged { get; set; }

        [Parameter]
        public SwitchParameter Overwrite { get; set; }

        [Parameter]
        public SwitchParameter PublishWorkflows { get; set; }

        [Parameter]
        public SwitchParameter SkipDependencies { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            foreach (string fullPath in ResolvePaths(_paths, _shouldExpandWildcards))
            {
                byte[] content = File.ReadAllBytes(fullPath);

                ExecuteAction(fullPath, delegate
                {
                    Guid importjobid = Guid.NewGuid();
                    _repository.Execute("ImportSolution", new Hashtable() {
                        { "CustomizationFile", content },
                        { "ImportJobId", importjobid },
                        { "ConvertToManaged", ConvertToManaged.ToBool() },
                        { "OverwriteUnmanagedCustomizations", Overwrite.ToBool() },
                        { "PublishWorkflows", PublishWorkflows.ToBool() },
                        { "SkipProductUpdateDependencies", SkipDependencies.ToBool() }
                    });

                    WriteObject(_repository.Get("importjob", importjobid));
                });
            }
        }
    }
}
