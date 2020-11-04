using System;
namespace ForSolveProblem
{
    public class Problem5491 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int DiagonalSum(int[][] mat)
        {
            var res = 0;
            var n = mat.Length;

            var i = 0;
            var j = 0;
            while (i < n)
            {
                res += mat[i][j];
                i++;
                j++;
            }

            i = 0;
            j = n - 1;
            while (i < n)
            {
                res += mat[i][j];
                i++;
                j--;
            }

            if (n % 2 != 0)
            {
                var mid = n / 2;
                res -= mat[mid][mid];
            }

            return res;
        }
    }
}
