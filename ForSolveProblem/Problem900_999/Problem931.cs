using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem931 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinFallingPathSum(new int[][]
            {
                new int[]{1,2,3},
                new int[]{4,5,6},
                new int[]{7,8,9}
            });
            if (temp != 12) throw new Exception();
        }

        public int MinFallingPathSum(int[][] A)
        {
            var rows = A.Length;
            var cols = A[0].Length;

            var oneArray = new int[cols];
            for (int c = 0; c < cols; c++)
                oneArray[c] = A[0][c];

            var twoArray = new int[cols];
            for (int r = 1; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    var leftValue = int.MaxValue;
                    if (c - 1 >= 0)
                        leftValue = oneArray[c - 1];

                    var midValue = oneArray[c];

                    var rightValue = int.MaxValue;
                    if (c + 1 <= cols - 1)
                        rightValue = oneArray[c + 1];

                    var valueArray = new int[] { leftValue, midValue, rightValue };
                    twoArray[c] = valueArray.Min() + A[r][c];
                }

                for (int c = 0; c < cols; c++)
                    oneArray[c] = twoArray[c];
            }

            return oneArray.Min();
        }
    }
}
