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
using AMSoftware.Crm.PowerShell.Common.Repositories;

namespace AMSoftware.Crm.PowerShell.Commands.Metadata
{
    [Cmdlet(VerbsCommon.Remove, "OptionSetValue", HelpUri = HelpUrlConstants.RemoveOptionSetValueHelpUrl, SupportsShouldProcess = true, DefaultParameterSetName = RemoveOptionSetValueGlobalParameterSet)]
    public class RemoveOptionSetValueCommand : CrmOrganizationConfirmActionCmdlet
    {
        private const string RemoveOptionSetValueGlobalParameterSet = "RemoveOptionSetValueGlobal";
        private const string RemoveOptionSetValueEntityParameterSet = "RemoveOptionSetValueEntity";

        private MetadataRepository _repository = new MetadataRepository();

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = RemoveOptionSetValueGlobalParameterSet)]
        [ValidateNotNullOrEmpty]
        public string OptionSet { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = RemoveOptionSetValueEntityParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Entity { get; set; }

        [Parameter(Position = 2, Mandatory = true, ParameterSetName = RemoveOptionSetValueEntityParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Attribute { get; set; }

        [Parameter(Position = 2, Mandatory = true, ParameterSetName = RemoveOptionSetValueGlobalParameterSet)]
        [Parameter(Position = 3, Mandatory = true, ParameterSetName = RemoveOptionSetValueEntityParameterSet)]
        public int Value { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case RemoveOptionSetValueGlobalParameterSet:
                    ExecuteAction(OptionSet, delegate
                    {
                        _repository.DeleteOptionSetValue(OptionSet, Value);
                    });
                    break;
                case RemoveOptionSetValueEntityParameterSet:
                    ExecuteAction(string.Format("{0}: {1}", Entity, Attribute), delegate
                    {
                        _repository.DeleteOptionSetValue(Entity, Attribute, Value);
                    });
                    break;
                default:
                    break;
            }
        }
    }
}
