using System;
namespace ForSolveProblem
{
    public class Problem1010 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int NumPairsDivisibleBy60(int[] time)
        {
            var arr = new int[60];
            foreach (var timeItem in time)
                arr[timeItem % 60]++;

            var res = arr[0] * (arr[0] - 1) / 2;

            for (var i = 1; i < 30; i++)
                res += arr[i] * arr[60 - i];

            res += arr[30] * (arr[30] - 1) / 2;

            return res;
        }
    }
}
