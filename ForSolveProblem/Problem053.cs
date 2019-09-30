using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem053 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MaxSubArray(int[] nums)
        {
            /*
             * 思路：对前一个方法的改进在于，使用一个一维数组来维护
             */

            int maxTemp = int.MinValue;
            int[] dp = new int[nums.Length];
            dp[0] = nums[0];

            for(int i = 1; i < nums.Length; i++)
                dp[i] = Math.Max(nums[i], dp[i - 1] + nums[i]);

            foreach (var dpItem in dp) if (maxTemp < dpItem) maxTemp = dpItem;
            return maxTemp;
        }

        public int MaxSubArray1(int[] nums)
        {
            /*
             * 思路：
             * 1.使用dynamic program的方式来做；
             * 2.状态定义：每个元素，都有两种选择（状态）：加入前面的序列、不加入前面序列；
             * 3.状态转移：对于后一个元素，不加入，那么值就是自己了，加入的话，就要思考：加入前者值最大的可能性才有意义；
             * 4.最后的结果，就存在于这个二维数组中，遍历它找不来即可
             * 
             * 时间复杂度：O(n)，先遍历一遍元数据得到一个二维数组，再遍历二维数组，得到最后期望的结果；
             * 空间复杂度：O(n)，因为要记录并维护一个二维数组的关系；
             */

            /*按照题目的逻辑来理解的话，输入的序列是至少有一个元素的，不然返回的最大值就会比较随意了*/

            int maxTemp = int.MinValue;
            int[,] dp = new int[nums.Length, 2];
            dp[0, 0] = nums[0];
            dp[0, 1] = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                dp[i, 0] = nums[i];
                dp[i, 1] = Math.Max(dp[i - 1, 0], dp[i - 1, 1]) + nums[i];
            }

            foreach (var dpItem in dp) if (maxTemp < dpItem) maxTemp = dpItem;
            return maxTemp;
        }
    }
}
