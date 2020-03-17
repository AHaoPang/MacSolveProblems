using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1320 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinimumDistance("CAKE");
            if (temp != 3) throw new Exception();

            temp = MinimumDistance("HAPPY");
            if (temp != 6) throw new Exception();

            temp = MinimumDistance("NEW");
            if (temp != 3) throw new Exception();

            temp = MinimumDistance("YEAR");
            if (temp != 7) throw new Exception();
        }

        public int MinimumDistance(string word)
        {
            var length = word.Length;
            var dp = new int[length, 26, 26];

            var maxTemp = int.MaxValue >> 1;
            for (int i = 0; i < length; i++)
                for (int j = 0; j < 26; j++)
                    for (int k = 0; k < 26; k++)
                        dp[i, j, k] = maxTemp;

            var firstPos = word[0] - 'A';
            for (int i = 0; i < 26; i++)
            {
                dp[0, firstPos, i] = 0;
                dp[0, i, firstPos] = 0;
            }

            for (int i = 1; i < length; i++)
            {
                var preChar = word[i - 1] - 'A';
                var curChar = word[i] - 'A';
                var preToCur = GetDistance(preChar, curChar);

                for (int j = 0; j < 26; j++)
                {
                    dp[i, curChar, j] = Math.Min(dp[i, curChar, j], dp[i - 1, preChar, j] + preToCur);
                    dp[i, j, curChar] = Math.Min(dp[i, j, curChar], dp[i - 1, j, preChar] + preToCur);

                    for (int k = 0; k < 26; k++)
                    {
                        var tempToCur = GetDistance(k, curChar);

                        dp[i, curChar, preChar] = Math.Min(dp[i, curChar, preChar], dp[i - 1, k, preChar] + tempToCur);
                        dp[i, preChar, curChar] = Math.Min(dp[i, preChar, curChar], dp[i - 1, preChar, k] + tempToCur);
                    }
                }
            }

            var forReturn = int.MaxValue;
            for (int i = 0; i < 26; i++)
                for (int j = 0; j < 26; j++)
                    forReturn = Math.Min(dp[length - 1, i, j], forReturn);

            return forReturn;
        }

        private int GetDistance(int c1, int c2)
        {
            var c1x = c1 % 6;
            var c2x = c2 % 6;

            var c1y = c1 / 6;
            var c2y = c2 / 6;

            return Math.Abs(c1x - c2x) + Math.Abs(c1y - c2y);
        }
    }
}
