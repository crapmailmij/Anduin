using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static Anduin.Core.Services.Implementations.GitService;

namespace Anduin.Core.Services.Implementations
{
    public class FeatureBranchService : IFeatureBranchService
    {
        public IGitService _gitService;

        public FeatureBranchService(IGitService gitService)
        {
            _gitService = gitService;
        }

        public void DecomposeModel(string name)
        {
            
        }

        public void ComposeModel(string name)
        {

        }


        public List<string> ProcessFeatureBranch()
        {
            return new List<string>();
        }

        public List<string> ReadLocalFile()
        {
            using (var reader = new StreamReader(@"C:\test.csv"))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    listA.Add(values[0]);
                    listB.Add(values[1]);
                }
            }

            return new List<string>();
        }
    }
}
