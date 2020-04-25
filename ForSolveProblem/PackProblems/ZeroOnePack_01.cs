using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class ZeroOnePack_01 : IProblem
    {
        public void RunProblem()
        {
            /*
             * N个物品,一个容量为V的背包
             * 每个物品的大小是 vi
             * 每个物品的价值是 wi
             * 
             * 那么,如何选择物品,来让背包所装物品价值最大呢?
             * 
             * 4 5
             * 1 2
             * 2 4
             * 3 4
             * 4 5
             * 
             * 每个物品都只有一件,可以选择装入,也可以选择不装入
             * 定义状态dp[i][v]表示前i个物品选择完成以后,容量为v的背包的最大价值是多少
             * dp[i][v] = max(dp[i-1][v],dp[i-1][v-vi] + wi)
             */

            var temp = Solution01();

            temp = Solution2();
        }

        /// <summary>
        /// 二维数组的常规解法
        /// </summary>
        private int Solution01()
        {
            /*
             * 每个物品都只有一件,可以选择装入,也可以选择不装入
             * 定义状态dp[i][v]表示前i个物品选择完成以后,容量为v的背包的最大价值是多少
             * dp[i][v] = max(dp[i-1][v],dp[i-1][v-vi] + wi)
             */

            var N = 4;
            var V = 5;
            var vArr = new[] { 1, 2, 3, 4 };
            var wArr = new[] { 2, 4, 4, 5 };

            var dp = new int[N + 1, V + 1];
            for (var i = 1; i <= N; i++)
            {
                for (var j = 1; j <= V; j++)
                {
                    dp[i, j] = dp[i - 1, j];

                    var vi = vArr[i - 1];
                    var wi = wArr[i - 1];
                    if (vi <= j)
                        dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j - vi] + wi);
                }
            }

            var res = 0;
            for (var i = 0; i < V + 1; i++)
                res = Math.Max(res, dp[N, i]);

            return res;
        }

        /// <summary>
        /// 找规律后简化成一维数组
        /// 1.每一行只和上一行有关
        /// 2.修改的值刚好是上一次的值与前面的值
        /// </summary>
        private int Solution2()
        {
            var N = 4;
            var V = 5;
            var vArr = new[] { 1, 2, 3, 4 };
            var wArr = new[] { 2, 4, 4, 5 };

            var dp = new int[V + 1];
            for (var i = 1; i <= N; i++)
                for (var j = V; j >= vArr[i - 1]; j--)
                    dp[j] = Math.Max(dp[j], dp[j - vArr[i - 1]] + wArr[i - 1]);

            return dp[V]; //最优解是一定会保存在这个地方的
        }
    }
}
