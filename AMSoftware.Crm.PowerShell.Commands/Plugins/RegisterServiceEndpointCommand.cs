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
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands.Plugins
{
    [Cmdlet(VerbsLifecycle.Register, "CrmServiceEndpoint", HelpUri = HelpUrlConstants.RegisterServiceEndpointHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class RegisterServiceEndpointCommand : CrmOrganizationCmdlet
    {
        private const string RelayEndpointWithTokenParameterSet = "RelayEndpointWithToken";
        private const string QueueEndpointWithTokenParameterSet = "QueueuEndpointWithToken";
        private const string RelayEndpointWithKeyParameterSet = "RelayEndpointWithKey";
        private const string QueueEndpointWithKeyParameterSet = "QueueuEndpointWithKey";

        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public Guid Id { get; set; }

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        [ValidateNotNullOrEmpty]
        [Alias("NamespaceAddress", "Namespace")]
        public string Endpoint { get; set; }

        [Parameter(Mandatory = true, Position = 3)]
        [ValidateNotNullOrEmpty]
        public string EndpointPathOrName { get; set; }

        [Parameter()]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = RelayEndpointWithTokenParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = RelayEndpointWithKeyParameterSet)]
        [ValidateNotNull]
        [ValidateSet("Oneway", "Twoway", "Rest", IgnoreCase = true)]
        public CrmServiceEndpointContract RelayContract { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = QueueEndpointWithTokenParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = QueueEndpointWithKeyParameterSet)]
        [ValidateNotNull]
        [ValidateSet("Queue", "Topic", "Eventhub", IgnoreCase = true)]
        public CrmServiceEndpointContract QueueContract { get; set; }

        [Parameter(ParameterSetName = QueueEndpointWithTokenParameterSet)]
        [Parameter(ParameterSetName = QueueEndpointWithKeyParameterSet)]
        [ValidateNotNullOrEmpty]
        [PSDefaultValue(Value = CrmServiceEndpointMessageFormat.DOTNETBinary)]
        public CrmServiceEndpointMessageFormat MessageFormat { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = QueueEndpointWithTokenParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = RelayEndpointWithTokenParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SASToken { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = QueueEndpointWithKeyParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = RelayEndpointWithKeyParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SASKeyName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = QueueEndpointWithKeyParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = RelayEndpointWithKeyParameterSet)]
        [ValidateNotNullOrEmpty]
        [ValidateLength(44, 44)]
        public string SASKey { get; set; }

        [Parameter()]
        [ValidateNotNull]
        [Alias("UserInformation")]
        [PSDefaultValue(Value = CrmServiceEndpointUserClaim.None)]
        public CrmServiceEndpointUserClaim Claim { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (!this.MyInvocation.BoundParameters.ContainsKey(nameof(Claim))) Claim = CrmServiceEndpointUserClaim.None;
            if (!this.MyInvocation.BoundParameters.ContainsKey(nameof(MessageFormat))) MessageFormat = CrmServiceEndpointMessageFormat.DOTNETBinary;

            ValidateNameUnique(_repository, Name, Id);
            ValidateEndpoint(Endpoint, QueueContract != 0 ? QueueContract : RelayContract);
            ValidateMessageFormat(QueueContract != 0 ? QueueContract : RelayContract, MessageFormat);

            Entity serviceEndpointEntity = GenerateCrmEntity();
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Id)))
            {
                serviceEndpointEntity.Id = Id;
                _repository.Update(serviceEndpointEntity);

                if (PassThru) WriteObject(_repository.Get("serviceendpoint", Id));
            }
            else
            {
                Guid newId = _repository.Add(serviceEndpointEntity);
                
                if (PassThru) WriteObject(_repository.Get("serviceendpoint", newId));
            }
        }

        private Entity GenerateCrmEntity()
        {
            Entity crmServiceEndpoint = new Entity("serviceendpoint")
            {
                Attributes = new AttributeCollection()
            };

            crmServiceEndpoint.Attributes.Add("namespaceformat", new OptionSetValue(2));  //CrmServiceEndpointNamespaceFormat.Address
            crmServiceEndpoint.Attributes.Add("name", Name);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Description)))
            {
                crmServiceEndpoint.Attributes.Add("description", Description);
            }
            crmServiceEndpoint.Attributes.Add("connectionmode", new OptionSetValue((int)CrmServiceEndpointConnectionMode.Normal));

            crmServiceEndpoint.Attributes.Add("solutionnamespace",
                Endpoint.Split(
                    new char[1] { '.' }, 2).GetValue(0).ToString().Split('/').GetValue(2).ToString());
            crmServiceEndpoint.Attributes.Add("namespaceaddress", Endpoint);
            crmServiceEndpoint.Attributes.Add("path", EndpointPathOrName);

            if (ParameterSetName == RelayEndpointWithKeyParameterSet || ParameterSetName == RelayEndpointWithTokenParameterSet)
            {
                crmServiceEndpoint.Attributes.Add("contract", new OptionSetValue((int)RelayContract));
            }
            else
            {
                crmServiceEndpoint.Attributes.Add("contract", new OptionSetValue((int)QueueContract));
            }

            crmServiceEndpoint.Attributes.Add("messageformat", new OptionSetValue((int)MessageFormat));
            crmServiceEndpoint.Attributes.Add("userclaim", new OptionSetValue((int)Claim));

            switch (ParameterSetName)
            {
                case RelayEndpointWithTokenParameterSet:
                case QueueEndpointWithTokenParameterSet:
                    crmServiceEndpoint.Attributes.Add("authtype", new OptionSetValue((int)CrmServiceEndpointAuthType.SASToken));
                    crmServiceEndpoint.Attributes.Add("sastoken", SASToken);
                    break;
                case RelayEndpointWithKeyParameterSet:
                case QueueEndpointWithKeyParameterSet:
                    crmServiceEndpoint.Attributes.Add("authtype", new OptionSetValue((int)CrmServiceEndpointAuthType.SASKey));
                    crmServiceEndpoint.Attributes.Add("saskeyname", SASKeyName);
                    crmServiceEndpoint.Attributes.Add("saskey", SASKey);
                    break;
                default:
                    break;
            }

            return crmServiceEndpoint;
        }

        private static void ValidateEndpoint(string endpoint, CrmServiceEndpointContract contract)
        {
            if (!Uri.IsWellFormedUriString(endpoint, UriKind.Absolute))
            {
                throw new PSArgumentException("Endpoint is not a valid URI.", nameof(Endpoint));
            }

            if ((
                contract == CrmServiceEndpointContract.Rest || 
                contract == CrmServiceEndpointContract.OneWay || 
                contract == CrmServiceEndpointContract.TwoWay) && !endpoint.StartsWith("https://"))
            {
                throw new PSArgumentException("Invalid Endpoint URI.", nameof(Endpoint));
            }

            if ((
                contract == CrmServiceEndpointContract.Queue ||
                contract == CrmServiceEndpointContract.Topic ||
                contract == CrmServiceEndpointContract.EventHub) && !endpoint.StartsWith("sb://"))
            {
                throw new PSArgumentException("Invalid Endpoint URI.", nameof(Endpoint));
            }
        }

        private static void ValidateNameUnique(ContentRepository repostiory, string name, Guid? id)
        {
            QueryExpression query = new QueryExpression("serviceendpoint");
            query.Criteria.AddCondition("name", ConditionOperator.Equal, name);

            IEnumerable<Entity> existing = repostiory.Get(query);
            if (existing.Where(e => e.Id != id).Any())
            {
                throw new PSArgumentException("Service Endpoint Name must be Unique", nameof(Name));
            }
        }

        private static void ValidateMessageFormat(CrmServiceEndpointContract contract, CrmServiceEndpointMessageFormat messageFormat)
        {
            if (contract == CrmServiceEndpointContract.EventHub && messageFormat == CrmServiceEndpointMessageFormat.DOTNETBinary)
            {
                throw new PSArgumentException("Invalid MessageFormat. EventHub Contract requires JSON or XML.", nameof(MessageFormat));
            }
        }       
    }
}
