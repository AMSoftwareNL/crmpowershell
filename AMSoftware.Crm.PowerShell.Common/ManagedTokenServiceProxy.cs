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
using System.ServiceModel;
using System.ServiceModel.Description;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Discovery;
using Microsoft.Crm.Sdk.Messages;

namespace AMSoftware.Crm.PowerShell.Common
{
    internal sealed class ManagedTokenOrganizationServiceProxy : OrganizationServiceProxy
    {
        public ManagedTokenOrganizationServiceProxy(IServiceManagement<IOrganizationService> serviceManagement, ClientCredentials clientCredentials)
            : base(serviceManagement, clientCredentials)
        { }

        public ManagedTokenOrganizationServiceProxy(IServiceManagement<IOrganizationService> serviceManagement, SecurityTokenResponse securityTokenResponse)
            : base(serviceManagement, securityTokenResponse)
        { }

        protected override void AuthenticateCore()
        {
            PrepareCredentials();
            base.AuthenticateCore();
        }

        protected override void ValidateAuthentication()
        {
            RenewTokenIfRequired();
            base.ValidateAuthentication();
        }

        public void PrepareCredentials()
        {
            if (ClientCredentials == null)
            {
                return;
            }

            switch (ServiceConfiguration.AuthenticationType)
            {
                case AuthenticationProviderType.ActiveDirectory:
                    ClientCredentials.UserName.UserName = null;
                    ClientCredentials.UserName.Password = null;
                    break;
                case AuthenticationProviderType.Federation:
                    ClientCredentials.Windows.ClientCredential = null;
                    break;
                default:
                    return;
            }
        }

        public void RenewTokenIfRequired()
        {
            if (SecurityTokenResponse != null && DateTime.UtcNow.AddMinutes(15) >= SecurityTokenResponse.Response.Lifetime.Expires)
            {
                try
                {
                    Authenticate();
                }
                catch (CommunicationException)
                {
                    if (SecurityTokenResponse == null || DateTime.UtcNow >= SecurityTokenResponse.Response.Lifetime.Expires)
                    {
                        throw;
                    }

                    // Ignore the exception 
                }
            }
        }
    }

    internal sealed class ManagedTokenDiscoveryServiceProxy : DiscoveryServiceProxy
    {
        public ManagedTokenDiscoveryServiceProxy(IServiceManagement<IDiscoveryService> serviceManagement, ClientCredentials clientCredentials)
            : base(serviceManagement, clientCredentials)
        { }

        public ManagedTokenDiscoveryServiceProxy(IServiceManagement<IDiscoveryService> serviceManagement, SecurityTokenResponse securityTokenResponse)
            : base(serviceManagement, securityTokenResponse)
        { }

        protected override void AuthenticateCore()
        {
            PrepareCredentials();
            base.AuthenticateCore();
        }

        protected override void ValidateAuthentication()
        {
            RenewTokenIfRequired();
            base.ValidateAuthentication();
        }

        public void PrepareCredentials()
        {
            if (ClientCredentials == null)
            {
                return;
            }

            switch (ServiceConfiguration.AuthenticationType)
            {
                case AuthenticationProviderType.ActiveDirectory:
                    ClientCredentials.UserName.UserName = null;
                    ClientCredentials.UserName.Password = null;
                    break;
                case AuthenticationProviderType.Federation:
                    ClientCredentials.Windows.ClientCredential = null;
                    break;
                default:
                    return;
            }
        }

        public void RenewTokenIfRequired()
        {
            if (SecurityTokenResponse != null && DateTime.UtcNow.AddMinutes(15) >= SecurityTokenResponse.Response.Lifetime.Expires)
            {
                try
                {
                    Authenticate();
                }
                catch (CommunicationException)
                {
                    if (SecurityTokenResponse == null || DateTime.UtcNow >= SecurityTokenResponse.Response.Lifetime.Expires)
                    {
                        throw;
                    }

                    // Ignore the exception 
                }
            }
        }
    }
}
