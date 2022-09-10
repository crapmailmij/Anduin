using Anduin.Core.Models;
using Anduin.Core.Services.Implementations;
using Anduin.Core.ViewModels;
using Moq;
using MvvmCross;
using MvvmCross.Base;
using MvvmCross.Tests;
using MvvmCross.Views;
using System;
using System.Collections.Generic;
using System.Security.Permissions;
using Xunit;

namespace Anduin.Test
{
    public class FeatureBranchModelTest : MvxIoCSupportingTest
    {
        private void Setup()
        {
            base.ClearAll();
            var mockDispatcher = new MockDispatcher();
            Ioc.RegisterSingleton<IMvxViewDispatcher>(mockDispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(mockDispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadAsyncDispatcher>(mockDispatcher);
        }
    
        [Fact]  
        public void TestProcessLocalFeatureBranchesSingleFeatureBranch()
        {
            //Arrange
            Setup();
            var mockFeatureBranchService = new Mock<IFeatureBranchService>();
            Mvx.IoCProvider.RegisterSingleton<IFeatureBranchService>(mockFeatureBranchService.Object);
            mockFeatureBranchService.Setup(t => t.ProcessFeatureBranch()).Returns(new List<string> { "test" });
            var featureBranchViewModel = new FeatureBranchViewModel(mockFeatureBranchService.Object);

            //act
            featureBranchViewModel.ProcessLocalFeatureBranches();

            //assert
            Assert.Single(featureBranchViewModel.FeatureBranches);
        }

        [Fact]
        public void TestProcessLocalFeatureBranchesMultipleFeatureBranch()
        {
            //Arrange
            Setup();
            var mockFeatureBranchService = new Mock<IFeatureBranchService>();
            Mvx.IoCProvider.RegisterSingleton<IFeatureBranchService>(mockFeatureBranchService.Object);
            mockFeatureBranchService.Setup(t => t.ProcessFeatureBranch()).Returns(new List<string> { "test", "test2" });
            var featureBranchViewModel = new FeatureBranchViewModel(mockFeatureBranchService.Object);

            //act
            featureBranchViewModel.ProcessLocalFeatureBranches();

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
            mockFeatureBranchService.Setup(t => t.ProcessFeatureBranch()).Returns(new List<string> {  });
            var featureBranchViewModel = new FeatureBranchViewModel(mockFeatureBranchService.Object);

            //act
            featureBranchViewModel.ProcessLocalFeatureBranches();

            //assert
            Assert.Empty(featureBranchViewModel.FeatureBranches);
        }

        [Fact]
        public void TestProcessLocalFeatureBranchesDuplicatedBranches()
        {
            //Arrange
            Setup();
            var mockFeatureBranchService = new Mock<IFeatureBranchService>();
            Mvx.IoCProvider.RegisterSingleton<IFeatureBranchService>(mockFeatureBranchService.Object);
            mockFeatureBranchService.Setup(t => t.ProcessFeatureBranch()).Returns(new List<string> {"test","test" });
            var featureBranchViewModel = new FeatureBranchViewModel(mockFeatureBranchService.Object);

            //act
            featureBranchViewModel.ProcessLocalFeatureBranches();

            //assert
            Assert.Equal(2,featureBranchViewModel.FeatureBranches.Count);
        }

        [Fact]
        public void TestProcessCheckFeatureBranchSingleBranchTickedReturnsSingle()
        {
            //arrange
            Setup();
            var mockFeatureBranchService = new Mock<IFeatureBranchService>();
            Mvx.IoCProvider.RegisterSingleton<IFeatureBranchService>(mockFeatureBranchService.Object);
            FeatureBranchModel featureBranchModel1 = new FeatureBranchModel { Name = "test", IsSelected=true };
            FeatureBranchModel featureBranchModel2 = new FeatureBranchModel { Name = "test", IsSelected=false};
           
            var featureBranchViewModel = new FeatureBranchViewModel(mockFeatureBranchService.Object);
            featureBranchViewModel.FeatureBranches.Add(featureBranchModel1);
            featureBranchViewModel.FeatureBranches.Add(featureBranchModel2);

            //act
            featureBranchViewModel.ProcessCheckedFeatureBranch();

            //assert
            Assert.NotNull(featureBranchViewModel.SelectedFeatureBranch);
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

            var featureBranchViewModel = new FeatureBranchViewModel(mockFeatureBranchService.Object);
            featureBranchViewModel.FeatureBranches.Add(featureBranchModel1);
            featureBranchViewModel.FeatureBranches.Add(featureBranchModel2);

            //act
            featureBranchViewModel.ProcessCheckedFeatureBranch();

            //assert
            Assert.Null(featureBranchViewModel.SelectedFeatureBranch);
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

            var featureBranchViewModel = new FeatureBranchViewModel(mockFeatureBranchService.Object);
            featureBranchViewModel.FeatureBranches.Add(featureBranchModel1);
            featureBranchViewModel.FeatureBranches.Add(featureBranchModel2);

            //act
            featureBranchViewModel.ProcessCheckedFeatureBranch();

            //assert
            Assert.Null(featureBranchViewModel.SelectedFeatureBranch);
        }
    }
}
