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
using System.Management.Automation;
using System.Runtime.Serialization;

namespace AMSoftware.Crm.PowerShell.Common
{
    public class PSCrmObject<TInput, TDisplay> : PSObject
    {
        private Func<TInput, TDisplay> _toStringSelector;

        public PSCrmObject(TInput obj, Func<TInput, TDisplay> toStringSelector) : base(obj)
        {
            _toStringSelector = toStringSelector;
        }

        public override string ToString()
        {
            if (_toStringSelector != null)
            {
                TDisplay outputValue = _toStringSelector((TInput)BaseObject);
                return outputValue == null ? string.Empty : outputValue.ToString();
            }
            return base.ToString();
        }
    }
}
