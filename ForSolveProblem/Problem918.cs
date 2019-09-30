using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem918 : IProblem
    {
        public void RunProblem()
        {
            int[] A = new int[] { 1, -2, 3, -2 };
            var temp = MaxSubarraySumCircular(A);
            if (temp != 3) throw new Exception();

            A = new int[] { 5, -3, 5 };
            temp = MaxSubarraySumCircular(A);
            if (temp != 10) throw new Exception();

            A = new int[] { 3, -1, 2, -1 };
            temp = MaxSubarraySumCircular(A);
            if (temp != 4) throw new Exception();

            A = new int[] { 3, -2, 2, -3 };
            temp = MaxSubarraySumCircular(A);
            if (temp != 3) throw new Exception();

            A = new int[] { -2, -3, -1 };
            temp = MaxSubarraySumCircular(A);
            if (temp != -1) throw new Exception();
        }

        public int MaxSubarraySumCircular(int[] A)
        {
            /*
             * 求解循环数组的最大子数组和
             * 思路：
             *  1.因为子数组的最大长度是数组本身的长度
             *  2.那么就一共有两种结果的可能性，最大子数组不跨子数组，最大子数组跨数组
             *  3.对于不跨子数组的情况，相当于求解数组最大子数组
             *  4.对于跨子数组的情况，相当于用数组的和，减去最小子数组
             *  5.比较二者，取大的值就好了
             *  
             * 时间复杂度：O(n)，一次遍历数组，得到3个值，做比较就好了
             * 空间复杂度：O(1)，使用固定大小的额外空间
             */

            int minSum = int.MaxValue;
            int maxSum = int.MinValue;
            int totalSum = 0;

            int windowSumForMin = 0;
            int windowSumForMax = 0;
            for (int i = 0; i < A.Length; i++)
            {
                totalSum += A[i];

                if (windowSumForMin <= 0) windowSumForMin += A[i];
                else windowSumForMin = A[i];

                if (windowSumForMin < minSum) minSum = windowSumForMin;

                if (windowSumForMax <= 0) windowSumForMax = A[i];
                else windowSumForMax += A[i];

                if (windowSumForMax > maxSum) maxSum = windowSumForMax;
            }

            var maxSum2 = totalSum - minSum;
            if (maxSum2 == 0 && maxSum < 0) return maxSum;

            return Math.Max(maxSum, maxSum2);
        }

        public int MaxSubarraySumCircular1(int[] A)
        {
            /*
             * 在循环数组中，找到最大子数组
             * 思路：
             *  1.相当于给了每个元素成为最长子数组一员的机会
             *  2.不太好使用动态规划，因为貌似并不存在“最优子结构”
             *  3.考虑使用 滑动窗口 的思路
             *  4.滑动窗口 本身是使用两个指针作为边界的
             *  5.滑动窗口的和的汇总，本身就会进入下一个加入元素的阶段
             *  6.两个指针的距离，不能大于数组的长度
             *  7.若两个指针距离达到上限，那么就缩小，此时的平衡被打破，需要找到拥有最大值的子序列，再考虑进入下一轮
             *  8.若他们的值始终是负数，那么就从新加入的位置，作为窗的开始
             *  
             * 时间复杂度：O(n^2)，复杂度较高，因为一旦达到范围上限，为了达到新的平衡，就需要有O(n)的复杂度
             * 空间复杂度：O(1)，使用固定大小的额外空间
             */

            int maxLength = A.Length;

            int maxSum = int.MinValue;

            int headIndex = 0;
            int tailIndex = 0;
            int windowSum = int.MinValue;

            int curElementIndex = 0;
            while (curElementIndex < maxLength * 2)
            {
                //新元素加入判断
                if (windowSum <= 0)
                {
                    //以新元素打头
                    headIndex = curElementIndex;
                    windowSum = A[curElementIndex % maxLength];
                }
                else
                {
                    //加入成为其中的一员
                    windowSum += A[curElementIndex % maxLength];
                }

                tailIndex = curElementIndex;
                curElementIndex++;

                //最大值更新
                if (windowSum > maxSum) maxSum = windowSum;

                //窗口本身有效性更新
                if (tailIndex - headIndex == maxLength - 1)
                {
                    headIndex++;

                    //此时应该去努力达到新的平衡
                    var v = GetMaxHeadIndex(A, headIndex, tailIndex);
                    headIndex = v.Item1;
                    windowSum = v.Item2;
                }
            }

            return maxSum;
        }

        private Tuple<int, int> GetMaxHeadIndex(int[] A, int headIndex, int tailIndex)
        {
            int forReturnIndex = 0;
            int sumTemp = int.MinValue;

            int windowSumTemp = 0;
            for (int i = tailIndex; i >= headIndex; i--)
            {
                windowSumTemp += A[i % A.Length];

                if (sumTemp < windowSumTemp)
                {
                    forReturnIndex = i;
                    sumTemp = windowSumTemp;
                }
            }

            return Tuple.Create(forReturnIndex, sumTemp);
        }
    }
}
