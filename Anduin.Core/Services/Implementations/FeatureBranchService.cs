using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Anduin.Core.Services.Implementations
{
    public class FeatureBranchService : IFeatureBranchService
    {
        public IGitService _gitService;
        private readonly ILogger<FeatureBranchService> _logger;

        public FeatureBranchService(ILogger<FeatureBranchService> logger, IGitService gitService)
        {
            _logger = logger;
            _gitService = gitService;
        }

        public void DecomposeModel(string name)
        {
            _gitService.DecomposeModel(name);
        }

        public void ComposeModel(string name)
        {
            _gitService.ComposeModel(name);
        }


        public List<string> ProcessFetchedBranch()
        {
            return new List<string>();
        }

        public void InitialiseParameters()
        {

        }
    }
}
