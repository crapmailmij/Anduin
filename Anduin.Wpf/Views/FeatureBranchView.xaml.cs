using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;

namespace Anduin.Wpf.Views
{
    [MvxContentPresentation]
    //[MvxViewFor(typeof(FeatureBranchView))]
    public partial class FeatureBranchView : MvxWpfView
    {
        public FeatureBranchView()
        {
            InitializeComponent();
        }
    }
}
