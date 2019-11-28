using System;
namespace ForSolveProblem
{
    public class Problem695 : IProblem
    {
        public void RunProblem()
        {
            var temp = MaxAreaOfIsland(new int[][]
            {
                new int[]{1, 1, 0, 0, 0},
                new int[]{1, 1, 0, 0, 0},
                new int[]{0, 0, 0, 1, 1},
                new int[]{0, 0, 0, 1, 1 }
            });
            if (temp != 4) throw new Exception();

        }

        public int MaxAreaOfIsland(int[][] grid)
        {
            /*
             * 题目概述：判断上下左右连通的 1 的个数的最大值
             * 
             * 思路：
             *  1.全局遍历图表,发现陆地则进行深度优先的遍历
             *  2.采用染色法,发现一块儿陆地就沉下一块儿陆地
             *  3.判断发现的所有陆地的最大值
             *
             * 关键点：
             *
             * 时间复杂度：O(m*n)
             * 空间复杂度：O(1)
             */

            var rows = grid.Length;
            if (rows == 0) return 0;

            var forReturn = 0;
            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[r].Length; c++)
                {
                    if (grid[r][c] != 1) continue;

                    var sumTemp = DfsSearch(grid, r, c);
                    forReturn = Math.Max(forReturn, sumTemp);
                }
            }

            return forReturn;
        }

        private int DfsSearch(int[][] grid, int r, int c)
        {
            var rows = grid.Length;
            var cols = grid[0].Length;

            if (r < 0 || r >= rows || c < 0 || c >= cols) return 0;
            if (grid[r][c] != 1) return 0;

            var forReturn = 1;
            grid[r][c] = 0;

            var upDownArray = new int[] { -1, 1, 0, 0 };
            var leftRightArray = new int[] { 0, 0, -1, 1 };
            for (int i = 0; i < 4; i++)
                forReturn += DfsSearch(grid, r + upDownArray[i], c + leftRightArray[i]);

            return forReturn;
        }
    }
}
