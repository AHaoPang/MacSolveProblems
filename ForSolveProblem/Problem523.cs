using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem523 : IProblem
    {
        public void RunProblem()
        {
            var temp = CheckSubarraySum(new int[] { 23, 2, 4, 6, 7 }, 6);
            if (temp != true) throw new Exception();

            temp = CheckSubarraySum(new int[] { 0, 0, 0 }, 0);
            if (temp != true) throw new Exception();

            temp = CheckSubarraySum(new int[] { 2, 34, 56 }, 1);
            if (temp != true) throw new Exception();
        }

        public bool CheckSubarraySum(int[] nums, int k)
        {
            /*
             * 判断是否存在连续的子数组之和为K的倍数
             * 思路：
             *  1.考虑累计求和的方式，对每次累计和与K取余
             *  2.两个累计和取余的结果相同，那么他们的差值一定可以被K整除
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(K)
             */

            var indexArray = new Dictionary<int, int>() { { 0, -1 } };

            var sumTemp = 0;
            for(int i = 0;i < nums.Length; i++)
            {
                sumTemp += nums[i];

                int indexTemp = sumTemp;
                if (k != 0) indexTemp = sumTemp % k;

                if (!indexArray.ContainsKey(indexTemp)) indexArray[indexTemp] = i;
                else if(i - indexArray[indexTemp] > 1) return true;
            }

            return false;
        }
    }
}
