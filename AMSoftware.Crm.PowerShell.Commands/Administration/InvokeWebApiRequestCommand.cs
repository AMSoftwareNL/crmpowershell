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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net.Http;

namespace AMSoftware.Crm.PowerShell.Commands.Administration
{
    [Cmdlet(VerbsLifecycle.Invoke, "CrmWebApiRequest", HelpUri = HelpUrlConstants.InvokeWebApiRequestHelpUrl)]
    [OutputType(typeof(string))]
    public sealed class InvokeWebApiRequestCommand : CrmOrganizationCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        [ValidateNotNullOrEmpty]
        public Uri Url { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        [PSDefaultValue(Value = "Get")]
        [ValidateSet("Get", "Post", "Put", "Delete", "Patch", IgnoreCase = true)]
        public string Method { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public object Body { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        [PSDefaultValue(Value = "application/json")]
        public string ContentType { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter FormattedValues { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (CrmContext.Session.Client.OrganizationWebProxyClient == null) throw new PSInvalidOperationException("Web Proxy Client not available.");

            HttpMethod requestMethod = HttpMethod.Get;
            if (!string.IsNullOrWhiteSpace(Method)) requestMethod = new HttpMethod(Method);

            string requestContentType = "application/json";
            if (!string.IsNullOrWhiteSpace(ContentType)) requestContentType = ContentType;

            string requestBody = null;
            if (requestMethod != HttpMethod.Get && Body != null)
            {
                if (Body is string bodyValue) requestBody = bodyValue;
                else requestBody = JsonConvert.SerializeObject(Body);
            }

            Dictionary<string, List<string>> requestHeaders = new Dictionary<string, List<string>>();
            if (FormattedValues.ToBool())
            {
                requestHeaders.Add(
                    "Prefer",
                    new List<string>() { "odata.include-annotations=\"OData.Community.Display.V1.FormattedValue\"" });
            }

            HttpResponseMessage response = CrmContext.Session.Client.ExecuteCrmWebRequest(
                requestMethod, Url.ToString(), requestBody, requestHeaders, requestContentType);
            response.EnsureSuccessStatusCode();

            string content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            WriteObject(content);
        }
    }
}
