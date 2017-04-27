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
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk.Metadata;

namespace AMSoftware.Crm.PowerShell.Commands.Metadata
{
    [Cmdlet(VerbsCommon.Set, "RelationshipCascadeConfig", HelpUri = HelpUrlConstants.SetRelationshipCascadeConfigHelpUrl)]
    public sealed class SetRelationshipCascadeConfigCommand : CrmOrganizationCmdlet
    {
        private MetadataRepository _repository = new MetadataRepository();

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateNotNullOrEmpty]
        public string Relationship { get; set; }

        [Parameter]
        public CrmCascadeType? Assign  { get; set; }
        
        [Parameter]
        public CrmCascadeType? Delete  { get; set; }
        
        [Parameter]
        public CrmCascadeType? Merge  { get; set; }
        
        [Parameter]
        public CrmCascadeType? Reparent  { get; set; }
        
        [Parameter]
        public CrmCascadeType? Share  { get; set; }
        
        [Parameter]
        public CrmCascadeType? Unshare  { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            CascadeConfiguration config = new CascadeConfiguration();
            if (Assign.HasValue) config.Assign = ToCrmEnum(Assign.Value);
            if (Delete.HasValue) config.Delete = ToCrmEnum(Delete.Value);
            if (Merge.HasValue) config.Merge = ToCrmEnum(Merge.Value);
            if (Reparent.HasValue) config.Reparent = ToCrmEnum(Reparent.Value);
            if (Share.HasValue) config.Share = ToCrmEnum(Share.Value);
            if (Unshare.HasValue) config.Unshare = ToCrmEnum(Unshare.Value);

            OneToManyRelationshipMetadata relationship = new OneToManyRelationshipMetadata()
            {
                SchemaName = Relationship,
                CascadeConfiguration = config
            };

            _repository.UpdateRelationship(relationship);
        }

        private CascadeType ToCrmEnum(CrmCascadeType value)
        {
            switch (value)
            {
                case CrmCascadeType.None:
                    return CascadeType.NoCascade;
                case CrmCascadeType.Cascade:
                    return CascadeType.Cascade;
                case CrmCascadeType.Active:
                    return CascadeType.Active;
                case CrmCascadeType.UserOwned:
                    return CascadeType.UserOwned;
                case CrmCascadeType.RemoveLink:
                    return CascadeType.RemoveLink;
                case CrmCascadeType.Restrict:
                    return CascadeType.Restrict;
                default:
                    return CascadeType.NoCascade;
            }
        }
    }
}
