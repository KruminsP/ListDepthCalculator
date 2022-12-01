using System.Collections.Generic;

namespace ListDepthCalculator
{
    public class Branch
    {
        public List<Branch> branches;

        public Branch()
        {
        }

        public Branch(List<Branch> branch)
        {
            branches = branch;
        }
    }
}