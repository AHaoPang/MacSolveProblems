using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem263 : IProblem
    {
        public void RunProblem()
        {
            var temp = IsUgly(6);
            if (temp != true) throw new Exception();

            temp = IsUgly(8);
            if (temp != true) throw new Exception();

            temp = IsUgly(14);
            if (temp != false) throw new Exception();
        }

        public bool IsUgly(int num)
        {
            /*
             * 判断一个数字，是否是丑数，也就是是否能被 2、3、5 整除
             * 思路：
             *  1. 一个数，如果可以用 2^x * 3^y * 5^z表示，那么这个数就是丑数了
             *  2. 比如说，8 = 2^3 * 3^0 * 5^0，所以8是丑数
             *  3. 那么只要在循环中，不断整除各个因子就好了，如果最后的结果为1，那么就是丑数了
             *  
             * 时间复杂度：O(logn)，因为是不断的做除法，因此循环次数就是对数的复杂度了
             * 空间复杂度：O(1)，使用的额外空间固定
             */

            if (num <= 0) return false;

            while (num % 2 == 0) num /= 2;
            while (num % 3 == 0) num /= 3;
            while (num % 5 == 0) num /= 5;

            return num == 1;
        }
    }
}
