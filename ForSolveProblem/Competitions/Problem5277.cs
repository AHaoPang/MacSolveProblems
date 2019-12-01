using System;
namespace ForSolveProblem
{
    public class Problem5277 : IProblem
    {
        public void RunProblem()
        {
            var temp = CountSquares(new int[][]
            {
                  new int[]{0, 1, 1, 1 },
                  new int[]{1, 1, 1, 1},
                  new int[]{0, 1, 1, 1}
            });
            if (temp != 15) throw new Exception();

            temp = CountSquares(new int[][]
            {
                  new int[]{1, 0, 1},
                  new int[]{1, 1, 0},
                  new int[]{1, 1, 0 }
            });
            if (temp != 7) throw new Exception();
        }

        public int CountSquares(int[][] matrix)
        {
            var rows = matrix.Length;
            var cols = matrix[0].Length;
            var dp = new int[rows, cols];

            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    if (matrix[r][c] == 0)
                    {
                        dp[r, c] = 0;
                        continue;
                    }

                    var smallValue = int.MaxValue;
                    var upValue = 0;
                    if (r - 1 >= 0) upValue = dp[r - 1, c];
                    smallValue = Math.Min(smallValue, upValue);

                    var leftValue = 0;
                    if (c - 1 >= 0) leftValue = dp[r, c - 1];
                    smallValue = Math.Min(smallValue, leftValue);

                    var midValue = 0;
                    if (r - 1 >= 0 && c - 1 >= 0) midValue = dp[r - 1, c - 1];
                    smallValue = Math.Min(smallValue, midValue);

                    dp[r, c] = smallValue + 1;
                }
            }

            var forReturn = 0;
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    forReturn += dp[r, c];

            return forReturn;
        }
    }
}
