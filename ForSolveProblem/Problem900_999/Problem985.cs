using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem985 : IProblem
    {
        public void RunProblem()
        {
            var temp = SumEvenAfterQueries(new[] { 3, 2 }, new int[][] { new[] { 4, 0 }, new[] { 3, 0 } });
        }

        public int[] SumEvenAfterQueries(int[] A, int[][] queries)
        {
            var res = new int[queries.Length];
            var curSum = A.Sum(i => (i & 1) == 0 ? i : 0);
            var curIndex = 0;

            foreach (var querItem in queries)
            {
                var val = querItem[0];
                var index = querItem[1];

                var curValue = A[index];
                if ((curValue & 1) == 0)
                    curSum -= curValue;

                var newValue = curValue + val;
                if ((newValue & 1) == 0)
                    curSum += newValue;

                A[index] = newValue;
                res[curIndex++] = curSum;
            }

            return res;
        }
    }
}
