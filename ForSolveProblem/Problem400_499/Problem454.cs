using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem454 : IProblem
    {
        public void RunProblem()
        {
            var temp = FourSumCount(new int[] { 1, 2 }, new int[] { -2, -1 }, new int[] { -1, 2 }, new int[] { 0, 2 });
            if (temp != 2) throw new Exception();
        }

        public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
        {
            /*
             * 4数求和，求组队
             * 思路：
             *  1.利用加法的交换律，可以两两分组
             *  2.一组得到的值，对于另一组而言，就是期望值
             *  3.分组求期望的这种方法，可以极大的减少时间复杂度！
             *  
             * 时间复杂度：O(n^2)
             * 空间复杂度：O(n^2)
             */

            //得到AB的组合
            var sumDicCount = new Dictionary<int, int>();
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < B.Length; j++)
                {
                    var sumTemp = A[i] + B[j];

                    if (!sumDicCount.ContainsKey(sumTemp)) sumDicCount[sumTemp] = 0;
                    sumDicCount[sumTemp]++;
                }
            }

            //得到CD的组合，期望值，和累计值
            var forReturn = 0;
            for (int i = 0; i < C.Length; i++)
            {
                for (int j = 0; j < D.Length; j++)
                {
                    var respectValueTemp = -1 * (C[i] + D[j]);

                    if (!sumDicCount.ContainsKey(respectValueTemp)) continue;

                    forReturn += sumDicCount[respectValueTemp];
                }
            }

            return forReturn;
        }
    }
}
