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
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands.Administration
{
    [Cmdlet(VerbsCommon.Remove, "CrmEnvironmentVariable", HelpUri = HelpUrlConstants.RemoveEnvironmentVariableHelpUrl)]
    public sealed class RemoveEnvironmentVariableCommand : CrmOrganizationConfirmActionCmdlet
    {
        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [Alias("Id")]
        [ValidateNotNull]
        public Guid[] EnvironmentVariableId { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            foreach (Guid id in EnvironmentVariableId)
            {
                ExecuteAction(id.ToString(), "Remove", () =>
                {
                    _repository.Delete("environmentvariabledefinition", id);
                });
            }
        }
    }

    [Cmdlet(VerbsCommon.Remove, "CrmEnvironmentVariableValue", HelpUri = HelpUrlConstants.RemoveEnvironmentVariableValueHelpUrl)]
    public sealed class RemoveEnvironmentVariableValueCommand : CrmOrganizationConfirmActionCmdlet
    {
        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [Alias("Id")]
        [ValidateNotNull]
        public Guid[] EnvironmentVariableId { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            foreach (Guid environmentVariableId in EnvironmentVariableId)
            {
                QueryExpression query = new QueryExpression("environmentvariablevalue")
                {
                    ColumnSet = new ColumnSet("environmentvariablevalueid"),
                    Criteria =
                    {
                        Conditions =
                        {
                            new ConditionExpression("environmentvariabledefinitionid", ConditionOperator.Equal, environmentVariableId)
                        }
                    }
                };
                var values = _repository.Get(query);

                foreach (var value in values)
                {
                    ExecuteAction(value.Id.ToString(), "Remove", () =>
                     {
                         _repository.Delete("environmentvariablevalue", value.Id);
                     });
                }
            }
        }
    }
}
