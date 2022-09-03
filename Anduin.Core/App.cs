using Anduin.Core.Services.Implementations;
using Anduin.Core.Services.Interfaces;
using Anduin.Core.ViewModels;
using MvvmCross;
using MvvmCross.ViewModels;

namespace Anduin.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            Mvx.IoCProvider.RegisterType<IGitService, GitService>();

            RegisterAppStart<FeatureBranchViewModel>();

        }
    }
}
