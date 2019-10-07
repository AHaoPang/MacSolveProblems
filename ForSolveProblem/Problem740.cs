using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem740 : IProblem
    {
        public int DeleteAndEarn(int[] nums)
        {
            /*
             * 题目概述：拿到一个数字,就失去另外两个可能的数字,问最多可以拿多少数字
             * 
             * 思路：
             *  1. 定义状态 dp[i,2],表示从 1 开始的第 n 个数字,有 2 种状态,拿或者不拿,获得的点数分别是多少
             *  2. 数据范围在 10000 以内,那么结果将会是 max( dp[10000,0],dp[10000,1] )
             *  3. 状态转移方程:
             *      3.1 dp[i,0] 不拿 = max(dp[i-1,0],dp[i-1,1])
             *      3.2 dp[i,1] 拿  = dp[i-1,0] + a * i (a 是给定数组中 i 的个数)
             *  4. 在开始用 dp 处理前,需要统计各个数字的个数
             *
             * 关键点：
             *
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            var maxNum = 0;
            var numDic = new Dictionary<int, int>(nums.Length);
            for (int i = 0; i < nums.Length; i++)
            {
                var numTemp = nums[i];

                if (!numDic.ContainsKey(numTemp)) numDic[numTemp] = 0;
                numDic[numTemp]++;

                maxNum = Math.Max(maxNum, numTemp);
            }

            var dp = new int[maxNum + 1, 2];

            for (int i = 1; i <= maxNum; i++)
            {
                var numCountTemp = 0;
                if (numDic.ContainsKey(i)) numCountTemp = numDic[i];

                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1]);
                dp[i, 1] = dp[i - 1, 0] + i * numCountTemp;
            }

            return Math.Max(dp[maxNum, 0], dp[maxNum, 1]);
        }

        public void RunProblem()
        {
            var temp = DeleteAndEarn(new int[] { 3, 4, 2 });
            if (temp != 6) throw new Exception();

            temp = DeleteAndEarn(new int[] { 2, 2, 3, 3, 3, 4 });
            if (temp != 9) throw new Exception();

            temp = DeleteAndEarn(new int[] { 2, 2, 3, 3, 4, 9999, 9998 });
            if (temp != 10007) throw new Exception();
        }
    }
}
