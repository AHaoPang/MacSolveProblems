using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem326 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool IsPowerOfThree(int n)
        {
            /*
             * 判断n是否是3的次幂
             * 思路：
             *  1.将n转换为3进制的数，判断是否只有一个1即可
             *  
             * 时间复杂度：O(logn)
             * 空间复杂度：O(1)
             */

            if (n < 1) return false;

            while (n % 3 == 0) n /= 3;

            return n == 1;
        }
    }
}
