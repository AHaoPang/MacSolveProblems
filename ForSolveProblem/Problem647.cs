using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem647 : IProblem
    {
        public int CountSubstrings(string s)
        {
            /* 遍历字符串字符，向两边扩散来判断回文 */

            var forReturn = 0;

            for (int i = 0; i < s.Length; i++)
            {
                forReturn += 1;

                forReturn += CountNums(s, i - 1, i);
                forReturn += CountNums(s, i - 1, i + 1);
            }

            return forReturn;
        }

        private int CountNums(string s, int left, int right)
        {
            var forReturn = 0;

            while (left >= 0 && right < s.Length)
            {
                if (s[left] != s[right]) break;

                forReturn++;
                left--;
                right++;
            }

            return forReturn;
        }

        public int CountSubstrings1(string s)
        {
            /*
             * 题目概述：统计一个大的字符串中，有多少个回文子串
             * 
             * 思路：
             *  1. 就单独一个字符而言，如果它不构成回文（不是回文的组成部分，那它自己就是中心），如果是其它回文的一部分，那么它还以别人为中心
             *
             * 关键点：
             *
             * 时间复杂度： O(n)
             * 空间复杂度：O(1)
             */

            if (s.Length <= 1) return s.Length;

            var forReturn = 1;
            var preArray = new HashSet<int>(10) { 0 };
            var nextArray = new HashSet<int>(10);
            for (int i = 1; i < s.Length; i++)
            {
                nextArray.Clear();

                //1.自己就是中心，把自己加上
                nextArray.Add(i);
                //2.缝隙是中心，检测一下
                if (s[i] == s[i - 1]) nextArray.Add(i - 1);
                //3.前面认可的中心，是不是自己的中心，检测一下
                foreach (var preItem in preArray)
                {
                    int indexTemp = preItem - 1;
                    if (indexTemp >= 0 && s[indexTemp] == s[i]) nextArray.Add(preItem - 1);
                }

                forReturn += nextArray.Count;

                preArray.Clear();
                foreach (var nextItem in nextArray) preArray.Add(nextItem);
            }

            return forReturn;
        }

        public void RunProblem()
        {
            var temp = CountSubstrings("abc");
            if (temp != 3) throw new Exception();

            temp = CountSubstrings("aaa");
            if (temp != 6) throw new Exception();

            temp = CountSubstrings("aaaa");
            if (temp != 10) throw new Exception();
        }
    }
}
