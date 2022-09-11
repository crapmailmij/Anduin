using System.Management.Automation;
using System.Reflection;


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

        public void ClosePowerShellInstance(PowerShell powerShell)
        {
            powerShell.Stop();
        }

        public void WriteToLocalFile()
        {

        }

        public void DecomposeModel(string name)
        {
            PowerShell powerShell = CreatePowerShellInstance();
            powerShell.AddScript(" ");
            powerShell.AddParameter(" ");
            powerShell.Invoke();
            ClosePowerShellInstance(powerShell);
        }

        public void ComposeModel(string name)
        {
            PowerShell powerShell = CreatePowerShellInstance();
            powerShell.AddScript(" ");
            powerShell.AddParameter(" ");
            powerShell.Invoke();
            ClosePowerShellInstance(powerShell);
        }
    }
}
