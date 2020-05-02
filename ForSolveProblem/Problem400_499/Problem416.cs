using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem416 : IProblem
    {
        public void RunProblem()
        {
            var temp = CanPartition(new int[] { 1, 5, 11, 5 });
            if (temp != true) throw new Exception();

            temp = CanPartition(new int[] { 1, 2, 3, 5 });
            if (temp != false) throw new Exception();
        }

        public bool CanPartition(int[] nums)
        {
            var sum = nums.Sum();
            if (sum % 2 != 0) return false;

            var target = sum / 2;
            var dp = Enumerable.Repeat(int.MinValue, target + 1).ToArray();
            dp[0] = 0;
            for (var i = 0; i < nums.Length; i++)
                for (var j = target; j >= nums[i]; j--)
                    dp[j] = Math.Max(dp[j], dp[j - nums[i]] + nums[i]);

            return dp[target] == target;
        }

        public bool CanPartition1(int[] nums)
        {
            /*
             * 题目概述：判断给定的数组元素，能否分割成元素和相同的两个子数组
             * 
             * 思路：
             *  1. 相当于判断给定的原材料能否拼接成目标长度的问题
             *  2. 首先需要知道目标的大小，即元素总和的一半是多少
             *      2.1 若为奇数，则不可能达成目标
             *      2.2 若为偶数，则开始继续探究可行性
             *  3. 考虑使用递归加备忘录的方式来实现，也可称为回溯法
             *
             * 关键点：
             *
             * 时间复杂度：O(n^2)
             * 空间复杂度：O(n^2)
             */

            var elementSum = nums.Sum();
            if ((elementSum & 1) == 1) return false;

            var targetValue = elementSum / 2;
            return BackTrace(nums, 0, targetValue, new Dictionary<int, bool>());
        }

        private bool BackTrace(int[] nums, int curIndex, int targetValue, IDictionary<int, bool> dic)
        {
            if (targetValue == 0) return true;
            if (targetValue < 0) return false;

            for (int i = curIndex; i < nums.Length; i++)
            {
                Swap(nums, curIndex, i);

                var subTargetValue = targetValue - nums[curIndex];
                bool resultTemp;
                if (dic.ContainsKey(subTargetValue))
                    resultTemp = dic[subTargetValue];
                else
                {
                    resultTemp = BackTrace(nums, curIndex + 1, subTargetValue, dic);
                    dic[subTargetValue] = resultTemp;
                }

                if (resultTemp) return true;

                Swap(nums, curIndex, i);
            }

            return false;
        }

        private void Swap(int[] nums, int index1, int index2)
        {
            var temp = nums[index1];
            nums[index1] = nums[index2];
            nums[index2] = temp;
        }
    }
}
