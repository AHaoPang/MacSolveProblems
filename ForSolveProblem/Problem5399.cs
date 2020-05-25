using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5399 : IProblem
    {
        public void RunProblem()
        {
            var temp = LargestNumber(new[] { 4, 3, 2, 5, 6, 7, 2, 5, 5 }, 9);
            if (temp != "7772") throw new Exception();

            temp = LargestNumber(new[] { 7, 6, 5, 5, 5, 6, 8, 7, 8 }, 12);
            if (temp != "85") throw new Exception();

            temp = LargestNumber(new[] { 2, 4, 6, 2, 4, 6, 4, 4, 4 }, 5);
            if (temp != "0") throw new Exception();

            temp = LargestNumber(new[] { 6, 10, 15, 40, 40, 40, 40, 40, 40 }, 47);
            if (temp != "32211") throw new Exception();
        }

        public string LargestNumber(int[] cost, int target)
        {
            var dp = new int[10, target + 1];

            dp[0, 0] = 0;
            for (var i = 1; i <= target; i++)
                dp[0, i] = int.MinValue;

            for (var i = 1; i <= 9; i++)
            {
                var curCost = cost[i - 1];

                for (var j = 0; j <= target; j++)
                {
                    dp[i, j] = dp[i - 1, j];
                    if (j - curCost >= 0)
                        dp[i, j] = Math.Max(dp[i, j], dp[i, j - curCost] + 1);
                }
            }

            if (dp[9, target] <= 0)
                return "0";

            m_res = new List<int>();
            Search(dp, 9, target, cost, dp[9, target]);

            return string.Join("", m_res);
        }

        private List<int> m_res;

        private void Search(int[,] dp, int curLevel, int curCost, int[] cost, int curCount)
        {
            if (curLevel == 0)
                return;

            if (curCost - cost[curLevel - 1] >= 0 && dp[curLevel, curCost - cost[curLevel - 1]] == dp[curLevel, curCost] - 1)
            {
                m_res.Add(curLevel);
                Search(dp, curLevel, curCost - cost[curLevel - 1], cost, curCount - 1);
            }
            else
            {
                Search(dp, curLevel - 1, curCost, cost, curCount);
            }
        }
    }
}
