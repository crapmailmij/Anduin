using Anduin.Core.ViewModels;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anduin.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            RegisterAppStart<FeatureBranchViewModel>();

        }
    }
}
