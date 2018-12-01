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
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;

namespace AMSoftware.Crm.PowerShell.Common.ArgumentCompleters
{
    public class EntityKeyArgumentCompleter : IArgumentCompleter
    {
        private readonly string[] _filterParameters = new string[] { "Entity", "PrimaryEntity", "InputObject" };

        public IEnumerable<CompletionResult> CompleteArgument(string commandName, string parameterName, string wordToComplete, CommandAst commandAst, IDictionary fakeBoundParameters)
        {
            if (fakeBoundParameters == null) throw new ArgumentNullException("fakeBoundParameters");

            List<CompletionResult> result = new List<CompletionResult>();
            foreach (string filterParameter in _filterParameters)
            {
                if (fakeBoundParameters.Contains(filterParameter))
                {
                    MetadataRepository repository = new MetadataRepository();
                    IEnumerable<EntityKeyMetadata> entityKeyMetadatas = null;
                    try
                    {
                        if (fakeBoundParameters[filterParameter] is string)
                        {
                            entityKeyMetadatas = repository.GetEntityKey(fakeBoundParameters[filterParameter] as string, false);
                        }
                        else if (fakeBoundParameters[filterParameter] is Entity)
                        {
                            entityKeyMetadatas = repository.GetEntityKey((fakeBoundParameters[filterParameter] as Entity).LogicalName, false);
                        }
                    }
                    catch { }

                    if (entityKeyMetadatas != null)
                    {
                        return from entityKeyMetadata in entityKeyMetadatas
                               where entityKeyMetadata.LogicalName.StartsWith(wordToComplete.Trim('\'', '"'), StringComparison.InvariantCultureIgnoreCase)
                               orderby entityKeyMetadata.LogicalName
                               select new CompletionResult($"'{entityKeyMetadata.LogicalName}'", entityKeyMetadata.LogicalName, CompletionResultType.Text, entityKeyMetadata.LogicalName);
                    }
                }
            }

            if (result.Count == 0) return null;
            else return result;
        }
    }
}
