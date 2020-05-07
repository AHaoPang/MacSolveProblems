using System;
namespace ForSolveProblem
{
    public class Problem983 : IProblem
    {
        public void RunProblem()
        {
            var temp = MincostTickets(new[] { 1, 4, 6, 7, 8, 20 }, new[] { 2, 7, 15 });
        }

        public int MincostTickets(int[] days, int[] costs)
        {
            var dayLengthArr = new[] { 1, 7, 30 };
            var n = days.Length;
            var dp = new int[n + 1];
            for (var i = 0; i < days.Length; i++)
            {
                var day = days[i];
                var res = int.MaxValue;
                for (var j = 0; j < costs.Length; j++)
                {
                    var minDay = day - dayLengthArr[j];

                    var k = i - 1;
                    while (k >= 0 && days[k] > minDay)
                        k--;

                    res = Math.Min(res, dp[k + 1] + costs[j]);
                }

                dp[i + 1] = res;
            }

            return dp[n];
        }
    }
}
