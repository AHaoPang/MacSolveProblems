using System;
namespace ForSolveProblem
{
    public class Problem892 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int SurfaceArea(int[][] grid)
        {
            var res = 0;
            var arr = new[] { new[] { 0, -1 }, new[] { -1, 0 } };
            for (var r = 0; r < grid.Length; r++)
            {
                for (var c = 0; c < grid[r].Length; c++)
                {
                    var curNum = grid[r][c];
                    if (curNum == 0) continue;

                    res += curNum * 6 - (curNum - 1) * 2;

                    foreach (var arrItem in arr)
                    {
                        var newR = r + arrItem[0];
                        var newC = c + arrItem[1];
                        if (newR >= 0 && newC >= 0)
                            res -= Math.Min(curNum, grid[newR][newC]) * 2;
                    }
                }
            }

            return res;
        }
    }
}
