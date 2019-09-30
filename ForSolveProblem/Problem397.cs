using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem397 : IProblem
    {
        public void RunProblem()
        {
            var temp = IntegerReplacement(8);

            temp = IntegerReplacement(7);
        }

        public int IntegerReplacement(int n)
        {
            /*
             * 一个整数，最少经过多少次特定运算以后，得到的结果是1
             * 思路：
             *  1.当n为偶数，则只能做除法运算
             *  2.当n为奇数，则可以+1，也可以-1，正是因为这种选择性，使得存在最小次数
             *  3.从题目描述看，这是一个典型的递归问题，那么就使用递归的方式来做好了
             *  
             * 时间复杂度：O(logn)
             * 空间复杂度：O(logn)
             */

            int[] forReturn = new int[] { int.MaxValue };
            Recursive(forReturn, n, 0);

            return forReturn[0];
        }

        private void Recursive(int[] intArray, long curN, int operaCount)
        {
            if (curN == 1)
            {
                if (intArray[0] > operaCount) intArray[0] = operaCount;
                return;
            }

            if ((curN & 1) == 0)
                Recursive(intArray, curN >> 1, operaCount + 1);
            else
            {
                Recursive(intArray, (curN - 1) >> 1, operaCount + 2);
                Recursive(intArray, (curN + 1) >> 1, operaCount + 2);
            }
        }
    }
}
