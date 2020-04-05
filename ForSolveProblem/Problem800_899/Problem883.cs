using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem883 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int ProjectionArea(int[][] grid)
        {
            return GetFloorCount(grid) + GetLeftCount(grid) + GetRightCount(grid);
        }

        private int GetFloorCount(int[][] grid)
        {
            var res = 0;
            for (var r = 0; r < grid.Length; r++)
                for (var c = 0; c < grid[r].Length; c++)
                    if (grid[r][c] > 0)
                        res++;

            return res;
        }

        private int GetLeftCount(int[][] grid)
        {
            var res = 0;
            for (var r = 0; r < grid.Length; r++)
                res += grid[r].Max();

            return res;
        }

        private int GetRightCount(int[][] grid)
        {
            var res = 0;
            for (var c = 0; c < grid[0].Length; c++)
            {
                var max = 0;
                for (var r = 0; r < grid.Length; r++)
                    max = Math.Max(grid[r][c], max);

                res += max;
            }

            return res;
        }
    }
}
