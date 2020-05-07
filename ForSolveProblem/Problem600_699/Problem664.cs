using System;
namespace ForSolveProblem
{
    public class Problem664 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int StrangePrinter(string s)
        {
            if (s.Length == 0) return 0;
            var n = s.Length;
            var dp = new int[n, n];

            for (var len = 1; len <= n; len++)
            {
                for (var i = 0; i + len - 1 < n; i++)
                {
                    var j = i + len - 1;
                    if (i == j)
                    {
                        dp[i, j] = 1;
                        continue;
                    }

                    dp[i, j] = 1 + dp[i + 1, j];
                    for (var k = i + 1; k <= j; k++)
                        if (s[k] == s[i])
                            dp[i, j] = Math.Min(dp[i, j], dp[i + 1, k - 1] + dp[k, j]);
                }
            }

            return dp[0, n - 1];
        }
    }
}
