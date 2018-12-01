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
using System.Linq;
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.ArgumentCompleters;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk.Metadata;

namespace AMSoftware.Crm.PowerShell.Commands.Metadata
{
    [Cmdlet(VerbsCommon.Get, "CrmAttribute", HelpUri = HelpUrlConstants.GetAttributeHelpUrl, DefaultParameterSetName = GetAttributesByFilterParameterSet)]
    public sealed class GetAttributeCommand : CrmOrganizationCmdlet
    {
        private const string GetAttributeByIdParameterSet = "GetAttributeById";
        private const string GetAttributesByFilterParameterSet = "GetAttributesByFilter";

        private MetadataRepository _repository = new MetadataRepository();

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = GetAttributeByIdParameterSet, ValueFromPipeline = true)]
        [Alias("MetadataId")]
        [ValidateNotNull]
        public Guid[] Id { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = GetAttributesByFilterParameterSet, ValueFromPipelineByPropertyName = true)]
        [Alias("EntityLogicalName", "LogicalName")]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string Entity { get; set; }

        [Parameter(Position = 2, ParameterSetName = GetAttributesByFilterParameterSet)]
        [Alias("Include")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        [ArgumentCompleter(typeof(AttributeArgumentCompleter))]
        public string Name { get; set; }

        [Parameter(ParameterSetName = GetAttributesByFilterParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        [ArgumentCompleter(typeof(AttributeArgumentCompleter))]
        public string Exclude { get; set; }

        [Parameter(ParameterSetName = GetAttributesByFilterParameterSet)]
        public SwitchParameter CustomOnly { get; set; }

        [Parameter(ParameterSetName = GetAttributesByFilterParameterSet)]
        public SwitchParameter ExcludeManaged { get; set; }

        [Parameter(ParameterSetName = GetAttributesByFilterParameterSet)]
        public SwitchParameter IncludeLinked { get; set; }

        [Parameter(ParameterSetName = GetAttributesByFilterParameterSet)]
        public string AttributeType { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case GetAttributeByIdParameterSet:
                    foreach (Guid id in Id)
                    {
                        WriteObject(_repository.GetAttribute(id));
                    }
                    break;
                case GetAttributesByFilterParameterSet:
                    GetAttributeByFilter();
                    break;
                default:
                    break;
            }
        }

        private void GetAttributeByFilter()
        {
            IEnumerable<AttributeMetadata> result = _repository.GetAttribute(Entity, CustomOnly.ToBool(), ExcludeManaged.ToBool(), IncludeLinked.ToBool());
            if (!string.IsNullOrWhiteSpace(Name))
            {
                WildcardPattern includePattern = new WildcardPattern(Name, WildcardOptions.IgnoreCase);
                result = result.Where(a => includePattern.IsMatch(a.LogicalName));
            }
            if (!string.IsNullOrWhiteSpace(Exclude))
            {
                WildcardPattern excludePattern = new WildcardPattern(Exclude, WildcardOptions.IgnoreCase);
                result = result.Where(a => !excludePattern.IsMatch(a.LogicalName));
            }

            if (!string.IsNullOrWhiteSpace(AttributeType))
            {
                if (CrmVersionManager.IsSupported(CrmVersion.CRM2013_RTM))
                {
                    string attributeTypeName = AttributeType;
                    if (!attributeTypeName.EndsWith("Type", StringComparison.InvariantCultureIgnoreCase)) attributeTypeName = string.Format("{0}Type", attributeTypeName);
                    result = result.Where(a => a.AttributeTypeName == attributeTypeName);
                }
                else
                {
                    AttributeTypeCode typeCode = AttributeTypeCode.String;
                    if (Enum.TryParse<AttributeTypeCode>(AttributeType, true, out typeCode))
                    {
                        result = result.Where(a => a.AttributeType == typeCode);
                    }
                }
            }

            result = result.OrderBy(a => a.LogicalName);

            WriteObject(result, true);
        }
    }
}
