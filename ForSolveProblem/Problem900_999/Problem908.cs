using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem908 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int SmallestRangeI(int[] A, int K)
        {
            var v = (a: A[0], b: A[0]);
            var (a, b) = A.Aggregate(v, (v, i) =>
              {
                  v.a = Math.Min(v.a, i);
                  v.b = Math.Max(v.b, i);
                  return v;
              });

            if (b - K <= a + K)
                return 0;

            return b - K - (a + K);
        }
    }
}
