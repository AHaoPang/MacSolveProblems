using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem887 : IProblem
    {
        public void RunProblem()
        {
            var temp = SuperEggDrop(1, 2);
            ProblemHelper.AEqual(temp, 2);

            temp = SuperEggDrop(2, 6);
            ProblemHelper.AEqual(temp, 3);
        }

        public int SuperEggDrop(int K, int N)
        {
            m_dp = new Dictionary<int, int>();
            return Dp(K, N);
        }

        private Dictionary<int, int> m_dp;

        private int Dp(int k, int n)
        {
            if (m_dp.ContainsKey(n * 100 + k))
                return m_dp[n * 100 + k];

            var res = 0;
            if (k == 1)
                res = n;
            else if (n <= 1)
                res = n;
            else
            {
                var lo = 1;
                var hi = n;
                while (lo + 1 < hi)
                {
                    var mid = lo + (hi - lo) / 2;
                    var v1 = Dp(k, n - mid);
                    var v2 = Dp(k - 1, mid - 1);

                    if (v1 == v2)
                        lo = hi = mid;
                    else if (v1 > v2)
                        lo = mid;
                    else
                        hi = mid;
                }

                res = 1 + Math.Min(
                    Math.Max(Dp(k, n - lo), Dp(k - 1, lo - 1)),
                    Math.Max(Dp(k, n - hi), Dp(k - 1, hi - 1)));
            }

            m_dp[n * 100 + k] = res;
            return res;
        }
    }
}
