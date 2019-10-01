using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem974 : IProblem
    {
        public void RunProblem()
        {
            var temp = SubarraysDivByK(new int[] { 4, 5, 0, -2, -3, 1 }, 5);
            if (temp != 7) throw new Exception();

            temp = SubarraysDivByK(new int[] { -2 }, 6);

        }

        public int SubarraysDivByK(int[] A, int K)
        {
            /*
             * 在给定数组中，寻找连续的子数组，满足的条件是：和为K的倍数
             * 思路：
             *  1.子数组求和的问题，解法基本固定，就是求解累计值
             *  2.若两个值之差是K的倍数，那么两个值对K取余后的结果一定是一样的
             *  3.于是，我们可以得到取余后相同累计和的索引位置
             *  4.给定相同累计和的索引位置，从中取两个构成子数组，一共有多少种情况，这就是组合的问题了
             *  
             * 时间复杂度：O(n)，要把所有元素遍历一遍
             * 空间复杂度：O(n)，最坏情况下，累计和都不一样
             */

            var sumArray = new int[A.Length + 1];
            for (int i = 0; i < A.Length; i++)
                sumArray[i + 1] = sumArray[i] + A[i];

            var sameModDic = new int[K];
            foreach (var item in sumArray)
                sameModDic[(item % K + K) % K]++;

            var forReturn = 0;
            foreach (var modItem in sameModDic)
                forReturn += modItem * (modItem - 1) / 2;

            return forReturn;
        }
    }
}
