using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1523 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int CountOdds(int low, int high)
        {
            var total = high - low + 1;
            var res = total / 2;

            if (total % 2 != 0 && high % 2 != 0)
                res++;

            return res;
        }
    }
}
