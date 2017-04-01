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
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Helpers;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Commands.Customizations
{
    [Cmdlet(VerbsCommon.Add, "SolutionComponent", HelpUri = HelpUrlConstants.AddSolutionComponentHelpUrl)]
    public class AddSolutionComponentCommand : CrmOrganizationCmdlet, IDynamicParameters
    {
        private const string AddSolutionComponentSimpleParameterSet = "AddSolutionComponentSimple";
        private const string AddSolutionComponentAdvancedParameterSet = "AddSolutionComponentAdvanced";

        private ContentRepository _repository = new ContentRepository();
        private AddSolutionComponentDynamicParameters _context;

        private Dictionary<int, string> _validComponentTypes;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNull]
        public Guid Solution { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = AddSolutionComponentSimpleParameterSet)]
        [ValidateNotNull]
        public CrmComponentType Type { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = AddSolutionComponentAdvancedParameterSet)]
        [ValidateNotNull]
        public int ComponentType { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        public Guid ComponentId { get; set; }

        [Parameter]
        public SwitchParameter IncludeRequired { get; set; }

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

            switch (this.ParameterSetName)
            {
                case AddSolutionComponentSimpleParameterSet:
                    componentTypeValue = (int)Type;
                    break;
                case AddSolutionComponentAdvancedParameterSet:
                    componentTypeValue = ComponentType;
                    break;
                default:
                    break;
            }

            if (!_validComponentTypes.ContainsKey(componentTypeValue))
            {
                throw new NotSupportedException(string.Format("ComponentType '{0}' is not supported.", componentTypeValue));
            }
            
            OrganizationRequest request = new OrganizationRequest("AddSolutionComponent");
            request.Parameters = new ParameterCollection() {
                { "SolutionUniqueName", solutionUniqueName },
                {"ComponentType", componentTypeValue },
                {"ComponentId", ComponentId },
                {"AddRequiredComponents", IncludeRequired.ToBool() }
            };

            if (_context != null)
            {
                _context.SetParametersOnRequest(request);
            }

            OrganizationResponse response = _repository.Execute(request); // id
        }

        public object GetDynamicParameters()
        {
            if (CrmVersionManager.IsSupported(CrmVersion.CRM2016_RTM))
            {
                _context = new AddSolutionComponentDynamicParameters2016();
            }

            return _context;
        }
    }

    public abstract class AddSolutionComponentDynamicParameters
    {
        internal protected virtual void SetParametersOnRequest(OrganizationRequest request)
        {
        }
    }

    public class AddSolutionComponentDynamicParameters2016 : AddSolutionComponentDynamicParameters
    {
        [Parameter]
        public SwitchParameter ExcludeSubComponents { get; set; }

        [Parameter]
        public SwitchParameter ExcludeMetadata { get; set; }

        protected internal override void SetParametersOnRequest(OrganizationRequest request)
        {
            base.SetParametersOnRequest(request);

            request.Parameters.Add("DoNotIncludeSubcomponents", ExcludeSubComponents.ToBool());
            request.Parameters.Add("IncludedComponentSettingsValues", !ExcludeMetadata.ToBool());
        }
    }
}
