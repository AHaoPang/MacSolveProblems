using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem999 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int NumRookCaptures(char[][] board)
        {
            var sourcePos = new int[2];
            for (var r = 0; r < board.Length; r++)
            {
                for (var c = 0; c < board[r].Length; c++)
                {
                    if (board[r][c] == 'R')
                    {
                        sourcePos = new[] { r, c };
                        break;
                    }
                }
            }

            var res = 0;

            var arr = new int[][] { new[] { -1, 0 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { 0, 1 } };
            for (var i = 0; i < arr.Length; i++)
            {
                var inR = arr[i][0];
                var inC = arr[i][1];

                var startPos = new int[2];
                sourcePos.CopyTo(startPos, 0);
                while (true)
                {
                    startPos[0] += inR;
                    startPos[1] += inC;

                    if (startPos[0] < 0 || startPos[0] >= 8 || startPos[1] < 0 || startPos[1] >= 8 || board[startPos[0]][startPos[1]] == 'B')
                        break;

                    if (board[startPos[0]][startPos[1]] == 'p')
                    {
                        res++;
                        break;
                    }
                }
            }

            return res;
        }
    }
}
