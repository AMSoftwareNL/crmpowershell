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
using System.Xml;
using AMSoftware.Crm.PowerShell.Common.ArgumentCompleters;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace AMSoftware.Crm.PowerShell.Commands.Customizations
{
    [Cmdlet(VerbsData.Publish, "CrmComponent", HelpUri = HelpUrlConstants.PublishComponentHelpUrl, DefaultParameterSetName = PublishSolutionParameterSet)]
    public sealed class PublishComponentCommand : CrmOrganizationActionCmdlet
    {
        private const string PublishAllParameterSet = "PublishAll";
        private const string PublishSolutionParameterSet = "PublishSolution";
        private const string PublishComponentsParameterSet = "PublishComponents";

        private readonly ContentRepository _repository = new ContentRepository();

        [Parameter(ParameterSetName = PublishAllParameterSet)]
        public SwitchParameter All { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = PublishSolutionParameterSet, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Guid Solution { get; set; }

        [Parameter(ParameterSetName = PublishComponentsParameterSet)]
        [ValidateNotNull]
        [ValidateCount(1, int.MaxValue)]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string[] Entities { get; set; }

        [Parameter(ParameterSetName = PublishComponentsParameterSet)]
        [ValidateNotNull]
        [ValidateCount(1, int.MaxValue)]
        public Guid[] Webresources { get; set; }

        [Parameter(ParameterSetName = PublishComponentsParameterSet)]
        [ValidateNotNull]
        [ValidateCount(1, int.MaxValue)]
        [ArgumentCompleter(typeof(OptionSetArgumentCompleter))]
        public string[] Optionsets { get; set; }

        [Parameter(ParameterSetName = PublishComponentsParameterSet)]
        [ValidateNotNull]
        [ValidateCount(1, int.MaxValue)]
        public Guid[] Dashboards { get; set; }

        [Parameter(ParameterSetName = PublishComponentsParameterSet)]
        public SwitchParameter PublishRibbon { get; set; }

        [Parameter(ParameterSetName = PublishComponentsParameterSet)]
        public SwitchParameter PublishSiteMap { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            WriteProgress(new ProgressRecord(1, "Publishing Components", "Starting...")
            {
                RecordType = ProgressRecordType.Processing
            });
        }

        protected override void EndProcessing()
        {
            WriteProgress(new ProgressRecord(1, "Publishing Components", "Completed...")
            {
                RecordType = ProgressRecordType.Completed
            });

            base.EndProcessing();
        }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case PublishAllParameterSet:
                    PublishAll();
                    break;
                case PublishSolutionParameterSet:
                    PublishSolution();
                    break;
                case PublishComponentsParameterSet:
                    PublishComponents();
                    break;
                default:
                    break;
            }
        }

        private void PublishAll()
        {
            ExecuteAction("Organization", "PublishAll", delegate
            {
                WriteProgress(new ProgressRecord(1, "Publishing Components", "Publishing all components...")
                {
                    RecordType = ProgressRecordType.Processing
                });

                _repository.Execute(new OrganizationRequest("PublishAllXml"));
            });
        }

        private void PublishSolution()
        {
            ExecuteAction(Solution.ToString(), delegate
            {
                WriteProgress(new ProgressRecord(1, "Publishing Components", string.Format("Collecting components from solution '{0}'...", Solution))
                {
                    RecordType = ProgressRecordType.Processing
                });
                IEnumerable<PublishComponentInfo> solutioncomponents = CollectSolutionComponents(Solution);

                WriteProgress(new ProgressRecord(1, "Publishing Components", "Initializing components to publish...")
                {
                    RecordType = ProgressRecordType.Processing
                });
                solutioncomponents = InitializePublishComponents(solutioncomponents);
                string publishXml = ConstructPublishXml(
                    solutioncomponents,
                    solutioncomponents.Any(e =>
                        e.ComponentType == 48 || e.ComponentType == 49 || e.ComponentType == 50 ||
                        e.ComponentType == 52 || e.ComponentType == 53 || e.ComponentType == 55),
                    solutioncomponents.Any(e => e.ComponentType == 62));

                base.WriteVerboseWithTimestamp(publishXml);

                WriteProgress(new ProgressRecord(1, "Publishing Components", string.Format("Publishing components for solution '{0}'...", Solution))
                {
                    RecordType = ProgressRecordType.Processing
                });

                OrganizationRequest request = new OrganizationRequest("PublishXml")
                {
                    Parameters = new ParameterCollection()
                };
                request.Parameters.Add("ParameterXml", publishXml);

                OrganizationResponse response = _repository.Execute(request);
            });
        }

        private void PublishComponents()
        {
            ExecuteAction("", "Publish", delegate
            {
                WriteProgress(new ProgressRecord(1, "Publishing Components", "Initializing components to publish...")
                {
                    RecordType = ProgressRecordType.Processing
                });
                List<PublishComponentInfo> solutioncomponents = new List<PublishComponentInfo>();
                if (Entities != null && Entities.Length > 0)
                {
                    solutioncomponents.AddRange(Entities.Select(e => new PublishComponentInfo()
                    {
                        ComponentType = 1,
                        LogicalName = e
                    }));
                }

                if (Optionsets != null && Optionsets.Length > 0)
                {
                    solutioncomponents.AddRange(Optionsets.Select(e => new PublishComponentInfo()
                    {
                        ComponentType = 9,
                        LogicalName = e
                    }));
                }

                if (Dashboards != null && Dashboards.Length > 0)
                {
                    solutioncomponents.AddRange(Dashboards.Select(e => new PublishComponentInfo()
                    {
                        ComponentType = 60,
                        ObjectId = e
                    }));
                }

                if (Webresources != null && Webresources.Length > 0)
                {
                    solutioncomponents.AddRange(Webresources.Select(e => new PublishComponentInfo()
                    {
                        ComponentType = 61,
                        ObjectId = e
                    }));
                }

                string publishXml = ConstructPublishXml(solutioncomponents, PublishRibbon.ToBool(), PublishSiteMap.ToBool());

                base.WriteVerboseWithTimestamp(publishXml);
                WriteProgress(new ProgressRecord(1, "Publishing Components", "Publishing selected components...")
                {
                    RecordType = ProgressRecordType.Processing
                });

                OrganizationRequest request = new OrganizationRequest("PublishXml")
                {
                    Parameters = new ParameterCollection()
                };
                request.Parameters.Add("ParameterXml", publishXml);

                OrganizationResponse response = _repository.Execute(request);
            });
        }

        private IEnumerable<PublishComponentInfo> CollectSolutionComponents(Guid solutionId)
        {
            QueryExpression query = BuildSolutionComponentsQuery(solutionId);
            return _repository.Get(query).Select(e => new PublishComponentInfo()
            {
                ComponentType = e.GetAttributeValue<OptionSetValue>("componenttype").Value,
                ObjectId = e.GetAttributeValue<Guid>("objectid")
            });
        }

        private static QueryExpression BuildSolutionComponentsQuery(Guid solutionId)
        {
            /**
            1   Entiteit
            9   Optieset
            48  Lintopdracht
            49  Lintcontextgroep
            50  Lint aanpassen
            52  Lintregel
            53  Toewijzing linttabblad aan opdracht
            55  Verschil op lint
            60  Systeemformulier
            61  Webresource
            62  Siteoverzicht
            **/

            QueryExpression query = new QueryExpression("solutioncomponent")
            {
                ColumnSet = new ColumnSet("solutioncomponentid", "objectid", "componenttype"),
                Criteria =
                {
                    Conditions ={
                        new ConditionExpression("componenttype", ConditionOperator.In, 1,9,60,61,62,48,49,50,52,53,55),
                        new ConditionExpression("solutionid", ConditionOperator.Equal, solutionId)
                    }
                }
            };

            return query;
        }

        private static string ConstructPublishXml(IEnumerable<PublishComponentInfo> solutioncomponents, bool includeRibbon, bool includeSiteMap)
        {
            XmlDocument xDoc = new XmlDocument();
            XmlElement xRoot = xDoc.CreateElement("importexportxml");
            XmlElement xEntities = xDoc.CreateElement("entities");
            XmlElement xWebresources = xDoc.CreateElement("webresources");
            XmlElement xDashboards = xDoc.CreateElement("dashboards");
            XmlElement xOptionsets = xDoc.CreateElement("optionsets");

            foreach (var solutioncomponent in solutioncomponents.Where(e => e.ComponentType == 1))
            {
                XmlElement xEntity = xDoc.CreateElement("entity");
                xEntity.InnerText = solutioncomponent.LogicalName;
                xEntities.AppendChild(xEntity);
            }
            if (xEntities.HasChildNodes)
            {
                xRoot.AppendChild(xEntities);
            }

            foreach (var solutioncomponent in solutioncomponents.Where(e => e.ComponentType == 9))
            {
                XmlElement xOptionset = xDoc.CreateElement("optionset");
                xOptionset.InnerText = solutioncomponent.LogicalName;
                xOptionsets.AppendChild(xOptionset);
            }
            if (xOptionsets.HasChildNodes)
            {
                xRoot.AppendChild(xOptionsets);
            }

            foreach (var solutioncomponent in solutioncomponents.Where(e => e.ComponentType == 60))
            {
                XmlElement xDashboard = xDoc.CreateElement("dashboard");
                xDashboard.InnerText = solutioncomponent.ObjectId.ToString("B");
                xDashboards.AppendChild(xDashboard);
            }
            if (xDashboards.HasChildNodes)
            {
                xRoot.AppendChild(xDashboards);
            }

            foreach (var solutioncomponent in solutioncomponents.Where(e => e.ComponentType == 61))
            {
                XmlElement xWebresource = xDoc.CreateElement("webresource");
                xWebresource.InnerText = solutioncomponent.ObjectId.ToString("B");
                xWebresources.AppendChild(xWebresource);
            }
            if (xWebresources.HasChildNodes)
            {
                xRoot.AppendChild(xWebresources);
            }

            if (includeSiteMap)
            {
                XmlElement xSitemaps = xDoc.CreateElement("sitemaps");
                XmlElement xSitemap = xDoc.CreateElement("sitemap");
                xSitemaps.AppendChild(xSitemap);
                xRoot.AppendChild(xSitemaps);
            }

            if (includeRibbon)
            {
                XmlElement xRibbons = xDoc.CreateElement("ribbons");
                XmlElement xRibbon = xDoc.CreateElement("ribbon");
                xRibbons.AppendChild(xRibbon);
                xRoot.AppendChild(xRibbons);
            }

            return xRoot.OuterXml;
        }

        private static IEnumerable<PublishComponentInfo> InitializePublishComponents(IEnumerable<PublishComponentInfo> componentinfos)
        {
            MetadataRepository metadataRepository = new MetadataRepository();

            //var componentinfosp = componentinfos.AsParallel();
            var result = componentinfos.ToList();

            foreach (var a in result)
            {
                switch (a.ComponentType)
                {
                    case 1:     //Entity -> Need the logical name
                        if (string.IsNullOrWhiteSpace(a.LogicalName) && a.ObjectId != Guid.Empty)
                        {
                            a.LogicalName = metadataRepository.GetEntity(a.ObjectId).LogicalName;
                        }
                        break;
                    case 9:     //Optionset -> Need the logical name
                        if (string.IsNullOrWhiteSpace(a.LogicalName) && a.ObjectId != Guid.Empty)
                        {
                            a.LogicalName = metadataRepository.GetOptionSet(a.ObjectId).Name;
                        }
                        break;
                    default:
                        break;
                }
            }

            return result;
        }

        private class PublishComponentInfo
        {
            public int ComponentType { get; set; }
            public Guid ObjectId { get; set; }
            public string LogicalName { get; set; }
        }
    }
}
