using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem459 : IProblem
    {
        public void RunProblem()
        {
            var temp = RepeatedSubstringPattern("aba");
        }

        public bool RepeatedSubstringPattern(string s)
        {
            /*
             * ##### 1. 题目概述：检测父字符串是否是由重复的子字符串构成的
             * 
             * ##### 2. 思路：
             *    - 特征：若字符串是由重复的子字符串构成的,那么 KMP 的 next 数组会满足一个特定的条件
             *    - 方案：使用给定的字符串去构造 next 数组,内部是DP 的实现 --> next 数组,索引和值存储的都是字符串中字符的数组下标
             *    - 结果：判断 next 数组是否满足一个特定的条件
             *
             * ##### 3. 知识点：KMP 数学
             * 
             * ##### 4. 复杂度分析: 
             *    - 时间复杂度：O(n)
             *    - 空间复杂度：O(n)
             */

            var nextArray = GetKMPNextArray(s);
            var tailIndex = s.Length - 1;
            return nextArray[tailIndex] != -1 && s.Length % (tailIndex - nextArray[tailIndex]) == 0;
        }

        private int[] GetKMPNextArray(string s)
        {
            var forReturn = Enumerable.Repeat(-1, s.Length).ToArray();
            for (var i = 1; i < s.Length; i++)
            {
                var j = forReturn[i - 1];
                while (j >= 0 && s[j + 1] != s[i])
                    j = forReturn[j];

                if (s[j + 1] == s[i])
                    forReturn[i] = j + 1;
            }

            return forReturn;
        }

        public bool RepeatedSubstringPattern1(string s)
        {
            /*
             * ##### 1. 题目概述：重复的子字符串
             * 
             * ##### 2. 思路：
             *    - 特征：子字符串组成原始字符串,那么个数上一定是倍数关系;子字符串的最大长度是原始字符串的一半;判断是否足以构成,那就只能去挨个字符的判断了;
             *    - 方案：遍历长度 1 ~ 原始串的一半,找到可整除原始串长度的子长度,然后去判断这个字串是否可以构成原始串
             *    - 结果：一旦找到一个满足条件的,那么就是 true,否则就是 false
             *
             * ##### 3. 知识点：字符串
             * 
             * ##### 4. 复杂度分析: 
             *    - 时间复杂度：O(n^2)
             *    - 空间复杂度：O(n)
             */

            for (var i = 1; i <= s.Length / 2; i++)
                if (s.Length % i == 0 && IsRepeat(s, i)) return true;

            return false;
        }

        private bool IsRepeat(string s, int subLength)
        {
            var subStr = s.Substring(0, subLength);
            for (var i = subLength; i < s.Length; i++)
                if (subStr[i % subLength] != s[i]) return false;

            return true;
        }
    }
}
