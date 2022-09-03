using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
