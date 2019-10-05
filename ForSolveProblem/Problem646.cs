using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem646 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindLongestChain(new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 4 } });
            if (temp != 2) throw new Exception();

            temp = FindLongestChain(new int[][]
            {
                new int[]{3,4},
                new int[]{2,3},
                new int[]{1,2}
            });
            if (temp != 2) throw new Exception();
        }

        public int FindLongestChain(int[][] pairs)
        {
            var orderedPairs = pairs.OrderBy(i => i[1]).ToArray();

            var forReturn = 1;
            var curMax = orderedPairs.First()[1];
            for (int i = 1; i < orderedPairs.Length; i++)
            {
                if (orderedPairs[i][0] <= curMax) continue;

                forReturn++;
                curMax = orderedPairs[i][1];
            }

            return forReturn;
        }

        public int FindLongestChain1(int[][] pairs)
        {
            /*
             * 题目概述：在给出的数对中，判断能构造的最大的数对链有多长
             * 
             * 思路：
             *  1. 定义状态 dp[i] 表示从0开始一直到 i，i 参与其中的最长数对链有多长
             *  2. dp[i] = max(dp[x]) + 1 (x 是比 i 小的数对，x = 0~i-1)
             *  3. 遍历 dp 数组，找到最大的数值，即为解
             *
             * 关键点：
             *  1. 可以依据需要选择数对，即相对位置不固定
             *
             * 时间复杂度：O(n^2)
             * 空间复杂度：O(n)
             */

            var orderedPairs = pairs.OrderBy(i => i[0]).ToArray();
            var dp = Enumerable.Repeat(1, orderedPairs.Length).ToList();

            var forReturn = 1;
            for (int i = 1; i < orderedPairs.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (orderedPairs[j][1] < orderedPairs[i][0])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                        forReturn = Math.Max(forReturn, dp[i]);
                    }
                }
            }

            return forReturn;
        }
    }
}
