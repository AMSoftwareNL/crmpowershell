﻿/*
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
using System;

namespace AMSoftware.Crm.PowerShell.Common.PropertyAdapters
{
    internal class FormattedValuePropertyHandler : IAdaptedPropertyHandler<Entity>
    {
        private readonly string _formattedValueName;

        public FormattedValuePropertyHandler(string formattedValueName)
        {
            _formattedValueName = formattedValueName;
        }

        public virtual string TypeName
        {
            get { return typeof(string).FullName; }
        }

        public virtual bool IsSettable
        {
            get { return false; }
        }

        public virtual bool IsGettable
        {
            get { return true; }
        }

        public virtual object GetValue(Entity baseObject)
        {
            baseObject.FormattedValues.TryGetValue(_formattedValueName, out string result);

            return result;
        }

        public virtual void SetValue(Entity baseObject, object value)
        {
            throw new NotSupportedException();
        }
    }
}
