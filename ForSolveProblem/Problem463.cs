using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem463 : IProblem
    {
        public void RunProblem()
        {
            var temp = IslandPerimeter(new int[][]
            {
                new int[]{0,1,0,0},
                new int[]{1,1,1,0},
                new int[]{0,1,0,0},
                new int[]{1,1,0,0}
            });
            if (temp != 16) throw new Exception();
        }

        public int IslandPerimeter(int[][] grid)
        {
            /*
             * 岛屿周长求解
             * 思路：
             *  1.对岛屿周长的定义，即水和岛相间的地方
             *  2.找到这些间隔
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            var forReturn = 0;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] != 1) continue;

                    if (i - 1 < 0 || grid[i - 1][j] == 0) forReturn++;
                    if (i + 1 >= grid.GetLength(0) || grid[i + 1][j] == 0) forReturn++;
                    if (j - 1 < 0 || grid[i][j - 1] == 0) forReturn++;
                    if (j + 1 >= grid[i].Length || grid[i][j + 1] == 0) forReturn++;
                }
            }

            return forReturn;
        }
    }
}
