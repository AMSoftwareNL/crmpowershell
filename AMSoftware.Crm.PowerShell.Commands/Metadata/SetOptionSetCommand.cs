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
    [Cmdlet(VerbsCommon.Set, "OptionSet", HelpUri = HelpUrlConstants.SetOptionSetHelpUrl)]
    public sealed class SetOptionSetCommand : CrmOrganizationCmdlet
    {
        private const string SetOptionSetParameterSet = "SetOptionSet";
        private const string SetOptionSetByInputObjectParameterSet = "SetOptionSetByInputObject";

        private MetadataRepository _repository = new MetadataRepository();

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = SetOptionSetByInputObjectParameterSet)]
        [ValidateNotNull]
        public OptionSetMetadata OptionSet { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = SetOptionSetParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = SetOptionSetParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(ParameterSetName = SetOptionSetParameterSet)]
        [ValidateNotNull]
        public string Description { get; set; }

        [Parameter(ParameterSetName = SetOptionSetParameterSet)]
        [ValidateNotNull]
        public bool? Customizable { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case SetOptionSetParameterSet:
                    if (DisplayName != null || Description != null || Customizable.HasValue)
                    {
                        OptionSetMetadataBase internalOptionSet = BuildOptionSet();
                        _repository.UpdateOptionSet(internalOptionSet);
                    }
                    break;
                case SetOptionSetByInputObjectParameterSet:
                    _repository.UpdateOptionSet(OptionSet);
                    break;
                default:
                    break;
            }
        }

        private OptionSetMetadataBase BuildOptionSet()
        {
            // There is something to update;
            OptionSetMetadataBase optionSet = _repository.GetOptionSet(Name);
            if (DisplayName != null) optionSet.DisplayName = new Label(DisplayName, CrmContext.Language);
            if (Description != null) optionSet.Description = new Label(Description ?? string.Empty, CrmContext.Language);
            if (Customizable.HasValue) optionSet.IsCustomizable = new BooleanManagedProperty(Customizable.Value);
            return optionSet;
        }
    }
}
