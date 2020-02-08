using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5306 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinInsertions("zzazz");
            if (temp != 0) throw new Exception();

            temp = MinInsertions("mbadm");
            if (temp != 2) throw new Exception();

            temp = MinInsertions("leetcode");
            if (temp != 5) throw new Exception();

            temp = MinInsertions("g");
            if (temp != 0) throw new Exception();

            temp = MinInsertions("no");
            if (temp != 1) throw new Exception();

            temp = MinInsertions("zjveiiwvc");
            if (temp != 5) throw new Exception();

            temp = MinInsertions("swizunxvbbvjr");
            if (temp != 9) throw new Exception();
        }

        public int MinInsertions(string s)
        {
            var n = s.Length;
            var dp = new int[n + 1, n + 1];

            var jStr = new string(s.Reverse().ToArray());

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 1; j <= jStr.Length; j++)
                {
                    if (s[i - 1] == jStr[j - 1])
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }

            return s.Length - dp[n, n];
        }

        public int MinInsertions1(string s)
        {
            if (s.Length == 1) return 0;

            var startIndex = s.Length / 2 - 1;
            var minValue = int.MaxValue;
            for (int i = startIndex; i < s.Length - 1; i++)
            {
                var firstStr = s.Substring(0, i + 1);

                var nextOneStr = s.Substring(i + 1);
                var nextStr = new string(nextOneStr.Reverse().ToArray());
                var resultOne = DpCalc(firstStr, nextStr);
                minValue = Math.Min(minValue, resultOne);
                if (minValue == 0) return 0;

                if (i + 2 < s.Length)
                {
                    var nextTwoStr = s.Substring(i + 2);
                    var nextTStr = new string(nextTwoStr.Reverse().ToArray());
                    var resultTwo = DpCalc(firstStr, nextTStr);
                    minValue = Math.Min(minValue, resultTwo);
                    if (minValue == 0) return 0;
                }
            }

            return Math.Min(s.Length, minValue);
        }

        private int DpCalc(string s1, string s2)
        {
            var rows = s2.Length;
            var cols = s1.Length;

            var dp = new int[rows, cols];

            for (int c = 0; c < cols; c++)
            {
                if (s2[0] == s1[c])
                    dp[0, c] = c;
                else if (c == 0)
                    dp[0, c] = 1;
                else
                    dp[0, c] = dp[0, c - 1] + 1;
            }

            for (int r = 0; r < rows; r++)
            {
                if (s1[0] == s2[r])
                    dp[r, 0] = r;
                else if (r == 0)
                    dp[r, 0] = 1;
                else
                    dp[r, 0] = dp[r - 1, 0] + 1;
            }

            for (int r = 1; r < rows; r++)
            {
                for (int c = 1; c < cols; c++)
                {
                    var minTemp = Math.Min(dp[r - 1, c] + 1, dp[r, c - 1] + 1);
                    if (s1[c] == s2[r])
                        minTemp = Math.Min(minTemp, dp[r - 1, c - 1]);
                    else
                        minTemp = Math.Min(minTemp, dp[r - 1, c - 1] + 2);

                    dp[r, c] = minTemp;
                }
            }

            return dp[rows - 1, cols - 1];
        }
    }
}
