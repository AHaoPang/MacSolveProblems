using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem1005 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int LargestSumAfterKNegations(int[] A, int K)
        {
            var na = A.OrderBy(i => i).ToList();
            var has0 = A.Any(i => i == 0);

            for (var i = 0; i < na.Count && na[i] < 0 && K > 0; i++, K--)
                na[i] = -na[i];

            var sum = na.Sum();
            if (K == 0 || has0 || K % 2 == 0) return sum;

            return sum - 2 * na.Min();
        }
    }
}
