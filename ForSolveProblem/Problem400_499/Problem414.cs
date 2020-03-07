using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem414 : IProblem
    {
        public void RunProblem()
        {
            var temp = ThirdMax(new int[] { 1, 2, 3 });

        }

        public int ThirdMax(int[] nums)
        {
            var numList = new List<int>(3);
            foreach (var numItem in nums)
            {
                if (numList.Contains(numItem)) continue;

                if (numList.Count < 3)
                {
                    numList.Add(numItem);
                    numList.Sort();
                }
                else if (numList.Count == 3 && numList.First() < numItem)
                {
                    numList[0] = numItem;
                    numList.Sort();
                }
            }

            return numList.Count < 3 ? numList.Last() : numList.First();
        }

        public int ThirdMax2(int[] nums)
        {
            /*
             * ##### 1. 题目概述：找到第 3 大的数字
             * 
             * ##### 2. 思路：
             *    - 特征：第 3 大的数,自己维护起来也并不复杂,而且单论排序的话,时间复杂度也是相当低了
             *    - 方案：维护一个拥有 3 个元素的数组,它可以判重,元素少时,直接添加元素,元素多时,与最小的数字做比较,每次新增或者更新元素的时候,都要对数组重新排序
             *    - 结果：最后维护的数组,里面就存放了所求的解
             *
             * ##### 3. 知识点：数组 排序
             * 
             * ##### 4. 复杂度分析: 
             *    - 时间复杂度：O(n)
             *    - 空间复杂度：O(1)
             */

            var numArray = new int[3];
            var numSet = new HashSet<int>();
            var initIndex = 0;
            foreach (var numItem in nums)
            {
                if (numSet.Contains(numItem)) continue;
                numSet.Add(numItem);

                if (initIndex < 3)
                {
                    numArray[initIndex++] = numItem;

                    if (initIndex == 3)
                        Array.Sort(numArray);
                }
                else if (initIndex == 3 && numItem > numArray[0])
                {
                    numArray[0] = numItem;
                    Array.Sort(numArray);
                }
            }

            return initIndex == 3 ? numArray[0] : nums.Distinct().OrderBy(i => i).Last();
        }

        public int ThirdMax1(int[] nums)
        {
            /*
             * ##### 1. 题目概述：第三大的数
             * 
             * ##### 2. 思路：
             *    - 特征：找到最大的 3 个不同的数,返回那第 3 个数
             *    - 方案：小顶堆的应用场景,考虑使用有序列表这种数据结构,维护一个拥有 4 个空间的有序列表
             *    - 结果：有序列表里面存储的就是从小到大排列的 3 个最大的值,按照题目要求输出即可
             *
             * ##### 3. 知识点：堆
             * 
             * ##### 4. 复杂度分析: 
             *    - 时间复杂度：O(n)
             *    - 空间复杂度：O(1)
             */

            var sortedList = new SortedList<int, int>(4);

            foreach (var numItem in nums)
            {
                if (sortedList.ContainsKey(numItem)) continue;

                if (sortedList.Count < 3)
                    sortedList.Add(numItem, 1);
                else if (sortedList.Count == 3 && sortedList.First().Key < numItem)
                {
                    sortedList.RemoveAt(0);
                    sortedList.Add(numItem, 1);
                }
            }

            return sortedList.Count < 3 ? sortedList.Last().Key : sortedList.First().Key;
        }
    }
}
