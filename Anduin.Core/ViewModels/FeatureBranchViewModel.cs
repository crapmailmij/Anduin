using Anduin.Core.Models;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace Anduin.Core.ViewModels
{
    public class FeatureBranchViewModel : MvxViewModel
    {

        public FeatureBranchViewModel()
        {
            AddFeatureBranchCommand = new MvxCommand(AddFeatureBranch);

            _featureBranches.Add(new FeatureBranchModel
            {
                Name = "Test"
            });
            _featureBranches.Add(new FeatureBranchModel
            {
                Name = "Test"
            });
            _featureBranches.Add(new FeatureBranchModel
            {
                Name = "Test"
            });
            _featureBranches.Add(new FeatureBranchModel
            {
                Name = "Test"
            });
        }

        public IMvxCommand AddFeatureBranchCommand { get; set; }


        public void AddFeatureBranch()
        {
            FeatureBranchModel featureBranch = new FeatureBranchModel
            {
                Name = Name
            };
            Name = Name;
            Name = string.Empty;
            FeatureBranches.Add(featureBranch);
        }

        public bool CanAddFeatureBranch => Name?.Length > 0;

        private MvxObservableCollection<FeatureBranchModel> _featureBranches = new MvxObservableCollection<FeatureBranchModel>();
        public MvxObservableCollection<FeatureBranchModel> FeatureBranches
        {
            get { return _featureBranches; }
            set { SetProperty(ref _featureBranches, value); }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
                RaisePropertyChanged(() => CanAddFeatureBranch);
            }
        }

    }
}
