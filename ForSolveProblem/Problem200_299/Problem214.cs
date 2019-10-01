using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem214 : IProblem
    {
        public void RunProblem()
        {
            var temp = ShortestPalindrome("aacecaaa");
            if (temp != "aaacecaaa") throw new Exception();

            temp = ShortestPalindrome("abcd");
            if (temp != "dcbabcd") throw new Exception();
        }

        public string ShortestPalindrome(string s)
        {
            /*
             * 用最短的字符串，来构造回文串
             * 思路：
             *  1.将问题转换为，从开始位置找，最长的回文子串
             *  2.查找的方法是，把原有字符串反转，然后匹配最长的相同部分
             *  3.那么这个问题还可以转换为，将两个字符串拼接，最长的前缀字符串和后缀字符串相同的部分
             *  4.而一个字符串中，最长的可匹配前缀子串的后缀子串的计算方法，可以考虑使用动态规划
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            string reverseStr = new string(s.Reverse().ToArray());

            string newStr = $"{s}#{reverseStr}";

            int[] posArray = new int[newStr.Length];
            posArray[0] = 0;
            for (int i = 1; i < newStr.Length; i++)
            {
                int t = posArray[i - 1];
                while (t > 0 && newStr[t] != newStr[i])
                    t = posArray[t - 1];

                if (newStr[t] == newStr[i])
                    t++;

                posArray[i] = t;
            }

            return reverseStr.Substring(0, s.Length - posArray[newStr.Length - 1]) + s;
        }

        public string ShortestPalindrome1(string s)
        {
            /*
             * 最短回文串的构造
             * 思路：
             *  1.首先找到从左边开始的已有串中的最大回文串，然后把其余的补足，就是结果了
             *  2.反转字符串，依次交错比较两个字符串，直到找到目标值
             *  
             * 时间复杂度：O(n^2)，一次缩短一点，每次都要比较几乎所有的字符串，但是因为使用了系统提供的字符串比较函数，所以速度会快一些
             * 空间复杂度：O(1)
             */

            var reverseStr = new string(s.Reverse().ToArray());

            for (int i = 0; i < s.Length; i++)
                if (s.Substring(0, s.Length - i) == reverseStr.Substring(i))
                    return reverseStr.Substring(0, i) + s;

            return s;
        }
    }
}
