using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem072 : IProblem
    {
        public void RunProblem()
        {
            int temp = MinDistance("horse", "ros");
        }

        public int MinDistance(string word1, string word2)
        {
            /*
             * 动态规范法
             * 状态定义：word1的前i个字符和word2的前j个字符，最少的编辑距离
             * 状态推导：
             *     当前状态一共由3种状况得到：dp[i-1,j-1],dp[i-1,j],dp[i,j-1]后两者到dp[i,j]很显然是要做一个操作的，但是最前者是否做操作，主要看word[i]与word[j]是否相等
             * 时间复杂度：O(n*m)
             * 空间复杂度：O(n*m)
             */


            int[,] tableDistance = new int[word1.Length + 1, word2.Length + 1];

            for (int i = 0; i <= word1.Length; i++)
                tableDistance[i, 0] = i;

            for (int j = 0; j <= word2.Length; j++)
                tableDistance[0, j] = j;

            for (int k = 1; k <= word1.Length; k++)
                for (int l = 1; l <= word2.Length; l++)
                {
                    int opera = 1;
                    if (word1[k - 1] == word2[l - 1])
                        opera = 0;

                    tableDistance[k, l] = Math.Min(tableDistance[k - 1, l - 1] + opera, Math.Min(tableDistance[k - 1, l] + 1, tableDistance[k, l - 1] + 1));
                }

            return tableDistance[word1.Length, word2.Length];
        }
    }
}
