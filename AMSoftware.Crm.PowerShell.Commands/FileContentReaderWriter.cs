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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSoftware.Crm.PowerShell.Commands
{
    internal sealed class FileContentReaderWriter
    {
        public string Path { get; private set; }
        public Encoding FileEncoding { get; private set; }
        public bool AsBytes { get; private set; }

        public FileContentReaderWriter(string path, Encoding fileEncoding, bool asBytes)
        {
            Path = path;
            FileEncoding = fileEncoding;
            AsBytes = asBytes;
        }

        internal byte[] ReadAsBytes()
        {
            if (AsBytes) {
                return File.ReadAllBytes(Path);
            } else {
                return FileEncoding.GetBytes(File.ReadAllText(Path, FileEncoding)); 
            }
        }
    }
}
