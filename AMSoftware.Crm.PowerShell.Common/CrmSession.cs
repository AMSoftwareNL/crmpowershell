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
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Threading;

namespace AMSoftware.Crm.PowerShell.Common
{
    internal sealed class CrmSession : IDisposable
    {
        private bool _disposed = false;

        private readonly CrmServiceClient _client;
        private readonly int _organizationLanguage;
        private int _sessionLanguage;

        internal CrmSession(CrmServiceClient client)
        {
            _client = client;

            OrganizationProxy = (IOrganizationService)client;

            Entity organizationRow = OrganizationProxy.Retrieve("organization", _client.ConnectedOrgId, new ColumnSet("languagecode", "localeid"));
            _organizationLanguage = organizationRow.GetAttributeValue<int>("languagecode");
            Language = _organizationLanguage;
            LocaleId = organizationRow.GetAttributeValue<int>("localeid");

            Version = _client.ConnectedOrgVersion;
            ActiveSolutionName = null;

            UseMetadataCache = true;
            OrganizationCache = new MetadataCache();
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
                    //if (_client != null) _client.Dispose();
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

        internal IOrganizationService OrganizationProxy { get; }

        internal CrmServiceClient Client => _client;

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

        internal Guid ActiveSolutionId
        {
            get;
            set;
        }
        
        internal bool UseMetadataCache { 
            get; 
            set; 
        }
        
        internal bool BatchActive {
            get {
                return BatchRequestCollection != null;
            }
            set
            {
                if (value)
                {
                    if (!BatchActive)
                    {
                        BatchRequestCollection = new OrganizationRequestCollection();
                    } else
                    {
                        throw new InvalidOperationException("Active batch detected. Cannot start new batch.");
                    }
                } else
                {
                    BatchRequestCollection = null;
                }
            }
        }

        internal OrganizationRequestCollection BatchRequestCollection { get; private set; }
    }
}
