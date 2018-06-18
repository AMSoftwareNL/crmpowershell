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
    [Cmdlet(VerbsCommon.Set, "CrmServiceEndpoint", HelpUri = HelpUrlConstants.SetServiceEndpointHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class SetServiceEndpointCommand : CrmOrganizationCmdlet
    {
        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Guid Id { get; set; }
        
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter]
        [ValidateNotNull]
        public string Description { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Namespace { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter]
        [ValidateNotNull]
        public CrmServiceEndpointContract? Contract { get; set; }

        [Parameter]
        [ValidateNotNull]
        public CrmServiceEndpointUserClaim? Claim { get; set; }

        [Parameter]
        public SwitchParameter Federated {get;set;}

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Entity crmServiceEndpoint = _repository.Get("serviceendpoint", Id);

            Contract = Contract ?? (CrmServiceEndpointContract)crmServiceEndpoint.GetAttributeValue<OptionSetValue>("contract").Value;
            Claim = Claim ?? (CrmServiceEndpointUserClaim)crmServiceEndpoint.GetAttributeValue<OptionSetValue>("userclaim").Value;
            Federated = Federated.IsPresent ? Federated : new SwitchParameter(crmServiceEndpoint.GetAttributeValue<OptionSetValue>("connectionmode").Value == (int)CrmServiceEndpointConnectionMode.Federated);
                        
            if (Contract == CrmServiceEndpointContract.Rest && Federated.ToBool() == true)
            {
                throw new Exception("Federated mode not suppored for REST contract.");
            }

            if (!string.IsNullOrWhiteSpace(Name))
            {
                ValidateNameUnique(_repository, Id, Name);
            }

            if (!string.IsNullOrWhiteSpace(Name))
            {
                if (crmServiceEndpoint.Contains("name")) crmServiceEndpoint.Attributes["name"] = Name;
                else crmServiceEndpoint.Attributes.Add("name", Name);
            }
            if (!string.IsNullOrWhiteSpace(Namespace))
            {
                if (crmServiceEndpoint.Contains("solutionnamespace")) crmServiceEndpoint.Attributes["solutionnamespace"] = Namespace;
                else crmServiceEndpoint.Attributes.Add("solutionnamespace", Namespace);
            }
            if (!string.IsNullOrWhiteSpace(Path))
            {
                if (crmServiceEndpoint.Contains("path")) crmServiceEndpoint.Attributes["path"] = Path;
                else crmServiceEndpoint.Attributes.Add("path", Path);
            }
            if (Description != null)
            {
                string description = string.IsNullOrWhiteSpace(Description) ? null : Description;
                if (crmServiceEndpoint.Contains("description")) crmServiceEndpoint.Attributes["description"] = description;
                else crmServiceEndpoint.Attributes.Add("description", description);
            }
            
            
            crmServiceEndpoint.Attributes["contract"] = new OptionSetValue((int)Contract);
            crmServiceEndpoint.Attributes["userclaim"] = new OptionSetValue((int)Claim);
            if (Federated.ToBool() == true)
            {
                crmServiceEndpoint.Attributes["connectionmode"] = new OptionSetValue((int)CrmServiceEndpointConnectionMode.Federated);
            }
            else
            {
                crmServiceEndpoint.Attributes["connectionmode"] = new OptionSetValue((int)CrmServiceEndpointConnectionMode.Normal);
            }

            _repository.Update(crmServiceEndpoint);
            if (PassThru)
            {
                WriteObject(_repository.Get("serviceendpoint", Id));
            }
        }

        private static void ValidateNameUnique(ContentRepository repostiory, Guid id, string name)
        {
            QueryExpression query = new QueryExpression("serviceendpoint");
            query.Criteria.AddCondition("name", ConditionOperator.Equal, name);
            query.Criteria.AddCondition("serviceendpointid", ConditionOperator.NotEqual, id);

            IEnumerable<Entity> existing = repostiory.Get(query);
            if (existing.Any())
            {
                throw new Exception("Service Endpoint Name Should be Unique");
            }
        }
    }
}
