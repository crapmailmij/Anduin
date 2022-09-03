using Anduin.Core.ViewModels;
using MvvmCross.ViewModels;

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
