using System.Management.Automation;

namespace Anduin.Core.Services.Implementations
{
    public interface IGitService
    {
        PowerShell CreatePowerShellInstance();
        string InvokeCommand();
        void SetupGit();
        void WriteToLocalFile();
    }
}