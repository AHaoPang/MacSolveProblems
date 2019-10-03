using System;
namespace ForSolveProblem
{
    public class Problem303 : IProblem
    {
        public void RunProblem()
        {
            var t = new NumArray(new int[] { -2, 0, 3, -5, 2, -1 });
            var temp = t.SumRange(0, 2);
            if (temp != 1) throw new Exception();

            temp = t.SumRange(2, 5);
            if (temp != -1) throw new Exception();

            temp = t.SumRange(0, 5);
            if (temp != -3) throw new Exception();

            t = new NumArray(new int[] { });
        }

        public class NumArray
        {
            private int[,] innerArray;
            private int totalSum;
            private int maxIndex;

            public NumArray(int[] nums)
            {
                innerArray = new int[nums.Length, 2];
                totalSum = 0;
                maxIndex = nums.Length - 1;

                for (int i = 0; i < nums.Length; i++)
                {
                    totalSum += nums[i];
                    innerArray[i, 0] = totalSum;
                }

                for (int j = 1; j < nums.Length; j++)
                {
                    if (j == 0) innerArray[j, 1] = totalSum;
                    innerArray[j, 1] = totalSum - innerArray[j - 1, 0];
                }
            }

            public int SumRange(int i, int j)
            {
                /*
                 * 题目概述：求整数元素范围内的和
                 * 
                 * 思路：
                 *  1. 范围内的和，有两种求解方法：直接计算范围内的、用总和抛去范围外的
                 *  2. 此处我们使用第 2 中方法
                 *  3. 对于每一个索引位置，都要计算出来，它左边包含它的和，它右边包含它的和
                 *
                 * 关键点：
                 *
                 * 时间复杂度：O(n) 初始化，但是方法的使用，就是 O(1)
                 * 空间复杂度：O(n)
                 */

                if (i < 0) i = 0;
                if (j > maxIndex) j = maxIndex;

                var forReturn = totalSum;
                if (i - 1 >= 0) forReturn -= innerArray[i - 1, 0];
                if (j + 1 <= maxIndex) forReturn -= innerArray[j + 1, 1];

                return forReturn;
            }
        }
    }
}
