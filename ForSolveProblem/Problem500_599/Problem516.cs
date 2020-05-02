using System;
namespace ForSolveProblem
{
    public class Problem516 : IProblem
    {
        public void RunProblem()
        {
            var temp = LongestPalindromeSubseq("bbbab");
            if (temp != 4) throw new Exception();

            temp = LongestPalindromeSubseq("cbba");
            if (temp != 2) throw new Exception();
        }

        public int LongestPalindromeSubseq(string s)
        {
            var dp = new int[s.Length, s.Length];
            for (var i = s.Length - 1; i >= 0; i--)
            {
                for (var j = i; j <= s.Length - 1; j++)
                {
                    if (i == j)
                    {
                        dp[i, j] = 1;
                        continue;
                    }

                    dp[i, j] = Math.Max(dp[i, j - 1], dp[i + 1, j]);
                    if (s[i] == s[j])
                        dp[i, j] = Math.Max(dp[i, j], dp[i + 1, j - 1] + 2);
                }
            }

            return dp[0, s.Length - 1];
        }

        public int LongestPalindromeSubseq1(string s)
        {
            /*
             * 题目概述：寻找给定字符串中的最长回文字串
             * 
             * 思路：
             *  1. 这种问题，显然是一种递归求解的问题，现在需要定义递归过程中的状态
             *  2. 定义 dp[i][j] 表示字符串中，从 i 到 j 的最长回文串的长度
             *  3. 若 s[i] == s[j] 那么 dp[i][j] = dp[i+1][j-1] + 2
             *  4. 若 s[i] != s[j] 那么 dp[i][j] = max(dp[i+1][j],dp[i][j-1])
             *  5. 当 i == j 时，dp[i][j] = 1
             *
             * 关键点：
             *
             * 时间复杂度：O(n^2)
             * 空间复杂度：O(n)
             */

            if (s.Length == 0) return 0;

            var dp = new int[s.Length, s.Length];
            for (int i = 0; i < s.Length; i++) dp[i, i] = 1;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[i] == s[j]) dp[i, j] = dp[i + 1, j - 1] + 2;
                    else dp[i, j] = Math.Max(dp[i, j - 1], dp[i + 1, j]);
                }
            }

            return dp[0, s.Length - 1];
        }
    }
}
