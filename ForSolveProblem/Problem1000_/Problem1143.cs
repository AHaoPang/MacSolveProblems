using System;
namespace ForSolveProblem
{
    public class Problem1143 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int LongestCommonSubsequence(string text1, string text2)
        {
            var dp = new int[text1.Length + 1, text2.Length + 1];
            for (var r = 1; r <= text1.Length; r++)
            {
                for (var c = 1; c <= text2.Length; c++)
                {
                    if (text1[r - 1] == text2[c - 1])
                        dp[r, c] = dp[r - 1, c - 1] + 1;
                    else
                        dp[r, c] = Math.Max(dp[r - 1, c], dp[r, c - 1]);
                }
            }

            return dp[text1.Length, text2.Length];
        }
    }
}
