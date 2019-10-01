using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem191 : IProblem
    {
        public void RunProblem()
        {
            var temp = HammingWeight(3);
        }

        public int HammingWeight(uint n)
        {
            /*
             * 数字二进制表示中，位为“1”的个数
             * 思路：
             *  1. n 与 n-1 与 以后，得到的结果中，n的二进制1一定是少了1个
             *  2. 只要n 不为0 ，那么就说明还有位为1，那就继续 与 n-1 做 与
             *  3. 直到把所有的位1 打掉
             *  
             * 时间复杂度：O(1)，如果数字的所有位都为1，那么显然要遍历32次，不论是那个无符号数字，遍历次数的上限是确定的
             * 空间复杂度：O(1),没有使用额外的存储空间
             */

            int forReturn = 0;

            while(n != 0)
            {
                n &= (n - 1);
                forReturn++;
            }

            return forReturn;
        }
    }
}
