using System.Collections.Generic;

namespace Anduin.Core.Services.Implementations
{
    public interface IFeatureBranchService
    {
        List<string> ProcessFetchedBranch();

        void DecomposeModel(string v);
        void ComposeModel(string v);
        void InitialiseParameters();
    }
}