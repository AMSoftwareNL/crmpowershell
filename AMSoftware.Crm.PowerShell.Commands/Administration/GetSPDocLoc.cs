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
    [Cmdlet(VerbsCommon.Get, "CrmSPDocLoc", HelpUri = HelpUrlConstants.GetRoleHelpUrl, SupportsPaging = true, DefaultParameterSetName = "")]
    [OutputType(typeof(Entity))]
    public class GetSPDocucmentLocationCommand :CrmOrganizationCmdlet
    {
        [Parameter(Mandatory = true)]
        public Guid[] Id { get; set; }

        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        [Parameter]
        public string Entity { get; set; }
        private ContentRepository _repository = new ContentRepository();
        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if (String.IsNullOrEmpty(Entity))
            {
                foreach (var id in Id)
                {
                    RetrieveUrlById(id);
                }

            }
            else
            {
                foreach (var id in Id)
                {
                    QueryByAttribute query = new QueryByAttribute("sharepointdocumentlocation");
                    query.AddAttributeValue("regardingobjectid", id);
                    var doclocresult = _repository.Get(query);
                    foreach (var docloc in doclocresult)
                    {
                        RetrieveUrlById(docloc.Id);
                    }
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
