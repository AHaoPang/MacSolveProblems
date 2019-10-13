using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5223 : IProblem
    {
        public IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king)
        {
            var queenHash = new HashSet<string>(queens.Length);
            for (int i = 0; i < queens.Length; i++)
                queenHash.Add($"{queens[i][0]}_{queens[i][1]}");

            var kingRow = king[0];
            var kingCol = king[1];

            var forReturn = new List<IList<int>>();

            //左上
            var rowTemp = kingRow - 1;
            var colTemp = kingCol - 1;
            while(rowTemp >= 0 && colTemp >= 0)
            {
                var tempStr = $"{rowTemp}_{colTemp}";
                if (queenHash.Contains(tempStr))
                {
                    forReturn.Add(new List<int>() { rowTemp, colTemp });
                    break;
                }

                rowTemp--;
                colTemp--;
            }

            //上
            rowTemp = kingRow - 1;
            colTemp = kingCol;
            while(rowTemp >= 0)
            {
                var tempStr = $"{rowTemp}_{colTemp}";
                if (queenHash.Contains(tempStr))
                {
                    forReturn.Add(new List<int>() { rowTemp, colTemp });
                    break;
                }

                rowTemp--;
            }

            //右上
            rowTemp = kingRow - 1;
            colTemp = kingCol + 1;
            while(rowTemp >= 0 && colTemp <= 7)
            {
                var tempStr = $"{rowTemp}_{colTemp}";
                if (queenHash.Contains(tempStr))
                {
                    forReturn.Add(new List<int>() { rowTemp, colTemp });
                    break;
                }

                rowTemp--;
                colTemp++;
            }

            //左
            rowTemp = kingRow;
            colTemp = kingCol - 1;
            while(colTemp >= 0)
            {
                var tempStr = $"{rowTemp}_{colTemp}";
                if (queenHash.Contains(tempStr))
                {
                    forReturn.Add(new List<int>() { rowTemp, colTemp });
                    break;
                }

                colTemp--;
            }

            //右
            rowTemp = kingRow;
            colTemp = kingCol + 1;
            while(colTemp <= 7)
            {
                var tempStr = $"{rowTemp}_{colTemp}";
                if (queenHash.Contains(tempStr))
                {
                    forReturn.Add(new List<int>() { rowTemp, colTemp });
                    break;
                }

                colTemp++;
            }

            //左下
            rowTemp = kingRow + 1;
            colTemp = kingCol - 1;
            while(rowTemp <= 7 && colTemp >= 0)
            {
                var tempStr = $"{rowTemp}_{colTemp}";
                if (queenHash.Contains(tempStr))
                {
                    forReturn.Add(new List<int>() { rowTemp, colTemp });
                    break;
                }

                rowTemp++;
                colTemp--;
            }

            //下
            rowTemp = kingRow + 1;
            colTemp = kingCol;
            while(rowTemp <= 7)
            {
                var tempStr = $"{rowTemp}_{colTemp}";
                if (queenHash.Contains(tempStr))
                {
                    forReturn.Add(new List<int>() { rowTemp, colTemp });
                    break;
                }

                rowTemp++;
            }

            //右下
            rowTemp = kingRow + 1;
            colTemp = kingCol + 1;
            while(rowTemp <= 7 && colTemp <= 7)
            {
                var tempStr = $"{rowTemp}_{colTemp}";
                if (queenHash.Contains(tempStr))
                {
                    forReturn.Add(new List<int>() { rowTemp, colTemp });
                    break;
                }

                rowTemp++;
                colTemp++;
            }

            return forReturn;
        }

        public void RunProblem()
        {
            var temp = QueensAttacktheKing(new int[][]
            {
                new int[]{0,1},
                new int[]{1,0},
                new int[]{4,0},
                                new int[]{0,4},
                new int[]{3,3},
                new int[]{2,4},
            }, new int[] { 0, 0 });

            var temp2 = QueensAttacktheKing(new int[][]
            {
                new int[]{0,0},
                new int[]{1,1},
                new int[]{2,2},
                                new int[]{3,4},
                new int[]{3,5},
                new int[]{4,4},
                new int[]{4,5},
            }, new int[] { 3, 3 });
        }
    }
}
