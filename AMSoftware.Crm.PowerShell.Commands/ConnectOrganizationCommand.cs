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
using Microsoft.Xrm.Sdk.Discovery;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands
{
    [Cmdlet(VerbsCommunications.Connect, "CrmOrganization", HelpUri = HelpUrlConstants.ConnectOrganizationHelpUrl, DefaultParameterSetName = ConnectionstringParameterSet)]
    [OutputType(typeof(OrganizationDetail))]
    public sealed class ConnectOrganizationCommand : CrmCmdlet
    {
        private const string ConnectionstringParameterSet = "Connectionstring";
        private const string ConnectionParameterSet = "Connection";

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ConnectionstringParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Connectionstring { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ConnectionParameterSet)]
        [ValidateNotNull]
        public CrmServiceClient Connection { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            try
            {
                if (!string.IsNullOrWhiteSpace(Connectionstring))
                {
                    Connection = new CrmServiceClient(Connectionstring);
                }

                if (Connection != null && Connection.IsReady)
                {
                    CrmContext.Connect(Connection);
                    WriteObject(Connection.OrganizationDetail);
                }
                else
                {
                    throw new Exception(Connection.LastCrmError, Connection.LastCrmException);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
