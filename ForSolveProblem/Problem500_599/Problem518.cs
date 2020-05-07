using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem518 : IProblem
    {
        public void RunProblem()
        {
            var t = Change(5, new[] { 1, 2, 5 });
        }

        public int Change(int amount, int[] coins)
        {
            var dp = new int[amount + 1];
            dp[0] = 1;

            for (var i = 0; i < coins.Length; i++)
                for (var j = coins[i]; j <= amount; j++)
                    dp[j] = dp[j] + dp[j - coins[i]];

            return dp[amount];
        }
    }
}
