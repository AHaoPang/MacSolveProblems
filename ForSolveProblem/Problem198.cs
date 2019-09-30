using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem198 : IProblem
    {
        public void RunProblem()
        {
            int[] nums = new int[] { 1, 2, 3, 1 };

            var temp = Rob(nums);
            if (temp != 4) throw new Exception();

            nums = new int[] { 2, 7, 9, 3, 1 };
            temp = Rob(nums);
            if (temp != 12) throw new Exception();

            nums = new int[] { 2, 1, 1, 2 };
            temp = Rob(nums);
            if (temp != 4) throw new Exception();
        }

        public int Rob(int[] nums)
        {
            /*
             * 计算不相邻数组元素的最大值
             * 思路：
             *  1.对于一个数组而言，若一个元素被选择了，那么接下来要从剩下的元素中继续做选择-->这是一个典型的自上而下的递归问题；
             *  2.总是会遇到重复的子问题，即上层做了选择，同一个下层对于同一个指令做了相同的操作多次-->这是典型的重复子问题；
             *  3.那考虑下“自下而上”的方法，来避免重复子问题
             *  4.定义dp[i]，表示，从0到第i个位置，能取到的最大值；
             *  5.dp[i] = max(dp[i-1],fun[i]+dp[i-2])
             *  6.从表达式可以看出，当前值，仅和前面两个值有关，属于类斐波那契数列问题
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            if (!nums.Any()) return 0;
            if (nums.Length == 1) return nums[0];

            int[] dp = new int[nums.Length + 1];
            dp[0] = 0;
            dp[1] = nums[0];

            for (int i = 1; i < nums.Length; i++)
                dp[i + 1] = Math.Max(dp[i - 1] + nums[i], dp[i]);

            return dp[nums.Length];
        }


    }
}
