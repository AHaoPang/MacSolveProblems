using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5348 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
        {
            var forReturn = 0;

            foreach (var arrItem in arr1)
                if (!arr2.Any(i => i >= arrItem - d && i <= arrItem + d))
                    forReturn++;

            return forReturn;
        }
    }
}
