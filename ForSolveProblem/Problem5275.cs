using System;
namespace ForSolveProblem
{
    public class Problem5275 : IProblem
    {
        public void RunProblem()
        {
            var temp = Tictactoe(new int[][]
            {
               new int[]{0, 0},
               new int[]{2, 0},
               new int[]{1, 1},
               new int[]{2, 1},
               new int[]{2, 2 }
            });
            if (temp != "A") throw new Exception();

            temp = Tictactoe(new int[][]
            {
                new int[]{0, 0},
                new int[]{1, 1},
                new int[]{0, 1},
                new int[]{0, 2},
                new int[]{1, 0},
                new int[]{2, 0 }
            });
            if (temp != "B") throw new Exception();

            temp = Tictactoe(new int[][]
            {
                new int[]{0, 0},
                new int[]{1, 1},
                new int[]{2, 0},
                new int[]{1, 0},
                new int[]{1, 2},
                new int[]{2, 1},
                new int[]{0, 1},
                new int[]{0, 2},
                new int[]{2, 2 }
            });
            if (temp != "Draw") throw new Exception();

            temp = Tictactoe(new int[][]
            {
                new int[]{0,0},
                new int[]{1,1},
            });
            if (temp != "Pending") throw new Exception();
        }

        public string Tictactoe(int[][] moves)
        {
            var QiPan = new int[3, 3];
            for(int i = 0;i < moves.Length; i++)
            {
                var r = moves[i][0];
                var c = moves[i][1];

                var s = 1;
                if (i % 2 == 1) s = 2;

                QiPan[r, c] = s;
            }

            var winNum = 0;
            for(int i = 0;i < 3; i++)
            {
                if(QiPan[i,0] == QiPan[i,1] && QiPan[i,1] == QiPan[i, 2] && QiPan[i,0] != 0)
                {
                    winNum = QiPan[i, 0];
                    break;
                }
            }
            if (winNum != 0) return winNum == 1 ? "A" : "B";

            for(int c = 0;c < 3; c++)
            {
                if(QiPan[0,c] == QiPan[1,c] && QiPan[1,c] == QiPan[2, c] && QiPan[0,c] != 0)
                {
                    winNum = QiPan[0, c];
                    break;
                }
            }
            if (winNum != 0) return winNum == 1 ? "A" : "B";

            if (QiPan[0, 0] == QiPan[1, 1] && QiPan[1, 1] == QiPan[2, 2] && QiPan[0, 0] != 0)
                winNum = QiPan[0, 0];
            if (winNum != 0) return winNum == 1 ? "A" : "B";

            if (QiPan[0, 2] == QiPan[1, 1] && QiPan[1, 1] == QiPan[2, 0] && QiPan[1, 1] != 0)
                winNum = QiPan[1, 1];
            if (winNum != 0) return winNum == 1 ? "A" : "B";

            var hasBlank = false;
            for(int i = 0;i < 3; i++)
            {
                for(int j = 0;j < 3; j++)
                {
                    if(QiPan[i,j] == 0)
                    {
                        hasBlank = true;
                        break;
                    }
                }
            }

            return hasBlank ? "Pending" : "Draw";
        }
    }
}
