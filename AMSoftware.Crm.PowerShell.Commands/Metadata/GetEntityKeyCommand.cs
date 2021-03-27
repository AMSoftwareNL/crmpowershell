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
    [Cmdlet(VerbsCommon.Get, "CrmEntityKey", HelpUri = HelpUrlConstants.GetEntityKeyHelpUrl, DefaultParameterSetName = GetEntityKeysByFilterParameterSet)]
    [OutputType(typeof(EntityKeyMetadata))]
    public sealed class GetEntityKeyCommand : CrmOrganizationCmdlet
    {
        private const string GetEntityKeyByIdParameterSet = "GetEntityKeyById";
        private const string GetEntityKeysByFilterParameterSet = "GetEntityKeysByFilter";

        private readonly MetadataRepository _repository = new MetadataRepository();

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = GetEntityKeyByIdParameterSet, ValueFromPipeline = true)]
        [Alias("MetadataId")]
        [ValidateNotNull]
        public Guid[] Id { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = GetEntityKeysByFilterParameterSet, ValueFromPipelineByPropertyName = true)]
        [Alias("LogicalName", "EntityLogicalName")]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string Entity { get; set; }

        [Parameter(Position = 2, ParameterSetName = GetEntityKeysByFilterParameterSet)]
        [Alias("Include")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        [ArgumentCompleter(typeof(EntityKeyArgumentCompleter))]
        public string Name { get; set; }

        [Parameter(ParameterSetName = GetEntityKeysByFilterParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        [ArgumentCompleter(typeof(EntityKeyArgumentCompleter))]
        public string Exclude { get; set; }

        [Parameter(ParameterSetName = GetEntityKeysByFilterParameterSet)]
        public SwitchParameter ExcludeManaged { get; set; }

        [Parameter(ParameterSetName = GetEntityKeysByFilterParameterSet, ValueFromRemainingArguments = true)]
        [ValidateNotNull]
        [ValidateCount(1, int.MaxValue)]
        [ArgumentCompleter(typeof(Attribute))]
        public string[] Attributes { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            if (!CrmVersionManager.IsSupported(CrmVersion.CRM2015_1_RTM))
            {
                throw new NotSupportedException("Entity Keys are not supported in this version of Dynamics CRM or the SDK.");
            }
        }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case GetEntityKeyByIdParameterSet:
                    foreach (Guid id in Id)
                    {
                        WriteObject(_repository.GetEntityKey(id));
                    }
                    break;
                case GetEntityKeysByFilterParameterSet:
                    GetEntityKeyByFilter();
                    break;
                default:
                    break;
            }
        }

        private void GetEntityKeyByFilter()
        {
            IEnumerable<EntityKeyMetadata> result = _repository.GetEntityKey(Entity, ExcludeManaged.ToBool());
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

            if (Attributes != null && Attributes.Length != 0)
            {
                result = result.Where(
                    a => a.KeyAttributes.Intersect(Attributes, StringComparer.InvariantCultureIgnoreCase).Count() == Attributes.Length);
            }

            result = result.OrderBy(k => k.LogicalName);

            WriteObject(result, true);
        }
    }
}
