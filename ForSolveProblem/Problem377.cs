using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem377 : IProblem
    {
        public void RunProblem()
        {
            var temp = CombinationSum4(new int[] { 1, 2, 3 }, 4);
            if (temp != 7) throw new Exception();
        }

        private int BackTraceV2(int[] nums, int newTarget, IDictionary<int, int> dic)
        {
            if (newTarget == 0) return 1;
            if (dic.ContainsKey(newTarget)) return dic[newTarget];

            var sumResult = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                var subTemp = newTarget - nums[i];
                if (subTemp < 0) break;

                sumResult += BackTraceV2(nums, subTemp, dic);
            }

            dic[newTarget] = sumResult;
            return sumResult;
        }

        public int CombinationSum4(int[] nums, int target)
        {
            /*
             * 题目概述：使用给定的原材料，组合出目标数字，有多少种组合
             * 
             * 思路：
             *  1. 组合出目标数字，需要分为多个阶段去完成
             *  2. 每个阶段可选的原材料范围是固定的
             *  3. 这个问题，也是很典型的回溯算法问题
             *
             * 关键点：
             *
             * 时间复杂度： O(n^m)
             * 空间复杂度：O(1)
             */

            var orderedNums = nums.OrderBy(i => i).ToArray();

            return BackTraceV2(orderedNums, target, new Dictionary<int, int>());
        }

        private int m_count;
        private void BackTrace(int[] nums, int newTarget)
        {
            if (newTarget == 0)
            {
                m_count++;
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                var subTemp = newTarget - nums[i];
                if (subTemp < 0) break;

                BackTrace(nums, subTemp);
            }
        }
    }
}
