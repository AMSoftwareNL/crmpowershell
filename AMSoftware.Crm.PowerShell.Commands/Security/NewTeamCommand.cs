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
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Helpers;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using System;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands.Security
{
    [Cmdlet(VerbsCommon.New, "CrmTeam", HelpUri = HelpUrlConstants.NewTeamHelpUrl, DefaultParameterSetName = NewTeamParameterSet)]
    [OutputType(typeof(Entity))]
    public sealed class NewTeamCommand : CrmOrganizationCmdlet
    {
        private const string NewTeamParameterSet = "NewTeam";
        private const string NewAADTeamParameterSet = "NewAADTeam";

        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateNotNullOrEmpty]
        public CrmTeamType TeamType { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        [ValidateNotNullOrEmpty]
        public Guid Administrator { get; set; }

        [Parameter(ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Guid BusinessUnit { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(ParameterSetName = NewAADTeamParameterSet)]
        [ValidateNotNullOrEmpty]
        [PSDefaultValue(Value = CrmTeamMembershipType.MembersGuests)]
        public CrmTeamMembershipType MembershipType { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NewAADTeamParameterSet)]
        [ValidateNotNullOrEmpty]
        public Guid AADObjectId { get; set; }

        [Parameter(ValueFromRemainingArguments = true, ParameterSetName = NewTeamParameterSet)]
        [ValidateNotNull]
        public Guid[] Users { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Guid businessUnitId = this.MyInvocation.BoundParameters.ContainsKey(nameof(BusinessUnit)) ? BusinessUnit : SecurityManagementHelper.GetDefaultBusinessUnitId(_repository);

            if (!this.MyInvocation.BoundParameters.ContainsKey(nameof(MembershipType))) MembershipType = CrmTeamMembershipType.MembersGuests;

            Entity newTeam = new Entity("team")
            {
                Attributes = new AttributeCollection()
            };
            newTeam.Attributes.Add("name", Name);
            newTeam.Attributes.Add("teamtype", new OptionSetValue((int)TeamType));
            newTeam.Attributes.Add("administratorid", new EntityReference("systemuser", Administrator));
            newTeam.Attributes.Add("businessunitid", new EntityReference("businessunit", businessUnitId));
            if (!string.IsNullOrWhiteSpace(Description))
            {
                newTeam.Attributes.Add("description", Description);
            }

            if (this.ParameterSetName == NewTeamParameterSet)
            {
                if (TeamType != CrmTeamType.Owner && TeamType != CrmTeamType.Access)
                    throw new ParameterBindingException("Invalid Team Type. Only Owner Team or Access Team allowed");

                newTeam.Attributes.Add("membershiptype", new OptionSetValue((int)CrmTeamMembershipType.MembersGuests));
            }

            if (this.ParameterSetName == NewAADTeamParameterSet)
            {
                if (TeamType != CrmTeamType.AADOfficeGroup && TeamType != CrmTeamType.AADSecurityGroup)
                    throw new ParameterBindingException("Invalid Team Type. Only AAD Office Group or AAD Security Group allowed");

                newTeam.Attributes.Add("azureactivedirectoryobjectid", AADObjectId);
                newTeam.Attributes.Add("membershiptype", new OptionSetValue((int)MembershipType));
            }

            Guid newTeamId = _repository.Add(newTeam);

            if (this.ParameterSetName == NewTeamParameterSet && Users != null && Users.Length != 0)
            {
                SecurityManagementHelper.AddUsersToTeam(_repository, newTeamId, Users);
            }

            if (PassThru)
            {
                WriteObject(_repository.Get("team", newTeamId));
            }
        }
    }
}
