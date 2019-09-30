using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem462 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinMoves2(new int[] { 1, 2, 3 });
            if (temp != 2) throw new Exception();
        }

        public int MinMoves2(int[] nums)
        {
            /*
             * 最小移动次数，使数组元素相等
             * 思路：
             *  1.毫无疑问，往中间聚拢，移动次数是最少的
             *  2.那么主要就是如何求得中间位置的问题了
             *      2.1 总数是奇数 middlePos = n / 2
             *      2.2 总数是偶数 middlePos = n / 2 - 1 或 n / 2
             *      2.3 无论奇偶，middlePos = n / 2
             *  3.考虑使用快排的思路，在logn的时间里找到n/2
             *  4.遍历整个数组，累计其它数字与中位数的差值
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            var middlePos = nums.Length / 2;
            var middleValue = nums.OrderBy(i => i).ToArray()[middlePos];

            var forReturn = 0;
            foreach (var numItem in nums) forReturn += Math.Abs(numItem - middleValue);

            return forReturn;
        }
    }
}
