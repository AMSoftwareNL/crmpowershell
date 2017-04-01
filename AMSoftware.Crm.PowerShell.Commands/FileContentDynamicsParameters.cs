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
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.PowerShell.Commands;

namespace AMSoftware.Crm.PowerShell.Commands
{
    public abstract class FileContentDynamicsParameters
    {
        private static class NativeMethods
        {
            [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
            internal static extern uint GetOEMCP();
        }

        protected FileSystemCmdletProviderEncoding streamType = FileSystemCmdletProviderEncoding.String;

        public Encoding EncodingType
        {
            get
            {
                return GetEncodingFromEnum(this.streamType);
            }
        }

        public bool UsingByteEncoding
        {
            get
            {
                return this.streamType == FileSystemCmdletProviderEncoding.Byte;
            }
        }

        private static Encoding GetEncodingFromEnum(FileSystemCmdletProviderEncoding type)
        {
            Encoding result = System.Text.Encoding.Unicode;
            switch (type)
            {
                case FileSystemCmdletProviderEncoding.String:
                    result = System.Text.Encoding.Unicode;
                    return result;
                case FileSystemCmdletProviderEncoding.Unicode:
                    result = System.Text.Encoding.Unicode;
                    return result;
                case FileSystemCmdletProviderEncoding.BigEndianUnicode:
                    result = System.Text.Encoding.BigEndianUnicode;
                    return result;
                case FileSystemCmdletProviderEncoding.UTF8:
                    result = System.Text.Encoding.UTF8;
                    return result;
                case FileSystemCmdletProviderEncoding.UTF7:
                    result = System.Text.Encoding.UTF7;
                    return result;
                case FileSystemCmdletProviderEncoding.UTF32:
                    result = System.Text.Encoding.UTF32;
                    return result;
                case FileSystemCmdletProviderEncoding.Ascii:
                    result = System.Text.Encoding.ASCII;
                    return result;
                case FileSystemCmdletProviderEncoding.Default:
                    result = System.Text.Encoding.Default;
                    return result;
                case FileSystemCmdletProviderEncoding.Oem:
                    {
                        uint oEMCP = NativeMethods.GetOEMCP();
                        result = System.Text.Encoding.GetEncoding((int)oEMCP);
                        return result;
                    }
            }
            result = System.Text.Encoding.Unicode;
            return result;
        }
    }
}
