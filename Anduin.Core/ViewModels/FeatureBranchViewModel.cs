using Anduin.Core.Models;
using Anduin.Core.Services.Implementations;
using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anduin.Core.ViewModels
{
    public class FeatureBranchViewModel : MvxViewModel
    {

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


        private readonly IFeatureBranchService _featureBranchService;
        private ILogger<FeatureBranchViewModel> _logger;
        public FeatureBranchViewModel(ILogger<FeatureBranchViewModel> logger, IFeatureBranchService featureBranchService)
        {
            _logger = logger;
            _featureBranchService = featureBranchService;

            DecomposeModelTriggerCommand = new MvxCommand(DecomposeModelTrigger);
            ComposeModelTriggerCommand = new MvxCommand(ComposeModelTrigger);

            //for(int i = 0; i < 20; i++)
            //{
            //    FeatureBranches.Add(new FeatureBranchModel { Name = "test" });
            //}
        }
       
        
        public override async Task Initialize()
        {
            await base.Initialize();

            _featureBranchService.InitialiseParameters();
        }
        public IMvxCommand DecomposeModelTriggerCommand { get; set; }
        public void DecomposeModelTrigger()
        {
            bool branchIsSelected;

            FeatureBranchModel featureBranch = ProcessCheckedFeatureBranch();
            branchIsSelected = featureBranch != null;

            if (branchIsSelected)
            {
                _featureBranchService.ComposeModel(featureBranch.Name);
                _logger.LogInformation("starting compose model");
            }
            else
            {
                _logger.LogError("No featurebranch selected when it was clicked");
            }
        }
        public IMvxCommand ComposeModelTriggerCommand { get; set; }
        public void ComposeModelTrigger()
        {
            bool branchIsSelected;

            FeatureBranchModel featureBranch = ProcessCheckedFeatureBranch();
            branchIsSelected = featureBranch != null;

            if (branchIsSelected)
            {
                _featureBranchService.ComposeModel(featureBranch.Name);
            }
            else
            {
                _logger.LogError("No featurebranch selected when it was clicked");
            }

        }


        public FeatureBranchModel ProcessCheckedFeatureBranch()
        {
            var selectedFeatureBranch = FeatureBranches.Where(featureBranch => featureBranch.IsSelected).ToList();
            bool singleBranchSelected = selectedFeatureBranch.Count == 1;

            if (singleBranchSelected) return selectedFeatureBranch[0];
            else { return null; }

        }
        public void ProcessFetchedFeatureBranches()
        {
            List<string> fetchedFeatureBranches = _featureBranchService.ProcessFetchedBranch();
            bool isCorrectName;
            
            foreach (string name in fetchedFeatureBranches)
            {
                isCorrectName = name.Length > 1;

                if (isCorrectName)
                {
                    FeatureBranches.Add(new FeatureBranchModel
                    {
                        Name = name,
                        IsSelected = false
                    });

                    _logger.LogInformation($"Fetched featurebranch:{name} is processed");
                }
                else
                {
                    _logger.LogError($"Fetched featurebranch: {name} is not processed due to naming error");
                }
            }

        }


    }
}
