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
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace AMSoftware.Crm.PowerShell.Common.Helpers
{
    internal sealed class SecurityManagementHelper
    {
        public static IEnumerable<Guid> GetRolesForPrincipal(ContentRepository repository, CrmPrincipalType principalType, Guid principalId)
        {
            string entityName = null;
            string filterAttributeName = null;

            switch (principalType)
            {
                case CrmPrincipalType.User:
                    entityName = "systemuserroles";
                    filterAttributeName = "systemuserid";
                    break;
                case CrmPrincipalType.Team:
                    entityName = "teamroles";
                    filterAttributeName = "teamid";
                    break;
                default:
                    break;
            }

            QueryExpression query = new QueryExpression(entityName)
            {
                ColumnSet = new ColumnSet("roleid"),
                Criteria =
                {
                    Conditions = {
                        new ConditionExpression(filterAttributeName, ConditionOperator.Equal, principalId)
                    }
                }
            };

            return repository.Get(query).Select(e => e.GetAttributeValue<Guid>("roleid"));
        }

        public static IEnumerable<Guid> GetTeamsForUser(ContentRepository repository, Guid userId)
        {
            QueryExpression query = new QueryExpression("teammembership")
            {
                ColumnSet = new ColumnSet("teamid"),
                Criteria = {
                    Conditions = {
                        new ConditionExpression("systemuserid", ConditionOperator.Equal, userId)
                    }
                }
            };

            return repository.Get(query).Select(e => e.GetAttributeValue<Guid>("teamid"));
        }

        public static IEnumerable<Guid> GetPrincipalsInRole(ContentRepository repository, CrmPrincipalType principalType, Guid roleId)
        {
            string entityName = null;
            string resultAttributeName = null;

            switch (principalType)
            {
                case CrmPrincipalType.User:
                    entityName = "systemuserroles";
                    resultAttributeName = "systemuserid";
                    break;
                case CrmPrincipalType.Team:
                    entityName = "teamroles";
                    resultAttributeName = "teamid";
                    break;
                default:
                    break;
            }

            QueryExpression query = new QueryExpression(entityName)
            {
                ColumnSet = new ColumnSet(resultAttributeName),
                Criteria =
                {
                    Conditions = {
                        new ConditionExpression("roleid", ConditionOperator.Equal, roleId)
                    }
                }
            };

            return repository.Get(query).Select(e => e.GetAttributeValue<Guid>("systemuserid"));
        }

        public static IEnumerable<Guid> GetUsersInTeam(ContentRepository repository, Guid teamId)
        {
            QueryExpression query = new QueryExpression("teammembership")
            {
                ColumnSet = new ColumnSet("systemuserid"),
                Criteria =
                {
                    Conditions = {
                        new ConditionExpression("teamid", ConditionOperator.Equal, teamId)
                    }
                }
            };

            return repository.Get(query).Select(e => e.GetAttributeValue<Guid>("systemuserid"));
        }

        public static void LinkPrincipalRoles(ContentRepository repository, string entity, Guid id, string entity2, Guid[] related)
        {
            string relationshipName = "systemuserroles_association";
            if (entity.Equals("team", StringComparison.InvariantCultureIgnoreCase) || entity2.Equals("team", StringComparison.InvariantCultureIgnoreCase))
            {
                relationshipName = "teamroles_association";
            }

            repository.Associate(entity, id, new Relationship(relationshipName),
                new EntityReferenceCollection(
                    related.Select<Guid, EntityReference>(
                        g => new EntityReference(entity2, g)
                    ).ToList()
                )
            );
        }

        public static void UnlinkPrincipalRoles(ContentRepository repository, string entity, Guid id, string entity2, Guid[] related)
        {
            string relationshipName = "systemuserroles_association";
            if (entity.Equals("team", StringComparison.InvariantCultureIgnoreCase) || entity2.Equals("team", StringComparison.InvariantCultureIgnoreCase))
            {
                relationshipName = "teamroles_association";
            }

            repository.Disassociate(entity, id, new Relationship(relationshipName),
               new EntityReferenceCollection(
                   related.Select<Guid, EntityReference>(
                       g => new EntityReference(entity2, g)
                   ).ToList()
               )
           );
        }

        public static void AddUsersToTeam(ContentRepository repository, Guid teamId, Guid[] userIds)
        {
            OrganizationRequest request = new OrganizationRequest("AddMembersTeam");
            request.Parameters = new ParameterCollection();
            request.Parameters["TeamId"] = teamId;
            request.Parameters["MemberIds"] = userIds;

            OrganizationResponse response = repository.Execute(request);
        }

        public static void RemoveUsersFromTeam(ContentRepository repository, Guid teamId, Guid[] userIds)
        {
            OrganizationRequest request = new OrganizationRequest("RemoveMembersTeam");
            request.Parameters = new ParameterCollection();
            request.Parameters["TeamId"] = teamId;
            request.Parameters["MemberIds"] = userIds;

            OrganizationResponse response = repository.Execute(request);
        }

        public static Guid GetDefaultBusinessUnitId(ContentRepository repository)
        {
            QueryExpression query = new QueryExpression("businessunit")
            {
                Criteria =
                {
                    Conditions = {
                        new ConditionExpression("parentbusinessunitid", ConditionOperator.Null)
                    }
                }
            };

            var entities = repository.Get(query, 1);
            if (entities == null || entities.Count() != 1)
            {
                throw new Exception("Unable to determine default business unit.");
            }
            else
            {
                return entities.First().Id;
            }
        }
    }
}
