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
using AMSoftware.Crm.PowerShell.Common.Helpers;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands.Customizations
{
    [Cmdlet(VerbsCommon.Get, "SolutionComponent", HelpUri = HelpUrlConstants.GetSolutionComponentHelpUrl, SupportsPaging = true)]
    [OutputType(typeof(Entity))]
    public sealed class GetSolutionComponentCommand : CrmOrganizationCmdlet
    {
        private ContentRepository _repository = new ContentRepository();

        private Dictionary<int, string> _validComponentTypes;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNull]
        public Guid Solution { get; set; }

        [Parameter(Position = 2)]
        [Alias("ComponentType")]
        [ValidateNotNullOrEmpty]
        public string Type { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            _validComponentTypes = new Dictionary<int, string>(SolutionManagementHelper.GetComponentTypes());
        }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            string solutionUniqueName = SolutionManagementHelper.GetSolutionUniqueName(_repository, Solution);

            int? componentTypeValue = null;
            if (!string.IsNullOrWhiteSpace(Type))
            {
                if (int.TryParse(Type, out int typeAsInt) && _validComponentTypes.ContainsKey(typeAsInt))
                {
                    componentTypeValue = typeAsInt;
                }
                else if (_validComponentTypes.Any(v => v.Value.Equals(Type, StringComparison.InvariantCultureIgnoreCase)))
                {
                    componentTypeValue = _validComponentTypes.First(v => v.Value.Equals(Type, StringComparison.InvariantCultureIgnoreCase)).Key;
                }
                else
                {
                    throw new NotSupportedException(string.Format("ComponentType '{0}' is not supported.", Type));
                }
            }

            QueryExpression query = GetSolutionComponentQuery(Solution, componentTypeValue);

            if (PagingParameters.IncludeTotalCount)
            {
                int count = _repository.GetRowCount(query, out double accuracy);
                WriteObject(PagingParameters.NewTotalCount(Convert.ToUInt64(count), accuracy));
            }

            IEnumerable<Entity> result = _repository.Get(query, this.PagingParameters.First, this.PagingParameters.Skip);

            var groupedResult = result.GroupBy(k =>
            {
                var keyAttribute = k.GetAttributeValue<AliasedValue>("dependency.requiredcomponentobjectid");
                if (keyAttribute == null)
                {
                    return k.GetAttributeValue<Guid>("objectid");
                }
                else
                {
                    return (Guid)keyAttribute.Value;
                }
            });

            foreach (var groupResult in groupedResult)
            {
                WriteObject(groupResult.OrderBy(e => e.GetAttributeValue<OptionSetValue>("componenttype").Value), true);
            }
        }

        private QueryExpression GetSolutionComponentQuery(Guid solutionId, int? componentType)
        {
            QueryExpression query = new QueryExpression("solutioncomponent")
            {
                ColumnSet = new ColumnSet(true),
                Criteria =
                {
                    Conditions = {
                        new ConditionExpression("solutionid", ConditionOperator.Equal, solutionId)
                    }
                },
                LinkEntities =
                {
                    new LinkEntity("solutioncomponent", "dependency", "objectid", "dependentcomponentobjectid", JoinOperator.LeftOuter)
                    {
                        EntityAlias = "dependency",
                        Columns = new ColumnSet("requiredcomponentobjectid"),
                        LinkCriteria =
                        {
                            Conditions =
                            {
                                new ConditionExpression("dependencytype", ConditionOperator.Equal, 1)
                            }
                        }
                    }
                }
            };

            if (componentType.HasValue)
            {
                query.Criteria.AddCondition("componenttype", ConditionOperator.Equal, componentType.Value);
            }

            return query;
        }
    }
}
