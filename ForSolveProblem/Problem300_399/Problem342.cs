using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem342 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool IsPowerOfFour(int num)
        {
            /*
             * 判断整数是否是4的次幂
             * 思路：
             *  1.4的次幂，一定是在二进制的一个奇数位为1，其余位都是0的情况
             *  2.那么判断，必须是2的次幂，而且1的位置在奇数位
             *  
             * 时间复杂度：O(1)
             * 空间复杂度：O(1)
             */

            return num > 0 && (num & (num - 1)) == 0 && (num & 0x55555555) != 0;
        }
    }
}
