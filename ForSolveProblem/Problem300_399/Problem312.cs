using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem312 : IProblem
    {
        public void RunProblem()
        {
            var temp = MaxCoins(new[] { 3, 1, 5, 8 });
            if (temp != 167) throw new Exception();
        }

        public int MaxCoins2(int[] nums)
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

        public int MaxCoins(int[] nums)
        {
            var list = new List<int>(nums.Length + 2);
            list.Add(1);
            list.AddRange(nums);
            list.Add(1);

            var dp = new int[list.Count, list.Count];
            for (var c = 2; c < list.Count; c++)
            {
                var l = 0;
                var r = c;
                while (r < list.Count)
                {
                    for (var k = l + 1; k < r; k++)
                        dp[l, r] = Math.Max(dp[l, r], dp[l, k] + dp[k, r] + list[l] * list[k] * list[r]);

                    l++;
                    r++;
                }
            }

            return dp[0, list.Count - 1];
        }
    }
}
