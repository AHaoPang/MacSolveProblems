using System;
namespace ForSolveProblem
{
    public class Problem1406 : IProblem
    {
        public void RunProblem()
        {
            var temp = StoneGameIII(new[] { 1, 2, 3, 6 });
            if (temp != "Tie") throw new Exception();
        }

        public string StoneGameIII(int[] stoneValue)
        {
            var dp = new int[stoneValue.Length + 3];

            var sum = 0;
            for (int i = stoneValue.Length - 1; i >= 0; i--)
            {
                sum += stoneValue[i];
                dp[i] = int.MinValue;
                for (var j = 1; j <= 3; j++)
                    dp[i] = Math.Max(dp[i], sum - dp[i + j]);
            }

            var alice = dp[0];
            var bob = sum - dp[0];

            if (alice == bob) return "Tie";

            return alice > bob ? "Alice" : "Bob";
        }
    }
}
