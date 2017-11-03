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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace AMSoftware.Crm.PowerShell.Commands.Plugins
{
    [Cmdlet(VerbsLifecycle.Register, "ServiceEndpoint", HelpUri = HelpUrlConstants.RegisterServiceEndpointHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class RegisterServiceEndpointCommand : CrmOrganizationCmdlet
    {
        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        public CrmServiceEndpointContract Contract { get; set; }

        [Parameter]
        [ValidateNotNull]
        public CrmServiceEndpointUserClaim Claim { get; set; }

        [Parameter]
        public SwitchParameter Federated {get;set;}

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if ((int)Claim == 0) Claim = CrmServiceEndpointUserClaim.None;
            if (Contract == CrmServiceEndpointContract.Rest && Federated.ToBool() == true)
            {
                throw new Exception("Federated mode not suppored for REST contract.");
            }
            ValidateNameUnique(_repository, Name);

            Guid newId = _repository.Add(GenerateCrmEntity());
            if (PassThru)
            {
                WriteObject(_repository.Get("serviceendpoint", newId));
            }
        }

        private static void ValidateNameUnique(ContentRepository repostiory, string name)
        {
            QueryExpression query = new QueryExpression("serviceendpoint");
            query.Criteria.AddCondition("name", ConditionOperator.Equal, name);

            IEnumerable<Entity> existing = repostiory.Get(query);
            if (existing.Any())
            {
                throw new Exception("Service Endpoint Name Should be Unique");
            }
        }

        private Entity GenerateCrmEntity()
        {
            Entity crmServiceEndpoint = new Entity("serviceendpoint")
            {
                Attributes = new AttributeCollection()
            };
            crmServiceEndpoint.Attributes.Add("name", Name);
            crmServiceEndpoint.Attributes.Add("solutionnamespace", Namespace);
            crmServiceEndpoint.Attributes.Add("path", Path);
            crmServiceEndpoint.Attributes.Add("contract", new OptionSetValue((int)Contract));
            crmServiceEndpoint.Attributes.Add("userclaim", new OptionSetValue((int)Claim));
            if (!string.IsNullOrWhiteSpace(Description))
            {
                crmServiceEndpoint.Attributes.Add("description", Description);
            }
            if (Federated.ToBool() == true)
            {
                crmServiceEndpoint.Attributes.Add("connectionmode", new OptionSetValue((int)CrmServiceEndpointConnectionMode.Federated));
            }
            else
            {
                crmServiceEndpoint.Attributes.Add("connectionmode", new OptionSetValue((int)CrmServiceEndpointConnectionMode.Normal));
            }

            return crmServiceEndpoint;
        }
    }
}
