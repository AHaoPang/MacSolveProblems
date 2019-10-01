using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem560 : IProblem
    {
        public void RunProblem()
        {
            var temp = SubarraySum(new int[] { 1, 1, 1 }, 2);
            if (temp != 2) throw new Exception();
        }

        public int SubarraySum(int[] nums, int k)
        {
            /*
             * 找寻和为K的子数组
             * 思路：
             *  1.若把数组的累计值看做是一个折线图
             *  2.那么K表示的就是一种上升（正数）或者下降“负数”的趋势
             *  3.每累计到一个位置，然后可以往K的方向上看一下，有没有层级留下的足迹，能表明从那时到现在的趋势就是K
             *  
             * 时间复杂度：O(n)，数组的N个元素都是要遍历一次的
             * 空间复杂度：O(n)，数组N个元素，累计出N种情况
             */

            var forReturn = 0;
            var sum = 0;
            var sumResultDic = new Dictionary<int, int>() { { 0, 1 } };
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                var posTemp = sum - k;
                if (sumResultDic.ContainsKey(posTemp)) forReturn += sumResultDic[posTemp];

                if (!sumResultDic.ContainsKey(sum)) sumResultDic[sum] = 0;
                sumResultDic[sum]++;
            }

            return forReturn;
        }
    }
}
