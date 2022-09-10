using System.Collections.Generic;

namespace Anduin.Core.Services.Implementations
{
    public interface IFeatureBranchService
    {
        List<string> ProcessFeatureBranch();
        List<string> ReadLocalFile();
    }
}