using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Reflection;
using System.Text;


namespace Anduin.Core.Services.Implementations
{
    public class GitService : IGitService
    {
        public string InvokeCommand()
        {
            return "";
        }

        public void SetupGit()
        {
            PowerShell powerShell = CreatePowerShellInstance();
            string origAssemblyLocation = Assembly.GetExecutingAssembly().CodeBase;



        }

        public PowerShell CreatePowerShellInstance()
        {
            return PowerShell.Create();
        }

        public void WriteToLocalFile()
        {

        }


    }
}
