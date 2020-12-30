using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem1046 : IProblem
    {
        public void RunProblem()
        {
            var temp = LastStoneWeight(new[] { 2, 7, 4, 1, 8, 1 });
            if (temp != 1) throw new Exception();

            temp = LastStoneWeight(new[] { 2, 2 });
            if (temp != 0) throw new Exception();
        }

        public int LastStoneWeight2(int[] stones)
        {
            /*
             * 题目概述：最后一块儿石头的重量
             * 
             * 思路：
             *  1.C#中并没有提供优先级队列这种数据结构,因此本题考虑使用其他数据结构来做模拟,使用的是"有序列表"
             *  2."有序列表"里面,键存储的是排序的数字,值存储的是该数字的个数
             *  3.添加数据,取出数据,就是在不断的更新这个有序列表
             *
             * 知识点：有序列表
             *
             * 时间复杂度：O(nlogn)
             * 空间复杂度：O(n)
             */

            var sortedList = new SortedList<int, int>(stones.Length);
            foreach (var stoneItem in stones)
                AddData(sortedList, stoneItem);

            var forReturn = 0;
            while (sortedList.Count > 0)
            {
                var maxNum = GetAndUpdate(sortedList);
                if (sortedList.Count == 0)
                {
                    forReturn = maxNum;
                    break;
                }

                var minNum = GetAndUpdate(sortedList);
                var subValue = maxNum - minNum;
                if (subValue != 0)
                    AddData(sortedList, subValue);
            }

            return forReturn;
        }

        private void AddData(SortedList<int, int> sortedList, int num)
        {
            if (!sortedList.ContainsKey(num))
                sortedList.Add(num, 0);

            sortedList[num]++;
        }

        private int GetAndUpdate(SortedList<int, int> sortedList)
        {
            var maxItem = sortedList.Last();

            var forReturn = maxItem.Key;
            sortedList.RemoveAt(sortedList.Count - 1);

            if (maxItem.Value - 1 > 0)
                sortedList.Add(forReturn, maxItem.Value - 1);

            return forReturn;
        }

        public int LastStoneWeight1(int[] stones)
        {
            /*
             * 题目概述：最后一块儿石头的重量
             * 
             * 思路：
             *  1.每次都取出最重的两块儿,然后把差值放回原来的石碓中
             *  2.这个行为类似于优先级队列的行为,取出优先级高的元素,将新元素放入原来的优先级队列中
             *
             * 知识点：优先级队列
             *
             * 时间复杂度：O(nlogn)的排序 O(n)的比较
             * 空间复杂度：O(n)
             */

            var pq = new PriorityQueue<int>(true, stones.Length);
            foreach (var stoneItem in stones)
                pq.AddData(stoneItem);

            var lastNum = 0;
            while (pq.HasData())
            {
                var maxNum = pq.GetData();
                if (!pq.HasData())
                {
                    lastNum = maxNum;
                    break;
                }

                var minNum = pq.GetData();
                if (maxNum == minNum) continue;

                pq.AddData(maxNum - minNum);
            }

            return lastNum;
        }

        public int LastStoneWeight(int[] stones)
        {
            var sortDic = new SortedDictionary<int, int>();
            foreach (var item in stones)
            {
                if (!sortDic.ContainsKey(item))
                    sortDic[item] = 0;

                sortDic[item]++;
            }

            while (sortDic.Count > 0 && (sortDic.Count > 1 || sortDic.Last().Value > 1))
            {
                var item = sortDic.Last();
                var first = item.Key;

                var second = 0;
                if (item.Value > 1)
                {
                    second = item.Key;
                    sortDic[item.Key] = item.Value - 2;

                    if (sortDic[item.Key] == 0)
                        sortDic.Remove(item.Key);
                }
                else
                {
                    sortDic.Remove(item.Key);

                    var anotherItem = sortDic.Last();
                    second = anotherItem.Key;

                    if (anotherItem.Value > 1)
                        sortDic[anotherItem.Key] = anotherItem.Value - 1;
                    else
                        sortDic.Remove(anotherItem.Key);
                }

                var sub = first - second;
                if (sub > 0)
                {
                    if (!sortDic.ContainsKey(sub))
                        sortDic[sub] = 0;

                    sortDic[sub]++;
                }
            }

            return sortDic.Count == 0 ? 0 : sortDic.Last().Key;
        }
    }
}
