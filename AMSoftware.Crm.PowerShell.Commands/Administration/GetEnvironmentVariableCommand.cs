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
using System.Linq;
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace AMSoftware.Crm.PowerShell.Commands.Administration
{
    [Cmdlet(VerbsCommon.Get, "CrmEnvironmentVariable", HelpUri = HelpUrlConstants.GetEnvironmentVariableHelpUrl, SupportsPaging = true, DefaultParameterSetName = GetAllEnvironmentVariablesParameterSet)]
    [OutputType(typeof(Entity))]
    public sealed class GetEnvironmentVariableCommand : CrmOrganizationCmdlet
    {
        private const string GetAllEnvironmentVariablesParameterSet = "GetAllEnvironmentVariables";
        private const string GetEnvironmentVariableByIdParameterSet = "GetEnvironmentVariableById";

        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = GetEnvironmentVariableByIdParameterSet, ValueFromPipeline = true)]
        [ValidateNotNull]
        public Guid[] Id { get; set; }

        [Parameter(ParameterSetName = GetAllEnvironmentVariablesParameterSet, Position = 0)]
        [Alias("Include")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(ParameterSetName = GetAllEnvironmentVariablesParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Exclude { get; set; }

        [Parameter(ParameterSetName = GetAllEnvironmentVariablesParameterSet)]
        [ValidateNotNullOrEmpty]
        [PSDefaultValue(Value = CrmEnvironmentVariableType.All)]
        public CrmEnvironmentVariableType VariableType { get; set; }

        [Parameter(ParameterSetName = GetAllEnvironmentVariablesParameterSet)]
        [ValidateNotNullOrEmpty]
        public Guid SolutionId { get; set; }


        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case GetAllEnvironmentVariablesParameterSet:
                    GetFilteredContent();
                    break;
                case GetEnvironmentVariableByIdParameterSet:
                    foreach (Guid id in Id)
                    {
                        WriteObject(_repository.Get("environmentvariabledefinition", id));
                    }
                    break;
                default:
                    break;
            }
        }

        private void GetFilteredContent()
        {
            QueryExpression advancedFilterQuery = BuildEnvironmentVariableByFilterQuery();

            if (PagingParameters.IncludeTotalCount)
            {
                int count = _repository.GetRowCount(advancedFilterQuery, out double accuracy);
                WriteObject(PagingParameters.NewTotalCount(Convert.ToUInt64(count), accuracy));
            }

            var result = _repository.Get(advancedFilterQuery, PagingParameters.First, PagingParameters.Skip);
            if (!string.IsNullOrWhiteSpace(Name))
            {
                WildcardPattern includePattern = new WildcardPattern(Name, WildcardOptions.IgnoreCase);
                result = result.Where(a =>
                    includePattern.IsMatch(a.GetAttributeValue<string>("displayname")) ||
                    includePattern.IsMatch(a.GetAttributeValue<string>("schemaname"))
                );
            }
            if (!string.IsNullOrWhiteSpace(Exclude))
            {
                WildcardPattern excludePattern = new WildcardPattern(Exclude, WildcardOptions.IgnoreCase);
                result = result.Where(a =>
                    !(
                        excludePattern.IsMatch(a.GetAttributeValue<string>("displayname")) ||
                        excludePattern.IsMatch(a.GetAttributeValue<string>("schemaname"))
                    )
                );
            }

            WriteObject(result, true);
        }

        private QueryExpression BuildEnvironmentVariableByFilterQuery()
        {
            QueryExpression query = new QueryExpression("environmentvariabledefinition")
            {
                ColumnSet = new ColumnSet(true),
                Orders =
                {
                    new OrderExpression("schemaname", OrderType.Ascending)
                }
            };

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(VariableType)) && VariableType != CrmEnvironmentVariableType.All)
            {
                query.Criteria.AddCondition("type", ConditionOperator.Equal, (int)VariableType);
            }

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(SolutionId)) && SolutionId != Guid.Empty)
            {
                query.Criteria.AddCondition("solutionid", ConditionOperator.Equal, SolutionId);
            }
            return query;
        }
    }

    [Cmdlet(VerbsCommon.Get, "CrmEnvironmentVariableValue", HelpUri = HelpUrlConstants.GetEnvironmentVariableValueHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class GetEnvironmentVariableValueCommand : CrmOrganizationCmdlet
    {
        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [Alias("Id")]
        public Guid[] EnvironmentVariableId { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            foreach (Guid id in EnvironmentVariableId)
            {
                QueryExpression query = new QueryExpression("environmentvariablevalue")
                {
                    ColumnSet = new ColumnSet(true),
                    Criteria =
                    {
                        Conditions =
                        {
                            new ConditionExpression("environmentvariabledefinitionid", ConditionOperator.Equal, id)
                        }
                    }
                };

                var result = _repository.Get(query, 1).FirstOrDefault();
                if (result != default)
                {
                    WriteObject(result);
                }
            }
        }
    }
}
