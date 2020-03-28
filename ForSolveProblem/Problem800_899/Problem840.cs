using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem840 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int NumMagicSquaresInside(int[][] grid)
        {
            var res = 0;

            for (var r = 1; r < grid.Length - 1; r++)
            {
                for (var c = 1; c < grid[r].Length - 1; c++)
                {
                    if (grid[r][c] != 5) continue;

                    if (IsNineNums(grid, r, c) && IsCenterOk(grid, r, c) && IsAroundOk(grid, r, c))
                        res++;
                }
            }

            return res;
        }

        private bool IsNineNums(int[][] grid, int r, int c)
        {
            var set = new HashSet<int>();
            for (var i = r - 1; i <= r + 1; i++)
                for (var j = c - 1; j <= c + 1; j++)
                    if (grid[i][j] >= 1 && grid[i][j] <= 9)
                        set.Add(grid[i][j]);

            return set.Count == 9;
        }

        private bool IsCenterOk(int[][] grid, int r, int c)
        {
            return
                grid[r - 1][c - 1] + grid[r + 1][c + 1] == 10 &&
                grid[r + 1][c - 1] + grid[r - 1][c + 1] == 10 &&
                grid[r][c - 1] + grid[r][c + 1] == 10 &&
                grid[r - 1][c] + grid[r + 1][c] == 10;
        }

        private bool IsAroundOk(int[][] grid, int r, int c)
        {
            return
                grid[r - 1][c - 1] + grid[r - 1][c] + grid[r - 1][c + 1] == 15 &&
                grid[r + 1][c - 1] + grid[r + 1][c] + grid[r + 1][c + 1] == 15 &&
                grid[r - 1][c - 1] + grid[r][c - 1] + grid[r + 1][c - 1] == 15 &&
                grid[r - 1][c + 1] + grid[r][c + 1] + grid[r + 1][c + 1] == 15;
        }
    }
}
