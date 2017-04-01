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
using System.Collections;
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Commands.Content
{
    [Cmdlet(VerbsCommon.Set, "Content", HelpUri = HelpUrlConstants.SetContentHelpUrl, DefaultParameterSetName = SetContentByInputObjectParameterSet)]
    public class SetContentCommand : CrmOrganizationCmdlet
    {
        private const string SetContentParameterSet = "SetContent";
        private const string SetContentByInputObjectParameterSet = "SetContentByInputObject";

        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = SetContentByInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public Entity Record { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = SetContentParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Entity { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true, ParameterSetName = SetContentParameterSet)]
        public Guid Id { get; set; }

        [Parameter(Mandatory = true, Position = 3, ParameterSetName = SetContentParameterSet)]
        [ValidateNotNull]
        public Hashtable Attributes { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case SetContentParameterSet:
                    _repository.Update(Entity, Id, Attributes);
                    break;
                case SetContentByInputObjectParameterSet:
                    _repository.Update(Record);
                    break;
                default:
                    break;
            }
        }
    }
}
