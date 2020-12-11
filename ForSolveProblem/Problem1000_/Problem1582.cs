using System;
namespace ForSolveProblem
{
    public class Problem1582 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int NumSpecial(int[][] mat)
        {
            var rows = mat.Length;
            var cols = mat[0].Length;

            var rowArray = new int[rows];
            var colArray = new int[cols];

            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < cols; c++)
                {
                    rowArray[r] += mat[r][c];
                    colArray[c] += mat[r][c];
                }
            }

            var res = 0;
            for (var r = 0; r < rows; r++)
            {
                if (rowArray[r] != 1) continue;

                for (var c = 0; c < cols; c++)
                    if (colArray[c] == 1 && mat[r][c] == 1)
                        res++;
            }

            return res;
        }
    }
}
