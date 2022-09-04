using Anduin.Core.ViewModels;
using MvvmCross.Tests;
using System;
using Xunit;

namespace Anduin.Test
{
    public class UnitTest1 : MvxIoCSupportingTest
    {
        [Fact]
        public void TestViewModel()
        {
            base.Setup(); // from MvxIoCSupportingTest

            var featureBranchViewModel = new FeatureBranchViewModel();
            featureBranchViewModel.ProcessFeatureBranch();
            // your test code
        }
    }
}
