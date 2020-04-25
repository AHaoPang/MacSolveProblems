using System;
namespace ForSolveProblem
{
    public class Interview_08_11 : IProblem
    {
        public void RunProblem()
        {
            var temp = WaysToChange(10);
        }

        public int WaysToChange(int n)
        {
            var arr = new[] { 1, 5, 10, 25 };
            var constNum = (int)1e9 + 7;
            var dp = new int[n + 1];
            dp[0] = 1;
            foreach (var arrItem in arr)
            {
                for (var i = arrItem; i <= n; i++)
                {
                    dp[i] += dp[i - arrItem];
                    dp[i] %= constNum;
                }
            }

            return dp[n];
        }

        public int WaysToChange1(int n)
        {
            var arr = new[] { 1, 5, 10, 25 };
            var dp = new int[n + 1];
            var constNum = (int)1e9 + 7;

            dp[0] = 1;
            for (var i = 1; i <= n; i++)
            {
                var curValue = 0;
                foreach (var item in arr)
                {
                    if (i - item < 0) break;

                    curValue += dp[i - item];
                    curValue %= constNum;
                }

                dp[i] = curValue;
            }

            return dp[n];
        }
    }
}
