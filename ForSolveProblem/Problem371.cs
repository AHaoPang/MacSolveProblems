using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem371 : IProblem
    {
        public void RunProblem()
        {
            var temp = GetSum(1, 2);

            temp = GetSum(-2, 3);
        }

        public int GetSum(int a, int b)
        {
            /*
             * 在不使用 + 、-运算符的前提下，完成两个整数的加法运算
             * 思路：
             *  1.加法，实际上是由位的两部运算完成的
             *  2.先做异或运算，将不同的位补齐
             *  3.再做与运算，查看未补齐的进位
             *  4.若3与运算的结果为0，那么结束，反之要把与运算的结果左移后，继续第2步骤
             *  
             * 时间复杂度：O(1)，整数的位是有限的，最多32位，因此循环的次数是有上限的，因此是常量的复杂度
             * 空间复杂度：O(1)，使用的额外空间是固定大小的
             */

            int sum = 0;
            while(b != 0)
            {
                sum = a ^ b;
                b = a & b;

                if (b == 0) break;

                b = b << 1;
                a = sum;
            }

            return sum;
        }
    }
}
