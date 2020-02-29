using System;
namespace ForSolveProblem
{
    public class Problem1025 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool DivisorGame(int N)
        {
            /*
             * 题目概述：除数博弈
             * 
             * 思路：
             *  1.使用已计算出来的值,去推算更高的值,使用了动态规划的思路
             *  2.要知道给定的数字是否能让先手获胜,那么就要找到所有的可行解,看是否有让自己获胜的方法,有的话,就抓住
             *
             * 知识点：动态规划
             *
             * 时间复杂度：O(n^2)
             * 空间复杂度：O(n)
             */

            var dp = new bool[N + 1];

            for (var i = 2; i <= N; i++)
            {
                var halfValue = i / 2;

                for (var j = 1; j <= halfValue; j++)
                {
                    if (i % j == 0)
                    {
                        dp[i] = !dp[i - j];

                        if (dp[i]) break;
                    }
                }
            }

            return dp[N];
        }
    }
}
