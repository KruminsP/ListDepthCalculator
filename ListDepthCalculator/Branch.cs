using System.Collections.Generic;

namespace ListDepthCalculator
{
    public class Branch
    {
        public List<Branch> branches;

        public Branch()
        {
            branches = new List<Branch>();
        }

        public Branch(List<Branch> branch)
        {
            branches = branch;
        }
    }
}