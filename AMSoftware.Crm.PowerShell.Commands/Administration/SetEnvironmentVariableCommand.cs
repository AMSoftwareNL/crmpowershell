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
    [Cmdlet(VerbsCommon.Set, "CrmEnvironmentVariable", HelpUri = HelpUrlConstants.SetEnvironmentVariableHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class SetEnvironmentVariableCommand : CrmOrganizationCmdlet
    {
        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("Id")]
        public Guid[] EnvironmentVariableId { get; set; }

        [Parameter()]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter()]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter()]
        [ValidateNotNullOrEmpty]
        public object DefaultValue { get; set; }

        [Parameter()]
        [ValidateNotNullOrEmpty]
        public object Value { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            foreach (Guid id in EnvironmentVariableId)
            {
                Entity updatedEnvironmentVariable = new Entity("environmentvariabledefinition", id)
                {
                    Attributes = new AttributeCollection()
                };

                if (this.MyInvocation.BoundParameters.ContainsKey(nameof(DisplayName)))
                    updatedEnvironmentVariable.Attributes.Add("displayname", DisplayName);
                if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Description)))
                    updatedEnvironmentVariable.Attributes.Add("description", Description);
                if (this.MyInvocation.BoundParameters.ContainsKey(nameof(DefaultValue)))
                    updatedEnvironmentVariable.Attributes.Add("defaultvalue", DefaultValue);

                if (updatedEnvironmentVariable.Attributes.Count != 0)
                {
                    _repository.Update(updatedEnvironmentVariable);
                }

                if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Value)))
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
                    var values = _repository.Get(query).FirstOrDefault();

                    if (values == null) {
                        Entity newEnvironmentVariableValue = new Entity("environmentvariablevalue")
                        {
                            Attributes = new AttributeCollection()
                        };
                        newEnvironmentVariableValue.Attributes.Add("environmentvariabledefinitionid", new EntityReference("environmentvariabledefinition", id));
                        newEnvironmentVariableValue.Attributes.Add("value", Value);
                        _repository.Add(newEnvironmentVariableValue);
                    } else
                    {
                        values.Attributes["value"] = Value;
                        _repository.Update(values);
                    }
                }

                if (PassThru)
                {
                    WriteObject(_repository.Get("environmentvariabledefinition", id));
                }
            }
        }
    }
}
