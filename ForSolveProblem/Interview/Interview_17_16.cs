using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Interview_17_16 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int Massage(int[] nums)
        {
            /*
             * 优化的空间复杂度的方法
             * 因为当前状态只依赖前 2 个状态,因此只维护优先的几个状态就可以了
             * 算法复杂度:
             *  1.时间复杂度:O(n)
             *  2.空间复杂度:O(1)
             */
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];

            var one = nums[0];
            var two = Math.Max(nums[1], one);
            for (var i = 2; i < nums.Length; i++)
            {
                var three = Math.Max(two, one + nums[i]);
                one = two;
                two = three;
            }

            return Math.Max(one, two);
        }

        public int Massage1(int[] nums)
        {
            /*
             * ##### 1. 题目概述：按摩师
             * 
             * ##### 2. 思路：
             *    - 特征：求所有可能解中的最优解问题;
             *    - 方案：
             *          定义状态 dp[n],表示到序列第 n 个索引处,总时长最大是多少;
             *          如果选择了第 n 个数,那么总时长最大就是 dp[n-2] + nums[n];
             *          如果不选第 n 个数,那么总时长最大就是 dp[n-1];
             *          从以上 2 种情况种,选择最大的,作为 dp[n]的值
             *    - 结果：dp 数组中的最大值
             *
             * ##### 3. 知识点：动态规划
             *  3.1 数组的规模是横向扩展的;
             *  3.2 对于每个元素,都有多种不同的选择;
             *  3.3 每种不同的选择,所依赖之前的结果集不同;
             * 
             * ##### 4. 复杂度分析: 
             *    - 时间复杂度：O(n)
             *    - 空间复杂度：O(n)
             */

            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];

            var dp = new int[nums.Length];
            dp[0] = nums[0];
            dp[1] = Math.Max(dp[0], nums[1]);

            for (var i = 2; i < nums.Length; i++)
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);

            return dp.Max();
        }
    }
}
