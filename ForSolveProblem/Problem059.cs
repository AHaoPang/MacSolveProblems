using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem059 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[][] GenerateMatrix(int n)
        {
            var res = new int[n][];
            for (var r = 0; r < n; r++)
                res[r] = new int[n];

            var arr = new int[][] { new[] { 0, 1 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { -1, 0 } };
            var at = 0;
            var ar = arr[at];

            var rt = 0;
            var ct = -1;
            var v = 1;
            while (v <= n * n)
            {
                var nrt = rt + ar[0];
                var nct = ct + ar[1];

                if (nrt >= 0 && nrt < n && nct >= 0 && nct < n && res[nrt][nct] == 0)
                {
                    res[nrt][nct] = v++;
                    rt = nrt;
                    ct = nct;
                }
                else
                {
                    at++;
                    ar = arr[at % 4];
                }
            }

            return res;
        }
    }
}
