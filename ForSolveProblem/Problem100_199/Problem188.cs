using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem188 : IProblem
    {
        public void RunProblem()
        {
            var temp = MaxProfit(2, new[] { 2, 4, 1 });
            if (temp != 2) throw new Exception();

            temp = MaxProfit(2, new[] { 3, 2, 6, 5, 0, 3 });
            if (temp != 7) throw new Exception();
        }

        public int MaxProfit(int k, int[] prices)
        {
            if (!prices.Any())
                return 0;

            if (k >= prices.Length)
                return Max(prices);

            var dp = new int[prices.Length, 2, k + 1];
            for (var i = 1; i <= k; i++)
                dp[0, 1, i] = -prices[0];
            dp[0, 1, 0] = int.MinValue;

            for (var i = 1; i < prices.Length; i++)
            {
                for (var l = 0; l <= k; l++)
                {
                    dp[i, 0, l] = Math.Max(dp[i - 1, 0, l], dp[i - 1, 1, l] + prices[i]);

                    dp[i, 1, l] = dp[i - 1, 1, l];
                    if (l - 1 >= 0)
                        dp[i, 1, l] = Math.Max(dp[i - 1, 1, l], dp[i - 1, 0, l - 1] - prices[i]);
                }
            }

            return dp[prices.Length - 1, 0, k];
        }

        private int Max(int[] prices)
        {
            var res = 0;
            for (var i = 0; i < prices.Length - 1; i++)
                if (prices[i] < prices[i + 1])
                    res += prices[i + 1] - prices[i];

            return res;
        }
    }
}
