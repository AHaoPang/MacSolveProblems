using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem1332 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int RemovePalindromeSub(string s)
        {
            if (s.Length == 0) return 0;

            var isOk = true;
            var leftIndex = 0;
            var rightIndex = s.Length - 1;
            while (leftIndex < s.Length && rightIndex >= 0 && leftIndex <= rightIndex)
            {
                if (s[leftIndex++] != s[rightIndex--])
                {
                    isOk = false;
                    break;
                }
            }
            if (isOk) return 1;

            var charSet = new HashSet<char>();
            foreach (var sItem in s)
                charSet.Add(sItem);

            return charSet.Count;
        }

        public int RemovePalindromeSub1(string s)
        {
            /*
             * 题目概述：删除回文子序列
             * 
             * 思路：
             *  1.按照特定要求,对原有字符串做多次删除操作
             *  2.回文是对称的,与双指针的处理方式不谋而合
             *  3.考虑以左指针为标准,让右指针找到与之匹配的
             *  4.当左右指针相遇时,就说明找到了回文
             *  5.每一轮计数一次,总数就是要求的解
             *
             * 关键点：
             *
             * 因为字符串中仅仅包含 2 种字符,所以时间复杂度不会有理论值这么高
             * 时间复杂度：O(n^2)
             * 空间复杂度：O(n)
             */

            var forReturn = 0;

            var sPos = new bool[s.Length];
            while (true)
            {
                var isDel = false;
                var leftIndex = 0;
                var rightIndex = s.Length - 1;
                while (leftIndex < rightIndex)
                {
                    while (leftIndex < s.Length && sPos[leftIndex])
                        leftIndex++;
                    if (leftIndex == s.Length) break;

                    while (rightIndex >= 0 && (sPos[rightIndex] || s[leftIndex] != s[rightIndex]))
                        rightIndex--;

                    if (leftIndex > rightIndex) break;

                    isDel = true;
                    sPos[leftIndex] = sPos[rightIndex] = true;
                }

                if (!isDel) break;
                else forReturn++;
            }

            return forReturn;
        }
    }
}
