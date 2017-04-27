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
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace AMSoftware.Crm.PowerShell.Commands.Plugins
{
    [Cmdlet(VerbsCommon.Get, "PluginImage", HelpUri = HelpUrlConstants.GetPluginImageHelpUrl, SupportsPaging = true, DefaultParameterSetName = GetPluginImageByFilterParameterSet)]
    [OutputType(typeof(Entity))]
    public sealed class GetPluginImageCommand : CrmOrganizationCmdlet
    {
        private const string GetPluginImageByIdParameterSet = "GetPluginImageById";
        private const string GetPluginImageByFilterParameterSet = "GetPluginIMageByFilter";

        private ContentRepository _repository = new ContentRepository();

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = GetPluginImageByIdParameterSet)]
        [ValidateNotNull]
        public Guid Id { get; set; }

        [Parameter(Position = 1, ValueFromPipeline = true, ParameterSetName = GetPluginImageByFilterParameterSet)]
        [ValidateNotNullOrEmpty]
        public Guid PluginStep { get; set; }

        [Parameter(ParameterSetName = GetPluginImageByFilterParameterSet)]
        [ValidateNotNull]
        public CrmPluginImageType? ImageType { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case GetPluginImageByIdParameterSet:
                    WriteObject(_repository.Get("sdkmessageprocessingstepimage", Id));
                    break;
                case GetPluginImageByFilterParameterSet:
                    QueryExpression query = BuildPluginImageByFilterQuery();
                    GetContentByQuery(query);
                    break;
                default:
                    break;
            }
        }

        private void GetContentByQuery(QueryBase query)
        {
            if (PagingParameters.IncludeTotalCount)
            {
                double accuracy;
                int count = _repository.GetRowCount(query, out accuracy);
                WriteObject(PagingParameters.NewTotalCount(Convert.ToUInt64(count), accuracy));
            }

            foreach (var item in _repository.Get(query, PagingParameters.First, PagingParameters.Skip))
            {
                WriteObject(item);
            }
        }

        private QueryExpression BuildPluginImageByFilterQuery()
        {
            QueryExpression query = new QueryExpression("sdkmessageprocessingstepimage")
            {
                ColumnSet = new ColumnSet(true),
            };

            FilterExpression filter = new FilterExpression(LogicalOperator.And);
            if (PluginStep != Guid.Empty) filter.AddCondition("sdkmessageprocessingstepid", ConditionOperator.Equal, PluginStep);
            if (ImageType != null) filter.AddCondition("imagetype", ConditionOperator.Equal, (int)ImageType);

            if (filter.Conditions.Count > 0)
            {
                query.Criteria.AddFilter(filter);
            }

            return query;
        }
    }
}
