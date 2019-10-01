using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem368 : IProblem
    {
        public void RunProblem()
        {
            var temp = LargestDivisibleSubset(new int[] { 1, 2, 3 });
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new int[] { 1, 2 })) throw new Exception();

            temp = LargestDivisibleSubset(new int[] { 1, 2, 4, 8 });
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new int[] { 1, 2, 4, 8 })) throw new Exception();

            temp = LargestDivisibleSubset(new int[] { });
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new int[] { })) throw new Exception();

            temp = LargestDivisibleSubset(new int[] { 4, 8, 10, 240 });
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new int[] { 4, 8, 240 })) throw new Exception();
        }

        public IList<int> LargestDivisibleSubset(int[] nums)
        {
            /*
             * 寻找最大整除子集
             * 思路：
             *  1.主要考察的是数字之间的相互关系
             *  2.然后思考能不能从已有的结果中获益
             *  3.既然要求的是“相互之间整除”，那么要考虑下“整除的传递性”，即：
             *      3.1 已知：num1 < num2 < num3
             *      3.2 已知：num2 % num1 == 0 && num3 % num2 == 0
             *      3.3 那么：num3 % num1 == 0
             *  4.因此可以考虑将给定的序列从小到大排序，然后依次计算从开始到索引位置，最大子序列的元素数量
             *  5.状态定义：dp[n] 表示前n个数字中，最大子序列的个数
             *  6.状态转移方程为：dp[j] = dp[i] + 1 （i < j && num[j] % num[i] == 0）
             *  7.本题考虑使用C#提供的“有序列表”来解决
             *  8.结果一定在dp[n]中产生，找到那个最大的数字，然后遍历找出所有的子集
             *  
             * 时间复杂度：O(n^2)
             * 空间复杂度：O(n)
             */

            if (nums.Length == 0) return nums;

            var sortedNums = nums.OrderBy(i => i).ToArray();
            var elementCountArray = new List<int>(sortedNums.Length);
            var elementPreIndexArray = Enumerable.Repeat(-1, sortedNums.Length).ToArray();

            var maxCount = -1;
            var maxElement = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                var curNum = sortedNums[i];
                var subsetCount = 1;
                for (int j = 0; j < elementCountArray.Count; j++)
                {
                    if (curNum % sortedNums[j] == 0 && subsetCount < elementCountArray[j] + 1)
                    {
                        subsetCount = elementCountArray[j] + 1;
                        elementPreIndexArray[i] = j;
                    }
                }
                elementCountArray.Add(subsetCount);

                if (subsetCount > maxCount)
                {
                    maxCount = subsetCount;
                    maxElement = i;
                }
            }

            var forReturn = new List<int>(maxCount);
            var curIndex = maxElement;
            while (curIndex >= 0)
            {
                forReturn.Add(sortedNums[curIndex]);
                curIndex = elementPreIndexArray[curIndex];
            }

            return forReturn;
        }
    }
}
