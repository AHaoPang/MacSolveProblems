using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class CompletePack_02 : IProblem
    {
        public void RunProblem()
        {
            /*
             * N个物品,每个物品都有无限个
             * V是背包的容量
             * 每个物品有自己的容量vi
             * 每个物品也有自己的价值wi
             * 
             * 那么如何装,才能让背包内总价值最大
             */

            var temp = Solution1();
        }

        private int Solution1()
        {
            /*
             * 定义状态:
             * dp[i] 表示前n个物品装入i容量背包,所能获取的最大价值
             * 
             */

            var N = 4;
            var V = 5;
            var vArr = new[] { 1, 2, 3, 4 };
            var wArr = new[] { 2, 4, 4, 5 };

            var dp = new int[V + 1];
            for (var i = 1; i <= N; i++)
                for (var j = vArr[i - 1]; j <= V; j++)
                    dp[j] = Math.Max(dp[j], dp[j - vArr[i - 1]] + wArr[i - 1]);

            return dp[V];
        }
    }
}
