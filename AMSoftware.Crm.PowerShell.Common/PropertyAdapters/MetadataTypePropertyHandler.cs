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
using Microsoft.Xrm.Sdk.Metadata;
using System.Linq;
using System.Reflection;

namespace AMSoftware.Crm.PowerShell.Common.PropertyAdapters
{
    internal class MetadataTypePropertyHandler : MemberTypePropertyHandler<MetadataBase>
    {
        public MetadataTypePropertyHandler(PropertyInfo propertyInfo)
            : base(propertyInfo) { }

        public override object GetValue(MetadataBase baseObject)
        {
            var outputValue = base.GetValue(baseObject);

            switch (outputValue)
            {
                case Label l:
                    return new PSCrmObject<Label, string>(l, v =>
                    {
                        var languageLabel = v.LocalizedLabels.SingleOrDefault(i => i.LanguageCode == CrmContext.Language);
                        if (languageLabel != null)
                        {
                            return languageLabel.Label;
                        }

                        return null;
                    });
                case OptionSetMetadataBase osmb:
                    return new PSCrmObject<OptionSetMetadataBase, string>(osmb, v => v.Name);
                case BooleanManagedProperty bmp:
                    return new PSCrmObject<BooleanManagedProperty, bool>(bmp, v => v.Value);
                case AttributeRequiredLevelManagedProperty arlmp:
                    return new PSCrmObject<AttributeRequiredLevelManagedProperty, AttributeRequiredLevel>(arlmp, v => v.Value);
                case ConstantsBase<string> cbs:
                    return new PSCrmObject<ConstantsBase<string>, string>(cbs, v => v.Value);
                default:
                    return outputValue;
            }
        }
    }
}
