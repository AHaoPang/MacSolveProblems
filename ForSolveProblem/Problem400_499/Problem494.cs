using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem494 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindTargetSumWays(new int[] { 1, 1, 1, 1, 1 }, 3);
            if (temp != 5) throw new Exception();

            temp = FindTargetSumWays(new int[] { 1 }, 2);
            if (temp != 0) throw new Exception();

            temp = FindTargetSumWays(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 1 }, 1);
            if (temp != 256) throw new Exception();
        }

        public int FindTargetSumWays(int[] nums, int S)
        {
            var sumTemp = nums.Sum();
            if (sumTemp < S) return 0;

            var dp = new int[nums.Length, 2 * sumTemp + 1];

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j <= 2 * sumTemp; j++)
                {
                    if (i == 0)
                    {
                        dp[i, nums[i] + sumTemp] += 1;
                        dp[i, -nums[i] + sumTemp] += 1;
                        break;
                    }

                    var sumTotal = 0;
                    if (j - nums[i] >= 0) sumTotal += dp[i - 1, j - nums[i]];
                    if (j + nums[i] <= 2 * sumTemp) sumTotal += dp[i - 1, j + nums[i]];
                    dp[i, j] += sumTotal;
                }
            }

            return dp[nums.Length - 1, S + sumTemp];
        }

        public int FindTargetSumWays1(int[] nums, int S)
        {
            /*
             * 题目概述：n 个元素构造目标和的过程
             * 
             * 思路：
             *  1. 每个元素都有两个选择：添加+号，添加-号
             *  2. 当元素添加完符号以后，下一个数字就会有新的目标了
             *  3. 父层元素期望返回达成目标的次数
             *
             * 关键点：
             *
             * 时间复杂度：O(2^n)
             * 空间复杂度：O(2^n)
             */

            return Recursive(nums, 0, S, new Dictionary<string, int>());
        }

        private int Recursive(int[] nums, int curIndex, int targetValue, IDictionary<string, int> dic)
        {
            var keyTemp = $"{curIndex}_{targetValue}";
            if (dic.ContainsKey(keyTemp)) return dic[keyTemp];

            if (curIndex == nums.Length) return targetValue == 0 ? 1 : 0;

            var v1 = Recursive(nums, curIndex + 1, targetValue - nums[curIndex], dic);
            var v2 = Recursive(nums, curIndex + 1, targetValue + nums[curIndex], dic);

            dic[keyTemp] = v1 + v2;
            return v1 + v2;
        }
    }
}
