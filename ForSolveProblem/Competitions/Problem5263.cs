using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5263 : IProblem
    {
        public void RunProblem()
        {
            var temp = ShiftGrid(new int[][]
            {
                new int[]{1,2,3},
                new int[]{4,5,6},
                new int[]{7,8,9},
            }, 1);

            temp = ShiftGrid(new int[][]
            {
                new int[]{3,8,1,9},
                new int[]{19,7,2,5},
                new int[]{4,6,11,10},
                new int[]{12,0,21,13},
            }, 4);

            temp = ShiftGrid(new int[][]
            {
                new int[]{1,2,3},
                new int[]{4,5,6},
                new int[]{7,8,9},
            }, 9);
        }

        public IList<IList<int>> ShiftGrid(int[][] grid, int k)
        {
            var rows = grid.Length;
            var cols = grid[0].Length;

            var forReturn = new int[rows][];
            for (int i = 0; i < rows; i++)
                forReturn[i] = new int[cols];

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    var curValue = grid[rowIndex][colIndex];

                    var newRow = (rowIndex + (colIndex + k) / cols) % rows;
                    var newCol = (colIndex + k) % cols;

                    forReturn[newRow][newCol] = curValue;
                }
            }

            return forReturn;
        }
    }
}
