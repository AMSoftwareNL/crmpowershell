using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.ArgumentCompleters;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace AMSoftware.Crm.PowerShell.Commands.Administration
{
    [Cmdlet(VerbsCommon.Get, "CrmSPDocumentLocation", HelpUri = HelpUrlConstants.GetSPDocumentLocationHelpUrl, SupportsPaging = true, DefaultParameterSetName = GetBySharePointDocumentLocationId)]
    [OutputType(typeof(RetrieveAbsoluteAndSiteCollectionUrlResponse))]
    public class GetSPDocucmentLocationCommand : CrmOrganizationCmdlet
    {
        private const string GetBySharePointDocumentLocationId = "GetBySharePointDocumentLocationId";

        [Parameter(Mandatory = true, Position = 0,ParameterSetName = GetBySharePointDocumentLocationId)]
        [ValidateNotNullOrEmpty]
        [Alias("Id")]
        public Guid[] SharePointDocumentLocationId { get; set; }

        private const string GetByRegardingObjectId = "GetByRegardingObjectId";

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = GetByRegardingObjectId)]
        [ValidateNotNullOrEmpty]
        public Guid[] RegardingObjectId { get; set; }

        private ContentRepository _repository = new ContentRepository();
        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case GetBySharePointDocumentLocationId:
                    {
                        foreach (var id in SharePointDocumentLocationId)
                        {
                            RetrieveUrlById(id);
                        }
                        break;
                    }
                case GetByRegardingObjectId:
                    {
                        foreach (var id in RegardingObjectId)
                        {
                            QueryByAttribute query = new QueryByAttribute("sharepointdocumentlocation");
                            query.AddAttributeValue("regardingobjectid", id);
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
            var sourceUrlRequest = new RetrieveAbsoluteAndSiteCollectionUrlRequest
            {
                Target = new EntityReference("sharepointdocumentlocation", id)
            };
            var sourceUrlResponse = (RetrieveAbsoluteAndSiteCollectionUrlResponse)CrmContext.OrganizationProxy.Execute(sourceUrlRequest);
            WriteObject(sourceUrlResponse);
        }
    }
}
