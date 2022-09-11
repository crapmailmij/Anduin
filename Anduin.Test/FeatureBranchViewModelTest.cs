using Anduin.Core.Models;
using Anduin.Core.Services.Implementations;
using Anduin.Core.ViewModels;
using Moq;
using MvvmCross;
using MvvmCross.Base;
using MvvmCross.Tests;
using MvvmCross.Views;
using System.Collections.Generic;
using Xunit;

namespace Anduin.Test
{
    public class FeatureBranchViewModelTest : MvxIoCSupportingTest
    {
        private new void Setup()
        {
            base.ClearAll();
            var mockDispatcher = new MockDispatcher();
            Ioc.RegisterSingleton<IMvxViewDispatcher>(mockDispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(mockDispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadAsyncDispatcher>(mockDispatcher);
        }

        [Fact]
        public void TestProcessLocalFeatureBranches1SelectedReturns1()
        {
            //Arrange
            Setup();
            var mockFeatureBranchService = new Mock<IFeatureBranchService>();
            Mvx.IoCProvider.RegisterSingleton<IFeatureBranchService>(mockFeatureBranchService.Object);
            mockFeatureBranchService.Setup(t => t.ProcessFetchedBranch()).Returns(new List<string> { "test" });
            var loggerMock = new Mock<Microsoft.Extensions.Logging.ILogger<FeatureBranchViewModel>>();
            var featureBranchViewModel = new FeatureBranchViewModel(loggerMock.Object,mockFeatureBranchService.Object);

            //act
            featureBranchViewModel.ProcessFetchedFeatureBranches();

            //assert
            Assert.Single(featureBranchViewModel.FeatureBranches);
        }

        [Fact]
        public void TestProcessCheckedFeatureBranchsNonSelectedReturnsNull()
        {
            //Arrange
            Setup();
            var mockFeatureBranchService = new Mock<IFeatureBranchService>();
            Mvx.IoCProvider.RegisterSingleton<IFeatureBranchService>(mockFeatureBranchService.Object);
            mockFeatureBranchService.Setup(t => t.ProcessFetchedBranch()).Returns((List<string>)null);
            var loggerMock = new Mock<Microsoft.Extensions.Logging.ILogger<FeatureBranchViewModel>>();
            var featureBranchViewModel = new FeatureBranchViewModel(loggerMock.Object, mockFeatureBranchService.Object);

            //act
            featureBranchViewModel.ProcessCheckedFeatureBranch();

            //assert
            Assert.Empty(featureBranchViewModel.FeatureBranches);
        }

        [Fact]
        public void TestProcessLocalFeatureBranchesMultipleFeatureBranch()
        {
            //Arrange
            Setup();
            var mockFeatureBranchService = new Mock<IFeatureBranchService>();
            Mvx.IoCProvider.RegisterSingleton<IFeatureBranchService>(mockFeatureBranchService.Object);
            mockFeatureBranchService.Setup(t => t.ProcessFetchedBranch()).Returns(new List<string> { "test", "test2" });
            var loggerMock = new Mock<Microsoft.Extensions.Logging.ILogger<FeatureBranchViewModel>>();
            var featureBranchViewModel = new FeatureBranchViewModel(loggerMock.Object, mockFeatureBranchService.Object);

            //act
            featureBranchViewModel.ProcessFetchedFeatureBranches();

            //assert
            Assert.Equal(2, featureBranchViewModel.FeatureBranches.Count);
        }

        [Fact]
        public void TestProcessLocalFeatureBranchesZeroFeatureBranch()
        {
            //Arrange
            Setup();
            var mockFeatureBranchService = new Mock<IFeatureBranchService>();
            Mvx.IoCProvider.RegisterSingleton<IFeatureBranchService>(mockFeatureBranchService.Object);
            mockFeatureBranchService.Setup(t => t.ProcessFetchedBranch()).Returns(new List<string> { });
            var loggerMock = new Mock<Microsoft.Extensions.Logging.ILogger<FeatureBranchViewModel>>();
            var featureBranchViewModel = new FeatureBranchViewModel(loggerMock.Object, mockFeatureBranchService.Object);

            //act
            var returnedValue = featureBranchViewModel.ProcessCheckedFeatureBranch();

            //assert
            Assert.Empty(featureBranchViewModel.FeatureBranches);
        }

        [Fact]
        public void TestProcessLocalFeatureBranchesNullInputNotRegistered()
        {
            //Arrange
            Setup();
            var mockFeatureBranchService = new Mock<IFeatureBranchService>();
            Mvx.IoCProvider.RegisterSingleton<IFeatureBranchService>(mockFeatureBranchService.Object);
            mockFeatureBranchService.Setup(t => t.ProcessFetchedBranch()).Returns(new List<string> { "test", " ", "test" });
            var loggerMock = new Mock<Microsoft.Extensions.Logging.ILogger<FeatureBranchViewModel>>();
            var featureBranchViewModel = new FeatureBranchViewModel(loggerMock.Object, mockFeatureBranchService.Object);

            //act
            featureBranchViewModel.ProcessFetchedFeatureBranches();

            //assert
            Assert.Equal(2, featureBranchViewModel.FeatureBranches.Count);
        }

        [Fact]
        public void TestProcessLocalFeatureBranchesDuplicatedBranches()
        {
            //Arrange
            Setup();
            var mockFeatureBranchService = new Mock<IFeatureBranchService>();
            Mvx.IoCProvider.RegisterSingleton<IFeatureBranchService>(mockFeatureBranchService.Object);
            mockFeatureBranchService.Setup(t => t.ProcessFetchedBranch()).Returns(new List<string> { "test", "test" });
            var loggerMock = new Mock<Microsoft.Extensions.Logging.ILogger<FeatureBranchViewModel>>();
            var featureBranchViewModel = new FeatureBranchViewModel(loggerMock.Object, mockFeatureBranchService.Object);

            //act
            featureBranchViewModel.ProcessFetchedFeatureBranches();

            //assert
            Assert.Equal(2, featureBranchViewModel.FeatureBranches.Count);
        }

        [Fact]
        public void TestProcessCheckFeatureBranchSingleBranchTickedReturnsSingle()
        {
            //arrange
            Setup();
            var mockFeatureBranchService = new Mock<IFeatureBranchService>();
            Mvx.IoCProvider.RegisterSingleton<IFeatureBranchService>(mockFeatureBranchService.Object);
            FeatureBranchModel featureBranchModel1 = new FeatureBranchModel { Name = "test", IsSelected = true };
            FeatureBranchModel featureBranchModel2 = new FeatureBranchModel { Name = "test", IsSelected = false };

            var loggerMock = new Mock<Microsoft.Extensions.Logging.ILogger<FeatureBranchViewModel>>();
            var featureBranchViewModel = new FeatureBranchViewModel(loggerMock.Object, mockFeatureBranchService.Object);
            featureBranchViewModel.FeatureBranches.Add(featureBranchModel1);
            featureBranchViewModel.FeatureBranches.Add(featureBranchModel2);

            //act
            var returnedValue = featureBranchViewModel.ProcessCheckedFeatureBranch();

            //assert
            Assert.NotNull(returnedValue);
        }

        [Fact]
        public void TestProcessCheckFeatureBranchMultipuleBranchesTickedReturnsNull()
        {
            //arrange
            Setup();
            var mockFeatureBranchService = new Mock<IFeatureBranchService>();
            Mvx.IoCProvider.RegisterSingleton<IFeatureBranchService>(mockFeatureBranchService.Object);
            FeatureBranchModel featureBranchModel1 = new FeatureBranchModel { Name = "test", IsSelected = true };
            FeatureBranchModel featureBranchModel2 = new FeatureBranchModel { Name = "test", IsSelected = true };

            var loggerMock = new Mock<Microsoft.Extensions.Logging.ILogger<FeatureBranchViewModel>>();
            var featureBranchViewModel = new FeatureBranchViewModel(loggerMock.Object, mockFeatureBranchService.Object);
            featureBranchViewModel.FeatureBranches.Add(featureBranchModel1);
            featureBranchViewModel.FeatureBranches.Add(featureBranchModel2);

            //act
            var returnedValue = featureBranchViewModel.ProcessCheckedFeatureBranch();

            //assert
            Assert.Null(returnedValue);
        }

        [Fact]
        public void TestProcessCheckFeatureBranchNoBranchesTicked()
        {
            //arrange
            Setup();
            var mockFeatureBranchService = new Mock<IFeatureBranchService>();
            Mvx.IoCProvider.RegisterSingleton<IFeatureBranchService>(mockFeatureBranchService.Object);
            FeatureBranchModel featureBranchModel1 = new FeatureBranchModel { Name = "test", IsSelected = false };
            FeatureBranchModel featureBranchModel2 = new FeatureBranchModel { Name = "test", IsSelected = false };

            var loggerMock = new Mock<Microsoft.Extensions.Logging.ILogger<FeatureBranchViewModel>>();
            var featureBranchViewModel = new FeatureBranchViewModel(loggerMock.Object, mockFeatureBranchService.Object);
            featureBranchViewModel.FeatureBranches.Add(featureBranchModel1);
            featureBranchViewModel.FeatureBranches.Add(featureBranchModel2);

            //act
            var returnedValue = featureBranchViewModel.ProcessCheckedFeatureBranch();

            //assert
            Assert.Null(returnedValue);
        }



    }
}
