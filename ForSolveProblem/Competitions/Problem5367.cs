using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5367 : IProblem
    {
        public void RunProblem()
        {
            var t = LongestPrefix("bba");
        }

        public string LongestPrefix(string s)
        {
            var dp = Enumerable.Repeat(-1, s.Length).ToArray();
            for (var i = 1; i < s.Length; i++)
            {
                var j = dp[i - 1];
                while (j >= 0 && s[j + 1] != s[i])
                    j = dp[j];

                if (s[j + 1] == s[i])
                    dp[i] = j + 1;
            }

            return s.Substring(0, dp[s.Length - 1] + 1);
        }
    }
}
