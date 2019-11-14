using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem130 : IProblem
    {
        public void RunProblem()
        {
            Solve(new char[][]
            {
                new char[]{'O','O'},
                new char[]{'O','O'}
            });
        }

        public void Solve(char[][] board)
        {
            /*
             * 问题:淹没湖心岛
             * 思路:
             *  1.绕着网格看一圈,把联通的'O'做特殊的标记
             *  2.开始淹没湖心岛,即没被标记过的'O'改为'X',标记过的还原为'O'
             * 
             * 关键点:
             * 
             * 时间复杂度:O(m*n)
             * 空间复杂度:O(m*n)
             */

            var rows = board.Length;
            if (rows == 0) return;
            var cols = board[0].Length;

            var rowActionArray = new int[] { 0, 1, 0, -1 };
            var colActionArray = new int[] { 1, 0, -1, 0 };
            var rowInitValue = new int[] { 0, 0, rows - 1, rows - 1 };
            var colInitValue = new int[] { 0, cols - 1, cols - 1, 0 };
            var arrayIndex = 0;
            while (arrayIndex < 4)
            {
                var rowTemp = rowInitValue[arrayIndex];
                var colTemp = colInitValue[arrayIndex];
                while (true)
                {
                    if (board[rowTemp][colTemp] == 'O')
                        Recursive(board, rowTemp, colTemp);

                    rowTemp += rowActionArray[arrayIndex];
                    colTemp += colActionArray[arrayIndex];

                    if (rowTemp >= rows || rowTemp < 0 || colTemp >= cols || colTemp < 0) break;
                }

                arrayIndex++;
            }

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    board[i][j] = board[i][j] == 'Y' ? 'O' : 'X';
        }

        private void Recursive(char[][] board, int row, int col)
        {
            var rows = board.Length;
            var cols = board[0].Length;

            if (row < 0 || row >= rows || col < 0 || col >= cols) return;
            if (board[row][col] == 'X' || board[row][col] == 'Y') return;

            board[row][col] = 'Y';

            var upDownArray = new int[] { -1, 1, 0, 0 };
            var leftRigthArray = new int[] { 0, 0, -1, 1 };
            for (int i = 0; i < upDownArray.Length; i++)
                Recursive(board, row + upDownArray[i], col + leftRigthArray[i]);
        }
    }
}
