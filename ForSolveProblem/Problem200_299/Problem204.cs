using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem204 : IProblem
    {
        public void RunProblem()
        {
            var temp = CountPrimes(10000);
        }

        public int CountPrimes(int n)
        {
            /*
             * 小于n的质数的个数统计
             * 思路：
             *  1.质数，就是除了1和它自身以外，无法再被其它自然数整除的数字
             *  2.用一个数组，表示小于n的所有数
             *  3.从2开始，2是质数，然后把其余2的倍数，标记为非质数
             *  4.从下一个未标记的数开始，是3，标记为质数，然后把其余3的倍数，标记为非质数
             *  5.一直标记下去，知道小于n的数全部被标记完了
             * 
             * 时间复杂度：O(k*n)，k是质数的个数，n是要校验的个数
             * 空间复杂度：O(n)
             */

            int[] readyNums = new int[n];

            //循环标记
            //0：待标记
            //1: 质数
            //2. 非质数
            for (int j = 2; j < n; j++)
            {
                if (readyNums[j] == 0)
                {
                    readyNums[j] = 1;
                    for (int k = j * 2; k < n; k += j) readyNums[k] = 2;
                }
            }

            //个数统计
            int forReturn = 0;
            for (int i = 2; i < n; i++) if (readyNums[i] == 1) forReturn++;

            return forReturn;
        }
    }
}
