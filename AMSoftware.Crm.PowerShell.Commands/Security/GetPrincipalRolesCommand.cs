﻿/*
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
using System.Linq;
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Helpers;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using System.Collections.Generic;

namespace AMSoftware.Crm.PowerShell.Commands.Security
{
    [Cmdlet(VerbsCommon.Get, "CrmPrincipalRoles", HelpUri = HelpUrlConstants.GetPrincipalRolesHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class GetPrincipalRolesCommand : CrmOrganizationCmdlet
    {
        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [Alias("Id")]
        [ValidateNotNull]
        public Guid[] Principal { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            foreach (Guid id in Principal)
            {
                IEnumerable<Entity> teamRoles = SecurityManagementHelper.GetRolesForPrincipal(_repository, CrmPrincipalType.Team, id);
                WriteObject(teamRoles, true);

                IEnumerable<Entity> userRoles = SecurityManagementHelper.GetRolesForPrincipal(_repository, CrmPrincipalType.User, id);
                WriteObject(userRoles, true);
            }
        }
    }
}
