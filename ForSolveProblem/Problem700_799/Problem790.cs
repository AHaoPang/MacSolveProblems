using System;
namespace ForSolveProblem
{
    public class Problem790 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int NumTilings(int N)
        {
            var constNum = (int)1e9 + 7;
            var dp = new int[] { 1, 0, 0, 0 };

            for (int i = 1; i < N; i++)
            {
                var newDp = new int[4];
                newDp[0b00] = (dp[0b00] + dp[0b11]) % constNum;
                newDp[0b01] = (dp[0b00] + dp[0b10]) % constNum;
                newDp[0b10] = (dp[0b00] + dp[0b01]) % constNum;
                newDp[0b11] = (dp[0b00] + dp[0b01] + dp[0b10]) % constNum;

                dp = newDp;
            }

            return dp[0];
        }
    }
}
