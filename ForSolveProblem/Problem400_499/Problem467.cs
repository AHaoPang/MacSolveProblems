using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem467 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindSubstringInWraproundString("a");
            if (temp != 1) throw new Exception();

            temp = FindSubstringInWraproundString("cac");
            if (temp != 2) throw new Exception();

            temp = FindSubstringInWraproundString("zab");
            if (temp != 6) throw new Exception();
        }

        public int FindSubstringInWraproundString(string p)
        {
            /*
             * 题目概述：判断 p 中满足特定条件的唯一子串的数量
             * 
             * 思路：
             *  1. 子串要么是单个字符，要么是连续循环的字符串
             *  2. 一个连续的子串，可以构造 (1 + length)*length/2 个子字符串，即递推关系为：dp[n] = dp[n-1]+n
             *  3. 为了避免重复统计，选择按照结尾字符来统计字串长度，即以每个字符结尾的情况下，最长的子串有多长，最后汇总长度可得子串数量
             *  4. 只要把每个字符结尾的串的长度加起来，就可以得到全部唯一子串的数量了
             *
             * 关键点：
             *
             * 时间复杂度：O(n)，字符串要编译一遍
             * 空间复杂度：O(1)，申请的数组大小是固定的
             */

            if (p.Length <= 1) return p.Length;

            var dp = new int[26];

            var lastChar = p[0];
            var count = 1;
            dp[lastChar - 'a'] = count;

            for (int i = 1; i < p.Length; i++)
            {
                if (p[i] - lastChar == 1 || (p[i] - lastChar == -25 && p[i] == 'a')) //相邻
                    count++;
                else //不相邻
                    count = 1;

                lastChar = p[i];
                dp[lastChar - 'a'] = Math.Max(dp[lastChar - 'a'], count);
            }

            return dp.Sum();
        }
    }
}
