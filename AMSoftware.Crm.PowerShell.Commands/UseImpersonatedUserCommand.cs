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
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Repositories;

namespace AMSoftware.Crm.PowerShell.Commands
{
    [Cmdlet(VerbsOther.Use, "CrmImpersonatedUser", HelpUri = HelpUrlConstants.UseImpersonatedUserHelpUrl)]
    public sealed class UseImpersonatedUserCommand : CrmOrganizationCmdlet
    {
        [Parameter(Position = 1, ValueFromPipeline = true)]
        [ValidateNotNull]
        [Alias("UserId")]
        public Guid ImpersonatedUserId { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ImpersonatedUserId == Guid.Empty)
            {
                CrmContext.Session.Client.CallerId = Guid.Empty;
                CrmContext.Session.Client.CallerAADObjectId = null;
            }
            else
            {
                ContentRepository repository = new ContentRepository();
                CrmContext.Session.Client.CallerId = ImpersonatedUserId;
                CrmContext.Session.Client.CallerAADObjectId = repository.Get("systemuser", ImpersonatedUserId).GetAttributeValue<Guid>("azureactivedirectoryobjectid");
            }
        }
    }
}
