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
using System.Diagnostics;

namespace AMSoftware.Crm.PowerShell.Common.Helpers
{
	internal sealed class AppDomainContext<TProxy> : IDisposable where TProxy : class, new()
	{
		private AppDomain _domain;
		private bool _disposed;

		public TProxy Proxy
		{
			get;
			private set;
		}

		public AppDomainContext(string appPathName = "") : this("TemporaryDomain1", appPathName)
		{
		}

		public AppDomainContext(string domainName, string appPathName = "")
		{
			if (string.IsNullOrWhiteSpace(domainName))
			{
				throw new ArgumentNullException("domainName");
			}

            AppDomainSetup appDomainSetup = new AppDomainSetup
            {
                ApplicationName = domainName + Guid.NewGuid().ToString().GetHashCode().ToString("x")
            };

            string assemblyFile = typeof(TProxy).Assembly.Location;
            //if (string.IsNullOrEmpty(appPathName))
            //{
				appDomainSetup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
            //}
            //else
            //{
            //    appDomainSetup.ApplicationBase = appPathName;
            //    AssemblyResolver.AddSpecialPathToBaseDirectories(appPathName);
            //}
			_domain = AppDomain.CreateDomain(appDomainSetup.ApplicationName, null, appDomainSetup);
            //AssemblyResolver.AttachResolver(AppDomain.CurrentDomain);
            //AssemblyResolver.AttachResolver(this._domain);
			object obj = this._domain.CreateInstanceFrom(assemblyFile, typeof(TProxy).FullName).Unwrap();
			Proxy = (TProxy)((object)obj);
		}

		~AppDomainContext()
		{
			this.Dispose(false);
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (_disposed)
			{
				return;
			}
			if (_domain != null)
			{
				try
				{
					AppDomain.Unload(_domain);
				}
				catch (CannotUnloadAppDomainException ex)
				{
					Trace.WriteLine(ex.Message);
				}
				_domain = null;
				Proxy = default(TProxy);
			}
			if (disposing)
			{
				_disposed = true;
			}
		}
	}
}
