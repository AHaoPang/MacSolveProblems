using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1202 : IProblem
    {
        public void RunProblem()
        {
            var temp = SmallestStringWithSwaps("dcab", new List<IList<int>>()
            {
                new List<int>{0,3},
                new List<int>{1,2},
            });
            if (temp != "bacd") throw new Exception();

            temp = SmallestStringWithSwaps("dcab", new List<IList<int>>
            {
                new List<int>{0,3},
                new List<int>{1,2},
                new List<int>{0,2},
            });
            if (temp != "abcd") throw new Exception();

            temp = SmallestStringWithSwaps("cba", new List<IList<int>>
            {
                new List<int>{0,1},
                new List<int>{1,2},
            });
            if (temp != "abc") throw new Exception();
        }

        public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
        {
            /*
             * 题目概述：交换字符串中同组索引的元素,使得字符串的字母序最小
             * 
             * 思路：
             *  1.使用并查集来将给定的索引对拼接成一个大的集体
             *  2.找到所有的集体
             *  3.将集体所代表的元素排序后写回到原来的字符串中
             *
             * 关键点：
             *  1.直接做字符串排序的话,时间复杂度较高,会超时,因为字符仅有小写字母,因此我自己写了"桶排序"来加速,效果还不错
             *
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            var DJS = new DisJointSet(s.Length);
            foreach (var pairItem in pairs)
                DJS.Union(pairItem[0], pairItem[1]);

            var groupDic = new Dictionary<int, IList<int>>();
            for (int i = 0; i < s.Length; i++)
            {
                var groupIndex = DJS.Find(i);

                if (!groupDic.ContainsKey(groupIndex))
                    groupDic[groupIndex] = new List<int>();

                groupDic[groupIndex].Add(i);
            }

            var forReturnCharArray = s.ToCharArray();
            foreach (var groupItem in groupDic)
                SortedAndInsert(forReturnCharArray, groupItem.Value);

            return new string(forReturnCharArray);
        }

        private void SortedAndInsert(char[] charArray, IList<int> indexSet)
        {
            var groupChars = new char[indexSet.Count];
            for (int i = 0; i < indexSet.Count; i++)
            {
                var charIndex = indexSet[i];
                groupChars[i] = charArray[charIndex];
            }

            groupChars = SortedChars(groupChars);

            var orderList = indexSet.OrderBy(i => i).ToList();
            for (int i = 0; i < indexSet.Count; i++)
                charArray[orderList[i]] = groupChars[i];
        }

        private char[] SortedChars(char[] charArray)
        {
            var intArray = new int[26];
            foreach (var charItem in charArray)
                intArray[charItem - 'a']++;

            var forReturn = new List<char>(charArray.Length);
            for (int i = 0; i < intArray.Length; i++)
                if (intArray[i] != 0) forReturn.AddRange(Enumerable.Repeat((char)('a' + i), intArray[i]));

            return forReturn.ToArray();
        }
    }
}
