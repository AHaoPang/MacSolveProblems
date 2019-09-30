using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem286 : IProblem
    {
        public void RunProblem()
        {
            var temp = MissingNumber(new int[] { 3, 0, 1 });
            if (temp != 2) throw new Exception();

            temp = MissingNumber(new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 });
            if (temp != 8) throw new Exception();
        }

        public int MissingNumber(int[] nums)
        {
            /*
             * 一共有n+1个不同的元素，结果现在给了一个有n个元素的数组，那么丢失了哪一个呢？
             * 思路：
             *  1.考虑用异或的方式来解决
             *  2.期望中的数列+给出的数列，重复的元素会被抵消，最后剩下的就是丢失的那一个元素
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */


            int forReturn = nums.Length;
            for(int i = 0;i < nums.Length; i++)
            {
                forReturn ^= i;
                forReturn ^= nums[i];
            }

            return forReturn;
        }
    }
}
