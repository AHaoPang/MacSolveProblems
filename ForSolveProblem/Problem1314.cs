using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1314 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[][] MatrixBlockSum(int[][] mat, int K)
        {
            var r = mat.Length;
            var c = mat[0].Length;

            var sumArray = new int[r, c];
            for (int rIndex = 0; rIndex < r; rIndex++)
            {
                for (int cIndex = 0; cIndex < c; cIndex++)
                {
                    var upTemp = 0;
                    if (rIndex - 1 >= 0)
                        upTemp = sumArray[rIndex - 1, cIndex];

                    var leftTemp = 0;
                    if (cIndex - 1 >= 0)
                        leftTemp = sumArray[rIndex, cIndex - 1];

                    var midTemp = 0;
                    if (rIndex - 1 >= 0 && cIndex - 1 >= 0)
                        midTemp = sumArray[rIndex - 1, cIndex - 1];

                    sumArray[rIndex, cIndex] = upTemp + leftTemp - midTemp + mat[rIndex][cIndex];
                }
            }

            var forReturn = new int[r][];
            for (var rIndex = 0; rIndex < r; rIndex++)
            {
                forReturn[rIndex] = new int[c];
                for (var cIndex = 0; cIndex < c; cIndex++)
                {
                    var minR = rIndex - K;
                    if (minR < 0) minR = 0;

                    var maxR = rIndex + K;
                    if (maxR > r - 1) maxR = r - 1;

                    var minC = cIndex - K;
                    if (minC < 0) minC = 0;

                    var maxC = cIndex + K;
                    if (maxC > c - 1) maxC = c - 1;

                    var upTemp = 0;
                    if (minR - 1 >= 0)
                        upTemp = sumArray[minR - 1, maxC];

                    var leftTemp = 0;
                    if (minC - 1 >= 0)
                        leftTemp = sumArray[maxR, minC - 1];

                    var midTemp = 0;
                    if (minR - 1 >= 0 && minC - 1 >= 0)
                        midTemp = sumArray[minR - 1, minC - 1];

                    forReturn[rIndex][cIndex] = sumArray[maxR, maxC] - leftTemp - upTemp + midTemp;
                }
            }

            return forReturn;
        }
    }
}
