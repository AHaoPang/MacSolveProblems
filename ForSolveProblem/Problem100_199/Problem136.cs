using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem136 : IProblem
    {
        public void RunProblem()
        {
            var temp = SingleNumber(new int[] { 4, 1, 2, 1, 2 });
        }

        public int SingleNumber(int[] nums)
        {
            /*
             * 考虑如何不使用额外的空间
             * 1.可以考虑使用“异或运算”，位相同为0，位不同为1
             * 
             * 时间复杂度：O(n)，只需要遍历一次数组即可；
             * 空间复杂度：O(1)，使用固定大小的额外空间
             */

            int forReturn = 0;
            for(int i = 0;i < nums.Length;i++)
            {
                if (i == 0)
                    forReturn = nums[i];
                else
                    forReturn ^= nums[i];
            }

            return forReturn;
        }

        public int SingleNumber2(int[] nums)
        {
            /*
             * 查找只出现了一次的数字
             * 思路：
             *  1.站在统计的角度来看，只出现一次，那就说明可以统计每个数字出现的次数，然后找到满足要求的数字即可
             *  2.因此考虑到使用 HashTable
             *  
             * 时间复杂度：O(n)，编辑数组一次，做统计，再遍历HashTable一次，找满足要求的
             * 空间复杂度：O(n)，因为有可能要把所有的数字都统计一遍
             */

            Dictionary<int, int> numCount = new Dictionary<int, int>();

            foreach(var numItem in nums)
            {
                if (!numCount.ContainsKey(numItem))
                    numCount[numItem] = 0;

                numCount[numItem]++;
            }

            foreach(var countItem in numCount)
                if (countItem.Value == 1) return countItem.Key;

            return -1;
        }
    }
}
