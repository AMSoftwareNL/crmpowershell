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
using System.Xml;
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace AMSoftware.Crm.PowerShell.Commands.Plugins
{
    [Cmdlet(VerbsLifecycle.Register, "CrmWebhook", HelpUri = HelpUrlConstants.RegisterWebhookHelpUrl, DefaultParameterSetName = RegisterWebhookWithKeyAuthParameterSet)]
    [OutputType(typeof(Entity))]
    public sealed class RegisterCrmWebhookCommand : CrmOrganizationCmdlet
    {
        private const string RegisterWebhookWithKeyAuthParameterSet = "RegisterWebhookWithKeyAuth";
        private const string RegisterWebhookWithQuerystringAuthParameterSet = "RegisterWebhookWithQuerystringAuth";
        private const string RegisterWebhookWithHeaderAuthParameterSet = "RegisterWebhookWithHeaderAuth";

        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public Guid Id { get; set; }

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        [ValidateNotNullOrEmpty]
        public string Endpoint { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = RegisterWebhookWithKeyAuthParameterSet)]
        [ValidateNotNullOrEmpty]
        public string WebhookKey { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = RegisterWebhookWithQuerystringAuthParameterSet)]
        [ValidateNotNullOrEmpty]
        public Hashtable Querystring { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = RegisterWebhookWithHeaderAuthParameterSet)]
        [ValidateNotNullOrEmpty]
        public Hashtable Headers { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ValidateEndpoint(Endpoint);
            ValidateNameUnique(_repository, Name, Id);

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

                if (PassThru) WriteObject(_repository.Get("serviceendpoint", Id));
            }
        }

        private static void ValidateNameUnique(ContentRepository repostiory, string name, Guid id)
        {
            QueryExpression query = new QueryExpression("serviceendpoint");
            query.Criteria.AddCondition("name", ConditionOperator.Equal, name);

            IEnumerable<Entity> existing = repostiory.Get(query);
            if (existing.Where(e => e.Id != id).Any())
            {
                throw new Exception("WebHook Name must be Unique");
            }
        }

        private static void ValidateEndpoint(string endpoint)
        {
            if (!Uri.IsWellFormedUriString(endpoint, UriKind.Absolute))
            {
                throw new PSArgumentException("Invalid Endpoint URI.", nameof(Endpoint));
            }

            if (!endpoint.StartsWith("https://"))
            {
                throw new PSArgumentException("Invalid Endpoint URI.", nameof(Endpoint));
            }
        }


        private Entity GenerateCrmEntity()
        {
            Entity crmServiceEndpoint = new Entity("serviceendpoint")
            {
                Attributes = new AttributeCollection()
            };
            crmServiceEndpoint.Attributes.Add("name", Name);
            crmServiceEndpoint.Attributes.Add("url", Endpoint);
            crmServiceEndpoint.Attributes.Add("contract", new OptionSetValue((int)CrmServiceEndpointContract.Webhook));
            crmServiceEndpoint.Attributes.Add("connectionmode", new OptionSetValue((int)CrmServiceEndpointConnectionMode.Normal));

            switch (ParameterSetName)
            {
                case RegisterWebhookWithQuerystringAuthParameterSet:
                    crmServiceEndpoint.Attributes.Add("authtype", new OptionSetValue((int)CrmServiceEndpointAuthType.HttpQueryString));
                    break;
                case RegisterWebhookWithHeaderAuthParameterSet:
                    crmServiceEndpoint.Attributes.Add("authtype", new OptionSetValue((int)CrmServiceEndpointAuthType.HttpHeader));
                    break;
                default:
                    crmServiceEndpoint.Attributes.Add("authtype", new OptionSetValue((int)CrmServiceEndpointAuthType.WebhookKey));
                    break;
            }
            crmServiceEndpoint.Attributes.Add("authvalue", GetAuthValue());

            return crmServiceEndpoint;
        }

        private string GetAuthValue()
        {
            if (ParameterSetName == RegisterWebhookWithKeyAuthParameterSet)
            {
                return WebhookKey;
            }

            XmlDocument xmlDocument = new XmlDocument();
            XmlElement xmlElement = xmlDocument.CreateElement("settings");

            Hashtable authValues = Headers ?? Querystring;

            if (authValues == null)
            {
                return string.Empty;
            }
            else
            {
                foreach (var item in authValues.Keys)
                {
                    XmlElement xmlElement2 = xmlDocument.CreateElement("setting");
                    xmlElement2.SetAttribute("name", (string)item);
                    xmlElement2.SetAttribute("value", (string)authValues[item]);
                    xmlElement.AppendChild(xmlElement2);
                }
                xmlDocument.AppendChild(xmlElement);
                return xmlDocument.InnerXml.ToString();
            }
        }
    }
}
