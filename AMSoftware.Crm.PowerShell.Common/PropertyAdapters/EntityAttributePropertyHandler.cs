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
using System;

namespace AMSoftware.Crm.PowerShell.Common.PropertyAdapters
{
    internal class EntityAttributePropertyHandler : IAdaptedPropertyHandler<Entity>
    {
        private string _attributeName;

        public EntityAttributePropertyHandler(string attributeName)
        {
            _attributeName = attributeName;
        }

        public virtual string TypeName
        {
            get { return typeof(object).FullName; }
        }

        public virtual bool IsSettable
        {
            get { return true; }
        }

        public virtual bool IsGettable
        {
            get { return true; }
        }

        public virtual object GetValue(Entity baseObject)
        {
            if (baseObject.Attributes.TryGetValue(_attributeName, out object result))
            {
                if (result is AliasedValue aliasResult)
                {
                    result = aliasResult.Value;
                }

                switch (result)
                {
                    case OptionSetValue o:
                        return new PSCrmObject<OptionSetValue, int>(o, v => v.Value);
                    case Money m:
                        return new PSCrmObject<Money, decimal>(m, v => v.Value);
                    case EntityReference e:
                        return new PSCrmObject<EntityReference, Guid>(e, v => v.Id);
                    default:
                        return result;
                }
            }

            return null;
        }

        public virtual void SetValue(Entity baseObject, object value)
        {
            if (baseObject.Attributes.Contains(_attributeName))
            {
                baseObject.Attributes[_attributeName] = value;
            }
            else
            {
                baseObject.Attributes.Add(_attributeName, value);
            }
        }
    }
}
