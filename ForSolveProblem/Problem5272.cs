using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5272 : IProblem
    {
        public void RunProblem()
        {
            var temp = CountServers(new int[][]
            {
                new int[]{1,0},
                new int[]{0,1},
            });
            if (temp != 0) throw new Exception();

            temp = CountServers(new int[][]
            {
                new int[]{1,0},
                new int[]{1,1},
            });
            if (temp != 3) throw new Exception();

            temp = CountServers(new int[][]
            {
                new int[]{1,1,0,0},
                new int[]{0,0,1,0},
                new int[]{0,0,1,0},
                new int[]{ 0, 0, 0, 1 }
            });
            if (temp != 4) throw new Exception();

            temp = CountServers(new int[][]
{
                new int[]{0,0,0,0},
                new int[]{1,1,1,1},
                new int[]{0,0,0,1},
                new int[]{0,0,1,1},
                new int[]{ 0, 0, 0, 1 }
});
            if (temp != 4) throw new Exception();
        }

        public int CountServers(int[][] grid)
        {
            var rows = grid.Length;
            var cols = grid[0].Length;

            var rowArray = new List<int>[rows];
            var colArray = new List<int>[cols];
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[row].Length; col++)
                {
                    if (grid[row][col] != 1) continue;

                    if (rowArray[row] == null) rowArray[row] = new List<int>();
                    rowArray[row].Add(row);
                    rowArray[row].Add(col);

                    if (colArray[col] == null) colArray[col] = new List<int>();
                    colArray[col].Add(row);
                    colArray[col].Add(col);
                }
            }

            var visited = new int[rows, cols];
            var forReturn = 0;
            foreach (var rowItem in rowArray)
            {
                if (rowItem == null || rowItem.Count < 3) continue;

                for (int j = 0; j < rowItem.Count - 1; j += 2)
                {
                    if (visited[rowItem[j], rowItem[j + 1]] == 1) continue;

                    visited[rowItem[j], rowItem[j + 1]] = 1;
                    forReturn++;
                }
            }

            foreach (var colItem in colArray)
            {
                if (colItem == null || colItem.Count < 3) continue;

                for (int j = 0; j < colItem.Count - 1; j += 2)
                {
                    if (visited[colItem[j], colItem[j + 1]] == 1) continue;

                    visited[colItem[j], colItem[j + 1]] = 1;
                    forReturn++;
                }
            }

            return forReturn;
        }
    }
}
