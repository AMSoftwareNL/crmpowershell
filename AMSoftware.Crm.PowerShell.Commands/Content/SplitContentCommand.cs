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
using AMSoftware.Crm.PowerShell.Common.Repositories;

namespace AMSoftware.Crm.PowerShell.Commands.Content
{
    [Cmdlet(VerbsCommon.Split, "Content", HelpUri = HelpUrlConstants.SplitContentHelpUrl)]
    public sealed class SplitContentCommand : CrmOrganizationCmdlet
    {
        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateNotNullOrEmpty]
        public string Entity { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        public Guid Id { get; set; }

        [Parameter(Mandatory = true, Position = 3)]
        [ValidateNotNullOrEmpty]
        public string FromEntity { get; set; }

        [Parameter(Mandatory = true, Position = 4)]
        public Guid FromId { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Attribute { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            _repository.Disassociate(Entity, Id, FromEntity, FromId, Attribute);
        }
    }
}
