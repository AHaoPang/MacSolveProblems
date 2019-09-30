using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem190 : IProblem
    {
        public void RunProblem()
        {
            var temp = reverseBits(43261596);
            if (temp != 964176192) throw new Exception();

            temp = reverseBits(4294967293);
            if (temp != 3221225471) throw new Exception();
        }

        public uint reverseBits(uint n)
        {
            /*
             * 颠倒无符号数的二进制位
             * 思路：
             *  1.使用位操作，逐渐取出一个数字的位，然后加到另一个数字中
             *  
             * 时间复杂度：O(1)，因为无符号数是32位，那么遍历的次数是固定的
             * 空间复杂度：O(1)，除了要返回的值外，不使用额外的存储空间
             */

            uint forReturn = 0;

            for (int i = 0; i < 32; i++)
            {
                forReturn = forReturn << 1;

                if ((n & 1) == 1) forReturn += 1;

                n = n >> 1;
            }

            return forReturn;
        }
    }
}
