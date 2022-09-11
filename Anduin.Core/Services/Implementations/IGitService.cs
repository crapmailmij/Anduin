using System.Management.Automation;

namespace Anduin.Core.Services.Implementations
{
    public interface IGitService
    {
        PowerShell CreatePowerShellInstance();
        string InvokeCommand();
        void SetupGit();
        void WriteToLocalFile();
        void DecomposeModel(string name);
        void ComposeModel(string name);

    }
}