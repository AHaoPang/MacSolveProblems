using System;
namespace ForSolveProblem
{
    public class Problem867 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[][] Transpose(int[][] A)
        {
            var rows = A.Length;
            var cols = A[0].Length;

            var res = new int[cols][];
            for (var c = 0; c < cols; c++)
                res[c] = new int[rows];

            for (var r = 0; r < rows; r++)
                for (var c = 0; c < cols; c++)
                    res[c][r] = A[r][c];

            return res;
        }
    }
}
