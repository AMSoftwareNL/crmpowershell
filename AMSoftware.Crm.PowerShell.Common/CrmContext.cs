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
using System.ComponentModel;
using System.Management.Automation;
using System.Net;
using System.Threading;
using AMSoftware.Crm.PowerShell.Common.Converters;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Discovery;
using Microsoft.Crm.Sdk.Messages;

namespace AMSoftware.Crm.PowerShell.Common
{
    public static class CrmContext
    {
        static CrmContext()
        {
            try
            {
                TypeDescriptor.AddAttributes(typeof(Microsoft.Xrm.Sdk.Money), new TypeConverterAttribute(typeof(MoneyConverter)));
                TypeDescriptor.AddAttributes(typeof(Microsoft.Xrm.Sdk.OptionSetValue), new TypeConverterAttribute(typeof(OptionSetValueConverter)));
                TypeDescriptor.AddAttributes(typeof(Microsoft.Xrm.Sdk.Entity), new TypeConverterAttribute(typeof(EntityConverter)));
                TypeDescriptor.AddAttributes(typeof(Microsoft.Xrm.Sdk.Label), new TypeConverterAttribute(typeof(LabelConverter)));
                TypeDescriptor.AddAttributes(typeof(Microsoft.Xrm.Sdk.BooleanManagedProperty), new TypeConverterAttribute(typeof(ManagedPropertyConverter)));
                TypeDescriptor.AddAttributes(typeof(Microsoft.Xrm.Sdk.Metadata.AttributeRequiredLevel), new TypeConverterAttribute(typeof(ManagedPropertyConverter)));

                var accelerators = typeof(PSObject).Assembly.GetType("System.Management.Automation.TypeAccelerators");
                accelerators.InvokeMember("Add", System.Reflection.BindingFlags.InvokeMethod, null, null, new object[] { "crmmoney", typeof(Microsoft.Xrm.Sdk.Money) });
                accelerators.InvokeMember("Add", System.Reflection.BindingFlags.InvokeMethod, null, null, new object[] { "crmoptionsetvalue", typeof(Microsoft.Xrm.Sdk.OptionSetValue) });
                accelerators.InvokeMember("Add", System.Reflection.BindingFlags.InvokeMethod, null, null, new object[] { "crmlabel", typeof(Microsoft.Xrm.Sdk.Label) });
            }
            catch { }
        }
        
        public static void ConnectDeployment(Uri discoveryUri, NetworkCredential credential, bool isOnPremises = false)
        {
            CrmSession.Connect(discoveryUri, credential, isOnPremises);
        }

        public static void ConnectOrganization(OrganizationDetail organization)
        {
            Session.Connect(organization);
        }

        public static CrmSession Session
        {
            get
            {
                return CrmSession.Current;
            }
        }

        public static IDiscoveryService DiscoveryProxy
        {
            get
            {
                if (Session == null) return null;
                return Session.DiscoveryProxy;
            }
        }

        public static IOrganizationService OrganizationProxy
        {
            get
            {
                if (Session == null) return null;
                return Session.OrganizationProxy;
            }
        }

        internal static MetadataCache Cache
        {
            get
            {
                if (Session == null) return null;
                return Session.OrganizationCache;
            }
        }

        public static int Language
        {
            get
            {
                if (Session == null) return Thread.CurrentThread.CurrentCulture.LCID;
                return Session.Language;
            }
            set
            {
                if (Session != null && Session.OrganizationProxy != null)
                {
                    Session.Language = value;
                }
            }
        }

        public static string ActiveSolution
        {
            get
            {
                if (Session == null) return null;
                return Session.ActiveSolutionName;
            }
            set
            {
                if (Session != null && Session.OrganizationProxy != null)
                {
                    Session.ActiveSolutionName = value;
                }
            }
        }

        internal static Version Version
        {
            get
            {
                if (Session == null) return null;
                return Session.Version;
            }
        }
    }
}
