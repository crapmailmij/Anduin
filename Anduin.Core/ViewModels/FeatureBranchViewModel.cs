﻿using Anduin.Core.Models;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Anduin.Core.ViewModels
{
    public class FeatureBranchViewModel : MvxViewModel
    {

        public FeatureBranchViewModel()
        {
            AddFeatureBranchCommand = new MvxCommand(AddFeatureBranch);
            ProcessFeatureBranchCommand = new MvxCommand(ProcessFeatureBranch);

            for (int i = 0; i < 10; i++)
            {
                _featureBranches.Add(new FeatureBranchModel
                {
                    Name = i.ToString()
                });

            }
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

        public void ProcessFeatureBranch()
        {
            var featureBranchName = FeatureBranches.Where(d => d.IsSelected.Equals(true));

            var test = FeatureBranches.Where(featureBranch => featureBranch.IsSelected);

            foreach(FeatureBranchModel featureBranch in FeatureBranches)
            {
                bool IsSelected = featureBranch.IsSelected == true;
                if (IsSelected)
                {
                    string testName = featureBranch.Name;
                }
            }

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
