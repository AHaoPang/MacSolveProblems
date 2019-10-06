using System;
using System.IO.IsolatedStorage;

namespace ForSolveProblem
{
    public class Problem376 : IProblem
    {
        public void RunProblem()
        {
            var temp = WiggleMaxLength(new int[] { 1, 7, 4, 9, 2, 5 });
            if (temp != 6) throw new Exception();

            temp = WiggleMaxLength(new int[] { 1, 17, 5, 10, 13, 15, 10, 5, 16, 8 });
            if (temp != 7) throw new Exception();

            temp = WiggleMaxLength(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            if (temp != 2) throw new Exception();
        }

        public int WiggleMaxLength(int[] nums)
        {
            if (nums.Length <= 1) return nums.Length;

            var initIsPositive = false;
            var initCount = 1;
            var isStart = false;

            for (int i = 1; i < nums.Length; i++)
            {
                var subValue = nums[i] - nums[i - 1];
                if (subValue == 0) continue;

                if (!isStart)
                {
                    initIsPositive = subValue > 0;
                    initCount++;
                    isStart = true;
                }
                else
                {
                    var isPositive = subValue > 0;
                    if (initIsPositive != isPositive)
                    {
                        initIsPositive = isPositive;
                        initCount++;
                    }
                }
            }

            return initCount;
        }

        public int WiggleMaxLength1(int[] nums)
        {
            /*
             * 题目概述：从数组中找到最长的摆动子序列的长度
             * 
             * 思路：
             *  1. 定义状态：dp[i,2] 表示长度为 i 的数组，与前面差值为正数是的最大长度，以及差值为负数的最大长度
             *  2. dp[i,0] = max(dp[i-x,1])+1; nums[i-x]与num[i]的差值为负
             *  3. dp[i,1] = max(dp[i-y,0])+1; nums[i-y]与num[i]的差值为正
             *  4. 最后从 dp 中找到最大的数字，作为结果
             *
             * 关键点：
             *
             * 时间复杂度： O(n^2)
             * 空间复杂度： O(n)
             */

            if (nums.Length == 0) return 0;

            var dp = new int[nums.Length, 2];
            dp[0, 0] = 1;
            dp[0, 1] = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                int positive = 1;
                int negitive = 1;
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] - nums[j] > 0) positive = Math.Max(positive, dp[j, 1] + 1);
                    else if (nums[i] - nums[j] < 0) negitive = Math.Max(negitive, dp[j, 0] + 1);
                }
                dp[i, 0] = positive;
                dp[i, 1] = negitive;
            }

            var forReturn = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                forReturn = Math.Max(dp[i, 0], forReturn);
                forReturn = Math.Max(dp[i, 1], forReturn);
            }
            return forReturn;
        }
    }
}
