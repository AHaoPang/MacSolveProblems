using System;
namespace ForSolveProblem
{
    public class Problem813 : IProblem
    {
        public double LargestSumOfAverages(int[] A, int K)
        {
            /*
             * 题目概述：将数组分成 K 组,希望 K 组的平均值之和是最大的
             * 
             * 思路：
             *  1. 从题目中比较容易发现递归的痕迹,即 全部分成 K 组平均值之和最大,那么一定来源于 部分+K-1 组平均值之和最大
             *  2. 从问题本身来看,能想到 3 个维度的变化
             *      2.1 数组的长度 从 1 到 最大
             *      2.2 K 的长度 从 1 到 最大
             *      2.3 子数组的长度 从 1 到 逻辑上限
             *  3. 定义状态 dp[i][k]表示从第 1 个元素到第 i 个元素,分成 k 组的平均值之和最大是多少
             *  4. 结果状态就是 dp[A.length][K]
             *  5. 状态转移方程式 dp[i][k] = max(dp[j][k-1]+array[j+1,1]) { 1<=j<i } 表明前 i 个元素分成 k 段 的最大平均值之和等于 前 j 个元素分成 k-1 段的最大平均值之和加上 j+1 到 i 这段之和
             *
             * 关键点：
             *
             * 时间复杂度：O(k*n*n)
             * 空间复杂度：O(k*n*n)
             */

            var rangeSum = new int[A.Length + 1];
            for (int i = 0; i < A.Length; i++)
                rangeSum[i + 1] = rangeSum[i] + A[i];

            var dp = new double[A.Length + 1, K + 1];
            for (int i = 1; i <= A.Length; i++)
            {
                dp[i, 1] = 1.0 * rangeSum[i] / i;
                for (int k = 2; k <= K && k <= i; k++)
                    for (int j = 1; j < i; j++)
                        dp[i, k] = Math.Max(dp[i, k], dp[j, k - 1] + 1.0 * (rangeSum[i] - rangeSum[j]) / (i - j));
            }

            return dp[A.Length, K];
        }

        public void RunProblem()
        {
            var temp = LargestSumOfAverages(new int[] { 9, 1, 2, 3, 9 }, 3);
            if (Math.Abs(temp - 20) > 1E-6) throw new Exception();
        }
    }
}
