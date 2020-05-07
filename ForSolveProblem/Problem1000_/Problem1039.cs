using System;
namespace ForSolveProblem
{
    public class Problem1039 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MinScoreTriangulation(int[] A)
        {
            var n = A.Length;
            var dp = new int[n, n];
            for (var len = 3; len <= n; len++)
            {
                for (var left = 0; left + len - 1 <= n - 1; left++)
                {
                    var right = left + len - 1;

                    dp[left, right] = int.MaxValue;
                    for (var i = left + 1; i < right; i++)
                        dp[left, right] = Math.Min(dp[left, right], dp[left, i] + dp[i, right] + A[i] * A[left] * A[right]);
                }
            }

            return dp[0, n - 1];
        }
    }
}
