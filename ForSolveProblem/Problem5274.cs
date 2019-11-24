using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5274 : IProblem
    {
        public void RunProblem()
        {
            var temp = NumWays(3, 2);
            if (temp != 4) throw new Exception();

            temp = NumWays(2, 4);
            if (temp != 2) throw new Exception();

            temp = NumWays(4, 2);
            if (temp != 8) throw new Exception();

            temp = NumWays(500, 969997);
            if (temp != 374847123) throw new Exception();
        }

        public int NumWays(int steps, int arrLen)
        {
            var modNum = (int)(1e9 + 7);
            var lenTemp = Math.Min(steps + 1, arrLen);
            var dp = new int[lenTemp, 2];
            dp[0, 0] = 1;

            for (int step = 1; step < steps; step++)
            {
                for (int len = 0; len < Math.Min(step + 1, lenTemp); len++)
                {
                    var numArray = new int[3];

                    var preNum = 0;
                    if (len - 1 >= 0) preNum = dp[len - 1, 0];
                    numArray[0] = preNum;

                    var curNum = dp[len, 0];
                    numArray[1] = curNum;

                    var nextNum = 0;
                    if (len + 1 <= arrLen - 1) nextNum = dp[len + 1, 0];
                    numArray[2] = nextNum;

                    var finNum = 0;
                    for (int n = 0; n < numArray.Length; n++)
                    {
                        finNum += numArray[n];

                        finNum %= modNum;
                    }

                    dp[len, 1] = finNum;
                }

                for (int t = 0; t < lenTemp; t++)
                    dp[t, 0] = dp[t, 1];
            }

            return (dp[0, 1] + dp[1, 1]) % modNum;
        }
    }
}
