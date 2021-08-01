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

namespace AMSoftware.Crm.PowerShell.Commands.Administration
{
    [Cmdlet(VerbsCommon.New, "CrmEnvironmentVariable", HelpUri = HelpUrlConstants.NewEnvironmentVariableHelpUrl)]
    [OutputType(typeof(Entity))]
    public sealed class NewEnvironmentVariableCommand : CrmOrganizationCmdlet
    {
        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter()]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public CrmEnvironmentVariableType VariableType { get; set; }

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

            switch (VariableType)
            {
                case CrmEnvironmentVariableType.All:
                    throw new PSNotSupportedException("Type 'All' is not a supported EnvironmentVariable Type.");
                case CrmEnvironmentVariableType.String:
                    break;
                case CrmEnvironmentVariableType.Number:
                    break;
                case CrmEnvironmentVariableType.Boolean:
                    break;
                case CrmEnvironmentVariableType.JSON:
                    break;
                case CrmEnvironmentVariableType.DataSource:
                    throw new PSNotImplementedException();
                default:
                    break;
            }

            Entity newEnvironmentVariable = new Entity("environmentvariabledefinition")
            {
                Attributes = new AttributeCollection()
            };
            newEnvironmentVariable.Attributes.Add("schemaname", Name);
            newEnvironmentVariable.Attributes.Add("displayname", DisplayName);
            newEnvironmentVariable.Attributes.Add("type", new OptionSetValue((int)VariableType));

            if (!string.IsNullOrWhiteSpace(Description))
            {
                newEnvironmentVariable.Attributes.Add("description", Description);
            }

            if (DefaultValue != null)
            {
                newEnvironmentVariable.Attributes.Add("defaultvalue", DefaultValue);
            }

            Guid newEnvironmentVariableId = _repository.Add(newEnvironmentVariable);

            if (Value != null)
            {
                Entity newEnvironmentVariableValue = new Entity("environmentvariablevalue")
                {
                    Attributes = new AttributeCollection()
                };
                newEnvironmentVariableValue.Attributes.Add("environmentvariabledefinitionid", new EntityReference("environmentvariabledefinition", newEnvironmentVariableId));
                newEnvironmentVariableValue.Attributes.Add("value", Value);
                _repository.Add(newEnvironmentVariableValue);
            }

            if (PassThru)
            {
                WriteObject(_repository.Get("environmentvariabledefinition", newEnvironmentVariableId));
            }
        }
    }
}
