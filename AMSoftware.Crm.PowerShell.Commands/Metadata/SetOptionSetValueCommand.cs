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
using System.Linq;
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk.Metadata;

namespace AMSoftware.Crm.PowerShell.Commands.Metadata
{
    [Cmdlet(VerbsCommon.Set, "OptionSetValue", HelpUri = HelpUrlConstants.SetOptionSetValueHelpUrl, DefaultParameterSetName = SetOptionSetValueGlobalParameterSet)]
    public sealed class SetOptionSetValueCommand : CrmOrganizationCmdlet
    {
        private const string SetOptionSetValueGlobalParameterSet = "SetOptionSetValueGlobal";
        private const string SetOptionSetValueEntityParameterSet = "SetOptionSetValueEntity";

        private MetadataRepository _repository = new MetadataRepository();

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = SetOptionSetValueGlobalParameterSet)]
        [ValidateNotNullOrEmpty]
        public string OptionSet { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = SetOptionSetValueEntityParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Entity { get; set; }

        [Parameter(Position = 2, Mandatory = true, ParameterSetName = SetOptionSetValueEntityParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Attribute { get; set; }

        [Parameter]
        [ValidateNotNull]
        public int? Value { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter]
        [ValidateNotNull]
        public string Description { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case SetOptionSetValueGlobalParameterSet:
                    UpdateGlobalOptionSet();
                    break;
                case SetOptionSetValueEntityParameterSet:
                    UpdateEntityOptionSet();
                    break;
                default:
                    break;
            }
        }

        private void UpdateGlobalOptionSet()
        {
            int? newValue = Value;
            bool isNew = true;

            // Can be new or update
            OptionSetMetadataBase optionSet = _repository.GetOptionSet(OptionSet);
            if (optionSet is OptionSetMetadata)
            {
                OptionSetMetadata localOptionSet = optionSet as OptionSetMetadata;
                if (localOptionSet.Options.Any(o => o.Value.Value.Equals(Value.Value)))
                {
                    // Existing; Do update
                    isNew = false;
                }
            }
            else if (optionSet is BooleanOptionSetMetadata)
            {
                BooleanOptionSetMetadata localOptionSet = optionSet as BooleanOptionSetMetadata;
                if (localOptionSet.TrueOption.Value.Equals(Value.Value) || localOptionSet.FalseOption.Value.Equals(Value.Value))
                {
                    // Existing; Do update
                    isNew = false;
                }
            }

            if (isNew)
            {
                newValue = _repository.AddOptionSetValue(OptionSet, DisplayName, Value, Description);
            }
            else
            {
                _repository.UpdateOptionSetValue(OptionSet, Value.Value, DisplayName, Description);
            }
        }

        private void UpdateEntityOptionSet()
        {
            int? newValue = Value;

            if (!Value.HasValue)
            {
                // Must be new
                newValue = _repository.AddOptionSetValue(Entity, Attribute, DisplayName, Value, Description);
            }
            else
            {
                // Can be new or update
                PicklistAttributeMetadata optionSetAttribute = (PicklistAttributeMetadata)_repository.GetAttribute(Entity, Attribute);

                if (optionSetAttribute.OptionSet.Options.Any(o => o.Value.Value.Equals(Value.Value)))
                {
                    // Existing; Do update
                    _repository.UpdateOptionSetValue(Entity, Attribute, Value.Value, DisplayName, Description);
                }
                else
                {
                    // Not existing; Do new
                    newValue = _repository.AddOptionSetValue(Entity, Attribute, DisplayName, Value, Description);
                }
            }
        }
    }
}
