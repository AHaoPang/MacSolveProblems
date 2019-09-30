using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem201 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int RangeBitwiseAnd(int m, int n)
        {
            /*
             * 将从m到n的位做与运算
             * 思路：
             *  1.n-m+1个数字做与运算
             *  2.就单个位而言，只要这个位置有过0，那么结果一定为0
             *  3.当进位的时候，包含进位与其右边的位，结果一定为0
             *  4.那么结果其实计算的是，m到n没有做过的进位，即从左侧起，m和n的最长的位相同的部分
             *  
             * 时间复杂度：O(1)，数字的长度是有限的，最长也就10位，因此是常量复杂度
             * 空间复杂度：O(1)
             */

            int count = 0;
            while (m != n)
            {
                m = m >> 1;
                n = n >> 1;
                count++;
            }

            return m << count;
        }
    }
}
