using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem718 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindLength(new int[] { 1, 2, 3, 2, 1 }, new int[] { 3, 2, 1, 4, 7 });
            if (temp != 3) throw new Exception();
        }

        public int FindLength(int[] A, int[] B)
        {
            /*
             * 找到两个数组的最长公共子数组的长度
             * 思路：
             *  1.A数组的长度为N，B数组的长度为M
             *  2.A可以构造N个子数组，B可以构造M个子数组
             *  3.那么A和B可以构成的子数组的组合就有N*M个
             *  4.考虑用DP[i][j]表示对应的子数组组合下，最长的公共子数组的长度
             *  5.如果A[i] == B[j]，那么它的DP[i][j] = DP[i+1][j+1] + 1
             *  
             * 时间复杂度：O(n*m)，因为一共有这么多组合，所以就要遍历这么多次
             * 空间复杂度：O(n*m)，需要一个二维数组来存储这么多种组合
             */

            int[,] dp = new int[A.Length + 1, B.Length + 1];
            var forReturn = 0;
            for (int i = A.Length - 1; i >= 0; i--)
            {
                for (int j = B.Length - 1; j >= 0; j--)
                {
                    if (A[i] != B[j]) continue;

                    dp[i, j] = dp[i + 1, j + 1] + 1;
                    forReturn = Math.Max(forReturn, dp[i, j]);
                }
            }

            return forReturn;
        }
    }
}
