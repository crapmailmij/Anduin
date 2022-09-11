using Anduin.Core.Services.Implementations;
using Moq;
using Xunit;

namespace Anduin.Test
{
    public class FeatureBranchServiceTest
    {
        [Fact]
        public void TestDecomposeModel()
        {
            Mock<IGitService> gitService = new Mock<IGitService>();
            var loggerMock = new Mock<Microsoft.Extensions.Logging.ILogger<FeatureBranchService>>();
            FeatureBranchService _featureBranchService = new FeatureBranchService(loggerMock.Object, gitService.Object);


        }

    }
}
