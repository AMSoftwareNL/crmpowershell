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
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AMSoftware.Crm.PowerShell.Common
{
    public enum CrmVersion
    {
        Unknown = 0,
        CRM2011_RTM,
        CRM2011_UR01,
        CRM2011_UR02,
        CRM2011_UR03,
        CRM2011_UR04,
        CRM2011_UR05,
        CRM2011_UR06,
        CRM2011_UR07,
        CRM2011_UR08,
        CRM2011_UR10,
        CRM2011_UR11,
        CRM2011_UR12,
        CRM2011_UR13,
        CRM2011_UR14,
        CRM2011_UR15,
        CRM2011_UR16,
        CRM2011_UR17,
        CRM2011_UR18,
        CRM2013_RTM,
        CRM2013_UR01,
        CRM2013_UR02,
        CRM2013_UR03,
        CRM2013_1_RTM,
        CRM2013_1_UR01,
        CRM2013_1_UR02,
        CRM2013_1_UR03,
        CRM2013_1_UR04,
        CRM2015_RTM,
        CRM2015_UR01,
        CRM2015_UR02,
        CRM2015_1_RTM,
        CRM2015_1_UR01,
        CRM2015_1_UR02,
        CRM2016_RTM,
        CRM2016_UR01,
        CRM2016_1_RTM,
        CRM2016_2_RTM
    }

    public static class CrmVersionManager
    {
        private static Version _sdkVersion;

        static CrmVersionManager()
        {
            _sdkVersion = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.GetName().Name.Equals("Microsoft.Xrm.Sdk", StringComparison.InvariantCultureIgnoreCase))
                .Select(a => new Version(FileVersionInfo.GetVersionInfo(a.Location).FileVersion))
                .FirstOrDefault();
        }

        internal static CrmVersion GetCrmVersionConstant(Version v)
        {
            if (v == null) return CrmVersion.Unknown;

            return (from vl in CrmVersionList
                    where vl.Value <= v
                    orderby vl.Key ascending
                    select vl.Key).Last();
        }

        internal static CrmVersion GetSdkVersionConstant(Version v)
        {
            if (v == null) return CrmVersion.Unknown;

            return (from vl in SdkVersionList
                    where vl.Value <= v
                    orderby vl.Key ascending
                    select vl.Key).Last();
        }

        public static bool IsSupported(CrmVersion requiredVersion)
        {
            var orgVersion = CrmContext.Version;
            var orgVersionEnum = GetCrmVersionConstant(orgVersion);
            var sdkVersionEnum = GetSdkVersionConstant(_sdkVersion);

            if (orgVersionEnum != CrmVersion.Unknown && sdkVersionEnum != CrmVersion.Unknown)
            {
                var minVersionEnum = (CrmVersion)Math.Min((int)orgVersionEnum, (int)sdkVersionEnum);
                return (minVersionEnum >= requiredVersion);
            }
            else if (orgVersionEnum != CrmVersion.Unknown)
            {
                return (orgVersionEnum >= requiredVersion);
            }
            else if (sdkVersionEnum != CrmVersion.Unknown)
            {
                return (sdkVersionEnum >= requiredVersion);
            }
            else
            {
                return false;
            }
        }

        private static Dictionary<CrmVersion, Version> CrmVersionList
        {
            get
            {
                return new Dictionary<CrmVersion, Version>() {
                    { CrmVersion.CRM2011_RTM, new Version("5.0.9688.583") }, 
                    { CrmVersion.CRM2011_UR01, new Version("5.0.9688.1045") }, 
                    { CrmVersion.CRM2011_UR02, new Version("5.0.9688.1155") },
                    { CrmVersion.CRM2011_UR03, new Version("5.0.9688.1244") },
                    { CrmVersion.CRM2011_UR04, new Version("5.0.9688.1450") },
                    { CrmVersion.CRM2011_UR05, new Version("5.0.9688.1533") },
                    { CrmVersion.CRM2011_UR06, new Version("5.0.9690.1992") },
                    { CrmVersion.CRM2011_UR07, new Version("5.0.9690.2165") },
                    { CrmVersion.CRM2011_UR08, new Version("5.0.9690.2243") },
                    { CrmVersion.CRM2011_UR10, new Version("5.0.9690.2730") },
                    { CrmVersion.CRM2011_UR11, new Version("5.0.9690.2835") },
                    { CrmVersion.CRM2011_UR12, new Version("5.0.9690.3236") },
                    { CrmVersion.CRM2011_UR13, new Version("5.0.9690.3448") },
                    { CrmVersion.CRM2011_UR14, new Version("5.0.9690.3557") },
                    { CrmVersion.CRM2011_UR15, new Version("5.0.9690.3731") },
                    { CrmVersion.CRM2011_UR16, new Version("5.0.9690.3911") },
                    { CrmVersion.CRM2011_UR17, new Version("5.0.9690.4150") },
                    { CrmVersion.CRM2011_UR18, new Version("5.0.9690.4374") },
                    { CrmVersion.CRM2013_RTM, new Version("	6.0.0.0809") },
                    { CrmVersion.CRM2013_UR01, new Version("6.0.1.0061") },
                    { CrmVersion.CRM2013_UR02, new Version("6.0.2.0051") },
                    { CrmVersion.CRM2013_UR03, new Version("6.0.3.0106") },
                    { CrmVersion.CRM2013_1_RTM, new Version("6.1.0.0581") },
                    { CrmVersion.CRM2013_1_UR01, new Version("6.1.1.0132") },
                    { CrmVersion.CRM2013_1_UR02, new Version("6.1.2.0112") },
                    { CrmVersion.CRM2013_1_UR03, new Version("6.1.3.0119") },
                    { CrmVersion.CRM2013_1_UR04, new Version("6.1.4.0145") },
                    { CrmVersion.CRM2015_RTM, new Version("7.0.0.3543") },
                    { CrmVersion.CRM2015_UR01, new Version("7.0.1.129") },
                    { CrmVersion.CRM2015_UR02, new Version("7.0.2.0053") },
                    { CrmVersion.CRM2015_1_RTM, new Version("7.1.0.1074") },
                    { CrmVersion.CRM2015_1_UR01, new Version("7.1.1.3113") },
                    { CrmVersion.CRM2015_1_UR02, new Version("7.1.2.1032") },
                    { CrmVersion.CRM2016_RTM, new Version("8.0.0.1088") },
                    { CrmVersion.CRM2016_UR01, new Version("8.0.1.0079") },
                    { CrmVersion.CRM2016_1_RTM, new Version("8.1.0.0362") },
                    { CrmVersion.CRM2016_2_RTM, new Version("8.2.0.0773") },
               };
            }
        }

        private static Dictionary<CrmVersion, Version> SdkVersionList
        {
            get
            {
                return new Dictionary<CrmVersion, Version>() {
                    { CrmVersion.CRM2011_RTM, new Version("5.0.1") }, 
                    { CrmVersion.CRM2011_UR01, new Version("5.0.3") }, 
                    { CrmVersion.CRM2011_UR02, new Version("5.0.4") },
                    { CrmVersion.CRM2011_UR03, new Version("5.0.5") },
                    { CrmVersion.CRM2011_UR04, new Version("5.0.5") },
                    { CrmVersion.CRM2011_UR05, new Version("5.0.7") },
                    { CrmVersion.CRM2011_UR06, new Version("5.0.9") },
                    { CrmVersion.CRM2011_UR07, new Version("5.0.10") },
                    { CrmVersion.CRM2011_UR08, new Version("5.0.10") },
                    { CrmVersion.CRM2011_UR10, new Version("5.0.12") },
                    { CrmVersion.CRM2011_UR11, new Version("5.0.12") },
                    { CrmVersion.CRM2011_UR12, new Version("5.0.13") },
                    { CrmVersion.CRM2011_UR13, new Version("5.0.15") },
                    { CrmVersion.CRM2011_UR14, new Version("5.0.15") },
                    { CrmVersion.CRM2011_UR15, new Version("5.0.18") },
                    { CrmVersion.CRM2011_UR16, new Version("5.0.18") },
                    { CrmVersion.CRM2011_UR17, new Version("5.0.18") },
                    { CrmVersion.CRM2011_UR18, new Version("5.0.18") },
                    { CrmVersion.CRM2013_RTM, new Version("	6.0.0") },
                    { CrmVersion.CRM2013_UR01, new Version("6.0.2") },
                    { CrmVersion.CRM2013_UR02, new Version("6.0.4") },
                    { CrmVersion.CRM2013_UR03, new Version("6.0.4") },
                    { CrmVersion.CRM2013_1_RTM, new Version("6.1.0") },
                    { CrmVersion.CRM2013_1_UR01, new Version("6.1.1") },
                    { CrmVersion.CRM2013_1_UR02, new Version("6.1.1") },
                    { CrmVersion.CRM2013_1_UR03, new Version("6.1.1") },
                    { CrmVersion.CRM2013_1_UR04, new Version("6.1.1") },
                    { CrmVersion.CRM2015_RTM, new Version("7.0.0") },
                    { CrmVersion.CRM2015_UR01, new Version("7.0.1") },
                    { CrmVersion.CRM2015_UR02, new Version("7.0.1") },
                    { CrmVersion.CRM2015_1_RTM, new Version("7.1.0") },
                    { CrmVersion.CRM2015_1_UR01, new Version("7.1.1") },
                    { CrmVersion.CRM2015_1_UR02, new Version("7.1.1") },
                    { CrmVersion.CRM2016_RTM, new Version("8.0.0") },
                    { CrmVersion.CRM2016_UR01, new Version("8.0.1") },
                    { CrmVersion.CRM2016_1_RTM, new Version("8.1.0") },
                    { CrmVersion.CRM2016_2_RTM, new Version("8.2.0") }
                };
            }
        }
    }
}
