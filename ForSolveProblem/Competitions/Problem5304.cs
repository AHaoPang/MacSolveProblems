using System;
namespace ForSolveProblem
{
    public class Problem5304 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[] XorQueries(int[] arr, int[][] queries)
        {
            var resultTemp = new int[arr.Length];
            var curValue = arr[0];
            resultTemp[0] = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                curValue ^= arr[i];
                resultTemp[i] = curValue;
            }

            var forReturn = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                var minTemp = queries[i][0] - 1;
                var maxTemp = queries[i][1];
                if (minTemp < 0)
                {
                    forReturn[i] = resultTemp[maxTemp];
                    continue;
                }

                forReturn[i] = resultTemp[maxTemp] ^ resultTemp[minTemp];
            }

            return forReturn;
        }
    }
}
