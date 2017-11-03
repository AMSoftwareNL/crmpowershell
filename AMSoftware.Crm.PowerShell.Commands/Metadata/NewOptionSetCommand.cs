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
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Commands.Models;
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace AMSoftware.Crm.PowerShell.Commands.Metadata
{
    [Cmdlet(VerbsCommon.New, "OptionSet", HelpUri = HelpUrlConstants.NewOptionSetHelpUrl, DefaultParameterSetName = NewOptionSetByInputObjectParameterSet)]
    [OutputType(typeof(OptionSetMetadata))]
    public sealed class NewOptionSetCommand : CrmOrganizationCmdlet
    {
        private const string NewOptionSetParameterSet = "NewOptionSet";
        private const string NewOptionSetByInputObjectParameterSet = "NewOptionSetByInputObject";

        private MetadataRepository _repository = new MetadataRepository();

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = NewOptionSetByInputObjectParameterSet, ValueFromPipeline = true)]
        [Alias("OptionSet")]
        [ValidateNotNull]
        public OptionSetMetadata InputObject { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = NewOptionSetParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 2, Mandatory = true, ParameterSetName = NewOptionSetParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NewOptionSetParameterSet, ValueFromRemainingArguments = true)]
        [ValidateNotNull]
        public PSOptionSetValue[] Values { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NewOptionSetParameterSet)]
        [ValidateNotNull]
        public string Description { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NewOptionSetParameterSet)]
        [ValidateNotNull]
        public bool? Customizable { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case NewOptionSetParameterSet:
                    OptionSetMetadata internalOptionset = BuildOptionSet();
                    Guid id1 = _repository.AddOptionSet(internalOptionset);
                    if (PassThru)
                    {
                        WriteObject(_repository.GetOptionSet(id1));
                    }
                    break;
                case NewOptionSetByInputObjectParameterSet:
                    Guid id2 = _repository.AddOptionSet(InputObject);
                    if (PassThru)
                    {
                        WriteObject(_repository.GetOptionSet(id2));
                    }
                    break;
                default:
                    break;
            }
        }

        private OptionSetMetadata BuildOptionSet()
        {
            OptionSetMetadata optionset = new OptionSetMetadata()
            {
                Name = Name,
                DisplayName = new Label(DisplayName, CrmContext.Language),
                Description = new Label(Description ?? string.Empty, CrmContext.Language),
                OptionSetType = OptionSetType.Picklist
            };
            if (Customizable.HasValue) optionset.IsCustomizable = new BooleanManagedProperty(Customizable.Value);

            foreach (var item in Values)
            {
                OptionMetadata option = new OptionMetadata(new Label(item.DisplayName, CrmContext.Language), item.Value)
                {
                    Description = new Label(item.Description ?? string.Empty, CrmContext.Language)
                };
                optionset.Options.Add(option);
            }
            return optionset;
        }
    }
}
