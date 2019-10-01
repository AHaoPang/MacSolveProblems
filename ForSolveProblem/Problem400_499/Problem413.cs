using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem413 : IProblem
    {
        public void RunProblem()
        {
            var temp = NumberOfArithmeticSlices(new int[] { 1, 2, 3, 4 });
            if (temp != 3) throw new Exception();

            temp = NumberOfArithmeticSlices(new int[] { 1, 2, 3, 4, 7, 8, 9, 10, 12, 14, 16, 18, 30 });
            if (temp != 12) throw new Exception();
        }

        public int NumberOfArithmeticSlices(int[] A)
        {
            /*
             * 判断一个数组中，等差数列的个数
             * 思路：
             *  1.挨个遍历数组元素的时候，是可以判断出来截止当前，前面的元素是否是等差数列的，以及等差数列的长度是多少
             *  2.当已知一段等差出列的长度SubLength以后，那么此段等差数列可以分解成 (SubLength-2)(SubLength-1)/2，若SubLength本身就减去了2，那么分解成SubLength*(SubLength+1)/2
             *  
             *  时间复杂度：O(n)
             *  空间复杂度：O(1)
             */

            var forReturn = 0;
            var count = 0;
            for (int i = 2; i < A.Length; i++)
            {
                if (A[i] - A[i - 1] == A[i - 1] - A[i - 2])
                    count++;
                else
                {
                    forReturn += count * (count + 1) / 2;
                    count = 0;
                }
            }

            return forReturn + count * (count + 1) / 2;
        }
    }
}
