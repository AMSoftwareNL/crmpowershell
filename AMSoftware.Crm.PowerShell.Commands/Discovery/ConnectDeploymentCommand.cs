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
using System.Net;
using System.Text.RegularExpressions;
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk.Discovery;

namespace AMSoftware.Crm.PowerShell.Commands.Discovery
{
    [Cmdlet(VerbsCommunications.Connect, "Deployment", HelpUri = HelpUrlConstants.ConnectDeploymentHelpUrl)]
    [OutputType(typeof(OrganizationDetail))]
    public sealed class ConnectDeploymentCommand : CrmCmdlet
    {
        private const string ConnectOnlineParameterSet = "ConnectOnline";
        private const string ConnectOnPremisesParameterSet = "ConnectOnPremises";

        private const string OnlineDiscoveryUrlFormat = "https://disco.{0}.dynamics.com/XRMServices/2011/Discovery.svc";
        private const string OnPremisesDiscoveryServicePath = "XRMServices/2011/Discovery.svc";
        private const string RegionRegexPattern = "^crm[1-9]?$";

        private DeploymentRepository _repository = new DeploymentRepository();

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ConnectOnlineParameterSet)]
        [ValidateNotNullOrEmpty]
        [ValidatePattern(RegionRegexPattern, Options = RegexOptions.IgnoreCase)]
        public string Region { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ConnectOnPremisesParameterSet)]
        [ValidateNotNull]
        public Uri DiscoveryUrl { get; set; }

        [Parameter(Mandatory = false, Position = 2, ParameterSetName = ConnectOnPremisesParameterSet)]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = ConnectOnlineParameterSet)]
        [ValidateNotNull]
        [Credential]
        public PSCredential Credential { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case ConnectOnlineParameterSet:
                    ConnectOnline();
                    break;
                case ConnectOnPremisesParameterSet:
                    ConnectOnPremises();
                    break;
                default:
                    break;
            }

            WriteObject(_repository.GetOrganization(), true);
        }

        private void ConnectOnPremises()
        {
            if (!DiscoveryUrl.IsAbsoluteUri)
            {
                throw new Exception("InvalidDiscoveryUrl");
            }

            Uri discoveryUri = DiscoveryUrl;
            if (!DiscoveryUrl.GetComponents(UriComponents.Path, UriFormat.Unescaped).EndsWith(OnPremisesDiscoveryServicePath, StringComparison.OrdinalIgnoreCase))
            {
                discoveryUri = new Uri(discoveryUri, OnPremisesDiscoveryServicePath);
            }

            CrmContext.ConnectDeployment(discoveryUri, Credential == null ? CredentialCache.DefaultNetworkCredentials : Credential.GetNetworkCredential());
        }

        private void ConnectOnline()
        {
            Uri discoveryUri = new Uri(string.Format(OnlineDiscoveryUrlFormat, Region), UriKind.Absolute);
            CrmContext.ConnectDeployment(discoveryUri, Credential.GetNetworkCredential());
        }
    }
}
