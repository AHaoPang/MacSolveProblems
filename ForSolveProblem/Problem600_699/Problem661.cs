using System;
namespace ForSolveProblem
{
    public class Problem661 : IProblem
    {
        public void RunProblem()
        {
            var temp = ImageSmoother(new int[][]
            {
                new[]{1,1,1 },
                new[]{1,0,1},
                new[]{1,1,1}
            });
        }

        public int[][] ImageSmoother(int[][] M)
        {
            var vectorArray = new int[][]
            {
                new[]{0,0},

                new[]{-1,-1},
                new[]{-1,0},
                new[]{-1,1},
                new[]{0,1},

                new[]{1,1},
                new[]{1,0},
                new[]{1,-1},
                new[]{0,-1}
            };

            var forReturn = new int[M.Length][];
            for (var r = 0; r < M.Length; r++)
            {
                var cols = M[r].Length;
                forReturn[r] = new int[cols];
                for (var c = 0; c < M[r].Length; c++)
                {
                    var sum = 0;
                    var count = 0;
                    foreach (var item in vectorArray)
                    {
                        var newR = r + item[0];
                        var newC = c + item[1];

                        if (newR >= 0 && newR < M.Length && newC >= 0 && newC < cols)
                        {
                            count++;
                            sum += M[newR][newC];
                        }
                    }

                    forReturn[r][c] = sum / count;
                }
            }

            return forReturn;
        }

        public int[][] ImageSmoother1(int[][] M)
        {
            var sumArray = new int[M.Length][];
            for (var r = 0; r < M.Length; r++)
            {
                var cols = M[r].Length;
                sumArray[r] = new int[cols];
                for (var c = 0; c < cols; c++)
                {
                    sumArray[r][c] = M[r][c];

                    if (c != 0)
                        sumArray[r][c] += sumArray[r][c - 1];

                    if (r != 0)
                        sumArray[r][c] += sumArray[r - 1][c];

                    if (c != 0 && r != 0)
                        sumArray[r][c] -= sumArray[r - 1][c - 1];
                }
            }

            var forReturnArray = new int[M.Length][];
            for (var r = 0; r < M.Length; r++)
            {
                var cols = M[r].Length;
                forReturnArray[r] = new int[cols];
                for (var c = 0; c < cols; c++)
                {
                    var rightDownRow = r + 1 >= M.Length ? r : r + 1;
                    var rightDownCol = c + 1 >= cols ? c : c + 1;
                    var leftUpRow = r - 1 >= 0 ? r - 1 : 0;
                    var leftUpCol = c - 1 >= 0 ? c - 1 : 0;

                    var rightDownSum = sumArray[rightDownRow][rightDownCol];
                    var leftDownSum = sumArray[rightDownRow][leftUpCol];
                    var rightUpSum = sumArray[leftUpRow][rightDownCol];
                    var leftUpSum = sumArray[leftUpRow][leftUpCol];

                    var unitCount = (rightDownRow - leftUpRow + 1) * (rightDownCol - leftUpCol + 1);
                    forReturnArray[r][c] = (rightDownSum - rightUpSum - leftDownSum + leftUpSum) / unitCount;
                }
            }

            return forReturnArray;
        }
    }
}
