using Anduin.Core.Services.Implementations;

using Anduin.Core.ViewModels;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace Anduin.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            //base.Initialize();

            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //Mvx.IoCProvider.RegisterType<IGitService, GitService>();
            //Mvx.IoCProvider.RegisterType<IFeatureBranchService, FeatureBranchService>();

            RegisterAppStart<FeatureBranchViewModel>();

        }
    }
}
