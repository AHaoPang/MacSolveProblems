using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5384 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            var maxValue = candies.Max();

            var res = new bool[candies.Length];
            for (var i = 0; i < candies.Length; i++)
                res[i] = candies[i] + extraCandies >= maxValue;

            return res;
        }
    }
}
