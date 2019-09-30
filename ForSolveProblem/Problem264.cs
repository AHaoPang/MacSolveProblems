using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem264 : IProblem
    {
        public void RunProblem()
        {
            var temp = NthUglyNumber(10);
            if (temp != 12) throw new Exception();
        }

        public int NthUglyNumber(int n)
        {
            /*
             * 得到第n个丑数
             * 思路：
             *  1.利用已有的丑数去生成新的丑数，直到生成目标位置的丑数为止
             *  2.生成的丑数要有序
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            int[] forReturnArray = new int[n];
            forReturnArray[0] = 1;

            int index2 = 0;
            int index3 = 0;
            int index5 = 0;

            int pos = 1;
            while (pos < n)
            {
                forReturnArray[pos] = Math.Min(forReturnArray[index2] * 2, Math.Min(forReturnArray[index3] * 3, forReturnArray[index5] * 5));

                while (forReturnArray[index2] * 2 <= forReturnArray[pos]) index2++;

                while (forReturnArray[index3] * 3 <= forReturnArray[pos]) index3++;

                while (forReturnArray[index5] * 5 <= forReturnArray[pos]) index5++;

                pos++;
            }

            return forReturnArray[n - 1];
        }
    }
}
