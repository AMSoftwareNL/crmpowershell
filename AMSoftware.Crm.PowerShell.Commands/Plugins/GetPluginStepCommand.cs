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
using AMSoftware.Crm.PowerShell.Common.Helpers;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace AMSoftware.Crm.PowerShell.Commands.Plugins
{
    [Cmdlet(VerbsCommon.Get, "CrmPluginStep", HelpUri = HelpUrlConstants.GetPluginStepHelpUrl, SupportsPaging = true, DefaultParameterSetName = GetPluginStepByFilterParameterSet)]
    [OutputType(typeof(Entity))]
    public sealed class GetPluginStepCommand : CrmOrganizationCmdlet
    {
        private const string GetPluginStepByIdParameterSet = "GetPluginStepById";
        private const string GetPluginStepByFilterParameterSet = "GetPluginStepByFilter";

        private ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, ParameterSetName = GetPluginStepByIdParameterSet)]
        [ValidateNotNull]
        public Guid Id { get; set; }

        [Parameter(Position = 1, ParameterSetName = GetPluginStepByFilterParameterSet, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Guid EventSource { get; set; }

        [Parameter(ParameterSetName = GetPluginStepByFilterParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Message { get; set; }

        [Parameter(ParameterSetName = GetPluginStepByFilterParameterSet)]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string Entity { get; set; }

        [Parameter(ParameterSetName = GetPluginStepByFilterParameterSet)]
        [ValidateNotNull]
        public CrmPluginStepStage? Stage { get; set; }

        [Parameter(ParameterSetName = GetPluginStepByFilterParameterSet)]
        [ValidateNotNull]
        public CrmPluginStepMode? Mode { get; set; }

        [Parameter(ParameterSetName = GetPluginStepByFilterParameterSet)]
        public SwitchParameter IncludeInternalStages { get; set; }

        [Parameter(ParameterSetName = GetPluginStepByFilterParameterSet)]
        public SwitchParameter IncludeHidden { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case GetPluginStepByIdParameterSet:
                    WriteObject(_repository.Get("sdkmessageprocessingstep", Id));
                    break;
                case GetPluginStepByFilterParameterSet:
                    QueryExpression query = BuildPluginStepByFilterQuery();
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
                int count = _repository.GetRowCount(query, out double accuracy);
                WriteObject(PagingParameters.NewTotalCount(Convert.ToUInt64(count), accuracy));
            }

            foreach (var item in _repository.Get(query, PagingParameters.First, PagingParameters.Skip))
            {
                WriteObject(item);
            }
        }

        private QueryExpression BuildPluginStepByFilterQuery()
        {
            QueryExpression query = new QueryExpression("sdkmessageprocessingstep")
            {
                ColumnSet = new ColumnSet(true),
                Orders = {
                    new OrderExpression("name", OrderType.Ascending),
                    new OrderExpression("stage", OrderType.Ascending)
                }
            };

            FilterExpression filter = new FilterExpression(LogicalOperator.And);
            if (EventSource != Guid.Empty) filter.AddCondition("eventhandler", ConditionOperator.Equal, EventSource);
            if (Stage != null) filter.AddCondition("stage", ConditionOperator.Equal, (int)Stage);
            if (Mode != null) filter.AddCondition("mode", ConditionOperator.Equal, (int)Mode);
            if (!IncludeInternalStages.IsPresent) filter.AddCondition("stage", ConditionOperator.In, 10, 20, 40);
            if (!IncludeHidden.IsPresent) filter.AddCondition("ishidden", ConditionOperator.Equal, false);

            if (!string.IsNullOrWhiteSpace(Message))
            {
                Guid messageId = PluginManagementHelper.GetSdkMessageId(_repository, Message);
                filter.AddCondition("sdkmessageid", ConditionOperator.Equal, messageId);
            }
            if (!string.IsNullOrWhiteSpace(Entity))
            {
                IEnumerable<Guid> filterIds = PluginManagementHelper.GetSdkMessageFilterIds(_repository, Entity);
                filter.Conditions.Add(new ConditionExpression("sdkmessagefilterid", ConditionOperator.In, filterIds.ToArray()));
            }

            if (filter.Conditions.Count > 0)
            {
                query.Criteria.AddFilter(filter);
            }

            return query;
        }
    }
}
