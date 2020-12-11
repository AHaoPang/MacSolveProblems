using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1537 : IProblem
    {
        public void RunProblem()
        {
            var temp = MaxSum(new[] { 2, 4, 5, 8, 10 }, new[] { 4, 6, 8, 9 });
            if (temp != 30) throw new Exception();

            temp = MaxSum(new[] { 1, 3, 5, 7, 9 }, new[] { 3, 5, 100 });
            if (temp != 109) throw new Exception();

            temp = MaxSum(new[] { 1, 2, 3, 4, 5 }, new[] { 6, 7, 8, 9, 10 });
            if (temp != 40) throw new Exception();

            temp = MaxSum(new[] { 1, 4, 5, 8, 9, 11, 19 }, new[] { 2, 3, 4, 11, 12 });
            if (temp != 61) throw new Exception();
        }

        public int MaxSum(int[] nums1, int[] nums2)
        {
            /*
             * 关键点:
             *  1. 64位,表示的数字范围是 10 的 18次方;  32位,表示的数字范围是 10 的 9次方;
             *  2. 双指针齐头并进的模型
             *     2.1 指向的时候,并不累计,前进的之后才会累计;
             *     2.2 指向的值相同时,才有比较大小的必要
             *     2.3 谁的值小,谁去前进
             *     
             *  贪心的思路
             */

            var constNum = (int)(1e9 + 7);
            var res = 0L;

            var oneIndex = 0;
            var oneSum = 0L;

            var twoIndex = 0;
            var twoSum = 0L;

            while (oneIndex != nums1.Length || twoIndex != nums2.Length)
            {
                if (oneIndex == nums1.Length)
                {
                    twoSum += nums2[twoIndex];
                    twoIndex++;
                }
                else if (twoIndex == nums2.Length)
                {
                    oneSum += nums1[oneIndex];
                    oneIndex++;
                }
                else
                {
                    if (nums1[oneIndex] == nums2[twoIndex])
                    {
                        oneSum += nums1[oneIndex];
                        twoSum += nums2[twoIndex];

                        res += Math.Max(oneSum, twoSum) % constNum;
                        oneSum = 0;
                        twoSum = 0;

                        oneIndex++;
                        twoIndex++;
                    }
                    else if (nums1[oneIndex] > nums2[twoIndex])
                    {
                        twoSum += nums2[twoIndex];
                        twoIndex++;
                    }
                    else
                    {
                        oneSum += nums1[oneIndex];
                        oneIndex++;
                    }
                }
            }

            res += Math.Max(oneSum, twoSum);
            return (int)(res % constNum);
        }
    }
}
