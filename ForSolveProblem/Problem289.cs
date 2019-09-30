using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem289 : IProblem
    {
        public void RunProblem()
        {
            int[][] board = new int[][]
            {
                new int[]{0,1,0},
                new int[]{0,0,1},
                new int[]{1,1,1},
                new int[]{0,0,0},
            };

            GameOfLife(board);
        }

        public void GameOfLife(int[][] board)
        {
            /*
             * 依据当前细胞的状态，判断下一帧细胞的状态
             * 思路：
             *  1.如果要在原地处理状态更新，那么现有的状态是不够的
             *  2.一共有4种状态需要标识
             *      2.1 活->活 就用原来的1
             *      2.2 活->死 就用 2 标识好了
             *      2.3 死->死 还是原来的0
             *      2.4 死->活 就用 -1 标识好了
             *  3.基于上面的规则，只要是大于0，就证明是活着，反之，是死了 
             *  4.最后再把标记还原成规则可理解的样子
             *  
             * 时间复杂度：O(m*n)
             * 空间复杂度：O(1)
             */

            int rowCount = board.GetLength(0);
            int colCount = board[0].Length;

            //先原地做标记和判断
            for (int r = 0; r < rowCount; r++)
                for (int c = 0; c < colCount; c++)
                    board[r][c] = JudgeLift2(board, r, c);

            //再还原为规则可理解的状态
            for (int r = 0; r < rowCount; r++)
                for (int c = 0; c < colCount; c++)
                    board[r][c] = ChangeStatus(board, r, c);
        }

        private int JudgeLift2(int[][] board, int r, int c)
        {
            int rowCount = board.GetLength(0);
            int colCount = board[0].Length;

            int livedCount = 0;
            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    if (x == 0 && y == 0) continue;

                    if (r + y < 0 || r + y >= rowCount) continue;
                    if (c + x < 0 || c + x >= colCount) continue;

                    if (board[r + y][c + x] > 0) livedCount++;
                }
            }

            if (board[r][c] == 0 && livedCount == 3) return -1;
            if (board[r][c] == 1 && livedCount != 2 && livedCount != 3) return 2;

            return board[r][c];
        }

        private int ChangeStatus(int[][] board, int r, int c)
        {
            if (board[r][c] == 2) return 0;
            if (board[r][c] == -1) return 1;

            return board[r][c];
        }

        public void GameOfLife1(int[][] board)
        {
            /*
             * 依据规则，更新当前画面的下一帧画面
             * 思路：
             *  1.首先是对规则的了解
             *      1.1 对于活细胞，继续存活的前提是：周围有 2~3 个活细胞
             *      1.2 对于死细胞，复活的前提是：周围有3个活细胞
             *      1.3 关注的主要是变化的原因，如果不变，其实是不用太过关心的
             *  2.那就没啥好说的了，为了更新每个细胞，就要遍历所有的细胞，要确定他的未来状态，就要统计他周围的状态
             *  
             * 时间复杂度：O(m*n)，相当于把每个细胞都遍历一遍，对于单个细胞而言，检查周围8个细胞，是常量，所以没有计入复杂度统计里面
             * 空间复杂度：O(m*n)，打算用一个新的画面来存储新的一帧
             */

            int rowCount = board.GetLength(0);
            int colCount = board[0].Length;

            int[][] newBoard = new int[rowCount][];

            for (int r = 0; r < rowCount; r++)
            {
                newBoard[r] = new int[colCount];

                for (int c = 0; c < colCount; c++)
                    newBoard[r][c] = JudgeLife1(board, r, c);
            }

            for (int r = 0; r < rowCount; r++)
                for (int c = 0; c < colCount; c++)
                    board[r][c] = newBoard[r][c];
        }

        /// <summary>
        /// 判定当前细胞的下一个状态
        /// </summary>
        private int JudgeLife1(int[][] board, int r, int c)
        {
            int rowCount = board.GetLength(0);
            int colCount = board[0].Length;

            //统计周围活细胞的数量
            int livedCount = 0;
            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    if (x == 0 && y == 0) continue;

                    if (r + y < 0 || r + y >= rowCount) continue;
                    if (c + x < 0 || c + x >= colCount) continue;

                    livedCount += board[r + y][c + x];
                }
            }

            //依据当前状态，对未来状态做判定

            //看下状态是不是变了
            if (board[r][c] == 0 && livedCount == 3) return 1;
            if (board[r][c] == 1 && (livedCount > 3 || livedCount < 2)) return 0;

            //没变就依然保持原状好了
            return board[r][c];
        }
    }
}
