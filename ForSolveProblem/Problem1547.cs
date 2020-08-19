using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1547 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinCost(7, new[] { 1, 3, 4, 5 });
            if (temp != 16) throw new Exception();

            temp = MinCost(9, new[] { 5, 6, 1, 4, 2 });
            if (temp != 22) throw new Exception();
        }

        public int MinCost(int n, int[] cuts)
        {
            var list = new List<int>(cuts.Length + 2);
            list.Add(0);
            list.AddRange(cuts);
            list.Add(n);

            var orderList = list.OrderBy(i => i).ToArray();
            var dp = new int[orderList.Length, orderList.Length];
            for (var r = 0; r < orderList.Length; r++)
            {
                for (var c = 0; c < orderList.Length; c++)
                {
                    dp[r, c] = int.MaxValue;

                    if (r == c || r + 1 == c)
                        dp[r, c] = 0;
                }
            }

            for (var c = 2; c < orderList.Length; c++)
            {
                var l = 0;
                var r = c;
                while (r < orderList.Length)
                {
                    for (var k = l + 1; k < r; k++)
                        dp[l, r] = Math.Min(dp[l, r], dp[l, k] + dp[k, r] + orderList[r] - orderList[l]);

                    l++;
                    r++;
                }
            }

            return dp[0, orderList.Length - 1];
        }
    }
}
