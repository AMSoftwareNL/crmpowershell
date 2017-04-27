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
using System.Net;
using System.ServiceModel.Description;
using System.Threading;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Discovery;
using Microsoft.Xrm.Sdk.Query;

namespace AMSoftware.Crm.PowerShell.Common
{
    internal sealed class CrmSession : IDisposable
    {
        private AuthenticationCredentials _tokenCredentials;
        private bool _disposed = false;

        private int _organizationLanguage;
        private int _sessionLanguage;

        #region Singleton
        private static CrmSession _session;
        internal static CrmSession Current
        {
            get { return _session; }
        }

        internal static CrmSession Connect(Uri discoveryUri, NetworkCredential credential, bool isOnPremises)
        {
            if (_session != null)
            {
                _session.Dispose();
                _session = null;
            }

            _session = new CrmSession(discoveryUri, credential, isOnPremises);
            return _session;
        }
        #endregion

        private CrmSession(Uri discoveryUri, NetworkCredential credential, bool isOnPremises)
        {
            IServiceManagement<IDiscoveryService> discoveryServiceManagement = ServiceConfigurationFactory.CreateManagement<IDiscoveryService>(discoveryUri);
            ClientCredentials clientCredentials = InitializeClientCredentials(credential, discoveryServiceManagement);

            AuthenticationCredentials authCredentials = new AuthenticationCredentials()
            {
                ClientCredentials = clientCredentials
            };
            if (isOnPremises && discoveryServiceManagement.AuthenticationType != AuthenticationProviderType.ActiveDirectory)
            {
                authCredentials.HomeRealm = discoveryUri;
            }

            _tokenCredentials = discoveryServiceManagement.Authenticate(authCredentials);

            DiscoveryProxy = GetService<IDiscoveryService>(discoveryServiceManagement, _tokenCredentials);
        }

        private static ClientCredentials InitializeClientCredentials(NetworkCredential credential, IServiceManagement<IDiscoveryService> discoveryServiceManagement)
        {
            ClientCredentials clientCredentials = new ClientCredentials();
            if (discoveryServiceManagement.AuthenticationType == AuthenticationProviderType.ActiveDirectory)
            {
                clientCredentials.Windows.ClientCredential = credential;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(credential.Domain))
                {
                    clientCredentials.UserName.UserName = string.Format("{0}\\{1}", credential.Domain, credential.UserName);
                }
                else
                {
                    clientCredentials.UserName.UserName = credential.UserName;
                }
                clientCredentials.UserName.Password = credential.Password;
            }
            return clientCredentials;
        }

        private static TService GetService<TService>(IServiceManagement<TService> serviceManagement, AuthenticationCredentials tokenCredentials)
            where TService : class
        {
            Type classType = null;
            if (typeof(TService) == typeof(IOrganizationService))
            {
                classType = typeof(ManagedTokenOrganizationServiceProxy);
            }
            else
            {
                classType = typeof(ManagedTokenDiscoveryServiceProxy);
            }

            if (serviceManagement.AuthenticationType != AuthenticationProviderType.ActiveDirectory)
            {
                return (TService)classType
                .GetConstructor(new Type[] 
                    { 
                        typeof(IServiceManagement<TService>), 
                        typeof(SecurityTokenResponse) 
                    })
                .Invoke(new object[] 
                    { 
                        serviceManagement, 
                        tokenCredentials.SecurityTokenResponse 
                    });
            }
            else
            {
                return (TService)classType
                .GetConstructor(new Type[] 
                   { 
                       typeof(IServiceManagement<TService>), 
                       typeof(ClientCredentials)
                   })
               .Invoke(new object[] 
                   { 
                       serviceManagement, 
                       tokenCredentials.ClientCredentials 
                   });
            }
        }

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (DiscoveryProxy != null) ((DiscoveryServiceProxy)DiscoveryProxy).Dispose();
                    if (OrganizationProxy != null) ((OrganizationServiceProxy)OrganizationProxy).Dispose();
                }
                // There are no unmanaged resources to release, but if we add them, they need to be released here.
            }
            _disposed = true;
        }

        ~CrmSession()
        {
            Dispose(false);
        }
        #endregion

        internal void Connect(OrganizationDetail organization)
        {
            DisconnectOrganization();

            Uri organizationUri = new Uri(organization.Endpoints[EndpointType.OrganizationService], UriKind.Absolute);
            IServiceManagement<IOrganizationService> organizationServiceManagement = 
                ServiceConfigurationFactory.CreateManagement<IOrganizationService>(organizationUri);
            OrganizationProxy = GetService<IOrganizationService>(organizationServiceManagement, _tokenCredentials);

            OrganizationCache = new MetadataCache();
            InitializeOrganizationInfo();

            Version = new Version(organization.OrganizationVersion);
            ActiveSolutionName = null;
        }

        private void DisconnectOrganization()
        {
            OrganizationCache = null;
            if (OrganizationProxy != null) ((OrganizationServiceProxy)OrganizationProxy).Dispose();
        }

        internal IDiscoveryService DiscoveryProxy
        {
            get;
            private set;
        }

        internal IOrganizationService OrganizationProxy
        {
            get;
            private set;
        }

        internal MetadataCache OrganizationCache
        {
            get;
            private set;
        }

        internal int LocaleId
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture.LCID;
            }
            private set
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(value);
            }
        }

        internal int Language
        {
            get
            {
                return _sessionLanguage;
            }
            set
            {
                if (value == 0)
                {
                    _sessionLanguage = _organizationLanguage;
                }
                else {
                    _sessionLanguage = value;
                }
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(_sessionLanguage);
            }
        }

        internal Version Version
        {
            get;
            private set;
        }

        internal string ActiveSolutionName
        {
            get;
            set;
        }

        private void InitializeOrganizationInfo()
        {
            OrganizationRequest whoAmIRequest = new OrganizationRequest("WhoAmI");
            OrganizationResponse whoAmIResponse = OrganizationProxy.Execute(whoAmIRequest);
            Guid organizationId = (Guid)whoAmIResponse.Results["OrganizationId"];

            Entity organizationRow = OrganizationProxy.Retrieve("organization", organizationId, new ColumnSet("languagecode", "localeid"));
            _organizationLanguage = organizationRow.GetAttributeValue<int>("languagecode");
            Language = _organizationLanguage;
            LocaleId = organizationRow.GetAttributeValue<int>("localeid");
        }
    }
}
