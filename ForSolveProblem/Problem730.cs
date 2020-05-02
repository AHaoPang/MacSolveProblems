using System;
namespace ForSolveProblem
{
    public class Problem730 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int CountPalindromicSubsequences(string S)
        {
            var constNum = (int)1e9 + 7;
            var n = S.Length;
            var dp = new long[4, n, n];
            for (var i = n - 1; i >= 0; i--)
            {
                for (var j = i; j <= n - 1; j++)
                {
                    for (var k = 0; k < 4; k++)
                    {
                        var cI = S[i];
                        var cJ = S[j];
                        if (i == j)
                        {
                            if (cI == k + 'a')
                                dp[k, i, j] = 1;

                            continue;
                        }

                        dp[k, i, j] = Math.Max(dp[k, i + 1, j], dp[k, i, j - 1]);
                        if (cI == k + 'a' && cJ == k + 'a')
                        {
                            var resTemp = 2L;
                            for (var l = 0; l < 4; l++)
                                resTemp += dp[l, i + 1, j - 1];

                            resTemp %= constNum;
                            dp[k, i, j] = Math.Max(dp[k, i, j], resTemp);
                        }
                    }
                }
            }

            var res = 0L;
            for (var i = 0; i < 4; i++)
            {
                res += dp[i, 0, n - 1];
                res %= constNum;
            }

            return (int)res;
        }

        public int CountPalindromicSubsequences1(string S)
        {
            var constNum = (int)1e9 + 7;
            var n = S.Length;
            var dp = new long[4, n, n];
            for (var i = n - 1; i >= 0; i--)
            {
                for (var j = i; j <= n - 1; j++)
                {
                    for (var k = 0; k < 4; k++)
                    {
                        var cI = S[i];
                        var cJ = S[j];
                        if (i == j)
                        {
                            if (cI == k + 'a')
                                dp[k, i, j] = 1;

                            continue;
                        }

                        if (cI != k + 'a')
                            dp[k, i, j] = dp[k, i + 1, j];
                        else if (cJ != k + 'a')
                            dp[k, i, j] = dp[k, i, j - 1];
                        else
                        {
                            var sumTemp = 2L;
                            for (var l = 0; l < 4; l++)
                            {
                                sumTemp += dp[l, i + 1, j - 1];
                                sumTemp %= constNum;
                            }
                            dp[k, i, j] = sumTemp;
                        }
                    }
                }
            }

            var res = 0L;
            for (var i = 0; i < 4; i++)
            {
                res += dp[i, 0, n - 1];
                res %= constNum;
            }

            return (int)res;
        }
    }
}
