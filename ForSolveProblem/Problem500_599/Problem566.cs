using System;
using System.Linq;
namespace ForSolveProblem
{
    public class Problem566 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[][] MatrixReshape(int[][] nums, int r, int c)
        {
            var rows = nums.Length;
            var cols = nums[0].Length;

            if (rows * cols != r * c) return nums;

            var forReturn = new int[r][];
            for (var i = 0; i < r; i++)
                forReturn[i] = new int[c];

            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    var curSum = row * cols + col;
                    forReturn[curSum / c][curSum % c] = nums[row][col];
                }
            }

            return forReturn;
        }
    }
}
