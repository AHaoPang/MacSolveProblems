using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem930 : IProblem
    {
        public void RunProblem()
        {
            var temp = NumSubarraysWithSum(new int[] { 1, 0, 1, 0, 1 }, 2);
            if (temp != 4) throw new Exception();

            temp = NumSubarraysWithSum(new int[] { 0, 0, 0, 0, 0 }, 0);
            if (temp != 15) throw new Exception();
        }

        public int NumSubarraysWithSum(int[] A, int S)
        {
            /*
             * 在数组A中，寻找连续元素的子数组，和为目标值，那么这样的子数组有多少个
             * 思路：
             *  1.考虑使用累计值的方法
             *  2.从开始到结束，能得到一个数组累计值的折线图，用字典记录每个累计和的元素个数
             *  3.求解的是一段区间范围内的和，即子数组的和，那么就是在统计区分范围内，左边界元素的个数了
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            var forReturn = 0;
            var sumDic = new Dictionary<int, int>() { { 0, 1 } };
            var sum = 0;
            foreach (var aItem in A)
            {
                sum += aItem;

                var aimSum = sum - S;
                if (sumDic.ContainsKey(aimSum)) forReturn += sumDic[aimSum];

                if (!sumDic.ContainsKey(sum)) sumDic[sum] = 0;
                sumDic[sum]++;
            }

            return forReturn;
        }

        public int NumSubarraysWithSum1(int[] A, int S)
        {
            /*
             * 在数组A中，寻找连续元素的子数组，和为目标值，那么这样的子数组有多少个
             * 思路：
             *  1.可以看做是一个滑动窗口，窗口不断向右移动
             *  2.右边界移动，状况会是：不满足-->满足-->不满足
             *  3.左边界移动，状况会是：不满足-->满足-->不满足
             *  4.左右边界移动的距离，其实就是子数组的个数，统计一下就好了
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            var forReturn = 0;
            var rightEndIndex = 0;
            var leftEndIndex = 0;
            var sum = 0;
            while (true)
            {
                forReturn += GoRight(A, sum, S, rightEndIndex, out rightEndIndex, out sum);
                forReturn += GoLeft(A, sum, S, leftEndIndex, out leftEndIndex, out sum);

                if (rightEndIndex >= A.Length - 1) break;
            }

            return forReturn;
        }

        /// <summary>
        /// 滑动窗口右边界移动
        /// </summary>
        private int GoRight(int[] A, int sum, int S, int startIndex, out int endIndex, out int endSum)
        {
            var forReturn = 0;
            for (; startIndex < A.Length; startIndex++)
            {
                sum += A[startIndex];

                if (sum == S) forReturn++;
                if (sum > S) break;
            }

            endIndex = startIndex;
            endSum = sum;
            return forReturn;
        }

        /// <summary>
        /// 滑动窗口左边界移动
        /// </summary>
        private int GoLeft(int[] A, int sum, int S, int startIndex, out int endIndex, out int endSum)
        {
            var forReturn = 0;
            for (; startIndex < A.Length; startIndex++)
            {
                sum -= A[startIndex];

                if (sum == S) forReturn++;
                if (sum < S) break;
            }

            endIndex = startIndex;
            endSum = sum;
            return forReturn;
        }
    }
}
