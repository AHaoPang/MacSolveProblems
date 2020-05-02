using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem312 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MaxCoins(int[] nums)
        {
            var n = nums.Length;
            var list = new List<int>(n + 2);
            list.Add(1);
            list.AddRange(nums);
            list.Add(1);

            var newN = n + 2;
            var dp = new int[newN, newN];
            for (var len = 2; len <= newN; len++)
            {
                for (var i = 0; i + len - 1 < newN; i++)
                {
                    var j = i + len - 1;
                    for (var k = i + 1; k <= j - 1; k++)
                        dp[i, j] = Math.Max(dp[i, j], dp[i, k] + dp[k, j] + list[i] * list[k] * list[j]);
                }
            }

            return dp[0, newN - 1];
        }
    }
}
