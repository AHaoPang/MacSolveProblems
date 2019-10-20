using System;
namespace ForSolveProblem
{
    public class Problem583 : IProblem
    {
        public int MinDistance(string word1, string word2)
        {
            /*
            * 题目概述：为了让两个单词相同,所需要最少的字符删除次数
            * 
            * 思路：
            *  1. 定义状态 dp[i][j],i 和 j 分别表示两个单词中的第几个字符,他们从 1 开始,dp[i][j]表示截止这个字符,已经做的操作数
            *  2. 状态转移过程
            *       2.1 word1[i] == word2[j], dp[i][j] = dp[i-1][j-1]
            *       2.2 word1[i] != word2[j], dp[i][j] = min( dp[i-1][j]+1,dp[i][j-1]+1 )
            *
            * 关键点：
            *
            * 时间复杂度：O(m*n)
            * 空间复杂度：O(m*n)
            */

            var dp = new int[word1.Length + 1, word2.Length + 1];

            for (int i = 0; i < word1.Length; i++)
                dp[i + 1, 0] = dp[i, 0] + 1;

            for (int j = 0; j < word2.Length; j++)
                dp[0, j + 1] = dp[0, j] + 1;

            for (int i = 1; i <= word1.Length; i++)
                for (int j = 1; j <= word2.Length; j++)
                    dp[i, j] = word1[i - 1] == word2[j - 1] ? dp[i - 1, j - 1] : Math.Min(dp[i - 1, j], dp[i, j - 1]) + 1;

            return dp[word1.Length, word2.Length];
        }

        public void RunProblem()
        {
            var temp = MinDistance("sea", "eat");
            if (temp != 2) throw new Exception();

            temp = MinDistance("plasma", "altruism");
            if (temp != 8) throw new Exception();
        }
    }
}
