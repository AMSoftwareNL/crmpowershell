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
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections;
using System.Management.Automation;

namespace AMSoftware.Crm.PowerShell.Commands.Administration
{
    [Cmdlet(VerbsCommon.Get, "CrmSPDocumentLocation", HelpUri = HelpUrlConstants.GetSPDocumentLocationHelpUrl, DefaultParameterSetName = GetBySharePointDocumentLocationIdParameterSet)]
    [OutputType(typeof(RetrieveAbsoluteAndSiteCollectionUrlResponse))]
    public class GetSPDocucmentLocationCommand : CrmOrganizationCmdlet
    {
        private const string GetBySharePointDocumentLocationIdParameterSet = "GetBySharePointDocumentLocationId";
        private const string GetByRegardingObjectIdParameterSet = "GetByRegardingObjectId";

        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = GetBySharePointDocumentLocationIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public Guid[] Id { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = GetByRegardingObjectIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public Guid[] RegardingObjectId { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case GetBySharePointDocumentLocationIdParameterSet:
                    {
                        foreach (var locationId in Id)
                        {
                            RetrieveUrlById(locationId);
                        }
                        break;
                    }
                case GetByRegardingObjectIdParameterSet:
                    {
                        foreach (var regardingId in RegardingObjectId)
                        {
                            QueryByAttribute query = new QueryByAttribute("sharepointdocumentlocation");
                            query.AddAttributeValue("regardingobjectid", regardingId);
                            var doclocresult = _repository.Get(query);
                            foreach (var docloc in doclocresult)
                            {
                                RetrieveUrlById(docloc.Id);
                            }
                        }
                        break;
                    }
            }
        }

        private void RetrieveUrlById(Guid id)
        {
            OrganizationResponse response = _repository.Execute("RetrieveAbsoluteAndSiteCollectionUrl", new Hashtable() {
                { "Target", new EntityReference("sharepointdocumentlocation", id) }
            });

            WriteObject(response);
        }
    }
}
