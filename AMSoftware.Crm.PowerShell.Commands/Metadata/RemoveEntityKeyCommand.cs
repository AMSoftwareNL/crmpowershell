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
    [Cmdlet(VerbsCommon.Remove, "EntityKey", HelpUri = HelpUrlConstants.RemoveEntityKeyHelpUrl, SupportsShouldProcess = true)]
    public sealed class RemoveEntityKeyCommand : CrmOrganizationConfirmActionCmdlet
    {
        private MetadataRepository _repository = new MetadataRepository();

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Alias("EntityLogicalName")]
        [ValidateNotNullOrEmpty]
        public string Entity { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Alias("LogicalName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteAction(string.Format("{0}: {1}", Entity, Name), delegate
            {
                _repository.DeleteEntityKey(Entity, Name);
            });
        }
    }
}
