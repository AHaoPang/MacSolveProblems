using System;
using System.Threading;

namespace ForSolveProblem
{
    public class Problem044 : IProblem
    {
        public void RunProblem()
        {
            var temp = IsMatch("aa", "a");
            if (temp != false) throw new Exception();

            temp = IsMatch("aa", "*");
            if (temp != true) throw new Exception();

            temp = IsMatch("cb", "?a");
            if (temp != false) throw new Exception();

            temp = IsMatch("adceb", "*a*b");
            if (temp != true) throw new Exception();

            temp = IsMatch("acdcb", "a*c?b");
            if (temp != false) throw new Exception();

            temp = IsMatch("aab", "c*a*b");
            if (temp != false) throw new Exception();

            temp = IsMatch("mississippi", "m??*ss*?i*pi");
            if (temp != false) throw new Exception();
        }

        public bool IsMatch(string s, string p)
        {
            var dp = new bool[s.Length + 1, p.Length + 1];
            dp[0, 0] = true;
            for (var pi = 0; pi < p.Length; pi++)
                if (p[pi] == '*')
                    dp[0, pi + 1] = dp[0, pi];

            for (var si = 1; si <= s.Length; si++)
            {
                for (var pi = 1; pi <= p.Length; pi++)
                {
                    if (s[si - 1] == p[pi - 1] || p[pi - 1] == '?')
                        dp[si, pi] = dp[si - 1, pi - 1];
                    else if (p[pi - 1] == '*')
                        dp[si, pi] = dp[si, pi - 1] || dp[si - 1, pi];
                }
            }

            return dp[s.Length, p.Length];
        }
    }
}
