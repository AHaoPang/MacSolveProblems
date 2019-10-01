using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem172 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int TrailingZeroes(int n)
        {
            /*
             * 计算阶乘后0的个数
             * 思路：
             *  1.0个个数，即10^x，10的次方，即 2*5 的次方
             *  2.因此，阶乘中包含多少个 2和5 是关键，因为2肯定比5多，所以只要统计5的个数就可以了
             *  3.要统计5的个数，只要不断的除以5就可以了
             *  
             * 时间复杂度：O(logn)
             * 空间复杂度：O(1)
             */

            int forReturn = 0;

            while(n != 0)
            {
                forReturn += n / 5;
                n = n / 5;
            }

            return forReturn;
        }
    }
}
