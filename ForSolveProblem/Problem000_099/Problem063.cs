using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem063 : IProblem
    {
        public void RunProblem()
        {
            var obstacleGrid = new int[][]
            {
                new int[]{0,0},
            };

            var temp = UniquePathsWithObstacles(obstacleGrid);
        }

        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            /*
             * 思路：
             * 1.同样，依据动态规则 当前格子的路径可能性 = 左边格子的路径可能性 + 上面格子的路径可能性；
             * 2.因为出现了障碍物，障碍物是不可通过的，因此可以认为障碍物所在格子的路径可能性为 0；
             * 3.接下来就是依据递推方程和限制条件，依次求解即可；
             * 
             * 时间复杂度：O(m*n)，还是要把传入的二维表格遍历一遍的
             * 空间复杂度：O(m)，依据依赖关系，我们只需要维护一个一位网格就可以解决问题了
             */

            /*假定了网格中，至少有一个元素*/
            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;
            int[,] dp = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < obstacleGrid[i].Length; j++)
                {
                    if (i == 0 && j == 0)
                        dp[i, j] = 1;
                    else if (i == 0)
                        dp[i, j] = dp[i, j - 1];
                    else if (j == 0)
                        dp[i, j] = dp[i - 1, j];
                    else
                        dp[i, j] = dp[i, j - 1] + dp[i - 1, j];

                    if (obstacleGrid[i][j] == 1) dp[i, j] = 0;
                }
            }

            return dp[m - 1, n - 1];
        }
    }
}
