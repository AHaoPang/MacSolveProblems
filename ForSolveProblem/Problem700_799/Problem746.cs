using System;
namespace ForSolveProblem
{
    public class Problem746 : IProblem
    {
        public int MinCostClimbingStairs1(int[] cost)
        {
            /*
             * 题目概述：可以走 1 步,也可以走 2 步,从开始走到最后,累计值最少是多少
             * 
             * 思路：
             *  1. 定义状态 dp[i] 表示走到第 i 个台阶,所消耗的最少累计值是多少
             *  2. 结果状态 min( dp[length-1],dp[length-2])
             *  3. 状态转移 dp[i] = min(dp[i-1],dp[i-2]) + cost[i]
             *
             * 关键点：
             *
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            var dp = new int[cost.Length];

            dp[0] = cost[0];
            dp[1] = cost[1];
            for (int i = 2; i < cost.Length; i++)
                dp[i] = Math.Min(dp[i - 1], dp[i - 2]) + cost[i];

            return Math.Min(dp[cost.Length - 1], dp[cost.Length - 2]);
        }

        public void RunProblem()
        {
            var temp = MinCostClimbingStairs(new int[] { 10, 15, 20 });
            if (temp != 15) throw new Exception();

            temp = MinCostClimbingStairs(new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 });
            if (temp != 6) throw new Exception();
        }

        public int MinCostClimbingStairs(int[] cost)
        {
            var dp = new int[cost.Length];

            dp[0] = cost[0];
            dp[1] = cost[1];

            for (var i = 2; i < cost.Length; i++)
                dp[i] = Math.Min(dp[i - 1], dp[i - 2]) + cost[i];

            return Math.Min(dp[cost.Length - 1], dp[cost.Length - 2]);
        }
    }
}
