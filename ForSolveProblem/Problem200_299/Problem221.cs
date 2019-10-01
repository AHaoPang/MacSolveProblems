using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem221 : IProblem
    {
        public void RunProblem()
        {
        }

        public int MaximalSquare(char[][] matrix)
        {
            /*
             * 求解二维矩阵中的最大正方形面积
             * 思路：
             *  1.利用动态规划的方法计算得到，在指定大小的情况下，最大的矩阵
             *  
             * 时间复杂度：O(m*n)
             * 空间复杂度：O(n)
             */

            int rows = matrix.GetLength(0);
            if (rows == 0) return 0;

            int cols = matrix[0].Length;

            int[] dp = new int[cols];
            int maxLength = 0;

            for (int i = 0; i < rows; i++)
            {
                int preOld = dp[0];
                for (int j = 0; j < cols; j++)
                {
                    if (i == 0 || j == 0)
                        dp[j] = int.Parse(matrix[i][j].ToString());
                    else if (matrix[i][j] == '0')
                        dp[j] = 0;
                    else
                    {
                        int temp = Math.Min(preOld, Math.Min(dp[j - 1], dp[j])) + 1;
                        preOld = dp[j];
                        dp[j] = temp;
                    }

                    if (dp[j] > maxLength) maxLength = dp[j];
                }
            }

            return maxLength * maxLength;
        }
    }
}
