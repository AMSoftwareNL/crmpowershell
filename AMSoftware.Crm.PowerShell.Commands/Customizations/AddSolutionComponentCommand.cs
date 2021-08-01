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
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Helpers;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands.Customizations
{
    [Cmdlet(VerbsCommon.Add, "CrmSolutionComponent", HelpUri = HelpUrlConstants.AddSolutionComponentHelpUrl)]
    public sealed class AddSolutionComponentCommand : CrmOrganizationCmdlet
    {
        private readonly ContentRepository _repository = new ContentRepository();

        private Dictionary<int, string> _validComponentTypes;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNull]
        public Guid Solution { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        [ValidateNotNullOrEmpty]
        public string Type { get; set; }

        [Parameter(Mandatory = true, Position = 3)]
        [Alias("ObjectId")]
        [ValidateNotNull]
        public Guid ComponentId { get; set; }

        [Parameter]
        public SwitchParameter IncludeRequired { get; set; }

        [Parameter]
        public SwitchParameter ExcludeSubComponents { get; set; }

        [Parameter]
        public SwitchParameter ExcludeMetadata { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            _validComponentTypes = new Dictionary<int, string>(SolutionManagementHelper.GetComponentTypes());
        }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            string solutionUniqueName = SolutionManagementHelper.GetSolutionUniqueName(_repository, Solution, false);

            int componentTypeValue = 0;
            if (int.TryParse(Type, out int typeAsInt) && _validComponentTypes.ContainsKey(typeAsInt))
            {
                componentTypeValue = typeAsInt;
            }
            else if (_validComponentTypes.Any(v => v.Value.Equals(Type, StringComparison.InvariantCultureIgnoreCase)))
            {
                componentTypeValue = _validComponentTypes.First(v => v.Value.Equals(Type, StringComparison.InvariantCultureIgnoreCase)).Key;
            }
            else
            {
                throw new NotSupportedException(string.Format("ComponentType '{0}' is not supported.", Type));
            }

            OrganizationRequest request = new OrganizationRequest("AddSolutionComponent")
            {
                Parameters = new ParameterCollection() {
                    { "SolutionUniqueName", solutionUniqueName },
                    { "ComponentType", componentTypeValue },
                    { "ComponentId", ComponentId },
                    { "AddRequiredComponents", IncludeRequired.ToBool() },
                    { "DoNotIncludeSubcomponents", ExcludeSubComponents.ToBool() },
                    { "IncludedComponentSettingsValues", ExcludeMetadata.ToBool() ? new string[] { } : null }
                }
            };

            OrganizationResponse response = _repository.Execute(request); // id
        }
    }
}
