using System;
namespace ForSolveProblem
{
    public class Problem5340 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int CountNegatives(int[][] grid)
        {
            var forReturn = 0;
            for (var r = 0; r < grid.Length; r++)
                for (var c = 0; c < grid[r].Length; c++)
                    if (grid[r][c] < 0)
                        forReturn++;

            return forReturn;
        }
    }
}
