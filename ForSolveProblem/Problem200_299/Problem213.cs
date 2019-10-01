using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem213 : IProblem
    {
        public void RunProblem()
        {
            int[] nums = new int[] { 2, 3, 2 };
            var temp = Rob(nums);
            if (temp != 3) throw new Exception();

            nums = new int[] { 1, 2, 3, 1 };
            temp = Rob(nums);
            if (temp != 4) throw new Exception();

            nums = new int[] { 0,0 };
            temp = Rob(nums);
            if (temp != 0) throw new Exception();

        }

        public int Rob(int[] nums)
        {
            /*
             * 若为循环数组，那么取不相邻的数，最多能取多少
             * 思路：
             *  1.还是动态规划，现在是无头无尾的状态
             *  2.那可以这么考虑
             *      2.1 第0个位置，可以下手，最后一个位置放弃下手
             *      2.2 第0个位置，不下手，最后一个位置可以下手
             *      
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            //特殊情况处理
            if (!nums.Any()) return 0;
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 2) return nums[0] > nums[1] ? nums[0] : nums[1];

            //第0个位置，下手
            int[] dp0 = new int[nums.Length - 1];
            dp0[0] = nums[0];
            dp0[1] = nums[1] > dp0[0] ? nums[1] : dp0[0];

            for (int i = 2; i < nums.Length - 1; i++)
                dp0[i] = Math.Max(dp0[i - 1], dp0[i - 2] + nums[i]);

            //第0个位置，不下手
            int[] dp1 = new int[nums.Length];
            dp1[0] = 0;
            dp1[1] = nums[1];

            for (int j = 2; j < nums.Length; j++)
                dp1[j] = Math.Max(dp1[j - 1], dp1[j - 2] + nums[j]);

            return dp0[nums.Length - 2] > dp1[nums.Length - 1] ? dp0[nums.Length - 2] : dp1[nums.Length - 1];
        }
    }
}
