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
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common;

namespace AMSoftware.Crm.PowerShell.Commands
{
    [Cmdlet(VerbsOther.Use, "CrmLanguage", HelpUri = HelpUrlConstants.UseLanguageHelpUrl)]
    public sealed class UseLanguageCommand : CrmOrganizationCmdlet
    {
        [Parameter(Position = 1, ValueFromPipeline = true)]
        [ValidateNotNull]
        public int Language { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Language)))
            {
                CrmContext.Session.Language = Language;
            }
            else
            {
                CrmContext.Session.Language = 0;
            }
        }
    }
}
