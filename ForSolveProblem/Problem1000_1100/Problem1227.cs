using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1227 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public double NthPersonGetsNthSeat(int n)
        {
            return n == 1 ? 1 : 0.5;
        }

        public double NthPersonGetsNthSeat1(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 0.5;

            var dp = new double[n + 1];
            dp[1] = 1;
            dp[2] = 0.5;

            for (int i = 3; i <= n; i++)
            {
                var sumTemp = 1.0 / i;
                for (int j = 2; j < i; j++)
                    sumTemp += dp[j] / i;

                dp[i] = sumTemp;
            }

            return dp[n];
        }
    }
}
