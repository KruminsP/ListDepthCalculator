using System.Collections.Generic;
using System.Linq;

namespace ListDepthCalculator
{
    public class Calculator
    {
        public int Counter(Branch input, int depthCounter = 1)
        {
            if (input == null || input.branches == null)
            {
                return depthCounter;
            }

            var maxElementDepth = new List<int>();

            foreach (var branch in input.branches)
            {
                maxElementDepth.Add(Counter(branch, depthCounter));
            }

            depthCounter += maxElementDepth.Count == 0 ? 0 : maxElementDepth.Max();

            return depthCounter;
        }
    }
}