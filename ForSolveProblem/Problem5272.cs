using System;
using System.Collections.Generic;
using System.Linq;
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
            if (temp != 8) throw new Exception();
        }

        public int CountServers(int[][] grid)
        {
            m_forReturn = 0;

            for(int rowIndex = 0;rowIndex < grid.Length; rowIndex++)
            {
                for(int colIndex = 0;colIndex < grid[rowIndex].Length; colIndex++)
                {
                    if (grid[rowIndex][colIndex] != '1') continue;

                    Recursion(grid, rowIndex, colIndex);
                }
            }

            return m_forReturn;
        }

        private int m_forReturn;

        private void Recursion(int[][] grid,int row,int col)
        {
            if (grid[row][col] != '1') return;

            var sameRow = new List<int>();
            for (int colIndex = 0; colIndex < grid[0].Length; colIndex++)
                if (grid[row][colIndex] == '1') sameRow.Add(colIndex);

            var sameCol = new List<int>();
            for (int rowIndex = 0; rowIndex < grid.Length; rowIndex++)
                if (grid[rowIndex][col] == '1') sameCol.Add(rowIndex);

            if(sameRow.Any() || sameCol.Any())
            {
                m_forReturn++;

                grid[row][col] = '0';

                foreach (var colItem in sameRow)
                    Recursion(grid, row, colItem);

                foreach (var rowItem in sameCol)
                    Recursion(grid, rowItem, col);
            }
        }

        public int CountServers1(int[][] grid)
        {
            /*
             * 题目概述：统计可通信服务器的数量
             * 
             * 思路：
             *  1.首先遍历二维矩阵,看每一行有几台服务器,每一列有几台服务器
             *  2.以上得到 2 个一维数组
             *  3.分别遍历两个一维数组,如果同 1 行或者同 1 列有超过 2 台机器,那么就去统计
             *  4.为了避免重复统计,使用了二维数组来标识
             *
             * 关键点：
             *
             * 时间复杂度： O(250*250)
             * 空间复杂度： O(250*250)
             */

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
                    rowArray[row].Add(col);

                    if (colArray[col] == null) colArray[col] = new List<int>();
                    colArray[col].Add(row);
                }
            }

            var visited = new int[rows, cols];
            var forReturn = 0;
            for(var rowIndex = 0; rowIndex < rowArray.Length; rowIndex++)
            {
                var curRow = rowArray[rowIndex];
                if (curRow == null || curRow.Count == 1) continue;

                foreach(var colPos in curRow)
                {
                    if (visited[rowIndex, colPos] == 1) continue;

                    visited[rowIndex, colPos] = 1;
                    forReturn++;
                }
            }
            for(var colIndex = 0;colIndex < colArray.Length; colIndex++)
            {
                var curCol = colArray[colIndex];
                if (curCol == null || curCol.Count == 1) continue;

                foreach(var rowPos in curCol)
                {
                    if (visited[rowPos, colIndex] == 1) continue;

                    visited[rowPos, colIndex] = 1;
                    forReturn++;
                }
            }

            return forReturn;
        }
    }
}
