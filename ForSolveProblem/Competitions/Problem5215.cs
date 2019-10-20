using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5215 : IProblem
    {
        public int GetMaximumGold(int[][] grid)
        {
            m_array = new int[grid.Length, grid.First().Length];
            m_max = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 0) continue;

                    DFS(grid, i, j, 0);
                }
            }

            return m_max;
        }

        private int[,] m_array;
        private int m_max;

        private void DFS(int[][] grid, int x, int y, int curCount)
        {
            if (x < 0 || x >= grid.Length || y < 0 || y >= grid.First().Length || grid[x][y] == 0 || m_array[x, y] == 1)
            {
                m_max = Math.Max(curCount, m_max);
                return;
            }

            curCount += grid[x][y];
            m_array[x, y] = 1;

            DFS(grid, x - 1, y, curCount);
            DFS(grid, x + 1, y, curCount);
            DFS(grid, x, y - 1, curCount);
            DFS(grid, x, y + 1, curCount);

            m_array[x, y] = 0;
        }


        #region 方案二

        public int GetMaximumGold3(int[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 0) continue;

                    DFS2(grid, i, j, 0, new HashSet<string>());
                }
            }

            return m_max;
        }

        private void DFS2(int[][] grid, int x, int y, int curCount, HashSet<string> visited)
        {
            var keyStr = $"{x}_{y}";

            if (x < 0 || x >= grid.Length || y < 0 || y >= grid.First().Length || grid[x][y] == 0 || visited.Contains(keyStr))
            {
                m_max = Math.Max(curCount, m_max);
                return;
            }

            curCount += grid[x][y];
            visited.Add(keyStr);

            DFS2(grid, x - 1, y, curCount, visited);
            DFS2(grid, x + 1, y, curCount, visited);
            DFS2(grid, x, y - 1, curCount, visited);
            DFS2(grid, x, y + 1, curCount, visited);

            visited.Remove(keyStr);
        }
        #endregion


        public void RunProblem()
        {
            var temp = GetMaximumGold(new int[][]
            {
                new int[]{0,6,0},
                new int[]{5,8,7},
                new int[]{0,9,0}
            });
            if (temp != 24) throw new Exception();

            temp = GetMaximumGold(new int[][]
            {
                new int[]{1,0,7},
                new int[]{2,0,6},
                new int[]{3,4,5},
                new int[]{0,3,0},
                new int[]{9,0,20}
            });
            if (temp != 28) throw new Exception();

            temp = GetMaximumGold(new int[][]
            {
                  new int[]{1, 0, 7, 0, 0, 0},
                  new int[]{2, 0, 6, 0, 1, 0},
                  new int[]{3, 5, 6, 7, 4, 2},
                  new int[]{4, 3, 1, 0, 2, 0 },
                  new int[]{3, 0, 5, 0, 20, 0 }
            });
            if (temp != 60) throw new Exception();
        }
    }
}
