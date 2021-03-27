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
using AMSoftware.Crm.PowerShell.Common.ArgumentCompleters;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk.Metadata;

namespace AMSoftware.Crm.PowerShell.Commands.Metadata
{
    [Cmdlet(VerbsCommon.Set, "CrmOptionSetValue", HelpUri = HelpUrlConstants.SetOptionSetValueHelpUrl, DefaultParameterSetName = SetOptionSetValueGlobalParameterSet)]
    public sealed class SetOptionSetValueCommand : CrmOrganizationCmdlet
    {
        private const string SetOptionSetValueGlobalParameterSet = "SetOptionSetValueGlobal";
        private const string SetOptionSetValueEntityParameterSet = "SetOptionSetValueEntity";

        private readonly MetadataRepository _repository = new MetadataRepository();

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = SetOptionSetValueGlobalParameterSet,ValueFromPipelineByPropertyName = true)]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(OptionSetArgumentCompleter))]
        public string OptionSet { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = SetOptionSetValueEntityParameterSet, ValueFromPipelineByPropertyName = true)]
        [Alias("EntityLogicalName")]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string Entity { get; set; }

        [Parameter(Position = 2, Mandatory = true, ParameterSetName = SetOptionSetValueEntityParameterSet, ValueFromPipelineByPropertyName = true)]
        [Alias("LogicalName")]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(AttributeArgumentCompleter))]
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
            OptionSetMetadataBase optionSet = _repository.GetOptionSet(OptionSet);
            // Can be new or update
            if (IsNewOptionSetValue(optionSet, Value))
            {
                _repository.AddOptionSetValue(OptionSet, DisplayName, Value, Description);
            }
            else
            {
                _repository.UpdateOptionSetValue(OptionSet, Value.Value, DisplayName, Description);
            }
        }

        private void UpdateEntityOptionSet()
        {
            AttributeMetadata attribute = _repository.GetAttribute(Entity, Attribute);

            // Can be new or update
            OptionSetMetadataBase attributeOptionSet = null;
            if (attribute is BooleanAttributeMetadata booleanAttribute)
            {
                attributeOptionSet = booleanAttribute.OptionSet;
            } else if (attribute is PicklistAttributeMetadata picklistAttribute)
            {
                attributeOptionSet = picklistAttribute.OptionSet;
            }

            if (IsNewOptionSetValue(attributeOptionSet, Value))
            {
                _repository.AddOptionSetValue(Entity, Attribute, DisplayName, Value, Description);
            }
            else
            {
                _repository.UpdateOptionSetValue(Entity, Attribute, Value.Value, DisplayName, Description);
            }
        }

        private static bool IsNewOptionSetValue(OptionSetMetadataBase optionSet, int? lookupValue)
        {
            bool isNew = true;

            if (!lookupValue.HasValue)
            {
                return true;
            }

            if (optionSet is OptionSetMetadata picklistOptionSet)
            {
                if (picklistOptionSet.Options.Any(o => o.Value.Value.Equals(lookupValue.Value)))
                {
                    // Existing; Do update
                    isNew = false;
                }
            }
            else if (optionSet is BooleanOptionSetMetadata booleanOptionSet)
            {
                if (booleanOptionSet.TrueOption.Value.Equals(lookupValue.Value) || booleanOptionSet.FalseOption.Value.Equals(lookupValue.Value))
                {
                    // Existing; Do update
                    isNew = false;
                }
            }

            return isNew;
        }
    }
}
