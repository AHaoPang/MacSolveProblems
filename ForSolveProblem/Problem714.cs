using System;
namespace ForSolveProblem
{
    public class Problem714:IProblem
    {
        public int MaxProfit(int[] prices, int fee)
        {
            /*
             * 题目概述：为了在股票市场中,利润最大化
             * 
             * 思路：
             *  1. 定义状态,dp[i,2] 分别表示今天持有股票的现金数目,与今天不持有股票的现金数目
             *  2. 定义状态转移,
             *      2.1 今天不持有股票,说明昨天就没持有,或者说昨天持有了,今天给卖掉了,选择利润最大的情况
             *      2.2 今天持有股票,说明昨天就持有股票,或者说昨天没有,今天刚买的,选择利润最大的情况
             *
             * 关键点：
             *
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            var dp = new int[prices.Length, 2];

            var forReturn = 0;
            for(int i = 0;i < prices.Length; i++)
            {
                if(i == 0)
                {
                    dp[i, 0] = 0;
                    dp[i, 1] = -prices[i];
                }
                else
                {
                    dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i] - fee);
                    dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] - prices[i]);

                    forReturn = Math.Max(forReturn, Math.Max(dp[i, 0], dp[i, 1]));
                }
            }

            return forReturn;
        }

        public void RunProblem()
        {
            var temp = MaxProfit(new int[] { 1, 3, 2, 8, 4, 9 }, 2);
            if (temp != 8) throw new Exception();

            temp = MaxProfit(new int[] { 15, 4, 3, 2, 1 }, 1);
            if (temp != 0) throw new Exception();

        }
    }
}
