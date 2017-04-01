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
using System.Linq;
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk.Metadata;

namespace AMSoftware.Crm.PowerShell.Commands.Metadata
{
    [Cmdlet(VerbsCommon.Get, "OptionSet", HelpUri = HelpUrlConstants.GetOptionSetHelpUrl, DefaultParameterSetName = GetOptionSetByFilterParameterSet)]
    [OutputType(typeof(OptionSetMetadataBase))]
    public class GetOptionSetCommand : CrmOrganizationCmdlet
    {
        private const string GetOptionSetByNameParameterSet = "GetOptionSetByName";
        private const string GetOptionSetByIdParameterSet = "GetOptionSetById";
        private const string GetOptionSetByFilterParameterSet = "GetOptionSetByFilter";

        private MetadataRepository _repository = new MetadataRepository();

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = GetOptionSetByIdParameterSet)]
        [ValidateNotNull]
        public Guid Id { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = GetOptionSetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = GetOptionSetByFilterParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Include { get; set; }

        [Parameter(ParameterSetName = GetOptionSetByFilterParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Exclude { get; set; }

        [Parameter(ParameterSetName = GetOptionSetByFilterParameterSet)]
        public SwitchParameter CustomOnly { get; set; }

        [Parameter(ParameterSetName = GetOptionSetByFilterParameterSet)]
        public SwitchParameter ExcludeManaged { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case GetOptionSetByNameParameterSet:
                    WriteObject(_repository.GetOptionSet(Name));
                    break;
                case GetOptionSetByIdParameterSet:
                    WriteObject(_repository.GetOptionSet(Id));
                    break;
                case GetOptionSetByFilterParameterSet:
                    IEnumerable<OptionSetMetadataBase> result = _repository.GetOptionSet(CustomOnly.ToBool(), ExcludeManaged.ToBool());
                    if (!string.IsNullOrWhiteSpace(Include))
                    {
                        WildcardPattern includePattern = new WildcardPattern(Include, WildcardOptions.IgnoreCase);
                        result = result.Where(o => includePattern.IsMatch(o.Name));
                    }
                    if (!string.IsNullOrWhiteSpace(Exclude))
                    {
                        WildcardPattern excludePattern = new WildcardPattern(Exclude, WildcardOptions.IgnoreCase);
                        result = result.Where(o => !excludePattern.IsMatch(o.Name));
                    }

                    WriteObject(result, true);

                    break;
                default:
                    break;
            }
        }
    }
}
