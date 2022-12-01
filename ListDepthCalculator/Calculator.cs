using System.Collections.Generic;
using System.Linq;

namespace ListDepthCalculator
{
    public class Calculator
    {
        public int Counter(List<Branch> input, int depthCounter = 0)
        {
            depthCounter = depthCounter == 0 ? 1 : depthCounter;

            if (input == null || input.Count == 0)
            {
                return depthCounter;
            }

            var maxElementDepth = new List<int>();

            foreach (var branch in input)
            {
                maxElementDepth.Add(Counter(branch.branches, depthCounter));
            }

            depthCounter += maxElementDepth.Max();

            return depthCounter;
        }
    }
}