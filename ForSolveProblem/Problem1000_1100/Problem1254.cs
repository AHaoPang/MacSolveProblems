using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1254 : IProblem
    {
        public void RunProblem()
        {
            var temp = ClosedIsland(new int[][]
            {
                new int[]{1, 1, 1, 1, 1, 1, 1, 0},
                new int[]{1, 0, 0, 0, 0, 1, 1, 0},
                new int[]{1, 0, 1, 0, 1, 1, 1, 0},
                new int[]{1, 0, 0, 0, 0, 1, 0, 1},
                new int[]{1, 1, 1, 1, 1, 1, 1, 0}
            });
            if (temp != 2) throw new Exception();

            temp = ClosedIsland(new int[][]
            {
                new int[]{0, 0, 1, 0, 0},
                new int[]{0, 1, 0, 1, 0},
                new int[]{0, 1, 1, 1, 0 }
            });
            if (temp != 1) throw new Exception();

            temp = ClosedIsland(new int[][]
            {
                new int[]{1, 1, 1, 1, 1, 1, 1},
                new int[]{1, 0, 0, 0, 0, 0, 1},
                new int[]{1, 0, 1, 1, 1, 0, 1},
                new int[]{1, 0, 1, 0, 1, 0, 1},
                new int[]{1, 0, 1, 1, 1, 0, 1},
                new int[]{1, 0, 0, 0, 0, 0, 1},
                new int[]{1, 1, 1, 1, 1, 1, 1 }
            });
            if (temp != 2) throw new Exception();
        }

        public int ClosedIsland(int[][] grid)
        {
            /*
             * 问题:统计封闭岛屿的个数
             * 思路:
             *  1.回溯染色的方式
             *  2.依次检查每一块儿陆地,时间复杂度是O(m*n)
             *  3.对于每一块儿陆地,都要去找它上下左右相邻的陆地,作为一块儿岛屿
             *  4.一边儿检测,可以一边儿将陆地变为水域
             *  5.通过上面的方式能检测出来有多少岛屿,但是题目要求的是"封闭岛屿",因此还要判断一块儿岛屿是否靠近了边缘地带,将靠近边缘的岛屿去除掉,剩下的就是"封闭岛屿"了
             * 
             * 关键点:
             * 
             * 时间复杂度:O(n*m)
             * 空间复杂度:O(max(n,m))
             */

            var forReturn = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1) continue;

                    if (Recursive(grid, i, j)) forReturn++;
                }
            }

            return forReturn;
        }

        private bool Recursive(int[][] grid, int i, int j)
        {
            var rows = grid.Length;
            var cols = grid[0].Length;
            if (i >= rows || j >= cols || i < 0 || j < 0 || grid[i][j] == 1) 
                return true;

            grid[i][j] = 1;
            var forReturn = true;

            if (i == 0 || j == 0 || i == rows - 1 || j == cols - 1)
                forReturn = false;

            var iPos = new int[] { -1, 1, 0, 0 };
            var jPos = new int[] { 0, 0, -1, 1 };
            for (int k = 0; k < iPos.Length; k++)
            {
                var result = Recursive(grid, i + iPos[k], j + jPos[k]);
                forReturn &= result;
            }

            return forReturn;
        }
    }
}
