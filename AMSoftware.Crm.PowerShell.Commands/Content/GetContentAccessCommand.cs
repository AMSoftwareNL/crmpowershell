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
using AMSoftware.Crm.PowerShell.Common.ArgumentCompleters;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using System;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands.Content
{
    [Cmdlet(VerbsCommon.Get, "CrmContentAccess", HelpUri = HelpUrlConstants.GetContentAccessHelpUrl, DefaultParameterSetName = GetContentAccessByInputObjectParameterSet)]
    [OutputType(typeof(PrincipalAccess))]
    public sealed class GetContentAccessCommand : CrmOrganizationCmdlet
    {
        private const string GetContentAccessParameterSet = "GetContentAccess";
        private const string GetContentAccessByInputObjectParameterSet = "GetContentAccessByInputObject";

        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = GetContentAccessByInputObjectParameterSet, ValueFromPipeline = true)]
        [Alias("Record")]
        [ValidateNotNullOrEmpty]
        public Entity InputObject { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = GetContentAccessParameterSet)]
        [Alias("LogicalName")]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        [ValidateNotNullOrEmpty]
        public string Entity { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = GetContentAccessParameterSet)]
        [ValidateNotNullOrEmpty]
        public Guid Id { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            EntityReference target = null;

            switch (this.ParameterSetName)
            {
                case GetContentAccessParameterSet:
                    target = new EntityReference(Entity, Id);
                    break;
                case GetContentAccessByInputObjectParameterSet:
                    target = InputObject.ToEntityReference();
                    break;
                default:
                    break;
            }

            OrganizationResponse response = _repository.Execute("RetrieveSharedPrincipalsAndAccess", new System.Collections.Hashtable() {
                { "Target", target }
            });

            if (response != null && response.Results != null && response.Results.ContainsKey("PrincipalAccesses") && response["PrincipalAccesses"] != null)
            {
                PrincipalAccess[] principalAccesses = (PrincipalAccess[])response["PrincipalAccesses"];

                foreach (var principalAccess in principalAccesses)
                {
                    var o = new PSObject(principalAccess);
                    o.Properties.Add(new PSNoteProperty("RecordLogicalName", target.LogicalName));
                    o.Properties.Add(new PSNoteProperty("RecordId", target.Id));
                    o.Properties.Add(new PSNoteProperty("PrincipalLogicalName", principalAccess.Principal.LogicalName));
                    o.Properties.Add(new PSNoteProperty("PrincipalId", principalAccess.Principal.Id));
                    o.Properties.Add(new PSNoteProperty("AccessRight", (CrmAccessRight)principalAccess.AccessMask));

                    o.Properties.Remove("ExtensionData");
                    o.Properties.Remove("AccessMask");
                    o.Properties.Remove("Principal");

                    WriteObject(o, false);
                }
            }
        }
    }
}
