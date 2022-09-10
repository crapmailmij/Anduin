using Anduin.Core.Models;
using Anduin.Core.Services.Implementations;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Anduin.Core.ViewModels
{
    public class FeatureBranchViewModel : MvxViewModel
    {
        private FeatureBranchModel _selectedFeatureBranch;

        public FeatureBranchModel SelectedFeatureBranch
        {
            get { return _selectedFeatureBranch; }
            set { _selectedFeatureBranch = value; }
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

        public bool CanAddFeatureBranch => Name?.Length > 0;

        private MvxObservableCollection<FeatureBranchModel> _featureBranches = new MvxObservableCollection<FeatureBranchModel>();
        public MvxObservableCollection<FeatureBranchModel> FeatureBranches
        {
            get { return _featureBranches; }
            set { SetProperty(ref _featureBranches, value); }
        }

        private IFeatureBranchService _featureBranchService;
        public FeatureBranchViewModel(IFeatureBranchService featureBranchService)
        {
            _featureBranchService = featureBranchService;

            AddFeatureBranchCommand = new MvxCommand(AddFeatureBranch);
            ProcessFeatureBranchCommand = new MvxCommand(ProcessCheckedFeatureBranch);
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

        public IMvxCommand ProcessFeatureBranchCommand { get; set; }

        public void ProcessCheckedFeatureBranch()
        {
            var selectedFeatureBranch = FeatureBranches.Where(featureBranch => featureBranch.IsSelected).ToList();
            bool singleBranchSelected = selectedFeatureBranch.Count == 1;

            if(singleBranchSelected) SelectedFeatureBranch = selectedFeatureBranch[0];
            else { SelectedFeatureBranch = null; }
           
         }

        public void ProcessLocalFeatureBranches()
        {
            List<string> featureBranches = _featureBranchService.ProcessFeatureBranch();
            bool featureBranchesNotEmpty = featureBranches != null;

            if (featureBranchesNotEmpty)
            {
                foreach (string name in featureBranches)
                {
                    FeatureBranchModel featureBranchModel = new FeatureBranchModel();
                    featureBranchModel.Name = name;
                    FeatureBranches.Add(featureBranchModel);
                }
            }

        }

    }
}
