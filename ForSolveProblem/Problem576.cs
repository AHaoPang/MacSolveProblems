using System;
namespace ForSolveProblem
{
    public class Problem576 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int FindPaths(int m, int n, int N, int i, int j)
        {
            /*
             * 题目概述：计算出界的路径总数
             * 
             * 思路：
             *  1.动态规划的思路,要计算 N 步内出界的情况,就去汇总 N-1 步内出界的情况
             *  2.当前位置在边缘时,移动一次都可以出界的情况,要记得汇总
             *  3.上一步中,上下左右四个位置的出界次数要汇总到本次中
             *
             * 关键点：
             *  1.当球位于边缘的时候,不光要汇总前一步出界的情况,还要加上自己可以出界的情况
             *
             * 时间复杂度： O(m*n*N)
             * 空间复杂度： O(m*n)
             */

            var dp = new int[m, n];
            var constNum = (int)1e9 + 7;
            var upDownLeftRightArray = new int[][]
            {
                new int[]{-1,0},
                new int[]{1,0},
                new int[]{0,-1},
                new int[]{0,1}
            };

            for (int k = 1; k <= N; k++)
            {
                var nextDp = new int[m, n];
                for (int row = 0; row < m; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        var times = 0;

                        if (row == 0) times++;
                        if (row == m - 1) times++;
                        if (col == 0) times++;
                        if (col == n - 1) times++;

                        foreach (var arrayItem in upDownLeftRightArray)
                        {
                            var newRow = row + arrayItem[0];
                            var newCol = col + arrayItem[1];

                            if (newRow < 0 || newRow >= m) continue;
                            if (newCol < 0 || newCol >= n) continue;

                            times += dp[newRow, newCol];
                            times %= constNum;
                        }

                        nextDp[row, col] = times;
                    }
                }

                dp = nextDp;
            }

            return dp[i, j];
        }
    }
}
