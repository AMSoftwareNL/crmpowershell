﻿/*
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
using System.Collections.ObjectModel;
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Common;
using Microsoft.PowerShell.Commands;

namespace AMSoftware.Crm.PowerShell.Commands
{
    public abstract class CrmCmdlet : PSCmdlet
    {
        protected override void BeginProcessing()
        {
            if (string.IsNullOrEmpty(base.ParameterSetName))
            {
                this.WriteVerboseWithTimestamp(string.Format("{0} begin processing without ParameterSet.", base.GetType().Name));
            }
            else
            {
                this.WriteVerboseWithTimestamp(string.Format("{0} begin processing with ParameterSet '{1}'.", base.GetType().Name, base.ParameterSetName));
            }
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            try
            {
                this.WriteVerboseWithTimestamp(string.Format("{0} process record.", base.GetType().Name));

                base.ProcessRecord();
                this.ExecuteCmdlet();
            }
            catch (PipelineStoppedException)
            {
            }
            catch (Exception ex)
            {
                this.WriteExceptionError(ex);
            }
        }

        protected virtual void ExecuteCmdlet()
        {
        }

        protected override void EndProcessing()
        {
            this.WriteVerboseWithTimestamp(string.Format("{0} end processing.", base.GetType().Name));
            base.EndProcessing();
        }

        protected void WriteDebugWithTimestamp(string message)
        {
            this.WriteDebug(string.Format("{0:T} - {1}", DateTime.Now, message));
        }

        protected void WriteDebugWithTimestamp(string message, params object[] args)
        {
            this.WriteDebug(string.Format("{0:T} - {1}", DateTime.Now, string.Format(message, args)));
        }

        protected void WriteErrorWithTimestamp(string message)
        {
            this.WriteError(new ErrorRecord(new Exception(string.Format("{0:T} - {1}", DateTime.Now, message)), string.Empty, ErrorCategory.NotSpecified, null));
        }

        protected void WriteVerboseWithTimestamp(string message)
        {
            this.WriteVerbose(string.Format("{0:T} - {1}", DateTime.Now, message));
        }

        protected void WriteVerboseWithTimestamp(string message, params object[] args)
        {
            this.WriteVerbose(string.Format("{0:T} - {1}", DateTime.Now, string.Format(message, args)));
        }

        protected void WriteWarningWithTimestamp(string message)
        {
            this.WriteWarning(string.Format("{0:T} - {1}", DateTime.Now, message));
        }

        protected virtual void WriteExceptionError(Exception ex)
        {
            this.WriteError(new ErrorRecord(ex, string.Empty, ErrorCategory.CloseError, null));
        }

        protected string[] ResolvePaths(string[] pathsToProcess, bool expandWildcards)
        {
            List<string> resolvedPaths = new List<string>();

            foreach (string path in pathsToProcess)
            {
                if (expandWildcards)
                {
                    Collection<string> resolvedProviderPaths = this.GetResolvedProviderPathFromPSPath(path, out ProviderInfo provider);
                    if (provider.ImplementingType != typeof(FileSystemProvider))
                    {
                        ArgumentException ex = new ArgumentException(path + " does not resolve to a path on the FileSystem provider.");
                        ErrorRecord error = new ErrorRecord(ex, "InvalidProvider", ErrorCategory.InvalidArgument, path);

                        this.WriteError(error);
                    }
                    else
                    {
                        resolvedPaths.AddRange(resolvedProviderPaths);
                    }
                }
                else
                {
                    resolvedPaths.Add(this.GetUnresolvedProviderPathFromPSPath(path));
                }
            }

            return resolvedPaths.ToArray();
        }
    }

    public abstract class CrmOrganizationCmdlet : CrmCmdlet
    {
        protected override void BeginProcessing()
        {
            if (CrmContext.Session.OrganizationProxy == null)
            {
                ThrowTerminatingError(new ErrorRecord(new Exception("Not connected with a CRM Organization. Run Connect-CrmOrganization."), string.Empty, ErrorCategory.ConnectionError, null));
            }

            base.BeginProcessing();

            CrmContext.Session.OrganizationCache.UpdateCache();

            if (!string.IsNullOrEmpty(CrmContext.Session.ActiveSolutionName))
            {
                this.WriteDebugWithTimestamp(string.Format("Applying solution '{0}' to processing.", CrmContext.Session.ActiveSolutionName));
            }

            this.WriteDebugWithTimestamp(string.Format("Applying language '{0}' to processing.", CrmContext.Session.Language));
        }
    }

    public abstract class CrmOrganizationActionCmdlet : CrmOrganizationCmdlet
    {
        protected virtual void ExecuteAction(string target, string action, Action cmdletAction)
        {
            if (ShouldProcess(target, action))
            {
                cmdletAction();
            }
        }

        protected virtual void ExecuteAction(string target, Action cmdletAction)
        {
            if (ShouldProcess(target))
            {
                cmdletAction();
            }
        }
    }

    public abstract class CrmOrganizationConfirmActionCmdlet : CrmOrganizationActionCmdlet
    {
        private bool _yesToAll;
        private bool _noToAll;

        [Parameter]
        public SwitchParameter Force { get; set; }

        protected override void ExecuteAction(string target, string action, Action cmdletAction)
        {
            if (ShouldProcess(target, action))
            {
                if (Force || ShouldContinue(target, action, ref _yesToAll, ref _noToAll))
                {
                    cmdletAction();
                }
            }
        }

        protected override void ExecuteAction(string target, Action cmdletAction)
        {
            if (ShouldProcess(target))
            {
                if (Force || ShouldContinue(string.Empty, string.Empty, ref _yesToAll, ref _noToAll))
                {
                    cmdletAction();
                }
            }
        }
    }
}
