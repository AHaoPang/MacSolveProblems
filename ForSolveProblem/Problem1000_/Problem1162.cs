using System;
using System.Linq;
namespace ForSolveProblem
{
    public class Problem1162 : IProblem
    {
        public void RunProblem()
        {
            var temp = MaxDistance(new int[][]
            {
                new[]{1,1,1,1},
                new[]{1,1,1,1},
                new[]{1,1,1,1},
                new[]{1,1,1,1}
            });

            temp = MaxDistance(new int[][]
            {
                new[]{1,0,1},
                new[]{0,0,0},
                new[]{1,0,1},
            });
        }

        public int MaxDistance(int[][] grid)
        {
            for (var r = 0; r < grid.Length; r++)
            {
                for (var c = 0; c < grid[r].Length; c++)
                {
                    if (grid[r][c] == 1) continue;

                    var up = r - 1 >= 0 && grid[r - 1][c] != 0 ? grid[r - 1][c] : int.MaxValue;
                    var left = c - 1 >= 0 && grid[r][c - 1] != 0 ? grid[r][c - 1] : int.MaxValue;

                    if (up != int.MaxValue || left != int.MaxValue)
                        grid[r][c] = Math.Min(left, up) + 1;
                }
            }

            for (var r = grid.Length - 1; r >= 0; r--)
            {
                for (var c = grid[r].Length - 1; c >= 0; c--)
                {
                    if (grid[r][c] == 1) continue;

                    var down = r + 1 < grid.Length && grid[r + 1][c] != 0 ? grid[r + 1][c] : int.MaxValue;
                    var right = c + 1 < grid[r].Length && grid[r][c + 1] != 0 ? grid[r][c + 1] : int.MaxValue;

                    if (down != int.MaxValue || right != int.MaxValue)
                    {
                        var min = Math.Min(down, right);

                        if (grid[r][c] > min || grid[r][c] == 0)
                            grid[r][c] = min + 1;
                    }
                }
            }

            var res = grid.Max(i => i.Max());
            return res == 0 || res == 1 ? -1 : res - 1;
        }

        public int MaxDistance1(int[][] grid)
        {
            var rows = grid.Length;
            var cols = grid[0].Length;
            var nGrid = new int[rows, cols];

            for (var r = 0; r < rows; r++)
                for (var c = 0; c < cols; c++)
                    nGrid[r, c] = grid[r][c];

            for (var r = 0; r < rows; r++)
                for (var c = 0; c < cols; c++)
                    if (grid[r][c] == 1)
                        Dfs(nGrid, r, c, 2);

            var res = 0;
            for (var r = 0; r < rows; r++)
                for (var c = 0; c < cols; c++)
                    res = Math.Max(nGrid[r, c], res);

            return (res == 1 || res == 0) ? -1 : res - 1;
        }

        private void Dfs(int[,] nGrid, int r, int c, int otherValue)
        {
            var rows = nGrid.GetLength(0);
            var cols = nGrid.GetLength(1);

            var arr = new int[][] { new[] { -1, 0 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { 0, 1 } };

            foreach (var arrItem in arr)
            {
                var newR = r + arrItem[0];
                var newC = c + arrItem[1];

                if (newR >= 0 && newR < rows && newC >= 0 && newC < cols &&
                    (nGrid[newR, newC] == 0 || nGrid[newR, newC] > otherValue))
                {
                    nGrid[newR, newC] = otherValue;
                    Dfs(nGrid, newR, newC, otherValue + 1);
                }
            }
        }
    }
}
