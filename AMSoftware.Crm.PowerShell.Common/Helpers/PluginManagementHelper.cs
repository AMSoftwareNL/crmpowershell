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
using System.Text;
using System.Threading.Tasks;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace AMSoftware.Crm.PowerShell.Common.Helpers
{
    internal sealed class PluginManagementHelper
    {
        public static Guid GetSdkMessageId(ContentRepository repository, string messageName)
        {
            QueryExpression query = new QueryExpression("sdkmessage")
            {
                ColumnSet = new ColumnSet("sdkmessageid"),
                Criteria =
                {
                    Conditions = {
                        new ConditionExpression("isprivate", ConditionOperator.Equal, false),
                        new ConditionExpression("name", ConditionOperator.Equal, messageName)
                    }
                }
            };

            IList<Guid> messages = repository.Get(query).Select(e => e.Id).ToList();
            if (messages.Count == 0)
            {
                throw new Exception("Unknown SDK Message.");
            }
            else if (messages.Count != 1)
            {
                throw new Exception("SDK Message is not unique.");
            }
            else
            {
                return messages[0];
            }
        }

        public static IEnumerable<Guid> GetSdkMessageFilterIds(ContentRepository repository, string entityName)
        {
            QueryExpression query = new QueryExpression("sdkmessagefilter")
            {
                ColumnSet = new ColumnSet("sdkmessagefilterid"),
                Criteria =
                {
                    Conditions = {
                        new ConditionExpression("primaryobjecttypecode", ConditionOperator.Equal, entityName)
                    }
                }
            };

            return repository.Get(query).Select(e => e.Id).ToList();
        }

        public static PluginAssemblyInfo RetrievePluginAssemblyInfo(string pathToAssembly)
        {
            PluginAssemblyInfo result;
            using (AppDomainContext<PluginAssemblyReader> appDomainContext = new AppDomainContext<PluginAssemblyReader>(string.Empty))
            {
                result = appDomainContext.Proxy.RetrievePluginAssemblyInfo(pathToAssembly);
            }

            return result;
        }

        public static void RefreshFromExistingAssembly(ContentRepository _repository, PluginAssemblyInfo assemblyInfo)
        {
            QueryByAttribute query = new QueryByAttribute("pluginassembly");
            query.ColumnSet = new ColumnSet(true);
            query.AddAttributeValue("name", assemblyInfo.Name);
            Entity crmPluginAssembly = _repository.Get(query).SingleOrDefault();
            if (crmPluginAssembly == null)
            {
                return;
            }
            assemblyInfo.AssemblyId = crmPluginAssembly.Id;
            if (crmPluginAssembly.Contains("description"))
            {
                assemblyInfo.Description = crmPluginAssembly.GetAttributeValue<string>("description");
            }

            query = new QueryByAttribute("plugintype");
            query.ColumnSet = new ColumnSet(true);
            query.AddAttributeValue("pluginassemblyid", assemblyInfo.AssemblyId);

            foreach (Entity crmPluginType in _repository.Get(query))
            {
                PluginTypeInfo typeInfo = assemblyInfo.Plugins.SingleOrDefault(p => p.TypeName.Equals(crmPluginType.GetAttributeValue<string>("typename"), StringComparison.InvariantCultureIgnoreCase));
                if (typeInfo != null)
                {
                    typeInfo.PluginId = crmPluginType.Id;
                    typeInfo.FriendlyName = crmPluginType.GetAttributeValue<string>("friendlyname");
                    typeInfo.Name = crmPluginType.GetAttributeValue<string>("name");
                    //TODO: Check attributename
                    if (crmPluginType.Contains("isworkflowactivity") && crmPluginType.GetAttributeValue<bool>("isworkflowactivity") == true)
                    {
                        // Check if previous Activity Groupname was the default. If so keep the new default name, else keep existing name
                        string existingGeneratedGroupName = PluginManagementHelper.GenerateDefaultGroupName(crmPluginAssembly.GetAttributeValue<string>("name"), new Version(crmPluginAssembly.GetAttributeValue<string>("version")));
                        string existingGroupName = crmPluginType.GetAttributeValue<string>("workflowactivitygroupname");

                        if (!string.Equals(existingGroupName, existingGeneratedGroupName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            typeInfo.WorkflowActivityGroupName = existingGroupName;
                        }
                    }
                }
            }
        }

        public static string GenerateDefaultGroupName(string assemblyName, Version version)
        {
            return string.Format("{0} ({1})", assemblyName, version);
        }

        public static string GenerateStepDescription(string typeName, string messageName, string primaryEntity, string secondaryEntity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(typeName))
            {
                stringBuilder.AppendFormat("{0}: ", typeName);
            }
            if (string.IsNullOrEmpty(messageName))
            {
                stringBuilder.Append("Not Specified of ");
            }
            else
            {
                stringBuilder.AppendFormat("{0} of ", messageName);
            }
            bool flag = false;
            if (!string.IsNullOrEmpty(primaryEntity) && !string.Equals(primaryEntity, "none", StringComparison.InvariantCultureIgnoreCase))
            {
                flag = true;
                stringBuilder.Append(primaryEntity);
            }
            if (!string.IsNullOrEmpty(secondaryEntity) && !string.Equals(secondaryEntity, "none", StringComparison.InvariantCultureIgnoreCase))
            {
                string format;
                if (flag)
                {
                    format = " and {0}";
                }
                else
                {
                    format = "{0}";
                }
                stringBuilder.AppendFormat(format, secondaryEntity);
            }
            else if (!flag)
            {
                stringBuilder.Append("any Entity");
            }
            return stringBuilder.ToString();
        }

        public static string[] GetSdkMessagePropertyNames(string sdkMessageName)
        {
            switch (sdkMessageName)
            {
                case "Assign":
                    return new string[] { "Target" };
                case "Create":
                    return new string[] { "Id" };
                case "Delete":
                    return new string[] { "Target" };
                case "DeliverIncoming":
                    return new string[] { "EmailId" };
                case "DeliverPromote":
                    return new string[] { "EmailId" };
                case "ExecuteWorkflow":
                    return new string[] { "Target" };
                case "Merge":
                    return new string[] { "Target", "SubordinateId" };
                case "Route":
                    return new string[] { "Target" };
                case "Send":
                    return new string[] { "EmailId" };
                case "SetState":
                    return new string[] { "EntityMoniker" };
                case "SetStateDynamicEntity":
                    return new string[] { "EntityMoniker" };
                case "Update":
                    return new string[] { "Target" };
            }

            return null;
        }
    }
}
