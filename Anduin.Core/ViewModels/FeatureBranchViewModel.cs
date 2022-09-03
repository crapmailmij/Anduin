using Anduin.Core.Models;
using MvvmCross.ViewModels;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Commands;

namespace Anduin.Core.ViewModels
{
    public class FeatureBranchViewModel : MvxViewModel
    {

        public FeatureBranchViewModel()
        {
            AddFeatureBranchCommand = new MvxCommand(AddFeatureBranch);
        }

        public IMvxCommand AddFeatureBranchCommand { get; set; }
       

        public void AddFeatureBranch()
        {
            FeatureBranchModel p = new FeatureBranchModel
            {
                Name = Name
            };
            Name = " asd" ;

            FeatureBranches.Add(p);
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
