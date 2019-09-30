using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem064 : IProblem
    {
        public void RunProblem()
        {
            int[][] grid = new int[][]
            {
                new int[]{1,3,1},
                new int[]{1,5,1},
                new int[]{ 4, 2, 1 }
            };

            var temp = MinPathSum(grid);
            if (temp != 7) throw new Exception();
        }

        public int MinPathSum(int[][] grid)
        {
            /*
             * 在二维网格中，找到一条从左上角到右下角的路径，使得路径上的和最小
             * 思路：
             *  1.每个节点的前进，只能是向右，或者向下的，那么，要经过一个节点，就只能从上方，或者左侧过来。
             *  2.因此，这个结果，可以拆分成，从上方过来的路径和最小，还是从左侧过来的路径和最小。          -->将大问题拆分成小问题，大问题的最优解依赖于小问题的最优解
             *  3.到达一个位置的路径有很多种，但是只有个别路径的和是最小的。                               -->重复的子问题求解
             *  
             * 关于动态规划
             *  1.以上是一个求最优解的过程，因为到右下角的路径有很多，但是最优解的路径只是一部分；
             *  2.这个最优解大问题，可以分解成最优解小问题，而且大问题的解依赖于小问题的解，即存在最优子结构；
             *  3.可以自上而下的分析，然后为了解决重复子问题，可以自下而上的求解
             *  
             * 时间复杂度：O(m*n)，就是一个逐个填写二维网格的过程；
             * 空间复杂度：O(m*n)，就是要存储一个求解的二维网格；
             * 
             * 考察点：
             *  1.动态规划
             */

            int heighTemp = grid.GetLength(0);
            int[][] dp = new int[heighTemp][];

            for (int i = 0; i < heighTemp; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (dp[i] == null) dp[i] = new int[grid[i].Length];

                    if (i == 0 && j == 0)
                        dp[i][j] = grid[i][j];
                    else if (i == 0)
                        dp[i][j] = dp[i][j - 1] + grid[i][j];
                    else if (j == 0)
                        dp[i][j] = dp[i - 1][j] + grid[i][j];
                    else
                        dp[i][j] = Math.Min(dp[i - 1][j], dp[i][j - 1]) + grid[i][j];
                }
            }

            return dp[heighTemp - 1].Last();
        }
    }
}
