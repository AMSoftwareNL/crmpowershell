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
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;

namespace AMSoftware.Crm.PowerShell.Common.ArgumentCompleters
{
    public class EntityArgumentCompleter : IArgumentCompleter
    {
        public IEnumerable<CompletionResult> CompleteArgument(string commandName, string parameterName, string wordToComplete, CommandAst commandAst, IDictionary fakeBoundParameters)
        {
            if (fakeBoundParameters == null) throw new ArgumentNullException("fakeBoundParameters");

            MetadataRepository repository = new MetadataRepository();
            IEnumerable<EntityMetadata> entitiesMetadatas = null;
            try
            {
                entitiesMetadatas = repository.GetEntity(false, false, true);
            }
            catch { }

            if (entitiesMetadatas != null)
            {
                return from entityMetadata in entitiesMetadatas
                       where entityMetadata.LogicalName.StartsWith(wordToComplete.Trim('\'', '"'), StringComparison.InvariantCultureIgnoreCase)
                       orderby entityMetadata.LogicalName
                       select new CompletionResult($"'{entityMetadata.LogicalName}'", entityMetadata.LogicalName, CompletionResultType.Text, entityMetadata.LogicalName);
            }

            return null;
        }
    }
}
