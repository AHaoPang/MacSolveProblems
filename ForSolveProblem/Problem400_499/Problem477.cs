using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem477 : IProblem
    {
        public void RunProblem()
        {
            var temp = TotalHammingDistance(new int[] { 4, 14, 2 });
        }

        public int TotalHammingDistance(int[] nums)
        {
            /*
             * 计算数组中任意两数汉明距离的总和
             * 思路：
             *  1.其实就是在统计每一位上1有多少，0有多少，然后乘法求和即可
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            int forReturn = 0;

            for (int j = 0; j < 32; j++)
            {
                int zeroCount = 0;
                int oneCount = 0;
                int zeroAmount = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    if ((nums[i] & 1) == 1) oneCount++;
                    else zeroCount++;

                    if (nums[i] == 0)
                    {
                        zeroAmount++;
                        continue;
                    }

                    nums[i] = nums[i] >> 1;
                }

                if (zeroAmount == nums.Length) break;

                forReturn += zeroCount * oneCount;
            }

            return forReturn;
        }
    }
}
