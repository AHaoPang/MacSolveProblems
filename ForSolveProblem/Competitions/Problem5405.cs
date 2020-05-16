using System;
namespace ForSolveProblem
{
    public class Problem5405 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int CountTriplets(int[] arr)
        {
            var dp = new int[arr.Length, arr.Length];
            for (var i = 0; i < arr.Length; i++)
            {
                var r = 0;
                for (var j = i; j < arr.Length; j++)
                {
                    r ^= arr[j];
                    dp[i, j] = r;
                }
            }

            var res = 0;
            for (var i = 0; i < arr.Length - 1; i++)
            {
                for (var j = i + 1; j < arr.Length; j++)
                {
                    for (var k = j; k < arr.Length; k++)
                    {
                        if (dp[i, j - 1] == dp[j, k])
                            res++;
                    }
                }
            }

            return res;
        }
    }
}
