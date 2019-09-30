using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem476 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindComplement(5);
        }

        public int FindComplement(int num)
        {
            //求得数字位数，然后与掩码求反

            int count = 0;
            int numTemp = num;
            while(numTemp != 0)
            {
                count++;
                numTemp = numTemp >> 1;
            }

            return num ^ ((1 << count) - 1);
        }

        public int FindComplement1(int num)
        {
            /*
             * 找寻数字的补数
             * 思路：
             *  1.将给定数字按位取反，然后前面的部分掩码掉即可
             *  
             * 时间复杂度：O(1)
             * 空间复杂度：O(1)
             */

            int mask = 0;
            for (int i = 31; i >= 0; i--)
            {
                var v = 1 << i;
                if ((num & v) == 0) mask = mask | v;
                else break;
            }

            return (int)((~(uint)num) & (~(uint)mask));
        }
    }
}
