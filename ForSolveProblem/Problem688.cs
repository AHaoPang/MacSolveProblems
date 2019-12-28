using System;
namespace ForSolveProblem
{
    public class Problem688 : IProblem
    {
        public void RunProblem()
        {
            var temp = KnightProbability(3, 2, 0, 0);
        }

        public double KnightProbability(int N, int K, int r, int c)
        {
            /*
             * 题目概述：走了 K 步以后,马依然在棋盘上的概率
             * 
             * 思路：
             *  1.想象一个 N*N 的棋盘
             *  2.如果走 0 步,那么棋盘每个位置依然在棋盘上的概率就是 1
             *  3.如果走 1 步,那么棋盘每个位置都有可能是从其它地方移动过来的,那么把其它格子的可能性求和再除以 8,就是当前格子的概率了
             *  4.有了状态的表示,也有了转态转移方程,问题就容易求解了
             *
             * 关键点：
             *
             * 时间复杂度：O(N*N*K)
             * 空间复杂度：O(N*N)
             */

            var dp = new double[N, N];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    dp[i, j] = 1;

            var rowArray = new int[] { -1, -2, -2, -1, 1, 2, 2, 1 };
            var colArray = new int[] { -2, -1, 1, 2, 2, 1, -1, -2 };
            for (int j = 1; j <= K; j++)
            {
                var newDp = new double[N, N];
                for (int row = 0; row < N; row++)
                {
                    for (int col = 0; col < N; col++)
                    {
                        var sumTemp = 0d;
                        for (int arrayIndex = 0; arrayIndex < rowArray.Length; arrayIndex++)
                        {
                            var rowTemp = row + rowArray[arrayIndex];
                            var colTemp = col + colArray[arrayIndex];

                            if (rowTemp >= 0 && rowTemp < N && colTemp >= 0 && colTemp < N)
                                sumTemp += dp[rowTemp, colTemp];
                        }

                        newDp[row, col] = sumTemp / 8;
                    }
                }
                dp = newDp;
            }

            return dp[r, c];
        }
    }
}
