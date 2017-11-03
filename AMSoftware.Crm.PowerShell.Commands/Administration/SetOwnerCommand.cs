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
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Commands.Administration
{
    [Cmdlet(VerbsCommon.Set, "Owner", HelpUri = HelpUrlConstants.SetOwnerHelpUrl, DefaultParameterSetName = AssignOwnerRecordParameterSet)]
    public sealed class SetOwnerCommand : CrmOrganizationCmdlet
    {
        private const string AssignOwnerRecordParameterSet = "AssignOwnerRecord";
        private const string ReassignOwnerParameterSet = "ReassignOwner";

        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = AssignOwnerRecordParameterSet, ValueFromPipelineByPropertyName = true)]
        [Alias("LogicalName")]
        [ValidateNotNullOrEmpty]
        public string Entity { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = AssignOwnerRecordParameterSet, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Guid Id { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ReassignOwnerParameterSet)]
        [ValidateNotNull]
        public CrmPrincipalType FromPrincipalType { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = ReassignOwnerParameterSet)]
        [ValidateNotNull]
        public Guid FromPrincipalId { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        public CrmPrincipalType ToPrincipalType { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        public Guid ToPrincipalId { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case AssignOwnerRecordParameterSet:
                    AssignOwner(
                        GetPrincipalReference(ToPrincipalType, ToPrincipalId),
                        new EntityReference(Entity, Id)
                    );
                    break;
                case ReassignOwnerParameterSet:
                    ReassignOwner(
                        GetPrincipalReference(FromPrincipalType, FromPrincipalId),
                        GetPrincipalReference(ToPrincipalType, ToPrincipalId)
                    );
                    break;
                default:
                    break;
            }
        }

        private void AssignOwner(EntityReference owner, EntityReference record)
        {
            OrganizationRequest request = new OrganizationRequest("Assign")
            {
                Parameters = new ParameterCollection()
            };
            request.Parameters["Assignee"] = owner;
            request.Parameters["Target"] = record;

            _repository.Execute(request);
        }

        private void ReassignOwner(EntityReference fromPrincipal, EntityReference toPrincipal)
        {
            OrganizationRequest request = new OrganizationRequest("ReassignObjectsOwner")
            {
                Parameters = new ParameterCollection()
            };
            request.Parameters["FromPrincipal"] = fromPrincipal;
            request.Parameters["ToPrincipal"] = toPrincipal;

            _repository.Execute(request);
        }

        private EntityReference GetPrincipalReference(CrmPrincipalType type, Guid id)
        {
            string logicalName = null;
            switch (type)
            {
                case CrmPrincipalType.User:
                    logicalName = "systemuser";
                    break;
                case CrmPrincipalType.Team:
                    logicalName = "team";
                    break;
                default:
                    break;
            }

            return new EntityReference(logicalName, id);
        }
    }
}
