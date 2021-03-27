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
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Management.Automation;
using System.Net;

namespace AMSoftware.Crm.PowerShell.Common
{
    internal static class CrmContext
    {
        static CrmContext()
        {
            try
            {
                var accelerators = typeof(PSObject).Assembly.GetType("System.Management.Automation.TypeAccelerators");
                accelerators.InvokeMember("Add", System.Reflection.BindingFlags.InvokeMethod, null, null, new object[] { "crmmoney", typeof(Money) });
                accelerators.InvokeMember("Add", System.Reflection.BindingFlags.InvokeMethod, null, null, new object[] { "crmoptionsetvalue", typeof(OptionSetValue) });
                accelerators.InvokeMember("Add", System.Reflection.BindingFlags.InvokeMethod, null, null, new object[] { "crmlabel", typeof(Label) });
            }
            catch {
                
            }

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        public static void Connect(CrmServiceClient connection)
        {

            Session = new CrmSession(connection);
        }

        public static void Disconnect()
        {
            if (Session != null)
            {
                Session.Dispose();
            }
        }

        public static CrmSession Session
        {
            get;
            private set;
        }
    }
}
