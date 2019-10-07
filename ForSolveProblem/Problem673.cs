using System;
namespace ForSolveProblem
{
    public class Problem673 : IProblem
    {
        public int FindNumberOfLIS(int[] nums)
        {
            /*
             * 题目概述：统计最长递增子序列的个数
             * 
             * 思路：
             *  1. 定义状态 dp[i][2] 表示从 0 开始到 i，i 参与到了哪几个最长子序列的构造中去了
             *  2. dp[i][0] 存放最长子序列的长度
             *  3. dp[i][1] 存放最长子序列的个数
             *  4. 最后遍历 dp[][1],即可汇总得到最长子序列的个数
             *
             * 关键点：
             *
             * 时间复杂度：O(n^2)
             * 空间复杂度：O(n)
             */

            var dp = new int[nums.Length, 2];

            var maxLength = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                var curMaxLength = 0;
                var curMaxLengthCount = 0;

                for (int j = 0; j < i; j++)
                {
                    if (nums[j] >= nums[i]) continue;

                    if (dp[j, 0] > curMaxLength)
                    {
                        curMaxLength = dp[j, 0];
                        curMaxLengthCount = dp[j, 1];
                    }
                    else if (dp[j, 0] == curMaxLength)
                    {
                        curMaxLengthCount += dp[j, 1];
                    }
                }

                dp[i, 0] = curMaxLength + 1;
                dp[i, 1] = curMaxLengthCount > 0 ? curMaxLengthCount : 1;

                maxLength = Math.Max(dp[i, 0], maxLength);
            }

            var forReturn = 0;
            for (int i = 0; i < nums.Length; i++)
                if (dp[i, 0] == maxLength)
                    forReturn += dp[i, 1];

            return forReturn;
        }

        public void RunProblem()
        {
            var temp = FindNumberOfLIS(new int[] { 1, 3, 5, 4, 7 });
            if (temp != 2) throw new Exception();

            temp = FindNumberOfLIS(new int[] { 2, 2, 2, 2, 2 });
            if (temp != 5) throw new Exception();

            temp = FindNumberOfLIS(new int[] { });
            if (temp != 0) throw new Exception();

            temp = FindNumberOfLIS(new int[] { 1, 2, 4, 3, 5, 4, 7, 2 });
            if (temp != 3) throw new Exception();
        }
    }
}
