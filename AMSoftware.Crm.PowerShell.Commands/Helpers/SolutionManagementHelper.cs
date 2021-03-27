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
using Microsoft.Xrm.Sdk;
using System;

namespace AMSoftware.Crm.PowerShell.Commands.Helpers
{
    public sealed class SolutionManagementHelper
    {
        public static string GetComponentName(OptionSetValue componentType, Guid objectId)
        {
            return GetComponentName(componentType.Value, objectId);
        }

        public static string GetComponentName(int componentType, Guid objectId)
        {
            string componentLogicalName;
            string primaryNameAttribute;

            MetadataRepository mdr = new MetadataRepository();
            switch (componentType)
            {
                case 1:  //Entity
                    return mdr.GetEntity(objectId).LogicalName;
                case 2:  //Attribute
                    return mdr.GetAttribute(objectId).LogicalName;
                case 3:  //Relationship
                    return mdr.GetRelationship(objectId).SchemaName;
                case 9:  //Option Set
                    return mdr.GetOptionSet(objectId).Name;
                case 10: //Entity Relationship
                    return mdr.GetRelationship(objectId).SchemaName;
                case 13: //Managed Property
                    return mdr.GetManagedProperty(objectId).LogicalName;
                case 11: //Relationship Role
                    componentLogicalName = "relationshiprole";
                    primaryNameAttribute = "name";
                    break;
                case 20: //Security Role
                    componentLogicalName = "role";
                    primaryNameAttribute = "name";
                    break;
                case 21: //Privilege
                    componentLogicalName = "privilege";
                    primaryNameAttribute = "name";
                    break;
                case 24: //User Dashboard
                    componentLogicalName = "userform";
                    primaryNameAttribute = "name";
                    break;
                case 25: //Organization
                    componentLogicalName = "organization";
                    primaryNameAttribute = "name";
                    break;
                case 26: //View
                    componentLogicalName = "savedquery";
                    primaryNameAttribute = "name";
                    break;
                case 29: //Process
                    componentLogicalName = "workflow";
                    primaryNameAttribute = "name";
                    break;
                case 31: //Report
                    componentLogicalName = "report";
                    primaryNameAttribute = "name";
                    break;
                case 36: //Email Template
                    componentLogicalName = "template";
                    primaryNameAttribute = "title";
                    break;
                case 37: //Contract Template
                    componentLogicalName = "contracttemplate";
                    primaryNameAttribute = "name";
                    break;
                case 38: //Article Template
                    componentLogicalName = "kbarticletemplate";
                    primaryNameAttribute = "title";
                    break;
                case 39: //Mail Merge Template
                    componentLogicalName = "mailmergetemplate";
                    primaryNameAttribute = "name";
                    break;
                case 44: //Duplicate Detection Rule
                    componentLogicalName = "duplicaterule";
                    primaryNameAttribute = "name";
                    break;
                case 59: //System Chart
                    componentLogicalName = "savedqueryvisualization";
                    primaryNameAttribute = "name";
                    break;
                case 60: //System Form
                    componentLogicalName = "systemform";
                    primaryNameAttribute = "name";
                    break;
                case 61: //Web Resource
                    componentLogicalName = "webresource";
                    primaryNameAttribute = "name";
                    break;
                case 63: //Connection Role
                    componentLogicalName = "connectionrole";
                    primaryNameAttribute = "name";
                    break;
                case 65: //Hierarchy Rule
                    componentLogicalName = "hierarchyrule";
                    primaryNameAttribute = "name";
                    break;
                case 70: //Field Security Profile
                    componentLogicalName = "fieldsecurityprofile";
                    primaryNameAttribute = "name";
                    break;
                case 90: //Plug-in Type
                    componentLogicalName = "plugintype";
                    primaryNameAttribute = "name";
                    break;
                case 91: //Plug-in Assembly
                    componentLogicalName = "pluginassembly";
                    primaryNameAttribute = "name";
                    break;
                case 92: //Sdk Message Processing Step
                    componentLogicalName = "sdkmessageprocessingstep";
                    primaryNameAttribute = "name";
                    break;
                case 93: //Sdk Message Processing Step Image
                    componentLogicalName = "sdkmessageprocessingstepimage";
                    primaryNameAttribute = "name";
                    break;
                case 95: //Service Endpoint
                    componentLogicalName = "serviceendpoint";
                    primaryNameAttribute = "name";
                    break;
                case 150: //Routing Rule Set
                    componentLogicalName = "routingrule";
                    primaryNameAttribute = "name";
                    break;
                case 151: //Rule Item
                    componentLogicalName = "routingruleitem";
                    primaryNameAttribute = "name";
                    break;
                case 152: //SLA
                    componentLogicalName = "sla";
                    primaryNameAttribute = "name";
                    break;
                case 154: //Record Creation and Update Rule
                    componentLogicalName = "convertrule";
                    primaryNameAttribute = "name";
                    break;
                case 155: //Record Creation and Update Rule Item
                    componentLogicalName = "convertruleitem";
                    primaryNameAttribute = "name";
                    break;
                default:
                    componentLogicalName = null;
                    primaryNameAttribute = null;
                    break;
            }

            if (!string.IsNullOrWhiteSpace(componentLogicalName) && !string.IsNullOrWhiteSpace(primaryNameAttribute))
            {
                ContentRepository ctr = new ContentRepository();
                Entity componentEntity = ctr.Get(componentLogicalName, objectId);

                return componentEntity.GetAttributeValue<string>(primaryNameAttribute);
            }

            return null;
        }
    }
}
