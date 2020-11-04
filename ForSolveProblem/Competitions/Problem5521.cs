using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5521 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MaxProductPath(int[][] grid)
        {
            var rows = grid.Length;
            var cols = grid[0].Length;
            var constNum = (int)1e9 + 7;

            var dp = new long[rows, cols, 2];
            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < cols; c++)
                {
                    var curValue = grid[r][c];

                    if (r - 1 < 0 && c - 1 < 0)
                    {
                        dp[r, c, 0] = curValue;
                        dp[r, c, 1] = curValue;
                    }
                    else if (r - 1 < 0)
                    {
                        var t = GetMaxMin(dp[r, c - 1, 0], dp[r, c - 1, 1], curValue);

                        dp[r, c, 0] = t.Item1;
                        dp[r, c, 1] = t.Item2;
                    }
                    else if (c - 1 < 0)
                    {
                        var t = GetMaxMin(dp[r - 1, c, 0], dp[r - 1, c, 1], curValue);

                        dp[r, c, 0] = t.Item1;
                        dp[r, c, 1] = t.Item2;
                    }
                    else
                    {
                        var t = GetMaxMin(dp[r, c - 1, 0], dp[r, c - 1, 1], curValue);
                        dp[r, c, 0] = t.Item1;
                        dp[r, c, 1] = t.Item2;

                        var t2 = GetMaxMin(dp[r - 1, c, 0], dp[r - 1, c, 1], curValue);
                        dp[r, c, 0] = Math.Max(dp[r, c, 0], t2.Item1);
                        dp[r, c, 1] = Math.Min(dp[r, c, 1], t2.Item2);
                    }
                }
            }

            return dp[rows - 1, cols - 1, 0] < 0 ? -1 : (int)(dp[rows - 1, cols - 1, 0] % constNum);
        }

        private (long, long) GetMaxMin(long l1, long l2, long curValue)
        {
            var v1 = l1 * curValue;
            var v2 = l2 * curValue;

            return (Math.Max(v1, v2), Math.Min(v1, v2));
        }
    }
}
