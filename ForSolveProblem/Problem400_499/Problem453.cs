using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem453 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinMoves(new int[] { 1, 2, 3 });
            if (temp != 3) throw new Exception();

            temp = MinMoves(new int[] { 1, 7, 8 });
            if (temp != 13) throw new Exception();

            temp = MinMoves(new int[] { 6, 7, 13, 15 });
            if (temp != 17) throw new Exception();
        }

        public int MinMoves(int[] nums)
        {
            /*
             * 为了使n个元素的值相等，需要移动的次数
             * 思路：
             *  1.这个问题，可以看成是一个此消彼长的过程
             *  2.一次只能让一个停止生长
             *  3.每次按住最大的，然后就能让最小的和最大的一样，与此同时就会出现新的最大值
             *  4.继续重复按住的过程即可
             *  5.可以算出，移动的次数，就是最小值与其他值的差的和
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            var min = nums.Min();

            var forReturn = 0;
            foreach (var numItem in nums) forReturn += numItem - min;

            return forReturn;
        }
    }
}
