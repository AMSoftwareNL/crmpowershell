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

namespace AMSoftware.Crm.PowerShell.Common.Helpers
{
    [Serializable]
    internal sealed class PluginAssemblyInfo
    {
        private List<PluginTypeInfo> _plugins;

        public PluginAssemblyInfo(string path)
        {
            LiteralPath = path;
        }

        public Guid AssemblyId { get; set; }
        public string LiteralPath { get; private set; }
        public string Name { get; set; }
        public CrmAssemblyIsolationMode IsolationMode { get; set; }
        public CrmAssemblySourceType SourceType { get; set; }
        public string ServerFileName { get; set; }
        public string Version { get; set; }
        public string PublicKeyToken { get; set; }
        public string Culture { get; set; }
        public string Description { get; set; }
        public int CustomizationLevel { get; set; }
        public Version SdkVersion { get; set; }
        public bool Enabled { get; set; }

        public List<PluginTypeInfo> Plugins
        {
            get
            {
                if (_plugins == null)
                {
                    _plugins = new List<PluginTypeInfo>();
                }
                return _plugins;
            }
        }
    }
}
