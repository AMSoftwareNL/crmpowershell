## Contributing
We love pull requests from everyone. By participating in this project, you agree to abide by the [code of conduct](CODE_OF_CONDUCT.md).

## Get the code
```git clone https://github.com/AMSoftwareNL/crmpowershell```

## Understand code layout
There are three parts: 
- `AMSoftware.Crm.PowerShell.Commands`  
  A Visual Studio 2017 project containing all the Cmdlets (inherited from PSCmdlet) and the code and attributes the interact with PowerShell.
- `AMSoftware.Crm.PowerShell.Common`
  A Visual Studio 2017 project containing the repositories to get to the (meta)data in Dynamics CRM, and the advanced helper code for Powershell like PSTypeConverters and PSPropertyAdapters.
- `AMSoftware.Crm.PowerShell`
  Just a folder containing the Powershell specific support files like the PDS1, Types.ps1xml and Format.ps1xml.

## First-time setup
Restore NuGet packages.You can do this from Visual Studio, or from the command line.

```.\.nuget\NuGet.exe restore```

**NOTE**: 
The projects include a link to a strong name key file, which isn't included. 
Just add a SNK-file named `AMSoftware.Crm.Powershell.snk` in the solution folder. 

The public key from the signing is used to expose the internals in `AMSoftware.Crm.PowerShell.Common` to `AMSoftware.Crm.PowerShell.Commands`. 
Update the `AssemblyInfo.cs` in `AMSoftware.Crm.PowerShell.Common` to reflect the new Public Key.

## Build
`AMSoftware.Crm.PowerShell.Commands` is the primary project to build. Just choose Build in Visual Studio and the bin folder will contain everything needed. `AMSoftware.Crm.PowerShell.Common` is included by reference and everything from the `AMSoftware.Crm.PowerShell` folder is copied in a post build step.
Now you can start a Powershell session and run Import-Module to get started.

## Docs and Help
Docs and Powershell are generated using PlatyPS (https://www.powershellgallery.com/packages/platyPS/). 
* Install PlatyPS from the PowerShell Gallery: `Install-Module -PlatyPS`
* Import the latest build of the CRM PowerShell Library
* Browse to the solution folder in Powershell and run `BuildHelp.ps1`. 

This will:
* Generate updated Docs
* Generate a Powershell Help File in the Release build folder
* Generate the CAB and HelpInfo to support `Update-Help`
