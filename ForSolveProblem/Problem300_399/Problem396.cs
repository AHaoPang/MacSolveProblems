using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem396 : IProblem
    {
        public void RunProblem()
        {
            var temp = MaxRotateFunction(new int[] { 4, 3, 2, 6 });
            if (temp != 26) throw new Exception();
        }

        public int MaxRotateFunction(int[] A)
        {
            /*
             * 求得数组A各种旋转结果的累积和最大是多少
             * 思路：
             *  1.累积和，就是元素索引与元素值的乘积之和
             *  2.依据题意，可以先求得各种累积和，然后比较得出，此时的算法复杂度是O(n^2)
             *  3.那么就考虑相邻累积和有没有什么关系
             *      3.1 multiSum[i]，表示旋转i个位置后的累积和
             *      3.2 multi[n-1]，表示旋转i个位置后最后一个索引的元素，其实可以转换为A[n-1-i]
             *      3.3 multiSum，表示元素数组，各项的累计和
             *      3.4 multiSum[i+1] = multiSum[i] - (n-1)*A[n-1-i] + (multiSum - A[n-1-i])
             *  4.以上，也可以看做是状态，以及状态转移，即，也被称为“动态规划”
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            var multiSumPre = 0;
            var multiSum = 0;
            for (int i = 0; i < A.Length; i++)
            {
                multiSumPre += i * A[i];
                multiSum += A[i];
            }

            var forReturn = multiSumPre;
            var multiSumNext = 0;
            for (int j = 0; j < A.Length - 1; j++)
            {
                multiSumNext = multiSumPre + multiSum - A.Length * A[A.Length - 1 - j];
                forReturn = Math.Max(forReturn, multiSumNext);
                multiSumPre = multiSumNext;
            }

            return forReturn;
        }
    }
}
