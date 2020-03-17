using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem485 : IProblem
    {
        public void RunProblem()
        {

        }

        public int FindMaxConsecutiveOnes(int[] nums)
        {
            var oneStrArray = string.Join("", nums).Split('0', StringSplitOptions.RemoveEmptyEntries);
            return oneStrArray.Any() ? oneStrArray.Max(i => i.Length) : 0;
        }

        public int FindMaxConsecutiveOnes2(int[] nums)
        {
            var forReturn = 0;
            var curCount = 0;
            foreach (var numItem in nums)
            {
                if (numItem == 1)
                    curCount++;
                else
                {
                    forReturn = Math.Max(forReturn, curCount);
                    curCount = 0;
                }
            }

            return Math.Max(forReturn, curCount);
        }

        public int FindMaxConsecutiveOnes1(int[] nums)
        {
            /*
             * ##### 1. 题目概述：最大连续 1 的个数
             * 
             * ##### 2. 思路：
             *    - 特征：就是要依次检测每个数字,如果是连续的 1 就做个单独的汇总;
             *    - 方案：两层循环,最外层负责记录最大连续 1 的个数,最内侧负责统计有多少个连续的 1
             *    - 结果：最外层循环记录的值,就是所求的解
             *
             * ##### 3. 知识点：数组
             * 
             * ##### 4. 复杂度分析: 
             *    - 时间复杂度：O(n)
             *    - 空间复杂度：O(1)
             */

            var forReturn = 0;
            var startIndex = 0;
            while (startIndex < nums.Length)
            {
                var count = 0;
                while (startIndex < nums.Length && nums[startIndex++] == 1)
                    count++;

                forReturn = Math.Max(forReturn, count);
            }

            return forReturn;
        }
    }
}
