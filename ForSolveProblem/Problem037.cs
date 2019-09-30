using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem037 : IProblem
    {
        public void RunProblem()
        {
            char[][] board = new char[9][]
            {
                new char[]{'5', '3', '.', '.', '7', '.', '.', '.', '.'},
                new char[]{'6', '.', '.', '1', '9', '5', '.', '.', '.'},
                new char[]{'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                new char[]{'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                new char[]{'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                new char[]{'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                new char[]{'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                new char[]{'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                new char[]{'.', '.', '.', '.', '8', '.', '.', '7', '9'}
            };

            SolveSudoku(board);
        }

        public void SolveSudoku(char[][] board)
        {
            DFS2(board);
        }

        private bool DFS2(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] == '.')
                    {
                        var validNums = GetValidNums(board, i, j);
                        foreach (var item in validNums)
                        {
                            board[i][j] = item;

                            if (DFS2(board))
                                return true;
                            else
                                board[i][j] = '.';
                        }

                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 找到当前位置的可选值
        /// </summary>
        private IList<char> GetValidNums(char[][] board, int i, int j)
        {
            IList<char> forReturn = new List<char>();

            HashSet<char> currentNums = new HashSet<char>();

            //行列已有值的记录
            for (int l = 0; l < 9; l++)
            {
                if (board[i][l] != '.')
                    currentNums.Add(board[i][l]);
                if (board[l][j] != '.')
                    currentNums.Add(board[l][j]);
            }

            //单元格已有值的记录
            int lIndex = i / 3 * 3;
            int mIndex = j / 3 * 3;
            for (int l = lIndex; l < lIndex + 3; l++) for (int m = mIndex; m < mIndex + 3; m++) if (board[l][m] != '.') currentNums.Add(board[l][m]);

            //找到可选值
            for (char k = '1'; k <= '9'; k++) if (!currentNums.Contains(k)) forReturn.Add(k);

            return forReturn;
        }

        #region Way1

        private bool IsEnd = false;

        private void DFS(char[][] board, int i, int j)
        {
            if (i == 9)
            {
                IsEnd = true;
                return;
            }

            int nexti = i;
            int nextj = j + 1;
            if (nextj == 9)
            {
                nexti++;
                nextj = 0;
            }

            if (board[i][j] == '.')
            {
                var validNums = GetValidNums(board, i, j);
                foreach (var item in validNums)
                {
                    board[i][j] = item;
                    DFS(board, nexti, nextj);

                    if (IsEnd) return;
                }

                board[i][j] = '.';
            }
            else
                DFS(board, nexti, nextj);
        }

        #endregion
    }
}
