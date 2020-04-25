using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class MultiplePack_03 : IProblem
    {
        public void RunProblem()
        {
            var temp = Solution1();

            temp = Solution2();
        }

        private int Solution1()
        {
            /*
             * 多重背包问题
             * N个物品
             * V容量的背包
             * 每个物品有自己的容量vi,而言还有数量ki
             * 
             * 那么将物品装入背包,可以装下的最大价值是多少
             */

            var N = 4;
            var V = 5;
            var vArr = new[] { 1, 2, 3, 4 };
            var wArr = new[] { 2, 4, 4, 5 };
            var kArr = new[] { 3, 1, 3, 2 };

            var dp = new int[V + 1];
            for (var i = 1; i <= N; i++)
                for (var j = V; j >= vArr[i - 1]; j--)
                    for (var k = 0; k <= kArr[i - 1] && k * vArr[i - 1] <= j; k++)
                        dp[j] = Math.Max(dp[j], dp[j - k * vArr[i - 1]] + k * wArr[i - 1]);

            return dp[V];
        }

        private int Solution2()
        {
            var N = 4;
            var V = 5;
            var vArr = new[] { 1, 2, 3, 4 };
            var wArr = new[] { 2, 4, 4, 5 };
            var kArr = new[] { 3, 1, 3, 2 };

            var queue = new Queue<(int v, int w)>();
            for (var i = 0; i < N; i++)
            {
                for (var k = 1; k <= kArr[i]; k *= 2)
                {
                    queue.Enqueue((k * vArr[i], k * wArr[i]));
                    kArr[i] -= k;
                }

                if (kArr[i] > 0)
                    queue.Enqueue((kArr[i] * vArr[i], kArr[i] * wArr[i]));
            }

            var dp = new int[V + 1];
            foreach (var (v, w) in queue)
                for (var j = V; j >= v; j--)
                    dp[j] = Math.Max(dp[j], dp[j - v] + w);

            return dp[V];
        }
    }
}
