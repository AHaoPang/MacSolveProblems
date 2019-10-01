using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem062 : IProblem
    {
        public void RunProblem()
        {
            var temp = UniquePaths(7, 3);
        }

        public int UniquePaths(int m, int n)
        {
            /*
             * 思路：
             * 1.依据动态规划的思想，当前格子的值 = 左边格子的值 + 上面格子的值
             * 2.那么可以将问题转换为一维数组的问题：当前格子的值 = 左边格子的值 + 当前格子的值 
             */

            int[] dp = new int[m];

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    if (i == 0 || j == 0)
                        dp[j] = 1;
                    else
                        dp[j] += dp[j - 1];
                }
            }

            return dp[m - 1];
        }

        public int UniquePaths1(int m, int n)
        {
            /*
             * 思路：从起点到终点，所有可能的路径和
             * 1.将起始位置到终止位置，想象成二维网格，到达每个单元格的路径可能性，一定等于它上面格子的可能性，加上，左面格子的可能性；
             * 2.基于以上的这个思想，可以不断累积计算得到：从起始位置到目标位置的可能性；
             * 
             * 时间复杂度：O(n*m)，遍历一次二维网格，右下角的格子值就是目标值；
             * 空间复杂度：O(n*m)，因为是一个二维网格；
             */

            int[,] dp = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0)
                        dp[i, j] = 1;
                    else
                        dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }

            return dp[m - 1, n - 1];
        }
    }
}
