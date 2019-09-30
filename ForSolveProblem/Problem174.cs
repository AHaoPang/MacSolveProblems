using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem174 : IProblem
    {
        public void RunProblem()
        {
            var temp = CalculateMinimumHP(new int[][]
            {
                new int[]{ -2, -3, 3 },
                new int[]{ -5, -10, 1 },
                new int[]{ 10, 30, -5 }
            });
        }

        public int CalculateMinimumHP(int[][] dungeon)
        {
            /*
             * 使用动态规划的方式来求解：
             * 最后活下来，HP至少是1，那么走到最后一个格子的时候，值就是确定的了；
             * 因为最后活下来是确定的，那么就只好逆序推理最开始的值了；
             * 
             * dp[i,j]表示，进入这个格子前，HP的值，这个值要保证，进入当前格子后，最后的HP大于1；
             * 情况一：最后活下来是1，那么右下角格子的必须是dp[i,j] = max(1,1-dungeon[i,j])
             * 情况二：最下一行，是依赖右边的格子的；
             * 情况三：最右一行，是依赖下面的格子的；
             * 情况四：中间的格子，依赖于下面和右边格子的值；
             * 最后，dp[0,0]就是要求解的最小HP
             */

            int width = dungeon.GetLength(0);
            int heigh = dungeon[0].GetLength(0);
            int[,] dp = new int[width, heigh];

            for (int i = width - 1; i >= 0; i--)
            {
                for (int j = heigh - 1; j >= 0; j--)
                {
                    if (i == width - 1 && j == heigh - 1)
                        dp[i, j] = Math.Max(1 - dungeon[i][j], 1);
                    else if (i == width - 1 && j != heigh - 1)
                        dp[i, j] = Math.Max(dp[i, j + 1] - dungeon[i][j], 1);
                    else if (j == heigh - 1 && i != width - 1)
                        dp[i, j] = Math.Max(dp[i + 1, j] - dungeon[i][j], 1);
                    else
                        dp[i, j] = Math.Max(Math.Min(dp[i, j + 1], dp[i + 1, j]) - dungeon[i][j], 1);
                }
            }

            return dp[0, 0];
        }
    }
}
