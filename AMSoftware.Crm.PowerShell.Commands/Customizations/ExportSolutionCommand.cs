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
using System.Collections;
using System.IO;
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.Helpers;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;

namespace AMSoftware.Crm.PowerShell.Commands.Customizations
{
    [Cmdlet(VerbsData.Export, "CrmSolution", HelpUri = HelpUrlConstants.ExportSolutionHelpUrl)]
    public sealed class ExportSolutionCommand : CrmOrganizationCmdlet, IDynamicParameters
    {
        private readonly ContentRepository _repository = new ContentRepository();
        private ExportSolutionDynamicParameters _context;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        [ValidateNotNull]
        public Guid Id { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter]
        public SwitchParameter Managed { get; set; }

        [Parameter]
        public SwitchParameter AutoNumberingSettings { get; set; }

        [Parameter]
        public SwitchParameter CalendarSettings { get; set; }

        [Parameter]
        public SwitchParameter CustomizationSettings { get; set; }

        [Parameter]
        public SwitchParameter EmailTrackingSettings { get; set; }

        [Parameter]
        public SwitchParameter GeneralSettings { get; set; }

        [Parameter]
        public SwitchParameter IsvConfig { get; set; }

        [Parameter]
        public SwitchParameter MarketingSettings { get; set; }

        [Parameter]
        public SwitchParameter OutlookSynchronizationSettings { get; set; }

        [Parameter]
        public SwitchParameter RelationshipRoles { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Hashtable requestParameters = new Hashtable()
            {
                { "SolutionName", SolutionManagementHelper.GetSolutionUniqueName(_repository, Id, false) },
                { "ExportAutoNumberingSettings", AutoNumberingSettings.ToBool() },
                { "ExportCalendarSettings", CalendarSettings.ToBool() },
                { "ExportCustomizationSettings",CustomizationSettings.ToBool() },
                { "ExportEmailTrackingSettings",EmailTrackingSettings.ToBool() },
                { "ExportGeneralSettings", GeneralSettings.ToBool()},
                { "ExportIsvConfig", IsvConfig.ToBool()},
                { "ExportMarketingSettings",MarketingSettings.ToBool() },
                { "ExportOutlookSynchronizationSettings",OutlookSynchronizationSettings.ToBool() },
                { "ExportRelationshipRoles", RelationshipRoles.ToBool()},
                { "Managed", Managed.ToBool() }
            };

            if (_context != null)
            {
                _context.SetParametersOnRequest(requestParameters);
            }

            OrganizationResponse response = _repository.Execute("ExportSolution", requestParameters);

            File.WriteAllBytes(Path, (byte[])response.Results["ExportSolutionFile"]);
        }

        public object GetDynamicParameters()
        {
            if (CrmVersionManager.IsSupported(CrmVersion.CRM2015_RTM))
            {
                _context = new ExportSolutionDynamicParameters2015();
            }

            return _context;
        }
    }

    public abstract class ExportSolutionDynamicParameters
    {
        internal protected virtual void SetParametersOnRequest(Hashtable requestParameters)
        {
        }
    }

    public sealed class ExportSolutionDynamicParameters2015 : ExportSolutionDynamicParameters
    {
        [Parameter]
        [ValidateNotNull]
        [ValidatePattern(@"^\d+(\.\d+){1,3}$")]
        public string Target { get; set; }

        protected internal override void SetParametersOnRequest(Hashtable requestParameters)
        {
            base.SetParametersOnRequest(requestParameters);

            if (!string.IsNullOrWhiteSpace(Target))
            {
                requestParameters.Add("TargetVersion", Target);
            }
        }
    }
}
