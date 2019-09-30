using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem079 : IProblem
    {
        public void RunProblem()
        {
            char[][] board = new char[][]
            {
                new char[]{'A','B','C','E' },
                new char[]{'S','F','C','S' },
                new char[]{'A','D','E','E' }
            };

            var temp = Exist(board, "ABCCED");
            if (temp != true) throw new Exception();

            temp = Exist(board, "SEE");
            if (temp != true) throw new Exception();

            temp = Exist(board, "ABCB");
            if (temp != false) throw new Exception();

            board = new char[][]
            {
                new char[]{'A','B','C','E'},
                new char[]{'S','F','E','S'},
                new char[]{'A','D','E','E'},
            };

            temp = Exist(board, "ABCESEEEFS");

        }

        public bool Exist(char[][] board, string word)
        {
            /*
             * 在二维网格中查找指定单词
             * 思路：
             *  1.大体上分为两个步骤：遍历网格找首字符、依据首字符开始逐个去匹配
             *  2.相当于遍历+回溯这两个步骤了
             *  
             * 时间复杂度：O(n*m)，n是二维网格的格子数量，m是单词的长度
             * 空间复杂度：O(m)，回溯的深度为单词的长度
             */

            //循环遍历二维网格
            int rowCount = board.GetLength(0);
            int colCount = board[0].Length;
            for (int r = 0; r < rowCount; r++)
                for (int c = 0; c < colCount; c++)
                    //遍历过程中，满足条件：字符首字符，就去做回溯判断
                    if (BackTrack(board, word, 0, r, c, new HashSet<string>())) return true;

            return false;
        }

        private bool BackTrack(char[][] board, string word, int wIndex, int curRow, int curCol, HashSet<string> passedPath)
        {
            if (word.Length == wIndex) return true;

            if (curRow < 0 || curRow > board.GetLength(0) - 1) return false;
            if (curCol < 0 || curCol > board[0].Length - 1) return false;

            /* 当前字符匹配，才会继续，查找方向和顺序为：上、下、左、右 */
            if (board[curRow][curCol] != word[wIndex]) return false;

            //校验是否为走过的路径
            string key = $"{curRow}-{curCol}";
            if (passedPath.Contains(key)) return false;
            passedPath.Add(key);

            if (BackTrack(board, word, wIndex + 1, curRow - 1, curCol, passedPath) ||
                BackTrack(board, word, wIndex + 1, curRow + 1, curCol, passedPath) ||
                BackTrack(board, word, wIndex + 1, curRow, curCol - 1, passedPath) ||
                BackTrack(board, word, wIndex + 1, curRow, curCol + 1, passedPath))
            {
                return true;
            }

            passedPath.Remove(key);
            return false;
        }

        public bool Exist1(char[,] board, string word)
        {
            /*
             * 在二维网格中查找指定单词
             * 思路：
             *  1.大体上分为两个步骤：遍历网格找首字符、依据首字符开始逐个去匹配
             *  2.相当于遍历+回溯这两个步骤了
             *  
             * 时间复杂度：O(n*m)，n是二维网格的格子数量，m是单词的长度
             * 空间复杂度：O(m)，回溯的深度为单词的长度
             */

            //循环遍历二维网格
            int rowCount = board.GetLength(0);
            int colCount = board.GetLength(1);
            for (int r = 0; r < rowCount; r++)
                for (int c = 0; c < colCount; c++)
                    //遍历过程中，满足条件：字符首字符，就去做回溯判断
                    if (BackTrack1(board, word, 0, r, c, new HashSet<string>())) return true;

            return false;
        }

        private bool BackTrack1(char[,] board, string word, int wIndex, int curRow, int curCol, HashSet<string> passedPath)
        {
            if (word.Length == wIndex) return true;

            if (curRow < 0 || curRow > board.GetLength(0) - 1) return false;
            if (curCol < 0 || curCol > board.GetLength(1) - 1) return false;

            /* 当前字符匹配，才会继续，查找方向和顺序为：上、下、左、右 */
            if (board[curRow, curCol] != word[wIndex]) return false;

            //校验是否为走过的路径
            string key = $"{curRow}-{curCol}";
            if (passedPath.Contains(key)) return false;
            passedPath.Add(key);

            return
                BackTrack1(board, word, wIndex + 1, curRow - 1, curCol, passedPath) ||
                BackTrack1(board, word, wIndex + 1, curRow + 1, curCol, passedPath) ||
                BackTrack1(board, word, wIndex + 1, curRow, curCol - 1, passedPath) ||
                BackTrack1(board, word, wIndex + 1, curRow, curCol + 1, passedPath);
        }
    }
}
